namespace Kntaco.AlcNetAcademy.Unit.Contents
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 基礎コースの Step5 のコンテンツを格納します。
    /// </summary>
    [XmlRoot("contents")]
    public class Step5 : ContentBase
    {
        /// <summary>
        /// 問題数を取得または設定します。
        /// </summary>
        [XmlAttribute("size")]
        public long Size { get; set; }

        /// <summary>
        /// 説明を取得または設定します。
        /// </summary>
        [XmlElement("instruction1")]
        public string Instruction { get; set; }

        /// <summary>
        /// 確認クイズの一覧を取得または設定します。
        /// </summary>
        [XmlElement("question")]
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<Question> Questions { get; set; }
    }
}
