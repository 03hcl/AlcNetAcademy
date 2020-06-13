namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// 穴埋め位置を含むテキストを格納します。
    /// </summary>
    public class TextWithBlankPosition : IXmlSerializable
    {
        /// <summary>
        /// 問題文を取得または設定します。
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// 穴埋めの位置を取得または設定します。
        /// </summary>
        public int BlankPosition { get; set; }
        
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062", Justification = "reader が検証されているときのみメソッドを呼び出します。")]
        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            if (reader.IsEmptyElement)
            {
                return;
            }

            do
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    this.BlankPosition = this.Text.Length;
                }
                else if (reader.NodeType == XmlNodeType.Text)
                {
                    this.Text += reader.Value;
                }
                else if (reader.NodeType == XmlNodeType.EndElement)
                {
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062", Justification = "writer が検証されているときのみメソッドを呼び出します。")]
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(this.Text.Substring(0, this.BlankPosition));
            writer.WriteElementString("blank", string.Empty);
            writer.WriteString(this.Text.Substring(this.BlankPosition));
        }

        #endregion
    }
}
