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
    ///  ALC NetAcademy2 技術英語基礎コース の 基礎コース のレビューテストのユニットデータを格納します。
    /// </summary>
    [XmlRoot("unit")]
    public class Review : UnitBase
    {
        /// <summary>
        /// レビュークイズを取得または設定します。
        /// </summary>
        [XmlElement("question")]
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<ReviewQuestion> Questions { get; set; }
    }
}
