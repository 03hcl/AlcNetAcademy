namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 語彙演習のポイントを格納します。
    /// </summary>
    public class Point
    {
        /// <summary>
        /// ポイント表示時の言語の種類を取得または設定します。
        /// </summary>
        [XmlAttribute("type")]
        public string LanguageType { get; set; }

        /// <summary>
        /// ポイントを表すテキストを取得または設定します。
        /// </summary>
        [XmlText]
        public string Text { get; set; }
    }
}
