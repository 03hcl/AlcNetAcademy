namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// フレーズ(1要素)を格納します。
    /// </summary>
    public class PhraseOnce
    {
        /// <summary>
        /// フレーズを取得または設定します。
        /// </summary>
        [XmlElement("ph")]
        public Phrase Phrase { get; set; }
    }
}
