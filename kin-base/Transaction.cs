// This file was modified by Kin Ecosystem (2019)


using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Kin.Base.xdr;

namespace Kin.Base
{
    public class Transaction
    {
        private const int BaseFee = 100;

        private Transaction(KeyPair sourceAccount, int fee, long sequenceNumber, Operation[] operations, Memo memo, TimeBounds timeBounds)
        {
            SourceAccount = sourceAccount ?? throw new ArgumentNullException(nameof(sourceAccount), "sourceAccount cannot be null");
            SequenceNumber = sequenceNumber;
            Operations = operations ?? throw new ArgumentNullException(nameof(operations), "operations cannot be null");

            if (operations.Length == 0)
                throw new ArgumentNullException(nameof(operations), "At least one operation required");

            Fee = fee;
            Signatures = new List<DecoratedSignature>();
            Memo = memo ?? Memo.None();
            TimeBounds = timeBounds;
        }

        public int Fee { get; }

        public KeyPair SourceAccount { get; }

        public long SequenceNumber { get; }

        public Operation[] Operations { get; }

        public Memo Memo { get; }

        public TimeBounds TimeBounds { get; }

        public List<DecoratedSignature> Signatures { get; }

        /// <summary>
        /// Adds a new signature ed25519PublicKey to this transaction.
        /// </summary>
        /// <param name="signer"> signer <see cref="KeyPair"/> object representing a signer</param>
        public void Sign(KeyPair signer)
        {
            Sign(signer, Network.Current);
        }

        /// <summary>
        /// Adds a new signature ed25519PublicKey to this transaction.
        /// </summary>
        /// <param name="signer"> signer <see cref="KeyPair"/> object representing a signer</param>
        /// <param name="network">The network <see cref="Network"/> the transaction will be sent to.</param>
        public void Sign(KeyPair signer, Network network)
        {
            if (signer == null)
                throw new ArgumentNullException(nameof(signer), "signer cannot be null");

            var txHash = Hash(network);
            Signatures.Add(signer.SignDecorated(txHash));
        }

        /// <summary>
        ///     Adds a new sha256Hash signature to this transaction by revealing preimage.
        /// </summary>
        /// <param name="preimage">the sha256 hash of preimage should be equal to signer hash</param>
        public void Sign(byte[] preimage)
        {
            var signature = new Signature
            {
                InnerValue = preimage ?? throw new ArgumentNullException(nameof(preimage), "preimage cannot be null")
            };

            var hash = Util.Hash(preimage);

            var length = hash.Length;
            var signatureHintBytes = hash.Skip(length - 4).Take(4).ToArray();

            var signatureHint = new SignatureHint {InnerValue = signatureHintBytes};

            var decoratedSignature = new DecoratedSignature
            {
                Hint = signatureHint,
                Signature = signature
            };

            Signatures.Add(decoratedSignature);
        }

        /// <summary>
        ///     Returns transaction hash.
        /// </summary>
        /// <returns></returns>
        public byte[] Hash()
        {
            return Hash(Network.Current);
        }

        /// <summary>
        ///     Returns transaction hash for the given network.
        /// </summary>
        /// <param name="network">The network <see cref="Network"/> the transaction will be sent to.</param>
        /// <returns></returns>
        public byte[] Hash(Network network)
        {
            return Util.Hash(SignatureBase(network));
        }

        /// <summary>
        ///     Returns signature base.
        /// </summary>
        /// <returns></returns>
        public byte[] SignatureBase()
        {
            return SignatureBase(Network.Current);
        }

        /// <summary>
        ///     Returns signature base for the given network.
        /// </summary>
        /// <param name="network">The network <see cref="Network"/> the transaction will be sent to.</param>
        /// <returns></returns>
        public byte[] SignatureBase(Network network)
        {
            if (network == null)
                throw new NoNetworkSelectedException();

            var writer = new XdrDataOutputStream();

            // Hashed NetworkID
            writer.Write(network.NetworkId);

            // Envelope Type - 4 bytes
            EnvelopeType.Encode(writer, EnvelopeType.Create(EnvelopeType.EnvelopeTypeEnum.ENVELOPE_TYPE_TX));

            // Transaction XDR bytes
            var txWriter = new XdrDataOutputStream();
            xdr.Transaction.Encode(txWriter, ToXdr());

            writer.Write(txWriter.ToArray());

            return writer.ToArray();
        }

