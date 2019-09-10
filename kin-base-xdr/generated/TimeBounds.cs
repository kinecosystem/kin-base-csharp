// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace Kin.Base.xdr
{
// === xdr source ============================================================
//  struct TimeBounds
//  {
//      TimePoint minTime;
//      TimePoint maxTime; // 0 here means no maxTime
//  };
//  ===========================================================================
    public class TimeBounds
    {
        public TimeBounds()
        {
        }

        public TimePoint MinTime { get; set; }
        public TimePoint MaxTime { get; set; }

        public static void Encode(XdrDataOutputStream stream, TimeBounds encodedTimeBounds)
        {
            TimePoint.Encode(stream, encodedTimeBounds.MinTime);
            TimePoint.Encode(stream, encodedTimeBounds.MaxTime);
        }

        public static TimeBounds Decode(XdrDataInputStream stream)
        {
            TimeBounds decodedTimeBounds = new TimeBounds();
            decodedTimeBounds.MinTime = TimePoint.Decode(stream);
            decodedTimeBounds.MaxTime = TimePoint.Decode(stream);
            return decodedTimeBounds;
        }
    }
}
