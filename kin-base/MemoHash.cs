// This file was modified by Kin Ecosystem (2019)


using Kin.Base.xdr;

namespace Kin.Base
{
    public class MemoHash : MemoHashAbstract
    {
        public MemoHash(byte[] bytes) : base(bytes)
        {
        }

        public MemoHash(string hexString) : base(hexString)
        {
        }

        public override xdr.Memo ToXdr()
        {
            var memo = new xdr.Memo();
            memo.Discriminant = MemoType.Create(MemoType.MemoTypeEnum.MEMO_HASH);

            var hash = new Hash();
            hash.InnerValue = MemoBytes;

            memo.Hash = hash;

            return memo;
        }
    }
}
