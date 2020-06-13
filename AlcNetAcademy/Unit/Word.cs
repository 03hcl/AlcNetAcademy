namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 日本語の単語情報を格納します。
    /// </summary>
    public class Word
    {
        /// <summary>
        /// IDを取得または設定します。
        /// </summary>
        [XmlAttribute("idx")]
        public long Id { get; set; }

        /// <summary>
        /// 英単語を取得または設定します。
        /// </summary>
        [XmlAttribute("name")]
        public string English { get; set; }

        /// <summary>
        /// list属性を取得または設定します。
        /// </summary>
        [XmlAttribute("list")]
        public bool IsList { get; set; }

        /// <summary>
        /// 日本語の意味を取得または設定します。
        /// </summary>
        [XmlElement("jp")]
        public string Japanese { get; set; }

        /// <summary>
        /// 日本語の意味の説明を取得または設定します。
        /// </summary>
        [XmlElement("exp")]
        public string Explanation { get; set; }

        /// <summary>
        /// 音声ファイル名を取得または設定します。
        /// </summary>
        [XmlElement("sound")]
        public string SoundFileName { get; set; }

        /// <summary>
        /// 画像ファイル名を取得または設定します。
        /// </summary>
        [XmlElement("image")]
        public string ImageFileName { get; set; }
    }
}
