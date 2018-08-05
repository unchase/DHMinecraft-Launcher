using System.Runtime.Serialization;

namespace DHMinecraft_Launcher_Configurator
{
    [DataContract]
    public class Profile
    {
        private static string defaultJavaExecutable = MineCraftConfiguratorSettings._defaultJavaExecutable;
        private static int defaultWidthResolution = MineCraftConfiguratorSettings._defaultWidthResolution;
        private static int defaultHeightResolution = MineCraftConfiguratorSettings._defaultHeightResolution;

        #region Данные
        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "gameDirectory")]
        public string gameDirectory { get; set; }

        [DataMember(Name = "memory")]
        public int memory { get; set; }

        [DataMember(Name = "resolution")]
        public Resolution resolution { get; set; }

        [DataContract]
        public class Resolution
        {
            public Resolution() : this(0, 0) { }
            public Resolution(int widthResolutionRes, int heightResolutionRes)
            {
                widthResolution = widthResolutionRes;
                heightResolution = heightResolutionRes;
            }

            [DataMember(Name = "widthResolution")]
            public int widthResolution { get; set; }

            [DataMember(Name = "heightResolution")]
            public int heightResolution { get; set; }
        }

        [DataMember(Name = "javaExecutable")]
        public string javaExecutable { get; set; }

        [DataMember(Name = "jvmArguments")]
        public string jvmArguments { get; set; }

        [DataMember(Name = "serverName")]
        public string serverName { get; set; }
        #endregion

        #region Конструкторы
        public Profile(string name, string gameDirectory, int memory, string serverName):this(name, gameDirectory, memory, defaultWidthResolution, defaultHeightResolution, defaultJavaExecutable, "", serverName){ }
        public Profile(string name, string gameDirectory, int memory, string javaExecutable, string serverName) : this(name, gameDirectory, memory, defaultWidthResolution, defaultHeightResolution, javaExecutable, "", serverName) { }
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
