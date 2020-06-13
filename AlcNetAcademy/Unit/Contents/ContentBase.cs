namespace Kntaco.AlcNetAcademy.Unit.Contents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// contents タグによってあらわされる各コンテンツの基本クラスです。
    /// </summary>
    public class ContentBase
    {
        /// <summary>
        /// コンテンツのタイプを表す文字列を取得または設定します。
        /// </summary>
        [XmlAttribute("type")]
        public string ContentType { get; set; }
    }
}
