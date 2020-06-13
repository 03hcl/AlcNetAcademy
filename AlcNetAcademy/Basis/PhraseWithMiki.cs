namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 幹センかどうかの情報を含むフレーズを格納します。
    /// </summary>
    public class PhraseWithMiki : Phrase
    {
        /// <summary>
        /// 幹センかどうかを取得または設定します。
        /// </summary>
        [XmlAttribute("miki")]
        public bool IsMiki { get; set; }
    }
}
