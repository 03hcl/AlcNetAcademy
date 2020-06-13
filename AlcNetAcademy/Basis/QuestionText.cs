namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// 確認クイズのテキストを格納します。
    /// </summary>
    public class QuestionText : IXmlSerializable
    {
        /// <summary>
        /// クイズのテキストと選択肢の位置、その答えを取得または設定します。
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<SelectionWithAnswer> Selections { get; set; } = new List<SelectionWithAnswer>();

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
            reader.Read();
            if (reader.IsEmptyElement)
            {
                return;
            }

            SelectionWithAnswer presentSelection = null;

            do
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (presentSelection != null)
                    {
                        this.Selections.Add(presentSelection);
                    }

                    presentSelection = new SelectionWithAnswer();
                    presentSelection.CD = reader.GetAttribute("cd");
                    presentSelection.Answer = long.Parse(reader.GetAttribute("answer"), CultureInfo.InvariantCulture);
                }
                else if (reader.NodeType == XmlNodeType.Text)
                {
                    presentSelection = presentSelection ?? new SelectionWithAnswer();
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
            while (reader.Name != "text");

            reader.Read();
        }

        /// <summary>
        /// オブジェクトを XML 表現に変換します。
        /// </summary>
        /// <param name="writer"> オブジェクトのシリアル化先の <see cref="XmlWriter"/> ストリーム。 </param>
        public void WriteXml(XmlWriter writer)
        {
            var serializer = new XmlSerializer(typeof(SelectionWithAnswer));

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            foreach (var selection in this.Selections)
            {
                serializer.Serialize(writer, selection, ns);
            }
        }

        #endregion
    }
}
