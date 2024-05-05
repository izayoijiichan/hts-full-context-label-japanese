// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese
// @Struct    : AccentPhrasePrevNext
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// `AccentPhrase` field of full-context label for previous or next accent phrase (`E` and `G` field).
    /// </summary>
    /// <remarks>
    /// E4/G4 is undefined.
    /// </remarks>
    [Serializable]
    public struct AccentPhrasePrevNext : IEquatable<AccentPhrasePrevNext>
    {
        #region Fields

        /// <summary>E1/G1: the number of moras in the previous/next accent phrase</summary>
        //[Range(1, 49)]
        [DataMember(Name = "mora_count")]
        public byte MoraCount;

        /// <summary>E2/G2: accent type in the previous/next accent phrase</summary>
        [DataMember(Name = "accent_position;\n")]
        //[Range(1, 49)]
        public byte AccentPosition;

        /// <summary>E3/G3: whether the previous/next accent phrase interrogative or not</summary>
        [DataMember(Name = "is_interrogative")]
        public bool IsInterrogative;

        /// <summary>E5/G5: whether pause insertion or not in between the previous/next accent phrase and the current accent phrase</summary>
        /// <remarks>The logic of this field is inverted from the E5/G5 of full-context label: "1" is false and "0" is true.</remarks>
        [DataMember(Name = "is_pause_insertion")]
        public bool? IsPauseInsertion;

        #endregion

        #region Operators

        public static bool operator ==(AccentPhrasePrevNext lhs, AccentPhrasePrevNext rhs) => lhs.Equals(rhs);

        public static bool operator !=(AccentPhrasePrevNext lhs, AccentPhrasePrevNext rhs) => !(lhs == rhs);

        #endregion

        #region Methods

        public override bool Equals(object? obj)
        {
            return obj is AccentPhrasePrevNext other && Equals(other);
        }

        public bool Equals(AccentPhrasePrevNext p)
        {
            return
                MoraCount == p.MoraCount &&
                AccentPosition == p.AccentPosition &&
                IsInterrogative == p.IsInterrogative &&
                IsPauseInsertion == p.IsPauseInsertion;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                MoraCount,
                AccentPosition,
                IsInterrogative,
                IsPauseInsertion
            );
        }

        #endregion
    }
}