        /// <summary>
        ///     Generates Transaction XDR object.
        /// </summary>
        /// <returns></returns>
        public xdr.Transaction ToXdr()
        {
            // fee
            var fee = new Uint32 {InnerValue = Fee};

            // sequenceNumber
            var sequenceNumberUint = new xdr.Int64(SequenceNumber);
            var sequenceNumber = new SequenceNumber {InnerValue = sequenceNumberUint};

            // sourceAccount
            var sourceAccount = new AccountID {InnerValue = SourceAccount.XdrPublicKey};

            // operations
            var operations = new xdr.Operation[Operations.Length];

            for (var i = 0; i < Operations.Length; i++)
                operations[i] = Operations[i].ToXdr();

            // ext
            var ext = new xdr.Transaction.TransactionExt {Discriminant = 0};

            var transaction = new xdr.Transaction
            {
                Fee = fee,
                SeqNum = sequenceNumber,
                SourceAccount = sourceAccount,
                Operations = operations,
                Memo = Memo.ToXdr(),
                TimeBounds = TimeBounds?.ToXdr(),
                Ext = ext
            };
            return transaction;
        }

        /// <summary>
        ///     Generates TransactionEnvelope XDR object. Transaction need to have at least one signature.
        /// </summary>
        /// <returns></returns>
        public TransactionEnvelope ToEnvelopeXdr()
        {
            if (Signatures.Count == 0)
                throw new NotEnoughSignaturesException("Transaction must be signed by at least one signer. Use transaction.sign().");

            var thisXdr = new TransactionEnvelope();
            var transaction = ToXdr();
            thisXdr.Tx = transaction;

            var signatures = Signatures.ToArray();
            thisXdr.Signatures = signatures;
            return thisXdr;
        }

        /// <summary>
        ///     Generates TransactionEnvelope XDR object. This transaction MUST be signed before being useful
        /// </summary>
        /// <returns></returns>
        public TransactionEnvelope ToUnsignedEnvelopeXdr()
        {
            if (Signatures.Count > 0)
                throw new TooManySignaturesException("Transaction must not be signed. Use ToEnvelopeXDR.");

            var thisXdr = new TransactionEnvelope();
            var transaction = ToXdr();
            thisXdr.Tx = transaction;
            thisXdr.Signatures = new DecoratedSignature[0];

            return thisXdr;
        }

        /// <summary>
        ///     Generates TransactionEnvelope XDR object. This transaction MUST be signed before being useful
        /// </summary>
        /// <returns></returns>
        public string ToUnsignedEnvelopeXdrBase64()
        {
            var envelope = ToUnsignedEnvelopeXdr();
            var writer = new XdrDataOutputStream();
            TransactionEnvelope.Encode(writer, envelope);

            return Convert.ToBase64String(writer.ToArray());
        }

        /// <summary>
        ///     Returns base64-encoded TransactionEnvelope XDR object. Transaction need to have at least one signature.
        /// </summary>
        /// <returns></returns>
        public string ToEnvelopeXdrBase64()
        {
            var envelope = ToEnvelopeXdr();
            var writer = new XdrDataOutputStream();
            TransactionEnvelope.Encode(writer, envelope);

            return Convert.ToBase64String(writer.ToArray());
        }

        public static Transaction FromEnvelopeXdr(string envelope)
        {
            byte[] bytes = Convert.FromBase64String(envelope);

            TransactionEnvelope transactionEnvelope = TransactionEnvelope.Decode(new XdrDataInputStream(bytes));
            return FromEnvelopeXdr(transactionEnvelope);
        }

