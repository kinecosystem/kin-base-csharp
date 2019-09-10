// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace Kin.Base.xdr
{
// === xdr source ============================================================
//  enum SCPStatementType
//  {
//      SCP_ST_PREPARE = 0,
//      SCP_ST_CONFIRM = 1,
//      SCP_ST_EXTERNALIZE = 2,
//      SCP_ST_NOMINATE = 3
//  };
//  ===========================================================================
    public class SCPStatementType
    {
        public enum SCPStatementTypeEnum
        {
            SCP_ST_PREPARE = 0,
            SCP_ST_CONFIRM = 1,
            SCP_ST_EXTERNALIZE = 2,
            SCP_ST_NOMINATE = 3,
        }

        public SCPStatementTypeEnum InnerValue { get; set; } = default(SCPStatementTypeEnum);

        public static SCPStatementType Create(SCPStatementTypeEnum v)
        {
            return new SCPStatementType
            {
                InnerValue = v
            };
        }

        public static SCPStatementType Decode(XdrDataInputStream stream)
        {
            int value = stream.ReadInt();
            switch (value)
            {
                case 0: return Create(SCPStatementTypeEnum.SCP_ST_PREPARE);
                case 1: return Create(SCPStatementTypeEnum.SCP_ST_CONFIRM);
                case 2: return Create(SCPStatementTypeEnum.SCP_ST_EXTERNALIZE);
                case 3: return Create(SCPStatementTypeEnum.SCP_ST_NOMINATE);
                default:
                    throw new Exception("Unknown enum value: " + value);
            }
        }

        public static void Encode(XdrDataOutputStream stream, SCPStatementType value)
        {
            stream.WriteInt((int) value.InnerValue);
        }
    }
}
