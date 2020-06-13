namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 基礎コースのイントロダクションを格納します。
    /// </summary>
    [XmlRoot("introduction")]
    public class Introduction
    {
        /// <summary>
        /// タイトルを取得または設定します。
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// 学習のポイントを取得または設定します。
        /// </summary>
        [XmlElement("read")]
        public string Point { get; set; }
    }
}
