namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 確認クイズのテキスト中にある選択肢の選択番号と、その答えを表す番号を格納します。
    /// </summary>
    [XmlRoot("sel")]
    public class SelectionWithAnswer : Selection
    {
        /// <summary>
        /// 答えを表す番号を取得または設定します。
        /// </summary>
        [XmlAttribute("answer")]
        public long Answer { get; set; }
    }
}
