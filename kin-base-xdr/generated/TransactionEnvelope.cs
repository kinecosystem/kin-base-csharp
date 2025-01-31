// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace Kin.Base.xdr
{
// === xdr source ============================================================
//  struct TransactionEnvelope
//  {
//      Transaction tx;
//      /* Each decorated signature is a signature over the SHA256 hash of
//       * a TransactionSignaturePayload */
//      DecoratedSignature signatures<20>;
//  };
//  ===========================================================================
    public class TransactionEnvelope
    {
        public TransactionEnvelope()
        {
        }

        public Transaction Tx { get; set; }
        public DecoratedSignature[] Signatures { get; set; }

        public static void Encode(XdrDataOutputStream stream, TransactionEnvelope encodedTransactionEnvelope)
        {
            Transaction.Encode(stream, encodedTransactionEnvelope.Tx);
            int signaturessize = encodedTransactionEnvelope.Signatures.Length;
            stream.WriteInt(signaturessize);
            for (int i = 0; i < signaturessize; i++)
            {
                DecoratedSignature.Encode(stream, encodedTransactionEnvelope.Signatures[i]);
            }
        }

        public static TransactionEnvelope Decode(XdrDataInputStream stream)
        {
            TransactionEnvelope decodedTransactionEnvelope = new TransactionEnvelope();
            decodedTransactionEnvelope.Tx = Transaction.Decode(stream);
            int signaturessize = stream.ReadInt();
            decodedTransactionEnvelope.Signatures = new DecoratedSignature[signaturessize];
            for (int i = 0; i < signaturessize; i++)
            {
                decodedTransactionEnvelope.Signatures[i] = DecoratedSignature.Decode(stream);
            }

            return decodedTransactionEnvelope;
        }
    }
}
