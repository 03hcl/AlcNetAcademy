namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 中間テスト／修了テスト の問題を格納します。
    /// </summary>
    public class TestQuestionBase
    {
        /// <summary>
        /// 問題番号を取得または設定します。
        /// </summary>
        [XmlAttribute("no")]
        public long Id { get; set; }

        /// <summary>
        /// 解答の番号を取得または設定します。
        /// </summary>
        [XmlAttribute("answer")]
        public long Answer { get; set; }

        /// <summary>
        /// コメントを取得または設定します。
        /// </summary>
        [XmlElement("comment")]
        public string Comment { get; set; }
    }
}
