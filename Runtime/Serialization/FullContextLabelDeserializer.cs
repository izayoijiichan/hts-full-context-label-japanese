// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese.Serialization
// @Class     : FullContextLabelLabelSerializer
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese.Serialization
{
    using Izayoi.Hts.FullContextLabel.Japanese.Extensions;
    using Izayoi.Hts.FullContextLabel.Japanese.IO;
    using System;

    /// <summary>
    /// HTS-style Full Context Label Serializer
    /// </summary>
    public partial class FullContextLabelSerializer
    {
        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="labelString"></param>
        /// <returns></returns>
        public Label Deserialize(string labelString)
        {
            try
            {
                int pIndex = 0;
                int pLength = labelString.IndexOf("/A:");

                int aIndex = pIndex + pLength;
                int aLength = labelString.AsSpan(aIndex).IndexOf("/B:");

                int bIndex = aIndex + aLength;
                int bLength = labelString.AsSpan(bIndex).IndexOf("/C:");

                int cIndex = bIndex + bLength;
                int cLength = labelString.AsSpan(cIndex).IndexOf("/D:");

                int dIndex = cIndex + cLength;
                int dLength = labelString.AsSpan(dIndex).IndexOf("/E:");

                int eIndex = dIndex + dLength;
                int eLength = labelString.AsSpan(eIndex).IndexOf("/F:");

                int fIndex = eIndex + eLength;
                int fLength = labelString.AsSpan(fIndex).IndexOf("/G:");

                int gIndex = fIndex + fLength;
                int gLength = labelString.AsSpan(gIndex).IndexOf("/H:");

                int hIndex = gIndex + gLength;
                int hLength = labelString.AsSpan(hIndex).IndexOf("/I:");

                int iIndex = hIndex + hLength;
                int iLength = labelString.AsSpan(iIndex).IndexOf("/J:");

                int jIndex = iIndex + iLength;
                int jLength = labelString.AsSpan(jIndex).IndexOf("/K:");

                int kIndex = jIndex + jLength;
                int kLength = labelString.AsSpan(kIndex).Length;

                string pString = labelString.AsSpan(pIndex, pLength).ToString();
                string aString = labelString.AsSpan(aIndex, aLength).ToString();
                string bString = labelString.AsSpan(bIndex, bLength).ToString();
                string cString = labelString.AsSpan(cIndex, cLength).ToString();
                string dString = labelString.AsSpan(dIndex, dLength).ToString();
                string eString = labelString.AsSpan(eIndex, eLength).ToString();
                string fString = labelString.AsSpan(fIndex, fLength).ToString();
                string gString = labelString.AsSpan(gIndex, gLength).ToString();
                string hString = labelString.AsSpan(hIndex, hLength).ToString();
                string iString = labelString.AsSpan(iIndex, iLength).ToString();
                string jString = labelString.AsSpan(jIndex, jLength).ToString();
                string kString = labelString.AsSpan(kIndex, kLength).ToString();

                var pObject = DeserializeP(pString);
                var aObject = DeserializeA(aString);
                var bObject = DeserializeB(bString);
                var cObject = DeserializeC(cString);
                var dObject = DeserializeD(dString);
                var eObject = DeserializeE(eString);
                var fObject = DeserializeF(fString);
                var gObject = DeserializeG(gString);
                var hObject = DeserializeH(hString);
                var iObject = DeserializeI(iString);
                var jObject = DeserializeJ(jString);
                var kObject = DeserializeK(kString);

                return new Label
                {
                    Phoneme = pObject,
                    Mora = aObject,
                    WordPrev = bObject,
                    WordCurr = cObject,
                    WordNext = dObject,
                    AccentPhrasePrev = eObject,
                    AccentPhraseCurr = fObject,
                    AccentPhraseNext = gObject,
                    BreathGroupPrev = hObject,
                    BreathGroupCurr = iObject,
                    BreathGroupNext = jObject,
                    Utterance = kObject,
                };
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// `p1^p2-p3+p4=p5`
        /// </summary>
        /// <param name="stringP"></param>
        /// <returns></returns>
        private Phoneme DeserializeP(string stringP)
        {
            var reader = new LabelStringReader(stringP);

            string? p1 = reader.ReadUntil('^').StringOrDefault();
            string? p2 = reader.ReadUntil('-').StringOrDefault();
            string? p3 = reader.ReadUntil('+').StringOrDefault();
            string? p4 = reader.ReadUntil('=').StringOrDefault();
            string? p5 = reader.ReadToEnd().StringOrDefault();

            return new Phoneme
            {
                P2 = p1,
                P1 = p2,
                C = p3,
                N1 = p4,
                N2 = p5,
            };
        }

        /// <summary>
        /// `/A:a1+a2+a3`
        /// </summary>
        /// <param name="stringA"></param>
        /// <returns></returns>
        private Mora? DeserializeA(string stringA)
        {
            var reader = new LabelStringReader(stringA);

            reader.SeekAfter("/A:");

            sbyte? a1 = reader.ReadUntil('+').ParseSbyteOrDefault();
            byte? a2 = reader.ReadUntil('+').ParseByteOrDefault();
            byte? a3 = reader.ReadToEnd().ParseByteOrDefault();

            if (a1.HasValue && a2.HasValue && a3.HasValue)
            {
                return new Mora
                {
                    RelativeAccentPosition = a1.Value,
                    PositionForward = a2.Value,
                    PositionBackward = a3.Value,
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// `/B:b1-b2_b3`
        /// </summary>
        /// <param name="stringB"></param>
        /// <returns></returns>
        private Word? DeserializeB(string stringB)
        {
            var reader = new LabelStringReader(stringB);

            reader.SeekAfter("/B:");

            byte? b1 = reader.ReadUntil('-').ParseByteOrDefault();
            byte? b2 = reader.ReadUntil('_').ParseByteOrDefault();
            byte? b3 = reader.ReadToEnd().ParseByteOrDefault();

            if (b1.HasValue || b2.HasValue || b3.HasValue)
            {
                return new Word
                {
                    Pos = b1,
                    CType = b2,
                    CForm = b3,
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// `/C:c1_c2+c3`
        /// </summary>
        /// <param name="stringC"></param>
        /// <returns></returns>
        private Word? DeserializeC(string stringC)
        {
            var reader = new LabelStringReader(stringC);

            reader.SeekAfter("/C:");

            byte? c1 = reader.ReadUntil('_').ParseByteOrDefault();
            byte? c2 = reader.ReadUntil('+').ParseByteOrDefault();
            byte? c3 = reader.ReadToEnd().ParseByteOrDefault();

            if (c1.HasValue || c2.HasValue || c3.HasValue)
            {
                return new Word
                {
                    Pos = c1,
                    CType = c2,
                    CForm = c3,
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// `/D:d1+d2_d3`
        /// </summary>
        /// <param name="stringD"></param>
        /// <returns></returns>
        private Word? DeserializeD(string stringD)
        {
            var reader = new LabelStringReader(stringD);

            reader.SeekAfter("/D:");

            byte? d1 = reader.ReadUntil('+').ParseByteOrDefault();
            byte? d2 = reader.ReadUntil('_').ParseByteOrDefault();
            byte? d3 = reader.ReadToEnd().ParseByteOrDefault();

            if (d1.HasValue || d2.HasValue || d3.HasValue)
            {
                return new Word
                {
                    Pos = d1,
                    CType = d2,
                    CForm = d3,
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// `/E:e1_e2!e3_e4-e5`
        /// </summary>
        /// <param name="stringE"></param>
        /// <returns></returns>
        private AccentPhrasePrevNext? DeserializeE(string stringE)
        {
            var reader = new LabelStringReader(stringE);

            reader.SeekAfter("/E:");

            byte? e1 = reader.ReadUntil('_').ParseByteOrDefault();
            byte? e2 = reader.ReadUntil('!').ParseByteOrDefault();
            bool? e3 = reader.ReadUntil('_').ParseBoolOrDefault();

            reader.ReadUntil('-').AssertXX();

            var e5 = reader.ReadToEnd().ParseBoolOrDefault(inverted: true);

            if (e1.HasValue && e2.HasValue && e3.HasValue)
            {
                return new AccentPhrasePrevNext
                {
                    MoraCount = e1.Value,
                    AccentPosition = e2.Value,
                    IsInterrogative = e3.Value,
                    IsPauseInsertion = e5.HasValue ? !e5 : null
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// `/F:f1_f2#f3_f4@f5_f6|f7_f8`
        /// </summary>
        /// <param name="stringF"></param>
        /// <returns></returns>
        private AccentPhraseCurrent? DeserializeF(string stringF)
        {
            var reader = new LabelStringReader(stringF);

            reader.SeekAfter("/F:");

            byte? f1 = reader.ReadUntil('_').ParseByteOrDefault();
            byte? f2 = reader.ReadUntil('#').ParseByteOrDefault();
            bool? f3 = reader.ReadUntil('_').ParseBoolOrDefault();

            reader.ReadUntil('@').AssertXX();

            byte? f5 = reader.ReadUntil('_').ParseByteOrDefault();
            byte? f6 = reader.ReadUntil('|').ParseByteOrDefault();
            byte? f7 = reader.ReadUntil('_').ParseByteOrDefault();
            byte? f8 = reader.ReadToEnd().ParseByteOrDefault();

            if (f1.HasValue &&
                f2.HasValue &&
                f3.HasValue &&
                f5.HasValue &&
                f6.HasValue &&
                f7.HasValue &&
                f8.HasValue)
            {
                return new AccentPhraseCurrent
                {
                    MoraCount = f1.Value,
                    AccentPosition = f2.Value,
                    IsInterrogative = f3.Value,
                    AccentPhrasePositionForward = f5.Value,
                    AccentPhrasePositionBackward = f6.Value,
                    MoraPositionForward = f7.Value,
                    MoraPositionBackward = f8.Value,
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// `/G:g1_g2%g3_g4_g5`
        /// </summary>
        /// <param name="stringG"></param>
        /// <returns></returns>
        private AccentPhrasePrevNext? DeserializeG(string stringG)
        {
            var reader = new LabelStringReader(stringG);

            reader.SeekAfter("/G:");

            byte? g1 = reader.ReadUntil('_').ParseByteOrDefault();
            byte? g2 = reader.ReadUntil('%').ParseByteOrDefault();
            bool? g3 = reader.ReadUntil('_').ParseBoolOrDefault();

            reader.ReadUntil('_').AssertXX();

            bool? g5 = reader.ReadToEnd().ParseBoolOrDefault(inverted: true);

            if (g1.HasValue && g2.HasValue && g3.HasValue)
            {
                return new AccentPhrasePrevNext
                {
                    MoraCount = g1.Value,
                    AccentPosition = g2.Value,
                    IsInterrogative = g3.Value,
                    IsPauseInsertion = g5.HasValue ? !g5 : null
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// `/H:h1_h2`
        /// </summary>
        /// <param name="stringH"></param>
        /// <returns></returns>
        private BreathGroupPrevNext? DeserializeH(string stringH)
        {
            var reader = new LabelStringReader(stringH);

            reader.SeekAfter("/H:");

            byte? h1 = reader.ReadUntil('_').ParseByteOrDefault();
            byte? h2 = reader.ReadToEnd().ParseByteOrDefault();

            if (h1.HasValue && h2.HasValue)
            {
                return new BreathGroupPrevNext
                {
                    AccentPhraseCount = h1.Value,
                    MoraCount = h2.Value,
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// `/I:i1-i2@i3+i4&i5-i6|i7+i8`
        /// </summary>
        /// <param name="stringI"></param>
        /// <returns></returns>
        private BreathGroupCurrent? DeserializeI(string stringI)
        {
            var reader = new LabelStringReader(stringI);

            reader.SeekAfter("/I:");

            byte? i1 = reader.ReadUntil('-').ParseByteOrDefault();
            byte? i2 = reader.ReadUntil('@').ParseByteOrDefault();
            byte? i3 = reader.ReadUntil('+').ParseByteOrDefault();
            byte? i4 = reader.ReadUntil('&').ParseByteOrDefault();
            byte? i5 = reader.ReadUntil('-').ParseByteOrDefault();
            byte? i6 = reader.ReadUntil('|').ParseByteOrDefault();
            byte? i7 = reader.ReadUntil('+').ParseByteOrDefault();
            byte? i8 = reader.ReadToEnd().ParseByteOrDefault();

            if (i1.HasValue &&
                i2.HasValue &&
                i3.HasValue &&
                i4.HasValue &&
                i5.HasValue &&
                i6.HasValue &&
                i7.HasValue &&
                i8.HasValue)
            {
                return new BreathGroupCurrent
                {
                    AccentPhraseCount = i1.Value,
                    MoraCount = i2.Value,
                    BreathGroupPositionForward = i3.Value,
                    BreathGroupPositionBackward = i4.Value,
                    AccentPhrasePositionForward = i5.Value,
                    AccentPhrasePositionBackward = i6.Value,
                    MoraPositionForward = i7.Value,
                    MoraPositionBackward = i8.Value,
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// `/J:j1_j2`
        /// </summary>
        /// <param name="stringJ"></param>
        /// <returns></returns>
        private BreathGroupPrevNext? DeserializeJ(string stringJ)
        {
            var reader = new LabelStringReader(stringJ);

            reader.SeekAfter("/J:");

            byte? j1 = reader.ReadUntil('_').ParseByteOrDefault();
            byte? j2 = reader.ReadToEnd().ParseByteOrDefault();

            if (j1.HasValue && j2.HasValue)
            {
                return new BreathGroupPrevNext
                {
                    AccentPhraseCount = j1.Value,
                    MoraCount = j2.Value,
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// `/K:k1+k2-k3`
        /// </summary>
        /// <param name="stringK"></param>
        /// <returns></returns>
        private Utterance DeserializeK(string stringK)
        {
            var reader = new LabelStringReader(stringK);

            reader.SeekAfter("/K:");

            sbyte k1 = reader.ReadUntil('+').ParseSbyte();
            byte k2 = reader.ReadUntil('-').ParseByte();
            byte k3 = reader.ReadToEnd().ParseByte();

            return new Utterance
            {
                BreathGroupCount = k1,
                AccentPhraseCount = k2,
                MoraCount = k3
            };
        }

        #endregion
    }
}
