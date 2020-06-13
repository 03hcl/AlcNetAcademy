namespace Kntaco.AlcNetAcademy.Unit.Contents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 基礎コースの Step2 のコンテンツを格納します。
    /// </summary>
    [XmlRoot("contents")]
    public class Step2 : ContentBase
    {
        /// <summary>
        /// 説明1を取得または設定します。
        /// </summary>
        [XmlElement("instruction1")]
        public string Instruction1 { get; set; }

        /// <summary>
        /// 説明2を取得または設定します。
        /// </summary>
        [XmlElement("instruction2")]
        public string Instruction2 { get; set; }

        /// <summary>
        /// 幹センかどうかの情報をを含む文章のフレーズを取得または設定します。
        /// </summary>
        [XmlElement("sentence")]
        public Write1Sentence<PhraseWithMiki> SentenceWithMiki { get; set; }

        /// <summary>
        /// 文型情報を含む幹センのフレーズを取得または設定します。
        /// </summary>
        [XmlElement("mikisentence")]
        public Write1Sentence<PhraseWithSentencePattern> MikiSentenceWithSentencePattern { get; set; }

        /// <summary>
        /// ヒントを取得または設定します。
        /// </summary>
        [XmlElement("hint")]
        public Hint<Phrase> Hint { get; set; }

        /// <summary>
        /// 先輩の答えを取得または設定します。
        /// </summary>
        [XmlElement("senior")]
        public Write1Senior Senior { get; set; }

        /// <summary>
        /// 先生の答えを取得または設定します。
        /// </summary>
        [XmlElement("teach")]
        public string Teach { get; set; }

        /// <summary>
        /// 解説を取得または設定します。
        /// </summary>
        [XmlElement("comment")]
        public string Comment { get; set; }
    }
}
