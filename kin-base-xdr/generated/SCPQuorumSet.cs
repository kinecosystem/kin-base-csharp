// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace Kin.Base.xdr
{
// === xdr source ============================================================
//  struct SCPQuorumSet
//  {
//      uint32 threshold;
//      PublicKey validators<>;
//      SCPQuorumSet innerSets<>;
//  };
//  ===========================================================================
    public class SCPQuorumSet
    {
        public SCPQuorumSet()
        {
        }

        public Uint32 Threshold { get; set; }
        public PublicKey[] Validators { get; set; }
        public SCPQuorumSet[] InnerSets { get; set; }

        public static void Encode(XdrDataOutputStream stream, SCPQuorumSet encodedSCPQuorumSet)
        {
            Uint32.Encode(stream, encodedSCPQuorumSet.Threshold);
            int validatorssize = encodedSCPQuorumSet.Validators.Length;
            stream.WriteInt(validatorssize);
            for (int i = 0; i < validatorssize; i++)
            {
                PublicKey.Encode(stream, encodedSCPQuorumSet.Validators[i]);
            }

            int innerSetssize = encodedSCPQuorumSet.InnerSets.Length;
            stream.WriteInt(innerSetssize);
            for (int i = 0; i < innerSetssize; i++)
            {
                SCPQuorumSet.Encode(stream, encodedSCPQuorumSet.InnerSets[i]);
            }
        }

        public static SCPQuorumSet Decode(XdrDataInputStream stream)
        {
            SCPQuorumSet decodedSCPQuorumSet = new SCPQuorumSet();
            decodedSCPQuorumSet.Threshold = Uint32.Decode(stream);
            int validatorssize = stream.ReadInt();
            decodedSCPQuorumSet.Validators = new PublicKey[validatorssize];
            for (int i = 0; i < validatorssize; i++)
            {
                decodedSCPQuorumSet.Validators[i] = PublicKey.Decode(stream);
            }

            int innerSetssize = stream.ReadInt();
            decodedSCPQuorumSet.InnerSets = new SCPQuorumSet[innerSetssize];
            for (int i = 0; i < innerSetssize; i++)
            {
                decodedSCPQuorumSet.InnerSets[i] = SCPQuorumSet.Decode(stream);
            }

            return decodedSCPQuorumSet;
        }
    }
}