        public static Transaction FromEnvelopeXdr(TransactionEnvelope envelope)
        {
            xdr.Transaction transactionXdr = envelope.Tx;
            int fee = transactionXdr.Fee.InnerValue;
            KeyPair sourceAccount = KeyPair.FromXdrPublicKey(transactionXdr.SourceAccount.InnerValue);
            long sequenceNumber = transactionXdr.SeqNum.InnerValue.InnerValue;
            Memo memo = Memo.FromXdr(transactionXdr.Memo);
            TimeBounds timeBounds = TimeBounds.FromXdr(transactionXdr.TimeBounds);

            Operation[] operations = new Operation[transactionXdr.Operations.Length];
            for (int i = 0; i < transactionXdr.Operations.Length; i++)
            {
                operations[i] = Operation.FromXdr(transactionXdr.Operations[i]);
            }

            Transaction transaction = new Transaction(sourceAccount, fee, sequenceNumber, operations, memo, timeBounds);

            foreach (var signature in envelope.Signatures)
            {
                transaction.Signatures.Add(signature);
            }

            return transaction;
        }

        /// <summary>
        ///     Builds a new Transaction object.
        /// </summary>
        public class Builder
        {
            private readonly BlockingCollection<Operation> _operations;
            private readonly ITransactionBuilderAccount _sourceAccount;
            private Memo _memo;
            private TimeBounds _timeBounds;
            private int _fee;

            /// <summary>
            ///     Construct a new transaction builder.
            /// </summary>
            /// <param name="sourceAccount">
            ///     The source account for this transaction. This account is the account
            ///     who will use a sequence number. When build() is called, the account object's sequence number will be incremented.
            /// </param>
            public Builder(ITransactionBuilderAccount sourceAccount)
            {
                _sourceAccount = sourceAccount ?? throw new ArgumentNullException(nameof(sourceAccount), "sourceAccount cannot be null");
                _operations = new BlockingCollection<Operation>();
                _fee = BaseFee;
            }

            public int OperationsCount => _operations.Count;

            /// <summary>
            ///     Adds a new operation to this transaction.
            ///     See: https://www.stellar.org/developers/learn/concepts/list-of-operations.html
            /// </summary>
            /// <param name="operation">operation</param>
            /// <returns>Builder object so you can chain methods.</returns>
            public Builder AddOperation(Operation operation)
            {
                if (operation == null)
                    throw new ArgumentNullException(nameof(operation), "operation cannot be null");

                _operations.Add(operation);
                return this;
            }

            /// <summary>
            ///     Adds a memo to this transaction.
            ///     See: https://www.stellar.org/developers/learn/concepts/transactions.html
            /// </summary>
            /// <param name="memo">Memo</param>
            /// <returns>Builder object so you can chain methods.</returns>
            public Builder AddMemo(Memo memo)
            {
                if (_memo != null)
                    throw new ArgumentException("Memo has been already added.", nameof(memo));

                _memo = memo ?? throw new ArgumentNullException(nameof(memo), "memo cannot be null");

                return this;
            }

            /// <summary>
            ///     Adds a time-bounds to this transaction.
            ///     See: https://www.stellar.org/developers/learn/concepts/transactions.html
            /// </summary>
            /// <param name="timeBounds">timeBounds</param>
            /// <returns>Builder object so you can chain methods.</returns>
            public Builder AddTimeBounds(TimeBounds timeBounds)
            {
                if (_timeBounds != null)
                    throw new ArgumentException("TimeBounds has been already added.", nameof(timeBounds));

                _timeBounds = timeBounds ?? throw new ArgumentNullException(nameof(timeBounds), "timeBounds cannot be null");

                return this;
            }

            /// <summary>
            ///     Set the transaction fee (in Quarks) per operation.
            ///     See: https://www.stellar.org/developers/learn/concepts/transactions.html
            /// </summary>
            /// <param name="fee">fee (in Quarks) for each operation in the transaction</param>
            /// <returns>Builder object so you can chain methods.</returns>
            public Builder SetFee(int fee)
            {
                if (_fee < 0)
                    throw new ArgumentException("Fee cant be negative", nameof(fee));

                _fee = fee;

                return this;
            }

            /// <summary>
            ///     Builds a transaction. It will increment sequence number of the source account.
            /// </summary>
            /// <returns></returns>
            public Transaction Build()
            {
                var operations = _operations.ToArray();

                var transaction = new Transaction(_sourceAccount.KeyPair, operations.Length * _fee, _sourceAccount.IncrementedSequenceNumber, operations, _memo, _timeBounds);
                // Increment sequence number when there were no exceptions when creating a transaction
                _sourceAccount.IncrementSequenceNumber();
                return transaction;
            }
        }
    }
}
