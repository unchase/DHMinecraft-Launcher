using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHMinecraft_Launcher_Configurator
{
    /// <summary>
    /// Класс, хранящий настройки minecraft.
    /// </summary>
    public static class MineCraftConfiguratorSettings
    {
        #region Uri
        /// <summary>
        /// Uri сайта сервера minecraft.
        /// </summary>
        public static string _siteUri = "http://minecraftdeep.hol.es";

        /// <summary>
        /// Uri на страницу "Как начать играть" на сервере.
        /// </summary>
        public static string _howToStartUri = "http://minecraftdeep.hol.es/go/guide/";

        /// <summary>
        /// Uri на страницу с правилами сервера.
        /// </summary>
        public static string _rulesUri = "http://minecraftdeep.hol.es/go/rules/";

        /// <summary>
        /// Uri на страницу форума.
        /// </summary>
        public static string _forumUri = "";

        /// <summary>
        /// Uri на страницу доната. 
        /// </summary>
        public static string _donateUri = "";

        /// <summary>
        /// Uri на страницу голосования.
        /// </summary>
        public static string _voteUri = "";

        /// <summary>
        /// Uri к php-скрипту авторизации на сервере.
        /// </summary>
        public static string _authWithServerUri = "http://minecraftdeep.hol.es/MineCraft/auth.php";

        /// <summary>
        /// Uri к php-скрипту с новостями minecraft.
        /// </summary>
        public static string _newsServerUri = "http://minecraftdeep.hol.es/MineCraft/news.php";

        /// <summary>
        /// Uri к php-скрипту со скином.
        /// </summary>
        public static string _skinUri = "http://minecraftdeep.hol.es/skin.php";

        //ToDo: исправить на верный путь к json-файлу
        /// <summary>
        /// Uri к json-файлу с настройками minecraft.
        /// </summary>
        public static string _mcJsonUri = "";
        #endregion

        #region Main Game Settings
        /// <summary>
        /// Полный путь к папке appData.
        /// </summary>
        public static string _appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        /// Корневой каталог с файлами minecraft в AppData.
        /// </summary>
        public static string _minecraftRootFolder = ".DHMinecraft";

        /// <summary>
        /// Имя папки с библиотеками в корневом каталоге minecraft.
        /// </summary>
        public static string _librariesFolder = "libraries";

        /// <summary>
        /// Имя папки с assets в корневом каталоге minecraft.
        /// </summary>
        public static string _assetsFolder = "assets";
        #endregion

        #region Monitor Resolution and Java memory
        /// <summary>
        /// Разрешение экрана в высоту по-умолчанию.
        /// </summary>
        public static int _defaultHeightResolution = 480;

        /// <summary>
        /// Разрешение экрана в ширину по-умолчанию. 
        /// </summary>
        public static int _defaultWidthResolution = 854;

        /// <summary>
        /// Максимально возможное кол-во используемой Java оперативной памяти.
        /// </summary>
        public static int _maxJavaUsageMemory = 8192;

        /// <summary>
        /// Минимально возможное кол-во используемой Java оперативной памяти.
        /// </summary>
        public static int _minJavaUsageMemory = 60;

        /// <summary>
        /// Минимальное разрешение экрана в пикселях по ширине.
        /// </summary>
        public static int _minWidthResolution = 320;

        /// <summary>
        /// Максимальное разрешение экрана в пикселях по ширине.
        /// </summary>
        public static int _maxWidthResolution = 7680;

        /// <summary>
        /// Минимальное разрешение экрана в пикселях по высоте.
        /// </summary>
        public static int _minHeightResolution = 240;

        /// <summary>
        /// Максимальное разрешение экрана в пикселях по высоте.
        /// </summary>
        public static int _maxHeightResolution = 4800;
        #endregion

        #region Other Settings
        /// <summary>
        /// Версия лаунчера.
        /// </summary>
        public static string _launcherVersion = "13";

        /// <summary>
        /// Последний билд игры.
        /// </summary>
        public static string _lastGameBuild = "";

        /// <summary>
        /// Id сессии.
        /// </summary>
        public static string _sessionID = "";

        /// <summary>
        /// Путь по-умолчанию к исполняемому файлу java.
        /// </summary>
        public static string _defaultJavaExecutable = @"C:\ProgramFiles\Java\jre7\bin\javaw.exe";

        /// <summary>
        /// Название сервера (папки для файлов сервера) по-умолчанию.
        /// </summary>
        public static string _defaultServerName = "HiTech";

        /// <summary>
        /// Название папки с файлами лаунчера.
        /// </summary>
        public static string _launcherMainFolder = "DHLauncher";

        /// <summary>
        /// Название папки с профилями лаунчера (эта папка находится в главной папке лаунчера, заданной в _launcherMainFolder).
        /// </summary>
        public static string _launcherProfilesFolder = "Profiles";

        /// <summary>
        /// Название папки со стилями лаунчера (эта папка находится в главной папке лаунчера, заданной в _launcherMainFolder).
        /// </summary>
        public static string _launcherStylesFolder = "Styles";

        /// <summary>
        /// Название папки пользователя лаунчера.
        /// </summary>
        public static string _launcherUserFolder = "User";

        /// <summary>
        /// Название папки с конфигурационным файлом скачиваемых фалов лаунчера (эта папка находится в главной папке лаунчера, заданной в _launcherMainFolder).
        /// </summary>
        public static string _launcherDownloadedFilesFolder = "Download";

        /// <summary>
        /// Название папки с версиями minecraft (с серверами, такими как Classic, HiTech и т.д.).
        /// </summary>
        public static string _defaultMinecraftVersionsFolder = "versions";

        /// <summary>
        /// Полный путь к папке с исполняемыми файлами Java.
        /// </summary>
        public static string _initialJavaFolder = @"C:\ProgramFiles\Java\jre7\bin";

        /// <summary>
        /// Ключ для шифрования и расшифровки логина.
        /// </summary>
        public static byte[] _keyLogin = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

        /// <summary>
        /// Имя файла, в котором будет храниться логин пользователя в зашифрованном виде.
        /// </summary>
        public static string _launcherEncryptUserLoginFileName = "user.dat";

        /// <summary>
        /// Имя файла, в котором будет храниться длина зашифрованного логина пользователя.
        /// </summary>
        public static string _launcherEncryptUserLoginLenghtFileName = "length.dat";

        /// <summary>
        /// Дополнительные аргументы JVM.
        /// </summary>
        public static string _additionalJVMArguments = "-Dfml.ignoreInvalidMinecraftCertificates=true -Dfml.ignorePatchDiscrepancies=true";
        #endregion

        /// <summary>
        /// Название папки, куда будут копироваться все найденные jar-файлы библиотек майнкрафт.
        /// </summary>
        public static string _tempLibrariesJarFilesFolder = "Temp";

        /// <summary>
        /// Полный путь к каталогу, в котором будут создаваться сборки.
        /// </summary>
        public static string _fullPathFolderToCreatedBuild = "C:\\MCBuilds";

        /// <summary>
        /// Название новой создаваемой сборки.
        /// </summary>
        public static string _defaultCreatedBuildName = "MCNewBuild";

        /// <summary>
        /// Имя папки с config в корневом каталоге minecraft.
        /// </summary>
        public static string _configFolder = "config";

        /// <summary>
        /// Имя папки с mods в корневом каталоге minecraft.
        /// </summary>
        public static string _modsFolder = "mods";

        /// <summary>
        /// Имя папки с recourcepacks в корневом каталоге minecraft.
        /// </summary>
        public static string _resourcepacksFolder = "resourcepacks";

        /// <summary>
        /// Имя папки с saves в корневом каталоге minecraft.
        /// </summary>
        public static string _savesFolder = "saves";

        /// <summary>
        /// Название папки, куда будут копироваться распакаованные zip-архивы библиотек в виде папок.
        /// </summary>
        public static string _tempLibrariesUnpackedFolders = "Unpacked";

        /// <summary>
        /// Название папки, в которую будт копироваться распакаованные папки библиотек.
        /// </summary>
        public static string _tempLibrariesUnpackedCollectedFolder = "UnpackedCollect";

        #region Minecraft Json
        /// <summary>
        /// Json: cтандартная строка с аргументами запуска minecraft. 
        /// </summary>
        public static string _defaultJsonMinecraftArguments = "--username ${auth_player_name} --session ${auth_session} --version ${version_name} --gameDir ${game_directory} --assetsDir ${game_assets} --tweakClass cpw.mods.fml.common.launcher.FMLTweaker";

        /// <summary>
        /// Json: cтандартная строка с основным классом minecraft. 
        /// </summary>
        public static string _defautJsonMainClass = "net.minecraft.launchwrapper.Launch";

        /// <summary>
        /// Json: cтандартная строка с минимальной версией лаунчера minecraft. 
        /// </summary>
        public static string _defaultJsonMinimumLauncherVersion = "1";

        /// <summary>
        /// Json: cтандартная строка с типом конфигурационного файла. 
        /// </summary>
        public static string _defaultJsonType = "release";

        /// <summary>
        /// Json: cтандартная строка с заменяемыми аргументами процесса запуска minecraft.
        /// </summary>
        public static string _defaultJsonProcessArguments = "username_session_version";

        /// <summary>
        /// Json: стандартное значение, необходима ли библиотека серверному приложению minecraft.
        /// </summary>
        public static bool _defaultJsonLibraryServerreq = false;

        /// <summary>
        /// Json: стандартное значение, необходима ли библиотека клиентскому приложению minecraft.
        /// </summary>
        public static bool _defaultJsonLibraryClientreq = true;

        /// <summary>
        /// Json: cтандартная строка с url для обновления библиотеки.
        /// </summary>
        public static string _defaultJsonLibraryUrl = "";

        /// <summary>
        /// Json: cтандартная строка с зависимостями windows для библиотеки.
        /// </summary>
        public static string _defaultJsonLibraryNativeWindows = "";

        /// <summary>
        /// Json: cтандартная строка с зависимостями osx для библиотеки.
        /// </summary>
        public static string _defaultJsonLibraryNativeOsx = "";

        /// <summary>
        /// Json: cтандартная строка с зависимостями linux для библиотеки.
        /// </summary>
        public static string _defaultJsonLibraryNativeLinux = "";
        #endregion

        #region AddedSettings
        
        #endregion
    }
}
