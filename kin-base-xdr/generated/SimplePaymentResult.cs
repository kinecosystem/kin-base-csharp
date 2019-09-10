// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace Kin.Base.xdr
{
// === xdr source ============================================================
//  struct SimplePaymentResult
//  {
//      AccountID destination;
//      Asset asset;
//      int64 amount;
//  };
//  ===========================================================================
    public class SimplePaymentResult
    {
        public SimplePaymentResult()
        {
        }

        public AccountID Destination { get; set; }
        public Asset Asset { get; set; }
        public Int64 Amount { get; set; }

        public static void Encode(XdrDataOutputStream stream, SimplePaymentResult encodedSimplePaymentResult)
        {
            AccountID.Encode(stream, encodedSimplePaymentResult.Destination);
            Asset.Encode(stream, encodedSimplePaymentResult.Asset);
            Int64.Encode(stream, encodedSimplePaymentResult.Amount);
        }

        public static SimplePaymentResult Decode(XdrDataInputStream stream)
        {
            SimplePaymentResult decodedSimplePaymentResult = new SimplePaymentResult();
            decodedSimplePaymentResult.Destination = AccountID.Decode(stream);
            decodedSimplePaymentResult.Asset = Asset.Decode(stream);
            decodedSimplePaymentResult.Amount = Int64.Decode(stream);
            return decodedSimplePaymentResult;
        }
    }
}
