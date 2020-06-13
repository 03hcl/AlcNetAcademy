namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 確認クイズのヒントを表す音声のファイル名を格納します。
    /// </summary>
    public class HintSound
    {
        /// <summary>
        /// 音声ファイル名を取得または設定します。
        /// </summary>
        [XmlElement("sound")]
        public string FileName { get; set; }
    }
}
