namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 選択肢の選択番号と、答えのフレーズを格納します。
    /// </summary>
    [XmlRoot("sel")]
    public class Selection
    {
        /// <summary>
        /// 選択肢の選択番号を表す文字を取得または設定します。
        /// </summary>
        [XmlAttribute("cd")]
        public string CD { get; set; }

        /// <summary>
        /// 答えのフレーズを取得または設定します。
        /// </summary>
        [XmlText]
        public string Text { get; set; }
    }
}
