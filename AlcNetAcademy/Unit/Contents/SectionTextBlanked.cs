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
    /// 中間テスト／修了テストの テキスト穴埋め式(セクション3、セクション4、またはセクション6)のコンテンツを格納します。
    /// </summary>
    [XmlRoot("part")]
    public class SectionTextBlanked : PartBase
    {
        /// <summary>
        /// 問題を取得または設定します。
        /// </summary>
        [XmlElement("question")]
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<TextBlankedQuestion> Questions { get; set; }

        /// <summary>
        /// 選択肢を取得または設定します。
        /// </summary>
        [XmlElement("sel")]
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<Selection> Selections { get; set; }

        /// <summary>
        /// ポイントを取得または設定します。
        /// </summary>
        [XmlElement("point")]
        public string Point { get; set; }
    }
}
