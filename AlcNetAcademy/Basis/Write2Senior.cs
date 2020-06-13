namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Xml.Serialization;

    /// <summary>
    /// 基礎コースの Write2 の先輩の答えを格納します。
    /// </summary>
    public class Write2Senior : DependencyObject
    {
        #region 依存関係プロパティ

        /// <summary>
        /// <see cref="AnswerText"/> 依存関係プロパティを識別します。
        /// </summary>
        public static readonly DependencyProperty AnswerTextProperty =
            DependencyProperty.Register(nameof(AnswerText), typeof(string), typeof(Write2Senior), new PropertyMetadata(new PropertyChangedCallback(OnAnswerTextChanged)));

        /// <summary>
        /// <see cref="Answer"/> 依存関係プロパティを識別します。
        /// </summary>
        public static readonly DependencyProperty AnswerProperty =
            DependencyProperty.Register(nameof(Answer), typeof(List<long>), typeof(Write2Senior), new PropertyMetadata(default(List<long>)));

        #endregion

        #region プロパティ

        /// <summary>
        /// 間違いの選択肢の答えを表す文字列を取得または設定します。
        /// </summary>
        [XmlAttribute("answer")]
        public string AnswerText
        {
            get { return (string)this.GetValue(AnswerTextProperty); }
            set { this.SetValue(AnswerTextProperty, value); }
        }

        /// <summary>
        /// 間違いの選択肢の答えを表す番号の一覧を取得または設定します。
        /// </summary>
        [XmlIgnore]
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<long> Answer
        {
            get { return (List<long>)this.GetValue(AnswerProperty); }
            protected set { this.SetValue(AnswerProperty, value); }
        }

        /// <summary>
        /// 先輩の答えのテキストを取得または設定します。
        /// </summary>
        [XmlText]
        public string Text { get; set; }

        #endregion

        #region プロパティ変更時のコールバック関数

        /// <summary>
        /// <see cref="AnswerText"/> 依存関係プロパティの有効なプロパティ値が変更されたときに呼び出されるコールバックを表します。
        /// </summary>
        /// <param name="d"> プロパティの値が変更された <see cref="DependencyObject"/> 。 </param>
        /// <param name="e"> このプロパティの有効値に対する変更を追跡するイベントによって発行されるイベント データ。 </param>
        private static void OnAnswerTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(AnswerProperty, ((string)e.NewValue).Split(',').Select(s => long.Parse(s, CultureInfo.InvariantCulture)).ToList());
        }

        #endregion
    }
}
