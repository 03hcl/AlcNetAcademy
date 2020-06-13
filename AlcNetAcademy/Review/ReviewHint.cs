namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Xml.Serialization;

    /// <summary>
    /// レビュークイズのヒントを格納します。
    /// </summary>
    public class ReviewHint : DependencyObject
    {
        #region 依存関係プロパティ

        /// <summary>
        /// <see cref="WordsText"/> 依存関係プロパティを識別します。
        /// </summary>
        public static readonly DependencyProperty WordsTextProperty =
            DependencyProperty.Register(nameof(WordsText), typeof(string), typeof(ReviewHint), new PropertyMetadata(new PropertyChangedCallback(OnWordsTextChanged)));

        /// <summary>
        /// <see cref="Words"/> 依存関係プロパティを識別します。
        /// </summary>
        public static readonly DependencyProperty WordsProperty =
            DependencyProperty.Register(nameof(Words), typeof(List<string>), typeof(ReviewHint), new PropertyMetadata(default(List<string>)));

        #endregion

        #region プロパティ

        /// <summary>
        /// ヒントのナンバーを取得または設定します。
        /// </summary>
        [XmlAttribute("no")]
        public long Id { get; set; }

        /// <summary>
        /// 全てのヒントの単語を表す文字列を取得または設定します。
        /// </summary>
        [XmlText]
        public string WordsText
        {
            get { return (string)this.GetValue(WordsTextProperty); }
            set { this.SetValue(WordsTextProperty, value); }
        }

        /// <summary>
        /// ヒントの単語を取得または設定します。
        /// </summary>
        [XmlIgnore]
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<string> Words
        {
            get { return (List<string>)this.GetValue(WordsProperty); }
            protected set { this.SetValue(WordsProperty, value); }
        }

        #endregion

        #region プロパティ変更時のコールバック関数

        /// <summary>
        /// <see cref="WordsText"/> 依存関係プロパティの有効なプロパティ値が変更されたときに呼び出されるコールバックを表します。
        /// </summary>
        /// <param name="d"> プロパティの値が変更された <see cref="global::System.Windows.DependencyObject"/> 。 </param>
        /// <param name="e"> このプロパティの有効値に対する変更を追跡するイベントによって発行されるイベント データ。 </param>
        private static void OnWordsTextChanged(global::System.Windows.DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(WordsProperty, ((string)e.NewValue).Split(',').ToList());
        }

        #endregion
    }
}
