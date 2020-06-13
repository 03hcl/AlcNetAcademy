namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    using Contents;

    /// <summary>
    /// ワードの一覧を格納します。
    /// </summary>
    /// <typeparam name="T"> 英単語を表す型。 </typeparam>
    [XmlRoot("contents")]
    public class WordList<T> : ContentBase
    {
        /// <summary>
        /// 英単語の一覧を取得または設定します。
        /// </summary>
        [XmlElement("p")]
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<T> Words { get; set; }
    }
}
