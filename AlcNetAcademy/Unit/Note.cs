namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 日本語の単語データを格納します。
    /// </summary>
    [XmlRoot("notes")]
    public class Note
    {
        /// <summary>
        /// 日本語の単語情報の一覧を取得または設定します。
        /// </summary>
        [XmlElement("w")]
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<Word> Words { get; set; }
    }
}
