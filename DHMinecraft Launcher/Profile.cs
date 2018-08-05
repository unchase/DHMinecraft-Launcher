using System.Runtime.Serialization;

namespace DHMinecraft_Launcher
{
    /// <summary>
    /// Класс, хранящий данные о профиле лаунчера.
    /// </summary>
    [DataContract]
    public class Profile
    {
        private static string defaultJavaExecutable = MineCraftSettings._defaultJavaExecutable;
        private static int defaultWidthResolution = MineCraftSettings._defaultWidthResolution;
        private static int defaultHeightResolution = MineCraftSettings._defaultHeightResolution;

        #region Данные
        /// <summary>
        /// Имя профиля.
        /// </summary>
        [DataMember(Name = "name")]
        public string name { get; set; }

        /// <summary>
        /// Полный путь к корневой директории игры.
        /// </summary>
        [DataMember(Name = "gameDirectory")]
        public string gameDirectory { get; set; }

        /// <summary>
        /// Кол-во используемой java оперативной памяти в Mb.
        /// </summary>
        [DataMember(Name = "memory")]
        public int memory { get; set; }

        /// <summary>
        /// Разрешение экрана.
        /// </summary>
        [DataMember(Name = "resolution")]
        public Resolution resolution { get; set; }

        /// <summary>
        /// Класс, хранящий данные о разрешении экрана.
        /// </summary>
        [DataContract]
        public class Resolution
        {
            /// <summary>
            /// Конструктор класса Resolution.
            /// </summary>
            public Resolution() : this(0, 0) { }
            /// <summary>
            /// Конструктор класса Resolution.
            /// </summary>
            /// <param name="widthResolutionRes">Разрешение экрана в пикселях по ширине.</param>
            /// <param name="heightResolutionRes">Разрешение экрана в пикселях по высоте.</param>
            public Resolution(int widthResolutionRes, int heightResolutionRes)
            {
                widthResolution = widthResolutionRes;
                heightResolution = heightResolutionRes;
            }

            /// <summary>
            /// Разрешение экрана в пикселях по ширине.
            /// </summary>
            [DataMember(Name = "widthResolution")]
            public int widthResolution { get; set; }

            /// <summary>
            /// Разрешение экрана в пикселях по высоте.
            /// </summary>
            [DataMember(Name = "heightResolution")]
            public int heightResolution { get; set; }
        }

        /// <summary>
        /// Полный путь к исполняемому файлу java.
        /// </summary>
        [DataMember(Name = "javaExecutable")]
        public string javaExecutable { get; set; }

        /// <summary>
        /// Дополнительные аргументы java.
        /// </summary>
        [DataMember(Name = "jvmArguments")]
        public string jvmArguments { get; set; }

        /// <summary>
        /// Имя сервера minecraft.
        /// </summary>
        [DataMember(Name = "serverName")]
        public string serverName { get; set; }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор класса Profile.
        /// </summary>
        /// <param name="name">Имя профиля.</param>
        /// <param name="gameDirectory">Полный путь к корневой директории игры.</param>
        /// <param name="memory">Кол-во используемой java оперативной памяти в Mb.</param>
        /// <param name="serverName">Имя сервера minecraft.</param>
        public Profile(string name, string gameDirectory, int memory, string serverName):this(name, gameDirectory, memory, defaultWidthResolution, defaultHeightResolution, defaultJavaExecutable, "", serverName){ }
        /// <summary>
        /// Конструктор класса Profile.
        /// </summary>
        /// <param name="name">Имя профиля.</param>
        /// <param name="gameDirectory">Полный путь к корневой директории игры.</param>
        /// <param name="memory">Кол-во используемой java оперативной памяти в Mb.</param>
        /// <param name="javaExecutable">Полный путь к исполняемому файлу java.</param>
        /// <param name="serverName">Имя сервера minecraft.</param>
        public Profile(string name, string gameDirectory, int memory, string javaExecutable, string serverName) : this(name, gameDirectory, memory, defaultWidthResolution, defaultHeightResolution, javaExecutable, "", serverName) { }
        /// <summary>
        /// Конструктор класса Profile.
        /// </summary>
        /// <param name="name">Имя профиля.</param>
        /// <param name="gameDirectory">Полный путь к корневой директории игры.</param>
        /// <param name="memory">Кол-во используемой java оперативной памяти в Mb.</param>
        /// <param name="widthResolution">Разрешение экрана в пикселях по ширине.</param>
        /// <param name="heightResolution">Разрешение экрана в пикселях по высоте.</param>
        /// <param name="javaExecutable">Полный путь к исполняемому файлу java.</param>
        /// <param name="jvmArguments">Дополнительные аргументы java.</param>
        /// <param name="serverName">Имя сервера minecraft.</param>
        public Profile(string name, string gameDirectory, int memory, int widthResolution, int heightResolution, string javaExecutable, string jvmArguments, string serverName)
        {
            this.name = name;
            this.gameDirectory = gameDirectory;
            this.memory = memory;
            this.resolution = new Resolution(widthResolution, heightResolution);
            this.javaExecutable = javaExecutable;
            this.jvmArguments = jvmArguments;
            this.serverName = serverName;
        }
        #endregion
    }
}
