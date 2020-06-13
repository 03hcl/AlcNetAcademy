namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    ///  ALC NetAcademy2 技術英語基礎コース の 語彙演習 のユニットデータを格納します。
    /// </summary>
    [XmlRoot("unit")]
    public class VocabularyBase : UnitBase
    {
        /// <summary>
        /// タイトルを取得または設定します。
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// 日本語の単語データを取得または設定します。
        /// </summary>
        [XmlElement("notes")]
        public Note JPContents { get; set; }

        /// <summary>
        /// 英単語データを取得または設定します。
        /// </summary>
        [XmlElement("contents")]
        public WordList<string> ENContents { get; set; }
    }
}
