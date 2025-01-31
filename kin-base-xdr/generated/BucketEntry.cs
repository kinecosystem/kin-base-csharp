// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace Kin.Base.xdr
{
// === xdr source ============================================================
//  union BucketEntry switch (BucketEntryType type)
//  {
//  case LIVEENTRY:
//  case INITENTRY:
//      LedgerEntry liveEntry;
//  
//  case DEADENTRY:
//      LedgerKey deadEntry;
//  case METAENTRY:
//      BucketMetadata metaEntry;
//  };
//  ===========================================================================
    public class BucketEntry
    {
        public BucketEntry()
        {
        }

        public BucketEntryType Discriminant { get; set; } = new BucketEntryType();
        public LedgerEntry LiveEntry { get; set; }
        public LedgerKey DeadEntry { get; set; }
        public BucketMetadata MetaEntry { get; set; }

        public static void Encode(XdrDataOutputStream stream, BucketEntry encodedBucketEntry)
        {
            stream.WriteInt((int) encodedBucketEntry.Discriminant.InnerValue);
            switch (encodedBucketEntry.Discriminant.InnerValue)
            {
                case BucketEntryType.BucketEntryTypeEnum.LIVEENTRY:
                case BucketEntryType.BucketEntryTypeEnum.INITENTRY:
                    LedgerEntry.Encode(stream, encodedBucketEntry.LiveEntry);
                    break;
                case BucketEntryType.BucketEntryTypeEnum.DEADENTRY:
                    LedgerKey.Encode(stream, encodedBucketEntry.DeadEntry);
                    break;
                case BucketEntryType.BucketEntryTypeEnum.METAENTRY:
                    BucketMetadata.Encode(stream, encodedBucketEntry.MetaEntry);
                    break;
            }
        }

        public static BucketEntry Decode(XdrDataInputStream stream)
        {
            BucketEntry decodedBucketEntry = new BucketEntry();
            BucketEntryType discriminant = BucketEntryType.Decode(stream);
            decodedBucketEntry.Discriminant = discriminant;
            switch (decodedBucketEntry.Discriminant.InnerValue)
            {
                case BucketEntryType.BucketEntryTypeEnum.LIVEENTRY:
                case BucketEntryType.BucketEntryTypeEnum.INITENTRY:
                    decodedBucketEntry.LiveEntry = LedgerEntry.Decode(stream);
                    break;
                case BucketEntryType.BucketEntryTypeEnum.DEADENTRY:
                    decodedBucketEntry.DeadEntry = LedgerKey.Decode(stream);
                    break;
                case BucketEntryType.BucketEntryTypeEnum.METAENTRY:
                    decodedBucketEntry.MetaEntry = BucketMetadata.Decode(stream);
                    break;
            }

            return decodedBucketEntry;
        }
    }
}
