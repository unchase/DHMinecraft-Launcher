using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DHMinecraft_Launcher
{
    [DataContract]
    public class DownloadedFiles
    {
        /// <summary>
        /// Массив со скачиваемыми файлами.
        /// </summary>
        [DataMember(Name = "downloadedfiles")]
        public List<DownloadedFile> downloadedFiles { get; set; }

        [DataContract]
        public class DownloadedFile
        {
            /// <summary>
            /// Имя скачиваемого файла.
            /// </summary>
            [DataMember(Name = "name")]
            public string name { get; set; }

            /// <summary>
            /// Uri для скачивания файла.
            /// </summary>
            [DataMember(Name = "uri")]
            public string uri { get; set; }

            /// <summary>
            /// Скачивать файл, если он уже существует?
            /// </summary>
            [DataMember(Name = "downloadifexist")]
            public bool downloadIfExist { get; set; }

            /// <summary>
            /// Относительный путь к скачиваемому файлу у получателя.
            /// </summary>
            [DataMember(Name = "localrelativepath")]
            public string localRelativePath { get; set; }

            /// <summary>
            /// Относительный путь к скачиваемому файлу у источника.
            /// </summary>
            [DataMember(Name = "sourcerelativepath")]
            public string sourceRelativePath { get; set; }

            /// <summary>
            /// MD5-хэш скачиваемого файла.
            /// </summary>
            [DataMember(Name = "md5checksum")]
            public string md5CheckSum { get; set; }

            /// <summary>
            /// Конструктор класса DownloadedFile.
            /// </summary>
            /// <param name="name">Имя скачиваемого файла.</param>
            /// <param name="uri">Uri для скачивания файла.</param>
            /// <param name="downloadIfExist">Скачивать файл, если он уже существует?</param>
            /// <param name="localRelativePath">Относительный путь к скачиваемому файлу у получателя.</param>
            /// <param name="sourceRelativePath">Относительный путь к скачиваемому файлу у источника.</param>
            /// <param name="md5CheckSum">MD5-хэш скачиваемого файла.</param>
            public DownloadedFile(string name, string uri, bool downloadIfExist, string localRelativePath, string sourceRelativePath, string md5CheckSum)
            {
                this.name = name;
                this.uri = uri;
                this.downloadIfExist = downloadIfExist;
                this.localRelativePath = localRelativePath;
                this.sourceRelativePath = sourceRelativePath;
                this.md5CheckSum = md5CheckSum;
            }
        }

        /// <summary>
        /// Конструктор класса DownloadedFiles.
        /// </summary>
        /// <param name="downloadedFiles">Массив со скачиваемыми файлами.</param>
        public DownloadedFiles(List<DownloadedFile> downloadedFiles)
        {
            this.downloadedFiles = downloadedFiles;
        }

        /// <summary>
        /// Метод для добавления скачиваемого файла в коллекцию List<DownloadedFile>.
        /// </summary>
        /// <param name="newDownloadedFile">Добавляемый скачиваемый файл.</param>
        public void AddDownloadedFile(DownloadedFile newDownloadedFile)
        {
            this.downloadedFiles.Add(newDownloadedFile);
        }

        /// <summary>
        /// Метод для добавления скачиваемого файла в коллекцию List<DownloadedFile>.
        /// </summary>
        /// <param name="name">Имя скачиваемого файла.</param>
        /// <param name="uri">Uri для скачивания файла.</param>
        /// <param name="downloadIfExist">Скачивать файл, если он уже существует?</param>
        /// <param name="localRelativePath">Относительный путь к скачиваемому файлу у получателя.</param>
        /// <param name="sourceRelativePath">Относительный путь к скачиваемому файлу у источника.</param>
        /// <param name="md5CheckSum">MD5-хэш скачиваемого файла.</param>
        public void AddDownloadedFile(string name, string uri, bool downloadIfExist, string localRelativePath, string sourceRelativePath, string md5CheckSum)
        {
            DownloadedFile newDownloadedFile = new DownloadedFile(name, uri, downloadIfExist, localRelativePath, sourceRelativePath, md5CheckSum);
            this.downloadedFiles.Add(newDownloadedFile);
        }
    }
}
