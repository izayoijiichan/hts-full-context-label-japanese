// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese.Serialization
// @Class     : FullContextLabelSerializer
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese.Serialization
{
    using Izayoi.Hts.FullContextLabel.Japanese.Extensions;
    using System.Text;

    /// <summary>
    /// HTS-style Full Context Label Serializer
    /// </summary>
    public partial class FullContextLabelSerializer
    {
        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public string Serialize(Label label)
        {
            var sb = new StringBuilder();

            try
            {
                sb.Append(SerializeP(label.Phoneme));
                sb.Append(SerializeA(label.Mora));
                sb.Append(SerializeB(label.WordPrev));
                sb.Append(SerializeC(label.WordCurr));
                sb.Append(SerializeD(label.WordNext));
                sb.Append(SerializeE(label.AccentPhrasePrev));
                sb.Append(SerializeF(label.AccentPhraseCurr));
                sb.Append(SerializeG(label.AccentPhraseNext));
                sb.Append(SerializeH(label.BreathGroupPrev));
                sb.Append(SerializeI(label.BreathGroupCurr));
                sb.Append(SerializeJ(label.BreathGroupNext));
                sb.Append(SerializeK(label.Utterance));

                return sb.ToString();
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
        /// <param name="phoneme"></param>
        private string SerializeP(Phoneme phoneme)
        {
            string p1 = phoneme.P2.ToLabelString();
            string p2 = phoneme.P1.ToLabelString();
            string p3 = phoneme.C.ToLabelString();
            string p4 = phoneme.N1.ToLabelString();
            string p5 = phoneme.N2.ToLabelString();

            string stringP = $"{p1}^{p2}-{p3}+{p4}={p5}";

            return stringP;
        }

        /// <summary>
        /// `/A:a1+a2+a3`
        /// </summary>
        /// <param name="mora"></param>
        private string SerializeA(Mora? mora)
        {
            string a1;
            string a2;
            string a3;

            if (mora.HasValue)
            {
                a1 = mora.Value.RelativeAccentPosition.ToLabelString();
                a2 = mora.Value.PositionForward.ToLabelString();
                a3 = mora.Value.PositionBackward.ToLabelString();
            }
            else
            {
                a1 = a2 = a3 = "xx";
            }

            string stringA = $"/A:{a1}+{a2}+{a3}";

            return stringA;
        }

        /// <summary>
        /// `/B:b1-b2_b3`
        /// </summary>
        /// <param name="wordPrev"></param>
        private string SerializeB(Word? wordPrev)
        {
            string b1;
            string b2;
            string b3;

            if (wordPrev.HasValue)
            {
                b1 = wordPrev.Value.Pos.ToLabelString("D2");
                b2 = wordPrev.Value.CType.ToLabelString("D1");
                b3 = wordPrev.Value.CForm.ToLabelString("D1");
            }
            else
            {
                b1 = b2 = b3 = "xx";
            }

            string stringB = $"/B:{b1}-{b2}_{b3}";

            return stringB;
        }

        /// <summary>
        /// `/C:c1_c2+c3`
        /// </summary>
        /// <param name="wordCurr"></param>
        private string SerializeC(Word? wordCurr)
        {
            string c1;
            string c2;
            string c3;

            if (wordCurr.HasValue)
            {
                c1 = wordCurr.Value.Pos.ToLabelString("D2");
                c2 = wordCurr.Value.CType.ToLabelString("D1");
                c3 = wordCurr.Value.CForm.ToLabelString("D1");
            }
            else
            {
                c1 = c2 = c3 = "xx";
            }

            string stringC = $"/C:{c1}_{c2}+{c3}";

            return stringC;
        }

        /// <summary>
        /// `/D:d1+d2_d3`
        /// </summary>
        /// <param name="wordNext"></param>
        private string SerializeD(Word? wordNext)
        {
            string d1;
            string d2;
            string d3;

            if (wordNext.HasValue)
            {
                d1 = wordNext.Value.Pos.ToLabelString("D2");
                d2 = wordNext.Value.CType.ToLabelString("D1");
                d3 = wordNext.Value.CForm.ToLabelString("D1");
            }
            else
            {
                d1 = d2 = d3 = "xx";
            }

            string stringD = $"/D:{d1}+{d2}_{d3}";

            return stringD;
        }

        /// <summary>
        /// `/E:e1_e2!e3_e4-e5`
        /// </summary>
        /// <param name="accentPhrasePrev"></param>
        private string SerializeE(AccentPhrasePrevNext? accentPhrasePrev)
        {
            string e1;
            string e2;
            string e3;
            string e4;
            string e5;

            if (accentPhrasePrev.HasValue)
            {
                e1 = accentPhrasePrev.Value.MoraCount.ToLabelString();
                e2 = accentPhrasePrev.Value.AccentPosition.ToLabelString();
                e3 = accentPhrasePrev.Value.IsInterrogative.ToLabelString();
                e4 = "xx";
                e5 = accentPhrasePrev.Value.IsPauseInsertion.ToLabelString(invert: true);
            }
            else
            {
                e1 = e2 = e3 = e4 = e5 = "xx";
            }

            string stringE = $"/E:{e1}_{e2}!{e3}_{e4}-{e5}";

            return stringE;
        }

        /// <summary>
        /// `/F:f1_f2#f3_f4@f5_f6|f7_f8`
        /// </summary>
        /// <param name="accentPhraseCurr"></param>
        private string SerializeF(AccentPhraseCurrent? accentPhraseCurr)
        {
            string f1;
            string f2;
            string f3;
            string f4;
            string f5;
            string f6;
            string f7;
            string f8;

            if (accentPhraseCurr.HasValue)
            {
                f1 = accentPhraseCurr.Value.MoraCount.ToLabelString();
                f2 = accentPhraseCurr.Value.AccentPosition.ToLabelString();
                f3 = accentPhraseCurr.Value.IsInterrogative.ToLabelString();
                f4 = "xx";
                f5 = accentPhraseCurr.Value.AccentPhrasePositionForward.ToLabelString();
                f6 = accentPhraseCurr.Value.AccentPhrasePositionBackward.ToLabelString();
                f7 = accentPhraseCurr.Value.MoraPositionForward.ToLabelString();
                f8 = accentPhraseCurr.Value.MoraPositionBackward.ToLabelString();
            }
            else
            {
                f1 = f2 = f3 = f4 = f5 = f6 = f7 = f8 = "xx";
            }

            string stringF = $"/F:{f1}_{f2}#{f3}_{f4}@{f5}_{f6}|{f7}_{f8}";

            return stringF;
        }

        /// <summary>
        /// `/G:g1_g2%g3_g4_g5`
        /// </summary>
        /// <param name="accentPhraseNext"></param>
        private string SerializeG(AccentPhrasePrevNext? accentPhraseNext)
        {
            string g1;
            string g2;
            string g3;
            string g4;
            string g5;

            if (accentPhraseNext.HasValue)
            {
                g1 = accentPhraseNext.Value.MoraCount.ToLabelString();
                g2 = accentPhraseNext.Value.AccentPosition.ToLabelString();
                g3 = accentPhraseNext.Value.IsInterrogative.ToLabelString();
                g4 = "xx";
                g5 = accentPhraseNext.Value.IsPauseInsertion.ToLabelString(invert: true);
            }
            else
            {
                g1 = g2 = g3 = g4 = g5 = "xx";
            }

            string stringG = $"/G:{g1}_{g2}%{g3}_{g4}_{g5}";

            return stringG;
        }

        /// <summary>
        /// `/H:h1_h2`
        /// </summary>
        /// <param name="breathGroupPrev"></param>
        private string SerializeH(BreathGroupPrevNext? breathGroupPrev)
        {
            string h1;
            string h2;

            if (breathGroupPrev.HasValue)
            {
                h1 = breathGroupPrev.Value.AccentPhraseCount.ToLabelString();
                h2 = breathGroupPrev.Value.MoraCount.ToLabelString();
            }
            else
            {
                h1 = h2 = "xx";
            }

            string stringH = $"/H:{h1}_{h2}";

            return stringH;
        }

        /// <summary>
        /// `/I:i1-i2@i3+i4&i5-i6|i7+i8`
        /// </summary>
        /// <param name="breathGroupCurr"></param>
        private string SerializeI(BreathGroupCurrent? breathGroupCurr)
        {
            string i1;
            string i2;
            string i3;
            string i4;
            string i5;
            string i6;
            string i7;
            string i8;

            if (breathGroupCurr.HasValue)
            {
                i1 = breathGroupCurr.Value.AccentPhraseCount.ToLabelString();
                i2 = breathGroupCurr.Value.MoraCount.ToLabelString();
                i3 = breathGroupCurr.Value.BreathGroupPositionForward.ToLabelString();
                i4 = breathGroupCurr.Value.BreathGroupPositionBackward.ToLabelString();
                i5 = breathGroupCurr.Value.AccentPhrasePositionForward.ToLabelString();
                i6 = breathGroupCurr.Value.AccentPhrasePositionBackward.ToLabelString();
                i7 = breathGroupCurr.Value.MoraPositionForward.ToLabelString();
                i8 = breathGroupCurr.Value.MoraPositionBackward.ToLabelString();
            }
            else
            {
                i1 = i2 = i3 = i4 = i5 = i6 = i7 = i8 = "xx";
            }

            string stringI = $"/I:{i1}-{i2}@{i3}+{i4}&{i5}-{i6}|{i7}+{i8}";

            return stringI;
        }

        /// <summary>
        /// `/J:j1_j2`
        /// </summary>
        /// <param name="breathGroupNext"></param>
        private string SerializeJ(BreathGroupPrevNext? breathGroupNext)
        {
            string j1;
            string j2;

            if (breathGroupNext.HasValue)
            {
                j1 = breathGroupNext.Value.AccentPhraseCount.ToLabelString();
                j2 = breathGroupNext.Value.MoraCount.ToLabelString();
            }
            else
            {
                j1 = j2 = "xx";
            }

            string stringJ = $"/J:{j1}_{j2}";

            return stringJ;
        }

        /// <summary>
        /// `/K:k1+k2-k3`
        /// </summary>
        /// <param name="utterance"></param>
        private string SerializeK(Utterance utterance)
        {
            string k1 = utterance.BreathGroupCount.ToLabelString();
            string k2 = utterance.AccentPhraseCount.ToLabelString();
            string k3 = utterance.MoraCount.ToLabelString();

            string stringK = $"/K:{k1}+{k2}-{k3}";

            return stringK;
        }

        #endregion
    }
}
