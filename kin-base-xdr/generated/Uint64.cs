// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace Kin.Base.xdr
{
// === xdr source ============================================================
//  typedef unsigned hyper uint64;
//  ===========================================================================
    public class Uint64
    {
        public long InnerValue { get; set; } = default(long);

        public Uint64()
        {
        }

        public Uint64(long value)
        {
            InnerValue = value;
        }

        public static void Encode(XdrDataOutputStream stream, Uint64 encodedUint64)
        {
            stream.WriteLong(encodedUint64.InnerValue);
        }

        public static Uint64 Decode(XdrDataInputStream stream)
        {
            Uint64 decodedUint64 = new Uint64();
            decodedUint64.InnerValue = stream.ReadLong();
            return decodedUint64;
        }
    }
}
