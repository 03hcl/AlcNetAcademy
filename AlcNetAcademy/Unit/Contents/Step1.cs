namespace Kntaco.AlcNetAcademy.Unit.Contents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 基礎コースの Step1 のコンテンツを格納します。
    /// </summary>
    [XmlRoot("contents")]
    public class Step1 : ContentBase
    {
        /// <summary>
        /// Step1 のテキストを取得または設定します。
        /// </summary>
        [XmlElement("p")]
        public TopicSentence Text { get; set; }
    }
}
