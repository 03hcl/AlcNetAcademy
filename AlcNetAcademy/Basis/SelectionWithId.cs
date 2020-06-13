namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 確認クイズの選択肢の選択番号と、答えのIDを格納します。
    /// </summary>
    public class SelectionWithId : Selection
    {
        /// <summary>
        /// 答えのIDを取得または設定します。
        /// </summary>
        [XmlAttribute("idx")]
        public long Id { get; set; }
    }
}
