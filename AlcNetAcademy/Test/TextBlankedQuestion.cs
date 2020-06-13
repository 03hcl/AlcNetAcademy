namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 中間テスト／修了テストの テキストの穴埋め式クイズを格納します。
    /// </summary>
    public class TextBlankedQuestion : TestQuestionBase
    {
        /// <summary>
        /// 穴埋め位置を含む英文テキストを取得または設定します。
        /// </summary>
        [XmlElement("text")]
        public TextWithBlankPosition Text { get; set; }

        /// <summary>
        /// 日本語に翻訳されたテキストを取得または設定します。
        /// </summary>
        [XmlElement("textTrans")]
        public string TranslatedText { get; set; }
    }
}
