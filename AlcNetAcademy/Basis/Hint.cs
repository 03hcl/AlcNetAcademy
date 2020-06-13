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
    /// 基礎コースのヒントを格納します。
    /// </summary>
    /// <typeparam name="T"> ヒントを表す要素の型。 </typeparam>
    public class Hint<T> : Write1Sentence<Phrase>
    {
        /// <summary>
        /// ヒントについての説明を表すテキストを取得または設定します。
        /// </summary>
        [XmlAttribute("text")]
        public string Text { get; set; }

        /////// <summary>
        /////// ヒントを表す要素の一覧を取得または設定します。
        /////// </summary>
        ////[XmlElement("ph")]
        ////[SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        ////[SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        ////public List<T> Phrases { get; set; }
    }
}
