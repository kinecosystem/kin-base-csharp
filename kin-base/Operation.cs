// This file was modified by Kin Ecosystem (2019)


using System;
using Kin.Base.xdr;

namespace Kin.Base
{
    public abstract class Operation
    {
        private KeyPair _sourceAccount;

        public KeyPair SourceAccount
        {
            get => _sourceAccount;
            set => _sourceAccount = value ?? throw new ArgumentNullException(nameof(value), "keypair cannot be null");
        }

        /// <summary>
        /// Threshold level for the operation.
        /// </summary>
        public virtual OperationThreshold Threshold
        {
            get => OperationThreshold.Medium;
        }

        public static long ToXdrAmount(string value)
        {
            return Amount.ToXdr(value);
        }

        public static string FromXdrAmount(long value)
        {
            return Amount.FromXdr(value);
        }

        ///<summary>
        /// Generates Operation XDR object.
        ///</summary>
        public xdr.Operation ToXdr()
        {
            var thisXdr = new xdr.Operation();
            if (SourceAccount != null)
            {
                var sourceAccount = new AccountID();
                sourceAccount.InnerValue = SourceAccount.XdrPublicKey;
                thisXdr.SourceAccount = sourceAccount;
            }

            thisXdr.Body = ToOperationBody();
            return thisXdr;
        }

        ///<summary>
        /// Returns base64-encoded Operation XDR object.
        ///</summary>
        public string ToXdrBase64()
        {
            var operation = ToXdr();
            var writer = new XdrDataOutputStream();
            xdr.Operation.Encode(writer, operation);
            return Convert.ToBase64String(writer.ToArray());
        }

        ///<summary>
        ///</summary>
        /// <returns>new Operation object from Operation XDR object.</returns>
        /// <param name="thisXdr">XDR object</param>
        public static Operation FromXdr(xdr.Operation thisXdr)
        {
            var body = thisXdr.Body;
            Operation operation;
            switch (body.Discriminant.InnerValue)
            {
                case OperationType.OperationTypeEnum.CREATE_ACCOUNT:
                    operation = new CreateAccountOperation.Builder(body.CreateAccountOp).Build();
                    break;
                case OperationType.OperationTypeEnum.PAYMENT:
                    operation = new PaymentOperation.Builder(body.PaymentOp).Build();
                    break;
                case OperationType.OperationTypeEnum.PATH_PAYMENT:
                    operation = new PathPaymentOperation.Builder(body.PathPaymentOp).Build();
                    break;
                case OperationType.OperationTypeEnum.MANAGE_SELL_OFFER:
                    operation = new ManageSellOfferOperation.Builder(body.ManageSellOfferOp).Build();
                    break;
                case OperationType.OperationTypeEnum.MANAGE_BUY_OFFER:
                    operation = new ManageBuyOfferOperation.Builder(body.ManageBuyOfferOp).Build();
                    break;
                case OperationType.OperationTypeEnum.CREATE_PASSIVE_SELL_OFFER:
                    operation = new CreatePassiveSellOfferOperation.Builder(body.CreatePassiveSellOfferOp).Build();
                    break;
                case OperationType.OperationTypeEnum.SET_OPTIONS:
                    operation = new SetOptionsOperation.Builder(body.SetOptionsOp).Build();
                    break;
                case OperationType.OperationTypeEnum.CHANGE_TRUST:
                    operation = new ChangeTrustOperation.Builder(body.ChangeTrustOp).Build();
                    break;
                case OperationType.OperationTypeEnum.ALLOW_TRUST:
                    operation = new AllowTrustOperation.Builder(body.AllowTrustOp).Build();
                    break;
                case OperationType.OperationTypeEnum.ACCOUNT_MERGE:
                    operation = new AccountMergeOperation.Builder(body).Build();
                    break;
                case OperationType.OperationTypeEnum.MANAGE_DATA:
                    operation = new ManageDataOperation.Builder(body.ManageDataOp).Build();
                    break;
                case OperationType.OperationTypeEnum.BUMP_SEQUENCE:
                    operation = new BumpSequenceOperation.Builder(body.BumpSequenceOp).Build();
                    break;
                case OperationType.OperationTypeEnum.INFLATION:
                    operation = new InflationOperation.Builder().Build();
                    break;
                default:
                    throw new Exception("Unknown operation body " + body.Discriminant.InnerValue);
            }

            if (thisXdr.SourceAccount != null)
                operation.SourceAccount = KeyPair.FromXdrPublicKey(thisXdr.SourceAccount.InnerValue);
            return operation;
        }

        ///<summary>
        /// Generates OperationBody XDR object
        ///</summary>
        ///<returns>OperationBody XDR object</returns>
        public abstract xdr.Operation.OperationBody ToOperationBody();
    }
}
