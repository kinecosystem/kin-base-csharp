// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace Kin.Base.xdr
{
// === xdr source ============================================================
//  union LedgerUpgrade switch (LedgerUpgradeType type)
//  {
//  case LEDGER_UPGRADE_VERSION:
//      uint32 newLedgerVersion; // update ledgerVersion
//  case LEDGER_UPGRADE_BASE_FEE:
//      uint32 newBaseFee; // update baseFee
//  case LEDGER_UPGRADE_MAX_TX_SET_SIZE:
//      uint32 newMaxTxSetSize; // update maxTxSetSize
//  case LEDGER_UPGRADE_BASE_RESERVE:
//      uint32 newBaseReserve; // update baseReserve
//  };
//  ===========================================================================
    public class LedgerUpgrade
    {
        public LedgerUpgrade()
        {
        }

        public LedgerUpgradeType Discriminant { get; set; } = new LedgerUpgradeType();
        public Uint32 NewLedgerVersion { get; set; }
        public Uint32 NewBaseFee { get; set; }
        public Uint32 NewMaxTxSetSize { get; set; }
        public Uint32 NewBaseReserve { get; set; }

        public static void Encode(XdrDataOutputStream stream, LedgerUpgrade encodedLedgerUpgrade)
        {
            stream.WriteInt((int) encodedLedgerUpgrade.Discriminant.InnerValue);
            switch (encodedLedgerUpgrade.Discriminant.InnerValue)
            {
                case LedgerUpgradeType.LedgerUpgradeTypeEnum.LEDGER_UPGRADE_VERSION:
                    Uint32.Encode(stream, encodedLedgerUpgrade.NewLedgerVersion);
                    break;
                case LedgerUpgradeType.LedgerUpgradeTypeEnum.LEDGER_UPGRADE_BASE_FEE:
                    Uint32.Encode(stream, encodedLedgerUpgrade.NewBaseFee);
                    break;
                case LedgerUpgradeType.LedgerUpgradeTypeEnum.LEDGER_UPGRADE_MAX_TX_SET_SIZE:
                    Uint32.Encode(stream, encodedLedgerUpgrade.NewMaxTxSetSize);
                    break;
                case LedgerUpgradeType.LedgerUpgradeTypeEnum.LEDGER_UPGRADE_BASE_RESERVE:
                    Uint32.Encode(stream, encodedLedgerUpgrade.NewBaseReserve);
                    break;
            }
        }

        public static LedgerUpgrade Decode(XdrDataInputStream stream)
        {
            LedgerUpgrade decodedLedgerUpgrade = new LedgerUpgrade();
            LedgerUpgradeType discriminant = LedgerUpgradeType.Decode(stream);
            decodedLedgerUpgrade.Discriminant = discriminant;
            switch (decodedLedgerUpgrade.Discriminant.InnerValue)
            {
                case LedgerUpgradeType.LedgerUpgradeTypeEnum.LEDGER_UPGRADE_VERSION:
                    decodedLedgerUpgrade.NewLedgerVersion = Uint32.Decode(stream);
                    break;
                case LedgerUpgradeType.LedgerUpgradeTypeEnum.LEDGER_UPGRADE_BASE_FEE:
                    decodedLedgerUpgrade.NewBaseFee = Uint32.Decode(stream);
                    break;
                case LedgerUpgradeType.LedgerUpgradeTypeEnum.LEDGER_UPGRADE_MAX_TX_SET_SIZE:
                    decodedLedgerUpgrade.NewMaxTxSetSize = Uint32.Decode(stream);
                    break;
                case LedgerUpgradeType.LedgerUpgradeTypeEnum.LEDGER_UPGRADE_BASE_RESERVE:
                    decodedLedgerUpgrade.NewBaseReserve = Uint32.Decode(stream);
                    break;
            }

            return decodedLedgerUpgrade;
        }
    }
}
