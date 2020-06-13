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
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// 基礎コースの Write1 の先輩の答えを格納します。
    /// </summary>
    public class Write1Senior : DependencyObject, IXmlSerializable
    {
        #region 依存関係プロパティ

        /// <summary>
        /// <see cref="AnswerText"/> 依存関係プロパティを識別します。
        /// </summary>
        public static readonly DependencyProperty AnswerTextProperty =
            DependencyProperty.Register(nameof(AnswerText), typeof(string), typeof(Write1Senior), new PropertyMetadata(new PropertyChangedCallback(OnAnswerTextChanged)));

        /// <summary>
        /// <see cref="Answer"/> 依存関係プロパティを識別します。
        /// </summary>
        public static readonly DependencyProperty AnswerProperty =
            DependencyProperty.Register(nameof(Answer), typeof(List<string>), typeof(Write1Senior), new PropertyMetadata(default(List<string>)));

        #endregion

        #region プロパティ

        /// <summary>
        /// 先輩の間違いの箇所を表す文字列取得または設定します。
        /// </summary>
        public string AnswerText
        {
            get { return (string)this.GetValue(AnswerTextProperty); }
            set { this.SetValue(AnswerTextProperty, value); }
        }

        /// <summary>
        /// 先輩の間違いの箇所を取得または設定します。
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<string> Answer
        {
            get { return (List<string>)this.GetValue(AnswerProperty); }
            protected set { this.SetValue(AnswerProperty, value); }
        }

        /// <summary>
        /// 先輩の答えのフレーズとその間違いの選択肢の一覧を取得または設定します。
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<Selection> Selections { get; set; } = new List<Selection>();

        #endregion

        #region IXmlSerializable

        /// <summary>
        /// このメソッドは予約されているため、使用できません。
        /// </summary>
        /// <returns> null. </returns>
        public XmlSchema GetSchema() => null;

        /// <summary>
        /// オブジェクトの XML 表現からオブジェクトを生成します。
        /// </summary>
        /// <param name="reader"> オブジェクトの逆シリアル化元である <see cref="XmlReader"/> ストリーム。 </param>
        [SuppressMessage("Microsoft.Design", "CA1062", Justification = "reader が検証されているときのみメソッドを呼び出します。")]
        public void ReadXml(XmlReader reader)
        {
            this.AnswerText = reader.GetAttribute("answer");

            reader.Read();
            if (reader.IsEmptyElement)
            {
                return;
            }

            Selection presentSelection = null;

            do
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (presentSelection != null)
                    {
                        this.Selections.Add(presentSelection);
                    }

                    presentSelection = new Selection();
                    presentSelection.CD = reader.GetAttribute("cd");
                }
                else if (reader.NodeType == XmlNodeType.Text)
                {
                    presentSelection = presentSelection ?? new Selection();
                    presentSelection.Text = reader.Value;
                    this.Selections.Add(presentSelection);
                    presentSelection = null;
                }
                else if (reader.NodeType == XmlNodeType.EndElement)
                {
                    if (presentSelection != null)
                    {
                        this.Selections.Add(presentSelection);
                        presentSelection = null;
                    }
                }

                reader.Read();
            }
            while (reader.Name != "senior");

            reader.Read();
        }

        /// <summary>
        /// オブジェクトを XML 表現に変換します。
        /// </summary>
        /// <param name="writer"> オブジェクトのシリアル化先の <see cref="XmlWriter"/> ストリーム。 </param>
        [SuppressMessage("Microsoft.Design", "CA1062", Justification = "writer が検証されているときのみメソッドを呼び出します。")]
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("answer", this.AnswerText);

            var serializer = new XmlSerializer(typeof(Selection));

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            foreach (var selection in this.Selections)
            {
                serializer.Serialize(writer, selection, ns);
            }
        }

        #endregion

        #region プロパティ変更時のコールバック関数

        /// <summary>
        /// <see cref="AnswerText"/> 依存関係プロパティの有効なプロパティ値が変更されたときに呼び出されるコールバックを表します。
        /// </summary>
        /// <param name="d"> プロパティの値が変更された <see cref="DependencyObject"/> 。 </param>
        /// <param name="e"> このプロパティの有効値に対する変更を追跡するイベントによって発行されるイベント データ。 </param>
        private static void OnAnswerTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(AnswerProperty, ((string)e.NewValue).Split(',').ToList());
        }

        #endregion
    }
}
