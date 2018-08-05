using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
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
            var result = "";

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
            var listOfFiles = new List<string>();
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
            var di = new DirectoryInfo(currentFolder);
            foreach (var currentFile in di.GetFiles(searchFilePattern))
            {
                listOfFiles.Add(currentFile.FullName);
            }
            foreach(var currentDirectory in di.GetDirectories())
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
            var streamJson = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(streamJson, classObj);
            streamJson.Position = 0;
            var srJson = new StreamReader(streamJson);
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
            var wc = new WebClient
            {
                Proxy = new WebProxy(),
                UseDefaultCredentials = true
            };
            var data = wc.DownloadString(jsonUri);
            var json = new DataContractJsonSerializer(typeof(T));
            return (T)json.ReadObject(new MemoryStream(encodingJson.GetBytes(data)));
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
            var json = Serialize<T>(classObj);

            if (!Directory.Exists(Path.GetDirectoryName(fullPathJsonFile)))
                Directory.CreateDirectory(Path.GetDirectoryName(fullPathJsonFile));

            using (var fsJson = new FileStream(fullPathJsonFile, FileMode.Create))
            {
                try
                {
                    var dataJson = encodingJson.GetBytes(json);
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
            public static string GetShortPathName(string longPath)
            {
                var shortPath = new StringBuilder(longPath.Length + 1);

                if (0 == GetShortPathName(longPath, shortPath, shortPath.Capacity))
                {
                    return longPath;
                }

                return shortPath.ToString();
            }

            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern int GetShortPathName(string path, StringBuilder shortPath, int shortPathLength);

            public static string GetLongPathName(string shortPath)
            {
                var longPath = new StringBuilder(1024);

                return 0 == GetLongPathName(shortPath, longPath, longPath.Capacity) ? shortPath : longPath.ToString();
            }

            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern int GetLongPathName(string shortPath, StringBuilder longPath, int longPathLength);
        }
        #endregion

        public static string GetFileChecksum(string filePath, HashAlgorithm algorithm)
        {
            var result = string.Empty;
            using (var fs = File.OpenRead(filePath))
            {
                result = BitConverter.ToString(algorithm.ComputeHash(fs)).ToLower().Replace("-", "");
            }

            return result;
        }
    }
}
