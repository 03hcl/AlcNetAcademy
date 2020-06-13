namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 文型情報を含むフレーズを格納します。
    /// </summary>
    public class PhraseWithSentencePattern : Phrase
    {
        /// <summary>
        /// 文型情報を取得または設定します。
        /// </summary>
        [XmlAttribute("type")]
        public string SentencePattern { get; set; }
    }
}
