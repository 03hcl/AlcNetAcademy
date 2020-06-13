namespace Kntaco.AlcNetAcademy.Unit.Contents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 基礎コースの Step3 のコンテンツを格納します。
    /// </summary>
    [XmlRoot("contents")]
    public class Step3 : ContentBase
    {
        /// <summary>
        /// ヒントを取得または設定します。
        /// </summary>
        [XmlElement("hint")]
        public Hint<Phrase> Hint { get; set; }
    }
}
