namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// トピックのテキストを格納します。
    /// </summary>
    [XmlRoot("w")]
    public class TopicText
    {
        /// <summary>
        /// テキストを取得または設定します。
        /// </summary>
        [XmlText]
        public string Text { get; set; }

        /// <summary>
        /// 単語のIDを取得または設定します。
        /// </summary>
        [XmlAttribute("idx")]
        public long WordId { get; set; }
    }
}
