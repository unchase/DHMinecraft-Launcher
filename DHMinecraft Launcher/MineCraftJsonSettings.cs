using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DHMinecraft_Launcher
{
    /// <summary>
    /// Класс, хранящий данные о профиле minecraft.
    /// </summary>
    [DataContract]
    public class MineCraftJsonSettings
    {
        #region Данные
        /// <summary>
        /// Аргументы коммандной строки.
        /// </summary>
        [DataMember(Name = "minecraftArguments")]
        public string minecraftArguments { get; set; }

        /// <summary>
        /// Библиотеки.
        /// </summary>
        [DataMember(Name = "libraries")]
        public Library[] libraries { get; set; }

        /// <summary>
        /// Класс, описывающий библиотеку.
        /// </summary>
        [DataContract]
        public class Library
        {
            /// <summary>
            /// Имя.
            /// </summary>
            [DataMember(Name = "name")]
            public string name { get; set; }

            /// <summary>
            /// Url.
            /// </summary>
            [DataMember(Name = "url")]
            public string url { get; set; }

            /// <summary>
            /// Необходим ли серверу.
            /// </summary>
            [DataMember(Name = "serverreq")]
            public bool serverreq { get; set; }

            /// <summary>
            /// Необходим ли клиенту.
            /// </summary>
            [DataMember(Name = "clientreq")]
            public bool clientreq { get; set; }

            /// <summary>
            /// Комментарии.
            /// </summary>
            [DataMember(Name = "comment")]
            public string comment { get; set; }

            /// <summary>
            /// Чек-сумма.
            /// </summary>
            [DataMember(Name = "checksums")]
            public string[] checksums { get; set; }

            /// <summary>
            /// Правила.
            /// </summary>
            [DataMember(Name = "rules")]
            public Rule[] rules { get; set; }

            /// <summary>
            /// Класс, описывающий правила.
            /// </summary>
            [DataContract]
            public class Rule
            {
                /// <summary>
                /// Действие.
                /// </summary>
                [DataMember(Name = "action")]
                public string action { get; set; }

                /// <summary>
                /// OS.
                /// </summary>
                [DataMember(Name = "os")]
                public OS os { get; set; }

                /// <summary>
                /// Класс, описывающий OS.
                /// </summary>
                [DataContract]
                public class OS
                {
                    /// <summary>
                    /// Версия.
                    /// </summary>
                    [DataMember(Name = "version")]
                    public string action { get; set; }

                    /// <summary>
                    /// Имя.
                    /// </summary>
                    [DataMember(Name = "name")]
                    public string name { get; set; }
                }
            }

            /// <summary>
            /// Natives.
            /// </summary>
            [DataMember(Name = "natives")]
            public Native[] natives { get; set; }

            /// <summary>
            /// Класс, описывающий native.
            /// </summary>
            [DataContract]
            public class Native
            {
                /// <summary>
                /// Windows-native.
                /// </summary>
                [DataMember(Name = "windows")]
                public string windows { get; set; }

                /// <summary>
                /// OSX-native.
                /// </summary>
                [DataMember(Name = "osx")]
                public string osx { get; set; }

                /// <summary>
                /// Linux-native.
                /// </summary>
                [DataMember(Name = "linux")]
                public string linux { get; set; }
            }

            //ToDo: дописать для checksums, extract (exclude)
            //[DataMember(Name = "extract")]
            //public string[] extract { get; set; }
        }

        /// <summary>
        /// Главный main класс minecraft.
        /// </summary>
        [DataMember(Name = "mainClass")]
        public string mainClass { get; set; }

        /// <summary>
        /// Минимальная версия лаунчера.
        /// </summary>
        [DataMember(Name = "minimumLauncherVersion")]
        public string minimumLauncherVersion { get; set; }

        /// <summary>
        /// Время.
        /// </summary>
        [DataMember(Name = "time")]
        public string time { get; set; }

        /// <summary>
        /// id.
        /// </summary>
        [DataMember(Name = "id")]
        public string id { get; set; }

        /// <summary>
        /// Тип.
        /// </summary>
        [DataMember(Name = "type")]
        public string type { get; set; }

        /// <summary>
        /// Аргументы запуска процесса.
        /// </summary>
        [DataMember(Name = "processArguments")]
        public string processArguments { get; set; }

        /// <summary>
        /// Дата релиза.
        /// </summary>
        [DataMember(Name = "releaseTime")]
        public string releaseTime { get; set; }
        #endregion

        #region Методы
        /// <summary>
        /// Метод парсит библиотеки minecraft в список с полными путями к ним.
        /// </summary>
        /// <param name="appData">Полный путь к appData.</param>
        /// <param name="minecraftRootFolder">Корневая папка minecraft.</param>
        /// <param name="currentServerName">Текущее имя сервера.</param>
        /// <param name="librariesFolder">Папка с библиотеками.</param>
        /// <returns>Возвращает список полных путей к библиотекам minecraft.</returns>
        public string[] ParseLibraries(string appData, string minecraftRootFolder, string currentServerName, string librariesFolder)
        {
            string[] results = new string[this.libraries.Length];
            for (var i = 0; i < this.libraries.Length; i++)
            {
                string tempName = this.libraries[i].name;
                string[] tempNameSplit = tempName.Split(':');
                tempNameSplit[0] = tempNameSplit[0].Replace('.', '\\');
                string filename = tempNameSplit[1] + "-" + tempNameSplit[2] + ".jar";
                foreach (string part in tempNameSplit)
                {
                    results[i] += "\\" + part;
                }
                results[i] += "\\" + filename;
                results[i] = appData + "\\" + minecraftRootFolder + "\\" + librariesFolder + results[i];
            }
            
            return results;
        }

        /// <summary>
        /// Метод парсит строку аогументов.
        /// </summary>
        /// <param name="appData">Полный путь к appData.</param>
        /// <param name="userLogin">Логин пользователя.</param>
        /// <param name="sessionID">Id сессии.</param>
        /// <param name="launcherVersion">Версия лаунчера minecraft.</param>
        /// <param name="minecraftRootFolder">Корневая папка minecraft.</param>
        /// <param name="currentServerName">Текущее имя сервера.</param>
        /// <param name="assetsFolder">Папка с assets.</param>
        /// <returns>Возвращает измененную строку с аргументами</returns>
        public string ParseArguments(string appData, string userLogin, string sessionID, string launcherVersion, string minecraftRootFolder, string currentServerName, string assetsFolder)
        {
            string result = this.minecraftArguments;
            result = result.Replace("${auth_player_name}", "\"" + userLogin + "\"");
            result = result.Replace("${auth_session}", "\"" + sessionID + "\"");
            result = result.Replace("${version_name}", "\"" + launcherVersion + "\"");
            result = result.Replace("${game_directory}", "\"" + appData + "\\" + minecraftRootFolder + "\\" + currentServerName + "\"");
            result = result.Replace("${game_assets}", "\"" + appData + "\\" + minecraftRootFolder + "\\" + currentServerName + "\\" + assetsFolder + "\"");

            return result;
        }
        #endregion
    }
}
