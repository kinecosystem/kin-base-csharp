// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace Kin.Base.xdr
{
// === xdr source ============================================================
//  enum CreateAccountResultCode
//  {
//      // codes considered as "success" for the operation
//      CREATE_ACCOUNT_SUCCESS = 0, // account was created
//  
//      // codes considered as "failure" for the operation
//      CREATE_ACCOUNT_MALFORMED = -1,   // invalid destination
//      CREATE_ACCOUNT_UNDERFUNDED = -2, // not enough funds in source account
//      CREATE_ACCOUNT_LOW_RESERVE =
//          -3, // would create an account below the min reserve
//      CREATE_ACCOUNT_ALREADY_EXIST = -4 // account already exists
//  };
//  ===========================================================================
    public class CreateAccountResultCode
    {
        public enum CreateAccountResultCodeEnum
        {
            CREATE_ACCOUNT_SUCCESS = 0,
            CREATE_ACCOUNT_MALFORMED = -1,
            CREATE_ACCOUNT_UNDERFUNDED = -2,
            CREATE_ACCOUNT_LOW_RESERVE = -3,
            CREATE_ACCOUNT_ALREADY_EXIST = -4,
        }

        public CreateAccountResultCodeEnum InnerValue { get; set; } = default(CreateAccountResultCodeEnum);

        public static CreateAccountResultCode Create(CreateAccountResultCodeEnum v)
        {
            return new CreateAccountResultCode
            {
                InnerValue = v
            };
        }

        public static CreateAccountResultCode Decode(XdrDataInputStream stream)
        {
            int value = stream.ReadInt();
            switch (value)
            {
                case 0: return Create(CreateAccountResultCodeEnum.CREATE_ACCOUNT_SUCCESS);
                case -1: return Create(CreateAccountResultCodeEnum.CREATE_ACCOUNT_MALFORMED);
                case -2: return Create(CreateAccountResultCodeEnum.CREATE_ACCOUNT_UNDERFUNDED);
                case -3: return Create(CreateAccountResultCodeEnum.CREATE_ACCOUNT_LOW_RESERVE);
                case -4: return Create(CreateAccountResultCodeEnum.CREATE_ACCOUNT_ALREADY_EXIST);
                default:
                    throw new Exception("Unknown enum value: " + value);
            }
        }

        public static void Encode(XdrDataOutputStream stream, CreateAccountResultCode value)
        {
            stream.WriteInt((int) value.InnerValue);
        }
    }
}
