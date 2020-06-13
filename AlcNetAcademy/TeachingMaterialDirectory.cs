namespace Kntaco.AlcNetAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// ALC NetAcademy2 の教材データについて、そのディレクトリの場所の格納と情報の読み込みを行います。
    /// </summary>
    public class TeachingMaterialDirectory
    {
        /// <summary>
        /// <see cref="TeachingMaterialDirectory"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        public TeachingMaterialDirectory()
        {
        }

        /// <summary>
        /// 教材データを読み込むベースとなるディレクトリの場所を指定して、
        /// <see cref="TeachingMaterialDirectory"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="baseUri"> 教材データを読み込むベースとなるディレクトリの場所。 </param>
        public TeachingMaterialDirectory(Uri baseUri)
        {
            this.BaseUri = baseUri;
        }
        
        /// <summary>
        /// 教材データを読み込むベースとなるディレクトリの場所を取得または設定します。
        /// </summary>
        [XmlAttribute]
        public Uri BaseUri { get; set; }

        /// <summary>
        /// <see cref="BaseAddress"/> から見た個々の教材データの相対的なファイルの場所を取得または設定します。
        /// </summary>
        [XmlAttribute("relative")]
        [SuppressMessage("Microsoft.Design", "CA1002", Justification = "再利用可能なライブラリにすることを意図していません。")]
        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "XMLシリアル化のために set アクセッサーを公開する必要があります。")]
        public List<Uri> RelativeUris { get; set; } = new List<Uri>();

        /// <summary>
        /// 教材のXMLデータを読み込んで、文字列の一覧を返します。
        /// </summary>
        /// <returns> XMLデータの文字列の一覧。 </returns>
        public IEnumerable<Task<string>> ReadXmls()
        {
            using (var client = new HttpClient() { BaseAddress = this.BaseUri })
            {
                foreach (var relativeUri in this.RelativeUris)
                {
                    yield return ReadXmlStringAsync(client, relativeUri);
                }
            }
        }

        /// <summary>
        /// 教材のXMLデータを読み込んで、指定したパスのディレクトリに同名のファイルとして非同期で保存します。
        /// </summary>
        /// <param name="path"> XMLデータを保存するディレクトリの相対パス。 </param>
        /// <returns> 非同期の保存操作を表すタスク。 </returns>
        public async Task SaveXmls(string path)
        {
            using (var client = new HttpClient() { BaseAddress = this.BaseUri })
            {
                var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                var streamDirectory
                    = exePath.Substring(0, exePath.LastIndexOf(Path.DirectorySeparatorChar)) + Path.DirectorySeparatorChar
                    + path + Path.DirectorySeparatorChar;

                foreach (var relativeUri in this.RelativeUris)
                {
                    using (var stream = new StreamWriter(streamDirectory + new Uri(this.BaseUri, relativeUri).Segments.Last(), false, Encoding.UTF8))
                    {
                        await stream.WriteAsync(await ReadXmlStringAsync(client, relativeUri));
                    }
                }
            }
        }

        /// <summary>
        /// ベースとなるURIが指定された <see cref="HttpClient"/> と相対URIを用いて、
        /// 教材のXMLデータを文字列として非同期で読み込みます。
        /// 読み込みに失敗した場合は <see cref="null"/> が返ります。
        /// </summary>
        /// <param name="client"> <see cref="HttpClient"/> . </param>
        /// <param name="relativeUri"> 相対URI。 </param>
        /// <returns> 非同期の読み取り操作を表すタスク。TResult パラメーターの値には、XMLデータを表す文字列が含まれます。 </returns>
        protected static async Task<string> ReadXmlStringAsync(HttpClient client, Uri relativeUri)
        {
            HttpResponseMessage response;

            try
            {
                response = await client.GetAsync(relativeUri);
                response.EnsureSuccessStatusCode();
            }
            catch
            {
                response = null;
            }

            return await response?.Content.ReadAsStringAsync();
        }
    }
}
