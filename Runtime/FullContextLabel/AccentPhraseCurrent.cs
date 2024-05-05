// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese
// @Struct    : AccentPhraseCurrent
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// `AccentPhrase` field of full-context label for current accent phrase (`F` field).
    /// </summary>
    /// <remarks>
    /// F4 is undefined.
    /// </remarks>
    [Serializable]
    public struct AccentPhraseCurrent : IEquatable<AccentPhraseCurrent>
    {
        #region Fields

        /// <summary>F1: the number of moras in the current accent phrase</summary>
        [DataMember(Name = "mora_count")]
        //[Range(1, 49)]
        public byte MoraCount;

        /// <summary>F2: accent type in the current accent phrase</summary>
        [DataMember(Name = "accent_position")]
        //[Range(1, 49)]
        public byte AccentPosition;

        /// <summary>F3: whether the current accent phrase interrogative or not</summary>
        [DataMember(Name = "is_interrogative")]
        public bool IsInterrogative;

        /// <summary>F5: position of the current accent phrase identity in the current breath group by the accent phrase (forward)</summary>
        [DataMember(Name = "accent_phrase_position_forward")]
        //[Range(1, 49)]
        public byte AccentPhrasePositionForward;

        /// <summary>F6: position of the current accent phrase identity in the current breath group by the accent phrase (backward)</summary>
        [DataMember(Name = "accent_phrase_position_backward")]
        //[Range(1, 49)]
        public byte AccentPhrasePositionBackward;

        /// <summary>F7: position of the current accent phrase identity in the current breath group by the mora (forward)</summary>
        [DataMember(Name = "mora_position_forward")]
        //[Range(1, 99)]
        public byte MoraPositionForward;

        /// <summary>F8: position of the current accent phrase identity in the current breath group by the mora (backward)</summary>
        [DataMember(Name = "mora_position_backward")]
        //[Range(1, 99)]
        public byte MoraPositionBackward;

        #endregion

        #region Operators

        public static bool operator ==(AccentPhraseCurrent lhs, AccentPhraseCurrent rhs) => lhs.Equals(rhs);

        public static bool operator !=(AccentPhraseCurrent lhs, AccentPhraseCurrent rhs) => !(lhs == rhs);

        #endregion

        #region Methods

        public override bool Equals(object? obj)
        {
            return obj is AccentPhraseCurrent other && Equals(other);
        }

        public bool Equals(AccentPhraseCurrent p)
        {
            return
                MoraCount == p.MoraCount &&
                AccentPosition == p.AccentPosition &&
                IsInterrogative == p.IsInterrogative &&
                AccentPhrasePositionForward == p.AccentPhrasePositionForward &&
                AccentPhrasePositionBackward == p.AccentPhrasePositionBackward &&
                MoraPositionForward == p.MoraPositionForward &&
                MoraPositionBackward == p.MoraPositionBackward;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                MoraCount,
                AccentPosition,
                IsInterrogative,
                AccentPhrasePositionForward,
                AccentPhrasePositionBackward,
                MoraPositionForward,
                MoraPositionBackward
            );
        }

        #endregion
    }
}
