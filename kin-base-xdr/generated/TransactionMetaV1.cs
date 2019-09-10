// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace Kin.Base.xdr
{
// === xdr source ============================================================
//  struct TransactionMetaV1
//  {
//      LedgerEntryChanges txChanges; // tx level changes if any
//      OperationMeta operations<>;   // meta for each operation
//  };
//  ===========================================================================
    public class TransactionMetaV1
    {
        public TransactionMetaV1()
        {
        }

        public LedgerEntryChanges TxChanges { get; set; }
        public OperationMeta[] Operations { get; set; }

        public static void Encode(XdrDataOutputStream stream, TransactionMetaV1 encodedTransactionMetaV1)
        {
            LedgerEntryChanges.Encode(stream, encodedTransactionMetaV1.TxChanges);
            int operationssize = encodedTransactionMetaV1.Operations.Length;
            stream.WriteInt(operationssize);
            for (int i = 0; i < operationssize; i++)
            {
                OperationMeta.Encode(stream, encodedTransactionMetaV1.Operations[i]);
            }
        }

        public static TransactionMetaV1 Decode(XdrDataInputStream stream)
        {
            TransactionMetaV1 decodedTransactionMetaV1 = new TransactionMetaV1();
            decodedTransactionMetaV1.TxChanges = LedgerEntryChanges.Decode(stream);
            int operationssize = stream.ReadInt();
            decodedTransactionMetaV1.Operations = new OperationMeta[operationssize];
            for (int i = 0; i < operationssize; i++)
            {
                decodedTransactionMetaV1.Operations[i] = OperationMeta.Decode(stream);
            }

            return decodedTransactionMetaV1;
        }
    }
}
