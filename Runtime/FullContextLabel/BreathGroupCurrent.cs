// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese
// @Struct    : BreathGroupCurrent
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// `BreathGroup` field of full-context label for current breath group (`I` field).
    /// </summary>
    [Serializable]
    public struct BreathGroupCurrent : IEquatable<BreathGroupCurrent>
    {
        #region Fields

        /// <summary>I1: the number of accent phrases in the current breath group</summary>
        [DataMember(Name = "accent_phrase_count")]
        //[Range(1, 49)]
        public byte AccentPhraseCount;

        /// <summary>I2: the number of moras in the current breath group</summary>
        [DataMember(Name = "mora_count")]
        //[Range(1, 99)]
        public byte MoraCount;

        /// <summary>I3: position of the current breath group identity by breath group (forward)</summary>
        [DataMember(Name = "breath_group_position_forward")]
        //[Range(1, 19)]
        public byte BreathGroupPositionForward;

        /// <summary>I4: position of the current breath group identity by breath group (backward)</summary>
        [DataMember(Name = "breath_group_position_backward")]
        //[Range(1, 19)]
        public byte BreathGroupPositionBackward;

        /// <summary>I5: position of the current breath group identity by accent phrase (forward)</summary>
        [DataMember(Name = "accent_phrase_position_forward")]
        //[Range(1, 49)]
        public byte AccentPhrasePositionForward;

        /// <summary>I6: position of the current breath group identity by accent phrase (backward)</summary>
        [DataMember(Name = "accent_phrase_position_backward")]
        //[Range(1, 49)]
        public byte AccentPhrasePositionBackward;

        /// <summary>I7: position of the current breath group identity by mora (forward)</summary>
        [DataMember(Name = "mora_position_forward")]
        //[Range(1, 199)]
        public byte MoraPositionForward;

        /// <summary>I8: position of the current breath group identity by mora (backward)</summary>
        [DataMember(Name = "mora_position_backward")]
        //[Range(1, 199)]
        public byte MoraPositionBackward;

        #endregion

        #region Operators

        public static bool operator ==(BreathGroupCurrent lhs, BreathGroupCurrent rhs) => lhs.Equals(rhs);

        public static bool operator !=(BreathGroupCurrent lhs, BreathGroupCurrent rhs) => !(lhs == rhs);

        #endregion

        #region Methods

        public override bool Equals(object? obj)
        {
            return obj is BreathGroupCurrent other && Equals(other);
        }

        public bool Equals(BreathGroupCurrent p)
        {
            return
                AccentPhraseCount == p.AccentPhraseCount &&
                MoraCount == p.MoraCount &&
                BreathGroupPositionForward == p.BreathGroupPositionForward &&
                BreathGroupPositionBackward == p.BreathGroupPositionBackward &&
                AccentPhrasePositionForward == p.AccentPhrasePositionForward &&
                AccentPhrasePositionBackward == p.AccentPhrasePositionBackward &&
                MoraPositionForward == p.MoraPositionForward &&
                MoraPositionBackward == p.MoraPositionBackward;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                AccentPhraseCount,
                MoraCount,
                BreathGroupPositionForward,
                BreathGroupPositionBackward,
                AccentPhrasePositionForward,
                AccentPhrasePositionBackward,
                MoraPositionForward,
                MoraPositionBackward
            );
        }

        #endregion
    }
}
