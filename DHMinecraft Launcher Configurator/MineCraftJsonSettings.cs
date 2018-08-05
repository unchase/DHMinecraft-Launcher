using System.Runtime.Serialization;

namespace DHMinecraft_Launcher_Configurator
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

                #region Конструкторы Native
                /// <summary>
                /// Конструктор Native.
                /// </summary>
                public Native()
                {
                    windows = MineCraftConfiguratorSettings._defaultJsonLibraryNativeWindows;
                    osx = MineCraftConfiguratorSettings._defaultJsonLibraryNativeOsx;
                    linux = MineCraftConfiguratorSettings._defaultJsonLibraryNativeLinux;
                }

                /// <summary>
                /// Конструктор Native.
                /// </summary>
                /// <param name="windows">Зависимости для windows.</param>
                public Native(string windows)
                {
                    this.windows = windows;
                    osx = MineCraftConfiguratorSettings._defaultJsonLibraryNativeOsx;
                    linux = MineCraftConfiguratorSettings._defaultJsonLibraryNativeLinux;
                }

                /// <summary>
                /// Конструктор Native.
                /// </summary>
                /// <param name="windows">Зависимости для windows.</param>
                /// <param name="osx">Зависимости для osx.</param>
                /// <param name="linux">Зависимости для linux.</param>
                public Native(string windows, string osx, string linux)
                {
                    this.windows = windows;
                    this.osx = osx;
                    this.linux = linux;
                }
                #endregion
            }

            #region Конструкторы Library
            /// <summary>
            /// Конструктор класса Library.
            /// </summary>
            /// <param name="name">Имя класса.</param>
            /// <param name="comment">Комментарии.</param>
            /// <param name="checksums">Чек-суммы.</param>
            public Library(string name, string comment, string[] checksums)
            {
                this.name = name;
                url = MineCraftConfiguratorSettings._defaultJsonLibraryUrl;
                serverreq = MineCraftConfiguratorSettings._defaultJsonLibraryClientreq;
                clientreq = MineCraftConfiguratorSettings._defaultJsonLibraryServerreq;
                this.comment = comment;
                this.checksums = checksums;
                rules = new Rule[1];
                natives = new Native[1];
            }

            /// <summary>
            /// Конструктор класса Library.
            /// </summary>
            /// <param name="name">Имя класса.</param>
            /// <param name="url">Url для обновления.</param>
            /// <param name="comment">Комментарии.</param>
            /// <param name="checksums">Чек-суммы.</param>
            public Library(string name, string url, string comment, string[] checksums)
            {
                this.name = name;
                this.url = url;
                serverreq = MineCraftConfiguratorSettings._defaultJsonLibraryClientreq;
                clientreq = MineCraftConfiguratorSettings._defaultJsonLibraryServerreq;
                this.comment = comment;
                this.checksums = checksums;
                rules = new Rule[1];
                natives = new Native[1];
            }

            /// <summary>
            /// Конструктор класса Library.
            /// </summary>
            /// <param name="name">Имя класса.</param>
            /// <param name="url">Url для обновления.</param>
            /// <param name="serverreq">Необходим ли серверному приложению minecraft.</param>
            /// <param name="clientreq">Необходим ли клиентскому приложению minecraft.</param>
            /// <param name="comment">Комментарии.</param>
            /// <param name="checksums">Чек-суммы.</param>
            /// <param name="rules">Правила.</param>
            /// <param name="natives">Зависимости.</param>
            public Library(string name, string url, bool serverreq, bool clientreq, string comment, string[] checksums, Rule[] rules, Native[] natives)
            {
                this.name = name;
                this.url = url;
                this.serverreq = serverreq;
                this.clientreq = clientreq;
                this.comment = comment;
                this.checksums = checksums;
                this.rules = rules;
                this.natives = natives;
            }
            #endregion


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

        #region Конструкторы
        /// <summary>
        /// Конструктор класса MineCraftJsonSettings.
        /// </summary>
        /// <param name="library"><seealso cref="MineCraftJsonSettings.Library"/> библиотека minecraft.</param>
        /// <param name="time">Время последнего изменения конфигурационного файла.</param>
        /// <param name="id">Название сервера (уникалоное).</param>
        /// <param name="releaseTime">Время создания конфигурационного файла.</param>
        public MineCraftJsonSettings(Library library, string time, string id, string releaseTime)
        {
            minecraftArguments = MineCraftConfiguratorSettings._defaultJsonMinecraftArguments;
            libraries = new Library[1];
            libraries[0] = library;
            mainClass = MineCraftConfiguratorSettings._defautJsonMainClass;
            minimumLauncherVersion = MineCraftConfiguratorSettings._defaultJsonMinimumLauncherVersion;
            this.time = time;
            this.id = id;
            type = MineCraftConfiguratorSettings._defaultJsonType;
            processArguments = MineCraftConfiguratorSettings._defaultJsonProcessArguments;
            this.releaseTime = releaseTime;
        }

        /// <summary>
        /// Конструктор класса MineCraftJsonSettings.
        /// </summary>
        /// <param name="libraries"></param>
        /// <param name="time">Время последнего изменения конфигурационного файла.</param>
        /// <param name="id">Название сервера (уникалоное).</param>
        /// <param name="releaseTime">Время создания конфигурационного файла.</param>
        public MineCraftJsonSettings(Library[] libraries, string time, string id, string releaseTime)
        {
            minecraftArguments = MineCraftConfiguratorSettings._defaultJsonMinecraftArguments;
            this.libraries = libraries;
            mainClass = MineCraftConfiguratorSettings._defautJsonMainClass;
            minimumLauncherVersion = MineCraftConfiguratorSettings._defaultJsonMinimumLauncherVersion;
            this.time = time;
            this.id = id;
            type = MineCraftConfiguratorSettings._defaultJsonType;
            processArguments = MineCraftConfiguratorSettings._defaultJsonProcessArguments;
            this.releaseTime = releaseTime;
        }

        /// <summary>
        /// Конструктор класса MineCraftJsonSettings.
        /// </summary>
        /// <param name="minecraftArguments">Аргументы командной строки запуска minecraft.</param>
        /// <param name="library"><seealso cref="MineCraftJsonSettings.Library"/> библиотека minecraft.</param>
        /// <param name="mainClass">Имя основного класса minecraft.</param>
        /// <param name="minimumLauncherVersion">Минимальная версия лаунчера.</param>
        /// <param name="time">Время последнего изменения конфигурационного файла.</param>
        /// <param name="id">Название сервера (уникалоное).</param>
        /// <param name="type">Тип конфигурационного файла, например, "release".</param>
        /// <param name="processArguments">Аргументы для подстановки в командную строку запуска, разделенные знаком "_".</param>
        /// <param name="releaseTime">Время создания конфигурационного файла.</param>
        public MineCraftJsonSettings(string minecraftArguments, Library library, string mainClass, string minimumLauncherVersion, string time, string id, string type, string processArguments, string releaseTime)
        {
            this.minecraftArguments = minecraftArguments;
            libraries = new Library[1];
            libraries[0] = library;
            this.mainClass = mainClass;
            this.minimumLauncherVersion = minimumLauncherVersion;
            this.time = time;
            this.id = id;
            this.type = type;
            this.processArguments = processArguments;
            this.releaseTime = releaseTime;
        }

        /// <summary>
        /// Конструктор класса MineCraftJsonSettings.
        /// </summary>
        /// <param name="minecraftArguments">Аргументы командной строки запуска minecraft.</param>
        /// <param name="libraries">Массив <seealso cref="MineCraftJsonSettings.Library"/> библиотек minecraft.</param>
        /// <param name="mainClass">Имя основного класса minecraft.</param>
        /// <param name="minimumLauncherVersion">Минимальная версия лаунчера.</param>
        /// <param name="time">Время последнего изменения конфигурационного файла.</param>
        /// <param name="id">Название сервера (уникалоное).</param>
        /// <param name="type">Тип конфигурационного файла, например, "release".</param>
        /// <param name="processArguments">Аргументы для подстановки в командную строку запуска, разделенные знаком "_".</param>
        /// <param name="releaseTime">Время создания конфигурационного файла.</param>
        public MineCraftJsonSettings(string minecraftArguments, Library[] libraries, string mainClass, string minimumLauncherVersion, string time, string id, string type, string processArguments, string releaseTime)
        {
            this.minecraftArguments = minecraftArguments;
            this.libraries = libraries;
            this.mainClass = mainClass;
            this.minimumLauncherVersion = minimumLauncherVersion;
            this.time = time;
            this.id = id;
            this.type = type;
            this.processArguments = processArguments;
            this.releaseTime = releaseTime;
        }
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
            var results = new string[libraries.Length];
            for (var i = 0; i < libraries.Length; i++)
            {
                var tempName = libraries[i].name;
                var tempNameSplit = tempName.Split(':');
                tempNameSplit[0] = tempNameSplit[0].Replace('.', '\\');
                var filename = tempNameSplit[1] + "-" + tempNameSplit[2] + ".jar";
                foreach (var part in tempNameSplit)
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
            var result = minecraftArguments;
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
