namespace Kntaco.AlcNetAcademy.Unit.Contents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 基礎コースの Step4 のコンテンツを格納します。
    /// </summary>
    [XmlRoot("contents")]
    public class Step4 : ContentBase
    {
        /// <summary>
        /// 先輩の答えを取得または設定します。
        /// </summary>
        [XmlElement("senior")]
        public Write2Senior Senior { get; set; }

        /// <summary>
        /// 先生の答えを取得または設定します。
        /// </summary>
        [XmlElement("teach")]
        public string Teach { get; set; }

        /// <summary>
        /// 解説を取得または設定します。
        /// </summary>
        [XmlElement("comment")]
        public string Comment { get; set; }
    }
}
