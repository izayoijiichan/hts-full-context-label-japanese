// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese
// @Struct    : Utterance
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// `Utterance` field of full-context label (`K` field).
    /// </summary>
    [Serializable]
    public struct Utterance : IEquatable<Utterance>
    {
        #region Fields

        /// <summary>K1: the number of breath groups in this utterance</summary>
        [DataMember(Name = "breath_group_count")]
        //[Range(1, 19)]
        public sbyte BreathGroupCount;

        /// <summary>K2: the number of accent phrases in this utterance</summary>
        [DataMember(Name = "accent_phrase_count")]
        //[Range(1, 49)]
        public byte AccentPhraseCount;

        /// <summary>K3: the number of moras in this utterance</summary>
        [DataMember(Name = "mora_count")]
        //[Range(1, 199)]
        public byte MoraCount;

        #endregion

        #region Operators

        public static bool operator ==(Utterance lhs, Utterance rhs) => lhs.Equals(rhs);

        public static bool operator !=(Utterance lhs, Utterance rhs) => !(lhs == rhs);

        #endregion

        #region Methods

        public override bool Equals(object? obj)
        {
            return obj is Utterance other && Equals(other);
        }

        public bool Equals(Utterance p)
        {
            return
                BreathGroupCount == p.BreathGroupCount &&
                AccentPhraseCount == p.AccentPhraseCount &&
                MoraCount == p.MoraCount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                BreathGroupCount,
                AccentPhraseCount,
                MoraCount
            );
        }

        #endregion
    }
}
