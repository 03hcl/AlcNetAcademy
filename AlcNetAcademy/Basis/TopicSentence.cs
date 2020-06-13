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
    /// 基礎コースのトピック文のすべての情報を格納します。
    /// </summary>
    public class TopicSentence : IXmlSerializable
    {
        /// <summary>
        /// トピックの文章の部分リストを取得または設定します。
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<TopicText> Texts { get; set; } = new List<TopicText>();

        /// <summary>
        /// トピックの文章全体を取得します。
        /// </summary>
        public string AllText => string.Join(string.Empty, this.Texts);

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

            TopicText presentTopicText = null;

            do
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (presentTopicText != null)
                    {
                        this.Texts.Add(presentTopicText);
                    }

                    presentTopicText = new TopicText();
                    presentTopicText.WordId = long.Parse(reader.GetAttribute("idx"), CultureInfo.InvariantCulture);
                }
                else if (reader.NodeType == XmlNodeType.Text)
                {
                    presentTopicText = presentTopicText ?? new TopicText();
                    presentTopicText.Text = reader.Value;
                    this.Texts.Add(presentTopicText);
                    presentTopicText = null;
                }
                else if (reader.NodeType == XmlNodeType.EndElement)
                {
                    if (presentTopicText != null)
                    {
                        this.Texts.Add(presentTopicText);
                        presentTopicText = null;
                    }
                }

                reader.Read();
             }
            while (reader.Name != "p");

            reader.Read();
        }

        /// <summary>
        /// オブジェクトを XML 表現に変換します。
        /// </summary>
        /// <param name="writer"> オブジェクトのシリアル化先の <see cref="XmlWriter"/> ストリーム。 </param>
        public void WriteXml(XmlWriter writer)
        {
            var serializer = new XmlSerializer(typeof(TopicText));

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            foreach (var text in this.Texts)
            {
                serializer.Serialize(writer, text, ns);
            }
        }

        #endregion
    }
}
