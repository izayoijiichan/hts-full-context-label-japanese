// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese
// @Struct    : Phoneme
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// `Phoneme` field of full-context label.
    /// </summary>
    [Serializable]
    public struct Phoneme : IEquatable<Phoneme>
    {
        #region Fields

        /// <summary>P1: the phoneme identity before the previous phoneme</summary>
        [DataMember(Name = "p2")]
        public string? P2;

        /// <summary>P2: the previous phoneme identity</summary>
        [DataMember(Name = "p1")]
        public string? P1;

        /// <summary>P3: the current phoneme identity</summary>
        [DataMember(Name = "c")]
        public string? C;

        /// <summary>P4: the next phoneme identity</summary>
        [DataMember(Name = "n1")]
        public string? N1;

        /// <summary>P5: the phoneme after the next phoneme identity</summary>
        [DataMember(Name = "n2")]
        public string? N2;

        #endregion

        #region Operators

        public static bool operator ==(Phoneme lhs, Phoneme rhs) => lhs.Equals(rhs);

        public static bool operator !=(Phoneme lhs, Phoneme rhs) => !(lhs == rhs);

        #endregion

        #region Methods

        public override bool Equals(object? obj)
        {
            return obj is Phoneme other && Equals(other);
        }

        public bool Equals(Phoneme p)
        {
            return
                P2 == p.P2 &&
                P1 == p.P1 &&
                C == p.C &&
                N1 == p.N1 &&
                N2 == p.N2;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                P2,
                P1,
                C,
                N1,
                N2
            );
        }

        #endregion
    }
}
