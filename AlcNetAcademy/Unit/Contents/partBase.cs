namespace Kntaco.AlcNetAcademy.Unit.Contents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// part タグによってあらわされる各コンテンツの基本クラスです。
    /// </summary>
    public class PartBase
    {
        /// <summary>
        /// セクション番号を取得または設定します。
        /// </summary>
        [XmlAttribute("no")]
        public long Id { get; set; }

        /// <summary>
        /// コンテンツのタイプを表す文字列を取得または設定します。
        /// </summary>
        [XmlAttribute("type")]
        public string ContentType { get; set; }
    }
}
