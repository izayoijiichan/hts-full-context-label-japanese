// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese
// @Struct    : Word
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// `Word` field of full-context label (`B`, `C`, and `D` field).
    /// </summary>
    [Serializable]
    public struct Word : IEquatable<Word>
    {
        #region Fields

        /// <summary>B1/C1/D1: pos (part-of-speech) of the word</summary>
        [DataMember(Name = "pos")]
        public byte? Pos;

        /// <summary>B2/C2/D2: conjugation type of the word</summary>
        [DataMember(Name = "ctype")]
        public byte? CType;

        /// <summary>B3/C3/D3: inflected forms of the word</summary>
        [DataMember(Name = "cform")]
        public byte? CForm;

        #endregion

        #region Operators

        public static bool operator ==(Word lhs, Word rhs) => lhs.Equals(rhs);

        public static bool operator !=(Word lhs, Word rhs) => !(lhs == rhs);

        #endregion
        
        #region Methods

        public override bool Equals(object? obj)
        {
            return obj is Word other && Equals(other);
        }

        public bool Equals(Word p)
        {
            return
                Pos == p.Pos &&
                CType == p.CType &&
                CForm == p.CForm;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                Pos,
                CType,
                CForm
            );
        }

        #endregion
    }
}
