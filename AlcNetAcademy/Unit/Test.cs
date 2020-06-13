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

    using Contents;

    /// <summary>
    ///  ALC NetAcademy2 技術英語基礎コース の 中間テスト／修了テスト のユニットデータを格納します。
    /// </summary>
    [XmlRoot("unit")]
    public class Test : UnitBase, IXmlSerializable
    {
        #region プロパティ

        /// <summary>
        /// セクション1 のコンテンツを取得または設定します。
        /// </summary>
        public SectionJapaneseSectional Section1 { get; set; }

        /// <summary>
        /// セクション2 のコンテンツを取得または設定します。
        /// </summary>
        public SectionJapaneseSectional Section2 { get; set; }

        /// <summary>
        /// セクション3 のコンテンツを取得または設定します。
        /// </summary>
        public SectionTextBlanked Section3 { get; set; }

        /// <summary>
        /// セクション4 のコンテンツを取得または設定します。
        /// </summary>
        public SectionTextBlanked Section4 { get; set; }

        /// <summary>
        /// セクション5 のコンテンツを取得または設定します。
        /// </summary>
        public SectionSelectionalTextBlanked Section5 { get; set; }

        /// <summary>
        /// セクション6 のコンテンツを取得または設定します。
        /// </summary>
        public SectionTextBlanked Section6 { get; set; }

        /// <summary>
        /// セクション7 のコンテンツを取得または設定します。
        /// </summary>
        public SectionEnglishSectional Section7 { get; set; }

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
            this.IdString = reader.GetAttribute("idx");
            reader.Read();
            XmlSerializer serializer;

            do
            {
                while (reader.NodeType != XmlNodeType.Element)
                {
                    reader.Read();
                }

                if (reader.IsStartElement("part"))
                {
                    string contentType = reader.GetAttribute("type");

                    if (contentType == "tech2-1")
                    {
                        serializer = new XmlSerializer(typeof(SectionJapaneseSectional));
                        this.Section1 = (SectionJapaneseSectional)serializer.Deserialize(reader);
                    }
                    else if (contentType == "tech2-2")
                    {
                        serializer = new XmlSerializer(typeof(SectionJapaneseSectional));
                        this.Section2 = (SectionJapaneseSectional)serializer.Deserialize(reader);
                    }
                    else if (contentType == "tech2-3")
                    {
                        serializer = new XmlSerializer(typeof(SectionTextBlanked));
                        this.Section3 = (SectionTextBlanked)serializer.Deserialize(reader);
                    }
                    else if (contentType == "tech2-4")
                    {
                        serializer = new XmlSerializer(typeof(SectionTextBlanked));
                        this.Section4 = (SectionTextBlanked)serializer.Deserialize(reader);
                    }
                    else if (contentType == "tech2-5")
                    {
                        serializer = new XmlSerializer(typeof(SectionSelectionalTextBlanked));
                        this.Section5 = (SectionSelectionalTextBlanked)serializer.Deserialize(reader);
                    }
                    else if (contentType == "tech2-6")
                    {
                        serializer = new XmlSerializer(typeof(SectionTextBlanked));
                        this.Section6 = (SectionTextBlanked)serializer.Deserialize(reader);
                    }
                    else if (contentType == "tech2-7")
                    {
                        serializer = new XmlSerializer(typeof(SectionEnglishSectional));
                        this.Section7 = (SectionEnglishSectional)serializer.Deserialize(reader);
                    }
                }
                else
                {
                    reader.Read();
                }
            }
            while (reader.IsEmptyElement || reader.Name != "unit");
        }

        /// <summary>
        /// オブジェクトを XML 表現に変換します。
        /// </summary>
        /// <param name="writer"> オブジェクトのシリアル化先の <see cref="XmlWriter"/> ストリーム。 </param>
        [SuppressMessage("Microsoft.Design", "CA1062", Justification = "writer が検証されているときのみメソッドを呼び出します。")]
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("idx", this.IdString);

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var ignorePropertyName = new List<string>()
            {
                nameof(UnitBase.IdString),
                nameof(UnitBase.Id),
                nameof(DependencyObject.DependencyObjectType),
                nameof(DependencyObject.Dispatcher),
                nameof(DependencyObject.IsSealed),
            };

            foreach (var propertyInfo
                in typeof(Test).GetProperties().Where(p => !ignorePropertyName.Any(i => i == p.Name)))
            {
                var serializer = new XmlSerializer(propertyInfo.PropertyType);
                serializer.Serialize(writer, propertyInfo.GetValue(this), ns);
            }
        }

        #endregion
    }
}
