namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// フレーズを格納します。
    /// </summary>
    public class Phrase
    {
        /// <summary>
        /// IDを取得または設定します。
        /// </summary>
        [XmlAttribute("idx")]
        public long Id { get; set; }

        /// <summary>
        /// テキストを取得または設定します。
        /// </summary>
        [XmlText]
        public string Text { get; set; }
    }
}
