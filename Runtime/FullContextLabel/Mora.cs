// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese
// @Struct    : Mora
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// `Mora` field of full-context label (`A` field).
    /// </summary>
    [Serializable]
    public struct Mora : IEquatable<Mora>
    {
        #region Fields

        /// <summary>A1: the difference between accent type and position of the current mora identity</summary>
        [DataMember(Name = "relative_accent_position")]
        //[Range(-49, 49)]
        public sbyte RelativeAccentPosition;

        /// <summary>A2: position of the current mora identity in the current accent phrase (forward)</summary>
        [DataMember(Name = "position_forward")]
        //[Range(1, 49)]
        public byte PositionForward;

        /// <summary>A3: position of the current mora identity in the current accent phrase (backward)</summary>
        [DataMember(Name = "position_backward")]
        //[Range(1, 49)]
        public byte PositionBackward;

        #endregion

        #region Operators

        public static bool operator ==(Mora lhs, Mora rhs) => lhs.Equals(rhs);

        public static bool operator !=(Mora lhs, Mora rhs) => !(lhs == rhs);

        #endregion

        #region Methods

        public override bool Equals(object? obj)
        {
            return obj is Mora other && Equals(other);
        }

        public bool Equals(Mora p)
        {
            return
                RelativeAccentPosition == p.RelativeAccentPosition &&
                PositionForward == p.PositionForward &&
                PositionBackward == p.PositionBackward;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RelativeAccentPosition, PositionForward, PositionBackward);
        }

        #endregion
    }
}
