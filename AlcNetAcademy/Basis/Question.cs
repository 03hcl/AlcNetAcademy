namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 基礎コースの確認クイズを格納します。
    /// </summary>
    public class Question
    {
        /// <summary>
        /// クイズナンバーを取得または設定します。
        /// </summary>
        [XmlAttribute("no")]
        public long Id { get; set; }

        /// <summary>
        /// クイズのタイプを取得または設定します。
        /// </summary>
        [XmlAttribute("type")]
        public string QuestionType { get; set; }

        /// <summary>
        /// 日本語に翻訳されたテキストを取得または設定します。
        /// </summary>
        [XmlElement("textTrans")]
        public string TranslatedText { get; set; }

        /// <summary>
        /// 英語のテキストを取得または設定します。
        /// </summary>
        [XmlElement("text")]
        public QuestionText Text { get; set; }

        /// <summary>
        /// 選択肢を取得または設定します。
        /// </summary>
        [XmlElement("sel")]
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<SelectionWithId> Selections { get; set; }

        /// <summary>
        /// ヒントを取得または設定します。
        /// </summary>
        [XmlElement("hint")]
        public HintSound HintSound { get; set; }

        /// <summary>
        /// ポイントを取得または設定します。
        /// </summary>
        [XmlElement("point")]
        public string Point { get; set; }
    }
}
