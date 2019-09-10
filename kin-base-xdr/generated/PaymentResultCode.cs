// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace Kin.Base.xdr
{
// === xdr source ============================================================
//  enum PaymentResultCode
//  {
//      // codes considered as "success" for the operation
//      PAYMENT_SUCCESS = 0, // payment successfuly completed
//  
//      // codes considered as "failure" for the operation
//      PAYMENT_MALFORMED = -1,          // bad input
//      PAYMENT_UNDERFUNDED = -2,        // not enough funds in source account
//      PAYMENT_SRC_NO_TRUST = -3,       // no trust line on source account
//      PAYMENT_SRC_NOT_AUTHORIZED = -4, // source not authorized to transfer
//      PAYMENT_NO_DESTINATION = -5,     // destination account does not exist
//      PAYMENT_NO_TRUST = -6,       // destination missing a trust line for asset
//      PAYMENT_NOT_AUTHORIZED = -7, // destination not authorized to hold asset
//      PAYMENT_LINE_FULL = -8,      // destination would go above their limit
//      PAYMENT_NO_ISSUER = -9       // missing issuer on asset
//  };
//  ===========================================================================
    public class PaymentResultCode
    {
        public enum PaymentResultCodeEnum
        {
            PAYMENT_SUCCESS = 0,
            PAYMENT_MALFORMED = -1,
            PAYMENT_UNDERFUNDED = -2,
            PAYMENT_SRC_NO_TRUST = -3,
            PAYMENT_SRC_NOT_AUTHORIZED = -4,
            PAYMENT_NO_DESTINATION = -5,
            PAYMENT_NO_TRUST = -6,
            PAYMENT_NOT_AUTHORIZED = -7,
            PAYMENT_LINE_FULL = -8,
            PAYMENT_NO_ISSUER = -9,
        }

        public PaymentResultCodeEnum InnerValue { get; set; } = default(PaymentResultCodeEnum);

        public static PaymentResultCode Create(PaymentResultCodeEnum v)
        {
            return new PaymentResultCode
            {
                InnerValue = v
            };
        }

        public static PaymentResultCode Decode(XdrDataInputStream stream)
        {
            int value = stream.ReadInt();
            switch (value)
            {
                case 0: return Create(PaymentResultCodeEnum.PAYMENT_SUCCESS);
                case -1: return Create(PaymentResultCodeEnum.PAYMENT_MALFORMED);
                case -2: return Create(PaymentResultCodeEnum.PAYMENT_UNDERFUNDED);
                case -3: return Create(PaymentResultCodeEnum.PAYMENT_SRC_NO_TRUST);
                case -4: return Create(PaymentResultCodeEnum.PAYMENT_SRC_NOT_AUTHORIZED);
                case -5: return Create(PaymentResultCodeEnum.PAYMENT_NO_DESTINATION);
                case -6: return Create(PaymentResultCodeEnum.PAYMENT_NO_TRUST);
                case -7: return Create(PaymentResultCodeEnum.PAYMENT_NOT_AUTHORIZED);
                case -8: return Create(PaymentResultCodeEnum.PAYMENT_LINE_FULL);
                case -9: return Create(PaymentResultCodeEnum.PAYMENT_NO_ISSUER);
                default:
                    throw new Exception("Unknown enum value: " + value);
            }
        }

        public static void Encode(XdrDataOutputStream stream, PaymentResultCode value)
        {
            stream.WriteInt((int) value.InnerValue);
        }
    }
}
