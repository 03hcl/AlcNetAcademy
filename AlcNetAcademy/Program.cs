namespace Kntaco.AlcNetAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// メインプログラムを格納します。
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// メインプログラムを実行します。
        /// </summary>
        /// <param name="args"> 引数。 </param>
        public static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                return;
            }
            else
            {
                var materialDirectory = new TeachingMaterialDirectory(
                    new Uri("https://academy.ge.kanazawa-u.ac.jp/anet2/course/tech2/media/"));

                materialDirectory.RelativeUris.Clear();
                SaveVocabulary(materialDirectory, 60, true);

                materialDirectory.RelativeUris.Clear();
                SaveBasis(materialDirectory, 32, true);

                materialDirectory.RelativeUris.Clear();
                SaveReview(materialDirectory, 8, true);

                materialDirectory.RelativeUris.Clear();
                SaveIllustration(materialDirectory, 9, true, false);

                materialDirectory.RelativeUris.Clear();
                SaveTest(materialDirectory, 2, true);

                #region シリアライズチェック

                ////#region Test
                ////{
                ////    for (long number = 1; number <= 1; number++)
                ////    {
                ////        var numberString = number.ToString("00", CultureInfo.InvariantCulture);
                ////        materialDirectory.RelativeUris.Add(
                ////            new Uri("tech2t/tech2t" + numberString + "/tech2t" + numberString + ".xml", UriKind.Relative));
                ////    }

                ////    string text = string.Empty;

                ////    foreach (var xml in materialDirectory.ReadXmls())
                ////    {
                ////        text = xml.Result;
                ////    }

                ////    ////materialDirectory.SaveXmls("test").Wait();

                ////    var serializer = new XmlSerializer(typeof(Unit.Test));
                ////    var ns = new XmlSerializerNamespaces();
                ////    ns.Add(string.Empty, string.Empty);

                ////    ////var builder = new StringBuilder();

                ////    using (var reader = new StringReader(text))
                ////    using (var writer = new StringWriter(new StringBuilder(), CultureInfo.InvariantCulture))
                ////    {
                ////        var unit = (Unit.Test)serializer.Deserialize(reader);
                ////        serializer.Serialize(writer, unit, ns);
                ////        var retext = writer.ToString();
                ////        using (var rereader = new StringReader(retext))
                ////        {
                ////            unit = (Unit.Test)serializer.Deserialize(rereader);
                ////        }
                ////    }
                ////}
                ////#endregion

                ////#region Illustration
                ////{
                ////    for (long number = 1; number <= 1; number++)
                ////    {
                ////        var numberString = number.ToString("00", CultureInfo.InvariantCulture);
                ////        materialDirectory.RelativeUris.Add(
                ////            new Uri("tech2v/tech2vi" + numberString + "/tech2vi" + numberString + ".xml", UriKind.Relative));
                ////    }

                ////    string text = string.Empty;

                ////    foreach (var xml in materialDirectory.ReadXmls())
                ////    {
                ////        text = xml.Result;
                ////    }

                ////    ////materialDirectory.SaveXmls("vocabulary_illustration").Wait();

                ////    var serializer = new XmlSerializer(typeof(Unit.Illustration));
                ////    var ns = new XmlSerializerNamespaces();
                ////    ns.Add(string.Empty, string.Empty);

                ////    ////var builder = new StringBuilder();

                ////    using (var reader = new StringReader(text))
                ////    using (var writer = new StringWriter(new StringBuilder(), CultureInfo.InvariantCulture))
                ////    {
                ////        var unit = (Unit.Illustration)serializer.Deserialize(reader);
                ////        serializer.Serialize(writer, unit, ns);
                ////        var retext = writer.ToString();
                ////        using (var rereader = new StringReader(retext))
                ////        {
                ////            unit = (Unit.Illustration)serializer.Deserialize(rereader);
                ////        }
                ////    }
                ////}
                ////#endregion

                ////#region Review
                ////{
                ////    for (long number = 1; number <= 1; number++)
                ////    {
                ////        var numberString = number.ToString("00", CultureInfo.InvariantCulture);
                ////        materialDirectory.RelativeUris.Add(
                ////            new Uri("tech2b/tech2br" + numberString + "/tech2br" + numberString + ".xml", UriKind.Relative));
                ////    }

                ////    string text = string.Empty;

                ////    foreach (var xml in materialDirectory.ReadXmls())
                ////    {
                ////        text = xml.Result;
                ////    }

                ////    ////materialDirectory.SaveXmls("basis_review").Wait();

                ////    var serializer = new XmlSerializer(typeof(Unit.Review));
                ////    var ns = new XmlSerializerNamespaces();
                ////    ns.Add(string.Empty, string.Empty);

                ////    ////var builder = new StringBuilder();

                ////    using (var reader = new StringReader(text))
                ////    using (var writer = new StringWriter(new StringBuilder(), CultureInfo.InvariantCulture))
                ////    {
                ////        var unit = (Unit.Review)serializer.Deserialize(reader);
                ////        serializer.Serialize(writer, unit, ns);
                ////        var retext = writer.ToString();
                ////        using (var rereader = new StringReader(retext))
                ////        {
                ////            unit = (Unit.Review)serializer.Deserialize(rereader);
                ////        }
                ////    }
                ////}
                ////#endregion

                ////#region Basis
                ////{
                ////    for (long number = 1; number <= 1; number++)
                ////    {
                ////        var numberString = number.ToString("00", CultureInfo.InvariantCulture);
                ////        materialDirectory.RelativeUris.Add(
                ////            new Uri("tech2b/tech2b" + numberString + "/tech2b" + numberString + ".xml", UriKind.Relative));
                ////    }

                ////    string text = string.Empty;

                ////    foreach (var xml in materialDirectory.ReadXmls())
                ////    {
                ////        text = xml.Result;
                ////    }

                ////    ////materialDirectory.SaveXmls("basis").Wait();

                ////    var serializer = new XmlSerializer(typeof(Unit.Basis));
                ////    var ns = new XmlSerializerNamespaces();
                ////    ns.Add(string.Empty, string.Empty);

                ////    ////var builder = new StringBuilder();

                ////    using (var reader = new StringReader(text))
                ////    using (var writer = new StringWriter(new StringBuilder(), CultureInfo.InvariantCulture))
                ////    {
                ////        var unit = (Unit.Basis)serializer.Deserialize(reader);
                ////        serializer.Serialize(writer, unit, ns);
                ////        var retext = writer.ToString();
                ////        using (var rereader = new StringReader(retext))
                ////        {
                ////            unit = (Unit.Basis)serializer.Deserialize(rereader);
                ////        }
                ////    }
                ////}
                ////#endregion

                ////#region Vocabulary
                ////{
                ////    for (long number = 1; number <= 1; number++)
                ////    {
                ////        var numberString = number.ToString("00", CultureInfo.InvariantCulture);
                ////        materialDirectory.RelativeUris.Add(
                ////            new Uri("tech2v/tech2v" + numberString + "/tech2v" + numberString + ".xml", UriKind.Relative));
                ////    }

                ////    string text = string.Empty;

                ////    foreach (var xml in materialDirectory.ReadXmls())
                ////    {
                ////        text = xml.Result;
                ////    }

                ////    ////materialDirectory.SaveXmls("vocabulary").Wait();

                ////    var serializer = new XmlSerializer(typeof(Unit.Vocabulary));
                ////    var ns = new XmlSerializerNamespaces();
                ////    ns.Add(string.Empty, string.Empty);

                ////    ////var builder = new StringBuilder();

                ////    using (var reader = new StringReader(text))
                ////    using (var writer = new StringWriter(new StringBuilder(), CultureInfo.InvariantCulture))
                ////    {
                ////        var unit = (Unit.Vocabulary)serializer.Deserialize(reader);
                ////        serializer.Serialize(writer, unit, ns);
                ////        var retext = writer.ToString();
                ////        using (var rereader = new StringReader(retext))
                ////        {
                ////            unit = (Unit.Vocabulary)serializer.Deserialize(rereader);
                ////        }
                ////    }
                ////}
                ////#endregion

                ////var serializer = new XmlSerializer(typeof(ObservableCollection<Course>));

                ////using (var writer = new StreamWriter(path, false, new UTF8Encoding(false)))
                ////{
                ////    serializer.Serialize(writer, courses);
                ////}

                #endregion
            }
        }

        /// <summary>
        /// 語彙をcsv(タブ区切り)で出力します。
        /// </summary>
        /// <param name="materialDirectory"> <see cref="TeachingMaterialDirectory"/>. </param>
        /// <param name="maxUnitId"> ユニット数。 </param>
        /// <param name="isSaveXml"> XMLを保存するかどうか。 </param>
        private static void SaveVocabulary(TeachingMaterialDirectory materialDirectory, long maxUnitId, bool isSaveXml)
        {
            for (long number = 1; number <= maxUnitId; number++)
            {
                var numberString = number.ToString("00", CultureInfo.InvariantCulture);
                materialDirectory.RelativeUris.Add(
                    new Uri("tech2v/tech2v" + numberString + "/tech2v" + numberString + ".xml", UriKind.Relative));
            }

            if (isSaveXml)
            {
                materialDirectory.SaveXmls("vocabulary").Wait();
            }

            var serializer = new XmlSerializer(typeof(Unit.Vocabulary));
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            #region コメントアウト

            ////var answers = new List<Answer>();

            ////foreach (var xml in materialDirectory.ReadXmls())
            ////{
            ////    using (var reader = new StringReader(xml.Result))
            ////    {
            ////        var unit = (Unit.Vocabulary)serializer.Deserialize(reader);
            ////        ////answerJapanese.Add(unit.Id, unit.JPContents.Words.OrderBy(w => w.Id).Select(j => j.Japanese).ToArray());
            ////        var answer = new Answer() { Id = unit.Id };
            ////        answer.Japanese = unit.JPContents.Words.Select(w => w.Japanese).ToArray();
            ////        answer.English = unit.JPContents.Words.Select(w => w.English).ToArray();
            ////        ////answer.English = unit.ENContents.Words.ToArray();
            ////        answers.Add(answer);
            ////    }
            ////}

            ////var lines = new string[21];

            ////foreach (var answer in answers)
            ////{
            ////    lines[0] += answer.Id + ":en," + answer.Id + ":jp,";
            ////    for (var index = 0; index < 20; index++)
            ////    {
            ////        lines[index + 1] += answer.English.ElementAt(index) + "," + answer.Japanese.ElementAt(index) + ",";
            ////    }
            ////}

            #endregion

            var lines = new StringBuilder[21].Select(l => new StringBuilder()).ToArray();
            var columns = 5;
            var counter = 0;

            using (var writer = new StreamWriter("vocabulary.csv", false, Encoding.UTF8))
            {
                foreach (var xml in materialDirectory.ReadXmls())
                {
                    Unit.Vocabulary unit;

                    using (var reader = new StringReader(xml.Result))
                    {
                        unit = (Unit.Vocabulary)serializer.Deserialize(reader);
                    }

                    counter++;
                    lines[0].Append("[");
                    lines[0].Append(unit.Id);
                    lines[0].Append("]\t\t");

                    for (var index = 0; index < unit.JPContents.Words.Count; index++)
                    {
                        lines[index + 1].Append(unit.JPContents.Words[index].English);
                        lines[index + 1].Append("\t");
                        lines[index + 1].Append(unit.JPContents.Words[index].Japanese);
                        lines[index + 1].Append("\t");
                    }

                    if (counter == columns)
                    {
                        for (var index = 0; index < lines.Count(); index++)
                        {
                            writer.WriteLine(lines[index]);
                            lines[index].Clear();
                        }

                        writer.WriteLine();
                        counter = 0;
                    }
                }
            }
        }

        /// <summary>
        /// 基礎をcsv(タブ区切り)で出力します。
        /// </summary>
        /// <param name="materialDirectory"> <see cref="TeachingMaterialDirectory"/>. </param>
        /// <param name="maxUnitId"> ユニット数。 </param>
        /// <param name="isSaveXml"> XMLを保存するかどうか。 </param>
        private static void SaveBasis(TeachingMaterialDirectory materialDirectory, long maxUnitId, bool isSaveXml)
        {
            for (long number = 1; number <= maxUnitId; number++)
            {
                var numberString = number.ToString("00", CultureInfo.InvariantCulture);
                materialDirectory.RelativeUris.Add(
                    new Uri("tech2b/tech2b" + numberString + "/tech2b" + numberString + ".xml", UriKind.Relative));
            }

            if (isSaveXml)
            {
                materialDirectory.SaveXmls("basis").Wait();
            }

            var serializer = new XmlSerializer(typeof(Unit.Basis));
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var seniorSelectionText = new Unit.SeniorSelectionText();
            var slashDelimiter = " / ";
            var commaDelimiter = ", ";

            using (var writer = new StreamWriter("basis.csv", false, Encoding.UTF8))
            {
                foreach (var xml in materialDirectory.ReadXmls())
                {
                    Unit.Basis unit;

                    using (var reader = new StringReader(xml.Result))
                    {
                        unit = (Unit.Basis)serializer.Deserialize(reader);
                    }

                    writer.WriteLine("[" + unit.Id + "]");
                    writer.WriteLine("[Step1]\t" + string.Join(slashDelimiter, unit.Notes.Words.Select(w => w.English)));
                    writer.WriteLine("[Step2]\t" + string.Join(slashDelimiter, unit.ContentsStep2.SentenceWithMiki.Phrases.Where(p => p.IsMiki).Select(p => p.Text)));
                    writer.WriteLine("\t" + unit.ContentsStep2.Teach);
                    writer.WriteLine("\t(先輩の間違い: " + string.Join(commaDelimiter, unit.ContentsStep2.Senior.Answer) + ")");
                    var step3 = System.Web.HttpUtility.HtmlDecode(unit.ContentsStep4.Teach);
                    step3 = Regex.Replace(step3, "<.*?>", string.Empty, RegexOptions.Singleline);
                    step3 = Regex.Replace(step3, "[\\s\\n]+", " ", RegexOptions.Singleline).Trim();
                    step3 = Regex.Replace(step3, "\\s([.,:;!?])", "$1", RegexOptions.Singleline).Trim();
                    writer.WriteLine("[Step3]\t" + step3);
                    writer.WriteLine("[Step4]\t(先輩の間違い: " + string.Join(commaDelimiter, unit.ContentsStep4.Senior.Answer.Select(a => seniorSelectionText[a])) + ")");
                    writer.Write("[Step5]");

                    foreach (var question in unit.ContentsStep5.Questions)
                    {
                        writer.WriteLine("\tQ" + question.Id + ". " + string.Join(slashDelimiter, question.Selections.Where(s => question.Text.Selections.Any(t => s.CD == t.CD && s.Id == t.Answer)).Select(s => s.Text)));
                    }

                    writer.WriteLine();
                }
            }
        }

        /// <summary>
        /// 基礎のレビュークイズをcsv(タブ区切り)で出力します。
        /// </summary>
        /// <param name="materialDirectory"> <see cref="TeachingMaterialDirectory"/>. </param>
        /// <param name="maxUnitId"> ユニット数。 </param>
        /// <param name="isSaveXml"> XMLを保存するかどうか。 </param>
        private static void SaveReview(TeachingMaterialDirectory materialDirectory, long maxUnitId, bool isSaveXml)
        {
            for (long number = 1; number <= maxUnitId; number++)
            {
                var numberString = number.ToString("00", CultureInfo.InvariantCulture);
                materialDirectory.RelativeUris.Add(
                    new Uri("tech2b/tech2br" + numberString + "/tech2br" + numberString + ".xml", UriKind.Relative));
            }

            if (isSaveXml)
            {
                materialDirectory.SaveXmls("basis_review").Wait();
            }

            var serializer = new XmlSerializer(typeof(Unit.Review));
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using (var writer = new StreamWriter("review.csv", false, Encoding.UTF8))
            {
                foreach (var xml in materialDirectory.ReadXmls())
                {
                    Unit.Review unit;

                    using (var reader = new StringReader(xml.Result))
                    {
                        unit = (Unit.Review)serializer.Deserialize(reader);
                    }

                    writer.WriteLine("[" + unit.Id + "]");

                    foreach (var question in unit.Questions)
                    {
                        writer.WriteLine(question.TranslatedText + "\t" + question.Text + "\t" + question.Reference);
                    }

                    writer.WriteLine();
                }
            }
        }

        /// <summary>
        /// 語彙のイラスト演習をcsv(タブ区切り)で出力します。
        /// </summary>
        /// <param name="materialDirectory"> <see cref="TeachingMaterialDirectory"/>. </param>
        /// <param name="maxUnitId"> ユニット数。 </param>
        /// <param name="isSaveXml"> XMLを保存するかどうか。 </param>
        /// <param name="isSaveImage"> 画像を保存するかどうか。 </param>
        private static void SaveIllustration(TeachingMaterialDirectory materialDirectory, long maxUnitId, bool isSaveXml, bool isSaveImage)
        {
            for (long number = 1; number <= maxUnitId; number++)
            {
                var numberString = number.ToString("00", CultureInfo.InvariantCulture);
                materialDirectory.RelativeUris.Add(
                    new Uri("tech2v/tech2vi" + numberString + "/tech2vi" + numberString + ".xml", UriKind.Relative));
            }

            if (isSaveXml)
            {
                materialDirectory.SaveXmls("vocabulary_illustration").Wait();
            }

            var serializer = new XmlSerializer(typeof(Unit.Illustration));
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var streamDirectory
                = exePath.Substring(0, exePath.LastIndexOf(Path.DirectorySeparatorChar)) + Path.DirectorySeparatorChar
                + "vocabulary_illustration" + Path.DirectorySeparatorChar;

            var lines = new StringBuilder[21].Select(l => new StringBuilder()).ToArray();
            var columns = 3;
            var counter = 0;

            using (var writer = new StreamWriter("illustration.csv", false, Encoding.UTF8))
            {
                foreach (var xml in materialDirectory.ReadXmls())
                {
                    Unit.Illustration unit;

                    using (var reader = new StringReader(xml.Result))
                    {
                        unit = (Unit.Illustration)serializer.Deserialize(reader);
                    }

                    if (isSaveImage)
                    {
                        using (var client = new HttpClient() { BaseAddress = new Uri(materialDirectory.BaseUri, "tech2v/tech2vi" + unit.IdString + "/") })
                        {
                            foreach (var word in unit.JPContents.Words)
                            {
                                using (var contentStream = client.GetAsync(word.ImageFileName).Result.Content.ReadAsStreamAsync().Result)
                                using (var fileStream = File.Create(streamDirectory + word.ImageFileName))
                                {
                                    contentStream.CopyTo(fileStream);
                                    fileStream.Flush();
                                }
                            }
                        }
                    }

                    counter++;

                    lines[0].Append("[");
                    lines[0].Append(unit.Id);
                    lines[0].Append("]\t\t\t");

                    for (var index = 0; index < unit.Questions.Count; index++)
                    {
                        var numOfSelection = 0;

                        foreach (var id in unit.Questions[index].Selections.Select(s => s.WordId))
                        {
                            numOfSelection++;
                            var word = unit.JPContents.Words.First(w => w.Id == id);
                            lines[(index * 2) + 1].Append(word.English);
                            lines[(index * 2) + 1].Append("\t");
                            lines[(index * 2) + 2].Append(word.ImageFileName);
                            lines[(index * 2) + 2].Append("\t");
                        }

                        lines[(index * 2) + 1].Append('\t', 3 - numOfSelection);
                        lines[(index * 2) + 2].Append('\t', 3 - numOfSelection);
                    }

                    if (counter == columns)
                    {
                        for (var index = 0; index < lines.Count(); index++)
                        {
                            writer.WriteLine(lines[index].ToString());
                            lines[index].Clear();
                        }

                        writer.WriteLine();
                        counter = 0;
                    }
                }
            }
        }

        /// <summary>
        /// テストークイズをcsv(タブ区切り)で出力します。
        /// </summary>
        /// <param name="materialDirectory"> <see cref="TeachingMaterialDirectory"/>. </param>
        /// <param name="maxUnitId"> ユニット数。 </param>
        /// <param name="isSaveXml"> XMLを保存するかどうか。 </param>
        private static void SaveTest(TeachingMaterialDirectory materialDirectory, long maxUnitId, bool isSaveXml)
        {
            for (long number = 1; number <= maxUnitId; number++)
            {
                var numberString = number.ToString("00", CultureInfo.InvariantCulture);
                materialDirectory.RelativeUris.Add(
                    new Uri("tech2t/tech2t" + numberString + "/tech2t" + numberString + ".xml", UriKind.Relative));
            }

            if (isSaveXml)
            {
                materialDirectory.SaveXmls("test").Wait();
            }

            var serializer = new XmlSerializer(typeof(Unit.Test));
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using (var writer = new StreamWriter("test.csv", false, Encoding.UTF8))
            {
                foreach (var xml in materialDirectory.ReadXmls())
                {
                    Unit.Test unit;

                    using (var reader = new StringReader(xml.Result))
                    {
                        unit = (Unit.Test)serializer.Deserialize(reader);
                    }

                    writer.WriteLine("[" + unit.Id + "]");

                    writer.Write("Ⅰ");

                    foreach (var question in unit.Section1.Questions)
                    {
                        writer.WriteLine("\t"
                            + (char)(question.Id + 0x60) + "\t"
                            + question.Answer + "\t"
                            + question.Selections.First(s => long.Parse(s.CD, CultureInfo.InvariantCulture) == question.Answer).Text);
                    }

                    writer.Write("Ⅱ");

                    foreach (var question in unit.Section2.Questions)
                    {
                        writer.WriteLine("\t"
                            + (char)(question.Id + 0x60) + "\t"
                            + question.Answer + "\t"
                            + question.Selections.First(s => long.Parse(s.CD, CultureInfo.InvariantCulture) == question.Answer).Text);
                    }

                    writer.Write("Ⅲ");

                    foreach (var question in unit.Section3.Questions)
                    {
                        writer.WriteLine("\t"
                            + (char)(question.Id + 0x60) + "\t"
                            + question.Answer + "\t"
                            + unit.Section3.Selections.First(s => long.Parse(s.CD, CultureInfo.InvariantCulture) == question.Answer).Text);
                    }

                    writer.Write("Ⅳ");

                    foreach (var question in unit.Section4.Questions)
                    {
                        writer.WriteLine("\t"
                            + (char)(question.Id + 0x60) + "\t"
                            + question.Answer + "\t"
                            + unit.Section4.Selections.First(s => long.Parse(s.CD, CultureInfo.InvariantCulture) == question.Answer).Text);
                    }

                    writer.Write("Ⅴ");

                    foreach (var question in unit.Section5.Questions)
                    {
                        writer.WriteLine("\t"
                            + (char)(question.Id + 0x60) + "\t"
                            + question.Answer + "\t"
                            + question.Selections.First(s => long.Parse(s.CD, CultureInfo.InvariantCulture) == question.Answer).Text);
                    }

                    writer.Write("Ⅵ");

                    foreach (var question in unit.Section6.Questions)
                    {
                        writer.WriteLine("\t"
                            + (char)(question.Id + 0x60) + "\t"
                            + question.Answer + "\t"
                            + unit.Section6.Selections.First(s => long.Parse(s.CD, CultureInfo.InvariantCulture) == question.Answer).Text);
                    }

                    writer.Write("Ⅶ");

                    foreach (var question in unit.Section7.Questions)
                    {
                        writer.WriteLine("\t"
                            + (char)(question.Id + 0x60) + "\t"
                            + question.Answer + "\t"
                            + question.Selections.First(s => long.Parse(s.CD, CultureInfo.InvariantCulture) == question.Answer).Text);
                    }

                    writer.WriteLine();
                }
            }
        }

        /////// <summary>
        /////// <see cref="Unit.Vocabulary"/> の答えの概要を表します。
        /////// </summary>
        ////private class Answer
        ////{
        ////    /// <summary>
        ////    /// IDを取得または設定します。
        ////    /// </summary>
        ////    public long Id { get; set; }

        ////    /// <summary>
        ////    /// 日本語の意味を取得または設定します。
        ////    /// </summary>
        ////    public IEnumerable<string> Japanese { get; set; }

        ////    /// <summary>
        ////    /// 英単語を取得または設定します。
        ////    /// </summary>
        ////    public IEnumerable<string> English { get; set; }
        ////}
    }
}
