// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese
// @Struct    : Label
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The structure representing a single line of HTS-style full-context label.
    /// </summary>
    [Serializable]
    public struct Label
    {
        #region Fields

        /// <summary>Phoneme</summary>
        [DataMember(Name = "phoneme")]
        public Phoneme Phoneme;

        /// <summary>A: Mora</summary>
        [DataMember(Name = "mora")]
        public Mora? Mora;

        /// <summary>B: Previous Word</summary>
        [DataMember(Name = "word_prev")]
        public Word? WordPrev;

        /// <summary>C: Current Word</summary>
        [DataMember(Name = "word_curr")]
        public Word? WordCurr;

        /// <summary>D: Next Word</summary>
        [DataMember(Name = "word_next")]
        public Word? WordNext;

        /// <summary>E: Previous Accent Phrase</summary>
        [DataMember(Name = "accent_phrase_prev")]
        public AccentPhrasePrevNext? AccentPhrasePrev;

        /// <summary>F: Current Accent Phrase</summary>
        [DataMember(Name = "accent_phrase_curr")]
        public AccentPhraseCurrent? AccentPhraseCurr;

        /// <summary>G: Next Accent Phrase</summary>
        [DataMember(Name = "accent_phrase_next")]
        public AccentPhrasePrevNext? AccentPhraseNext;

        /// <summary>H: Previous Breath Group</summary>
        [DataMember(Name = "breath_group_prev")]
        public BreathGroupPrevNext? BreathGroupPrev;

        /// <summary>I: Current Breath Group</summary>
        [DataMember(Name = "breath_group_curr")]
        public BreathGroupCurrent? BreathGroupCurr;

        /// <summary>J: Next Breath Group</summary>
        [DataMember(Name = "breath_group_next")]
        public BreathGroupPrevNext? BreathGroupNext;

        /// <summary>K: Utterance</summary>
        [DataMember(Name = "utterance")]
        public Utterance Utterance;

        #endregion
    }
}
