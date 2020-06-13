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
    /// 中間テスト／修了テストの 日本語選択式(セクション1、またはセクション2)のコンテンツを格納します。
    /// </summary>
    [XmlRoot("part")]
    public class SectionJapaneseSectional : PartBase
    {
        /// <summary>
        /// 問題を取得または設定します。
        /// </summary>
        [XmlElement("question")]
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<JapaneseSelectionalQuestion> Questions { get; set; }
    }
}
