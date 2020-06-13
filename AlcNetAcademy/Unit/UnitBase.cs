namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Xml.Serialization;

    /// <summary>
    /// ALC NetAcademy2 技術英語基礎コース のユニットデータを表す基本クラスです。
    /// </summary>
    public class UnitBase : DependencyObject
    {
        #region 依存関係プロパティ

        /// <summary>
        /// <see cref="IdString"/> 依存関係プロパティを識別します。
        /// </summary>
        public static readonly DependencyProperty IdStringProperty =
            DependencyProperty.Register(nameof(IdString), typeof(string), typeof(UnitBase), new PropertyMetadata(new PropertyChangedCallback(OnIdStringChanged)));

        /// <summary>
        /// <see cref="Id"/> 依存関係プロパティを識別します。
        /// </summary>
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register(nameof(Id), typeof(long), typeof(UnitBase), new PropertyMetadata(default(long)));

        #endregion

        #region プロパティ

        /// <summary>
        /// IDを表す文字列を取得または設定します。
        /// </summary>
        [XmlAttribute("idx")]
        public string IdString
        {
            get { return (string)this.GetValue(IdStringProperty); }
            set { this.SetValue(IdStringProperty, value); }
        }

        /// <summary>
        /// IDを取得または設定します。
        /// </summary>
        [XmlIgnore]
        public long Id
        {
            get { return (long)this.GetValue(IdProperty); }
            protected set { this.SetValue(IdProperty, value); }
        }

        #endregion

        #region プロパティ変更時のコールバック関数

        /// <summary>
        /// <see cref="IdString"/> 依存関係プロパティの有効なプロパティ値が変更されたときに呼び出されるコールバックを表します。
        /// </summary>
        /// <param name="d"> プロパティの値が変更された <see cref="DependencyObject"/> 。 </param>
        /// <param name="e"> このプロパティの有効値に対する変更を追跡するイベントによって発行されるイベント データ。 </param>
        private static void OnIdStringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(IdProperty, long.Parse((string)e.NewValue, CultureInfo.InvariantCulture));
        }

        #endregion
    }
}
