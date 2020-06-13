namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 中間テスト／修了テスト の選択式問題を格納します。
    /// </summary>
    public class SelectionalQuestion : TestQuestionBase
    {
        /// <summary>
        /// 問題テキストを取得または設定します。
        /// </summary>
        [XmlElement("text")]
        public string Text { get; set; }
    }
}
