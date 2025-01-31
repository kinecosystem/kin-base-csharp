// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace Kin.Base.xdr
{
// === xdr source ============================================================
//  union AccountMergeResult switch (AccountMergeResultCode code)
//  {
//  case ACCOUNT_MERGE_SUCCESS:
//      int64 sourceAccountBalance; // how much got transfered from source account
//  default:
//      void;
//  };
//  ===========================================================================
    public class AccountMergeResult
    {
        public AccountMergeResult()
        {
        }

        public AccountMergeResultCode Discriminant { get; set; } = new AccountMergeResultCode();
        public Int64 SourceAccountBalance { get; set; }

        public static void Encode(XdrDataOutputStream stream, AccountMergeResult encodedAccountMergeResult)
        {
            stream.WriteInt((int) encodedAccountMergeResult.Discriminant.InnerValue);
            switch (encodedAccountMergeResult.Discriminant.InnerValue)
            {
                case AccountMergeResultCode.AccountMergeResultCodeEnum.ACCOUNT_MERGE_SUCCESS:
                    Int64.Encode(stream, encodedAccountMergeResult.SourceAccountBalance);
                    break;
                default:
                    break;
            }
        }

        public static AccountMergeResult Decode(XdrDataInputStream stream)
        {
            AccountMergeResult decodedAccountMergeResult = new AccountMergeResult();
            AccountMergeResultCode discriminant = AccountMergeResultCode.Decode(stream);
            decodedAccountMergeResult.Discriminant = discriminant;
            switch (decodedAccountMergeResult.Discriminant.InnerValue)
            {
                case AccountMergeResultCode.AccountMergeResultCodeEnum.ACCOUNT_MERGE_SUCCESS:
                    decodedAccountMergeResult.SourceAccountBalance = Int64.Decode(stream);
                    break;
                default:
                    break;
            }

            return decodedAccountMergeResult;
        }
    }
}
