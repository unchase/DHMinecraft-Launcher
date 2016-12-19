using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;

namespace DHMinecraft_Launcher_Configurator
{
    public static class Utils
    {
        //ToDo: реализовать генерацию url для скачивания библиотек для данной сборки
        /// <summary>
        /// Метод генерирует url для сервера, по которому можно будет скачать готовую сборку.
        /// </summary>
        /// <param name="serverUri">Url для скачивания сборки.</param>
        /// <param name="buildFullPath">Полный путь к каталогу со сборкой.</param>
        /// <returns></returns>
        public static string GenerateUrlToDownloadLibrariesForBuild(string serverUri, string buildFullPath)
        {
            string result = "";

            return result;
        }

        #region Work with files and folders
        /// <summary>
        /// Метод для нахождения всех файлов с заданным паттерном из заданного каталога и его подкаталогов, исключая те каталоги, которые следует игнорировать.
        /// </summary>
        /// <param name="currentFolder">Каталог в котором будет производится поиск файлов.</param>
        /// <param name="searchFilePattern">Паттерн для поиска файлов, например "*.txt".</param>
        /// <param name="ignoreFolders">Список каталогов (подкаталогов), которые следует игнорировать при поиске файлов.</param>
        /// <returns>Возвращает список с полными путями к найденным файлам.</returns>
        public static List<string> GetAllFiles(string currentFolder, string searchFilePattern, string[] ignoreFolders)
        {
            List<string> listOfFiles = new List<string>();
            GetAllFilesInCurrentFolder(currentFolder, searchFilePattern, ignoreFolders, listOfFiles);
            return listOfFiles;
        }

        /// <summary>
        /// Рекурсивный метод для нахождения всех файлов с заданным паттерном из заданного каталога и его подкаталогов, исключая те коталоги, которые следует игнорировать.
        /// </summary>
        /// <param name="currentFolder">Каталог в котором будет производится поиск файлов.</param>
        /// <param name="searchFilePattern">Паттерн для поиска файлов, например "*.txt".</param>
        /// <param name="ignoreFolders">Список каталогов (подкаталогов), которые следует игнорировать при поиске файлов.</param>
        /// <param name="listOfFiles"></param>
        private static void GetAllFilesInCurrentFolder(string currentFolder, string searchFilePattern, string[] ignoreFolders, List<string> listOfFiles)
        {
            if (ignoreFolders.FirstOrDefault(x => x == new DirectoryInfo(currentFolder).Name) != null)
                return;
            DirectoryInfo di = new DirectoryInfo(currentFolder);
            FileInfo[] currentFiles = di.GetFiles(searchFilePattern);
            foreach (FileInfo currentFile in currentFiles)
            {
                listOfFiles.Add(currentFile.FullName);
            }
            DirectoryInfo[] currentDirectories = di.GetDirectories();
            foreach(DirectoryInfo currentDirectory in currentDirectories)
            {
                GetAllFilesInCurrentFolder(currentDirectory.FullName, searchFilePattern, ignoreFolders, listOfFiles);
            }
        }
        #endregion

        #region JSON Utils
        /// <summary>
        /// Сериализует класс в строку в формате json.
        /// </summary>
        /// <returns>Возвращает сериализованную json-строку.</returns>
        /// <param name="classObj">Объект класса, который необходимо сериализовать в json-строку.</param>
        public static string Serialize<T>(T classObj)
        {
            MemoryStream streamJson = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(streamJson, classObj);
            streamJson.Position = 0;
            StreamReader srJson = new StreamReader(streamJson);
            return srJson.ReadToEnd();
        }

        /// <summary>
        /// Десериализует строку в формате json в объект заданного класса, используя выбранную кодировку <seealso cref="System.Text.Encoding"/>.
        /// </summary>
        /// <returns>Возвращает десериализованный из строки в формате json объект класса.</returns>
        /// <param name="jsonUri">Uri, указывающий на расположение json-файла.</param>
        /// <param name="encodingJson">Кодировка <seealso cref="System.Text.Encoding"/>, которая будет использована при десериализации.</param>
        public static T Deserialize<T>(string jsonUri, Encoding encodingJson)
        {
            WebClient wc = new WebClient();
            wc.Proxy = new WebProxy();
            wc.UseDefaultCredentials = true;
            var data = wc.DownloadString(jsonUri);
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(T));
            T person = (T)json.ReadObject(new System.IO.MemoryStream(encodingJson.GetBytes(data)));
            return person;
        }

        /// <summary>
        /// Метод сохрняет выбранный объект класса в json-файл по выбранному пути с использованием выбранной кодировки <seealso cref="System.Text.Encoding"/>.
        /// </summary>
        /// <returns>Возвращает результат сохранения объекта выбранного класса в json-файл.</returns>
        /// <param name="classObj">Объект класса, который необходимо сохранить в json-файл.</param>
        /// <param name="fullPathJsonFile">Полный путь к json-файлу, куда будет сохранен результат.</param>
        /// <param name="encodingJson">Кодировка <seealso cref="System.Text.Encoding"/>, которая будет использована при сериализации.</param>
        public static bool SaveClassObjectToJsonFile<T>(T classObj, string fullPathJsonFile, Encoding encodingJson)
        {
            string json = Serialize<T>(classObj);

            if (!Directory.Exists(Path.GetDirectoryName(fullPathJsonFile)))
                Directory.CreateDirectory(Path.GetDirectoryName(fullPathJsonFile));

            using (FileStream fsJson = new FileStream(fullPathJsonFile, FileMode.Create))
            {
                try
                {
                    byte[] dataJson = encodingJson.GetBytes(json);
                    fsJson.Write(dataJson, 0, dataJson.Length);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return true;
        }
        #endregion

        #region Path extensions
        public static class PathExtensions
        {
            public static String GetShortPathName(String longPath)
            {
                StringBuilder shortPath = new StringBuilder(longPath.Length + 1);

                if (0 == PathExtensions.GetShortPathName(longPath, shortPath, shortPath.Capacity))
                {
                    return longPath;
                }

                return shortPath.ToString();
            }

            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern Int32 GetShortPathName(String path, StringBuilder shortPath, Int32 shortPathLength);

            public static String GetLongPathName(String shortPath)
            {
                StringBuilder longPath = new StringBuilder(1024);

                if (0 == PathExtensions.GetLongPathName(shortPath, longPath, longPath.Capacity))
                {
                    return shortPath;
                }

                return longPath.ToString();
            }

            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern Int32 GetLongPathName(String shortPath, StringBuilder longPath, Int32 longPathLength);
        }
        #endregion

        public static string GetFileChecksum(string filePath, HashAlgorithm algorithm)
        {
            string result = string.Empty;
            using (FileStream fs = File.OpenRead(filePath))
            {
                result = BitConverter.ToString(algorithm.ComputeHash(fs)).ToLower().Replace("-", "");
            }

            return result;
        }
    }
}
