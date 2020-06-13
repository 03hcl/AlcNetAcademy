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
    /// 中間テスト／修了テストのテキスト穴埋め選択式問題を格納します。
    /// </summary>
    public class SelectionalTextBlankedQuestion : TextBlankedQuestion
    {
        /// <summary>
        /// 選択肢を取得または設定します。
        /// </summary>
        [XmlElement("sel")]
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<Selection> Selections { get; set; }
    }
}
