namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// クイズの選択肢の選択番号と、単語IDを格納します。
    /// </summary>
    public class SelectionWithWordId : Selection
    {
        /// <summary>
        /// 単語IDを取得または設定します。
        /// </summary>
        [XmlAttribute("w")]
        public long WordId { get; set; }
    }
}
