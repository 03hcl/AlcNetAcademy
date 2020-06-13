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
    ///  ALC NetAcademy2 技術英語基礎コース の 基礎コース のユニットデータを格納します。
    /// </summary>
    [XmlRoot("unit")]
    public class Basis : UnitBase, IXmlSerializable
    {
        #region プロパティ

        /// <summary>
        /// イントロダクションを取得または設定します。
        /// </summary>
        public Introduction Introduction { get; set; }

        /// <summary>
        /// 日本語の単語データを取得または設定します。
        /// </summary>
        public Note Notes { get; set; }

        /// <summary>
        /// Step1 のコンテンツを取得または設定します。
        /// </summary>
        public Step1 ContentsStep1 { get; set; }

        /// <summary>
        /// Step2 のコンテンツを取得または設定します。
        /// </summary>
        public Step2 ContentsStep2 { get; set; }

        /// <summary>
        /// Step3 のコンテンツを取得または設定します。
        /// </summary>
        public Step3 ContentsStep3 { get; set; }

        /// <summary>
        /// Step4 のコンテンツを取得または設定します。
        /// </summary>
        public Step4 ContentsStep4 { get; set; }

        /// <summary>
        /// Step5 のコンテンツを取得または設定します。
        /// </summary>
        public Step5 ContentsStep5 { get; set; }

        /// <summary>
        /// 英語のフレーズの一覧を取得または設定します。
        /// </summary>
        public WordList<PhraseOnce> EnglishPhrase { get; set; }

        /// <summary>
        /// 日本語のフレーズの一覧を取得または設定します。
        /// </summary>
        public WordList<PhraseOnce> JapanesePhrase { get; set; }

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

                if (reader.IsStartElement("contents"))
                {
                    string contentType = reader.GetAttribute("type");

                    if (contentType == "tech2bStep1")
                    {
                        serializer = new XmlSerializer(typeof(Step1));
                        this.ContentsStep1 = (Step1)serializer.Deserialize(reader);
                    }
                    else if (contentType == "tech2bStep2")
                    {
                        serializer = new XmlSerializer(typeof(Step2));
                        this.ContentsStep2 = (Step2)serializer.Deserialize(reader);
                    }
                    else if (contentType == "tech2bStep3")
                    {
                        serializer = new XmlSerializer(typeof(Step3));
                        this.ContentsStep3 = (Step3)serializer.Deserialize(reader);
                    }
                    else if (contentType == "tech2bStep4")
                    {
                        serializer = new XmlSerializer(typeof(Step4));
                        this.ContentsStep4 = (Step4)serializer.Deserialize(reader);
                    }
                    else if (contentType == "tech2bStep5")
                    {
                        serializer = new XmlSerializer(typeof(Step5));
                        this.ContentsStep5 = (Step5)serializer.Deserialize(reader);
                    }
                    else if (contentType == "phrase")
                    {
                        serializer = new XmlSerializer(typeof(WordList<PhraseOnce>));
                        this.JapanesePhrase = (WordList<PhraseOnce>)serializer.Deserialize(reader);
                    }
                    else if (contentType == "translation")
                    {
                        serializer = new XmlSerializer(typeof(WordList<PhraseOnce>));
                        this.EnglishPhrase = (WordList<PhraseOnce>)serializer.Deserialize(reader);
                    }
                }
                else
                {
                    var contentName = reader.Name;

                    if (contentName == "introduction")
                    {
                        serializer = new XmlSerializer(typeof(Introduction));
                        this.Introduction = (Introduction)serializer.Deserialize(reader);
                    }
                    else if (contentName == "notes")
                    {
                        serializer = new XmlSerializer(typeof(Note));
                        this.Notes = (Note)serializer.Deserialize(reader);
                    }
                    else
                    {
                        reader.Read();
                    }
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
                in typeof(Basis).GetProperties().Where(p => !ignorePropertyName.Any(i => i == p.Name)))
            {
                var serializer = new XmlSerializer(propertyInfo.PropertyType);
                serializer.Serialize(writer, propertyInfo.GetValue(this), ns);
            }
        }

        #endregion
    }
}
