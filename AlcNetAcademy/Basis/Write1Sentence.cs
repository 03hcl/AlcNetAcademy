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
    /// 基礎コースの Write1 で使用される情報を含む文章のフレーズを格納します。
    /// </summary>
    /// <typeparam name="T"> 格納されるフレーズの型。 </typeparam>
    public class Write1Sentence<T> where T : Phrase
    {
        /// <summary>
        /// フレーズの一覧を取得または設定します。
        /// </summary>
        [XmlElement("ph")]
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<T> Phrases { get; set; }
    }
}
