// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese
// @Struct    : BreathGroupPrevNext
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// `BreathGroup` field of full-context label for previous or next breath group (`H` and `J` field).
    /// </summary>
    [Serializable]
    public struct BreathGroupPrevNext : IEquatable<BreathGroupPrevNext>
    {
        #region Fields

        /// <summary>H1/J1: the number of accent phrases in the previous/next breath group</summary>
        [DataMember(Name = "accent_phrase_count")]
        //[Range(1, 49)]
        public byte AccentPhraseCount;

        /// <summary>H2/J2: the number of moras in the previous/next breath group</summary>
        [DataMember(Name = "mora_count")]
        //[Range(1, 99)]
        public byte MoraCount;

        #endregion

        #region Operators

        public static bool operator ==(BreathGroupPrevNext lhs, BreathGroupPrevNext rhs) => lhs.Equals(rhs);

        public static bool operator !=(BreathGroupPrevNext lhs, BreathGroupPrevNext rhs) => !(lhs == rhs);

        #endregion

        #region Methods

        public override bool Equals(object? obj)
        {
            return obj is BreathGroupPrevNext other && Equals(other);
        }

        public bool Equals(BreathGroupPrevNext p)
        {
            return
                AccentPhraseCount == p.AccentPhraseCount &&
                MoraCount == p.MoraCount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                AccentPhraseCount,
                MoraCount
            );
        }

        #endregion
    }
}
