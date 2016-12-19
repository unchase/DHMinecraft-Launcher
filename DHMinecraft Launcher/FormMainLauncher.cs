using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace DHMinecraft_Launcher
{
    public partial class FormMainLauncher : Form
    {
        #region Settings
        /// <summary>
        /// Логин пользователя.
        /// </summary>
        private string userLogin;

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        private string userPassword;

        private string siteUri = MineCraftSettings._siteUri;
        private string howToStartUri = MineCraftSettings._howToStartUri;
        private string rulesUri = MineCraftSettings._rulesUri;
        private string forumUri = MineCraftSettings._forumUri;
        private string donateUri = MineCraftSettings._donateUri;
        private string voteUri = MineCraftSettings._voteUri;
        private string authWithServerUri = MineCraftSettings._authWithServerUri;
        private string newsServerUri = MineCraftSettings._newsServerUri;
        private string launcherVersion = MineCraftSettings._launcherVersion;
        private string lastGameBuild = MineCraftSettings._lastGameBuild;
        private string sessionID = MineCraftSettings._sessionID;
        private string appData = MineCraftSettings._appData;
        private string minecraftRootFolder = MineCraftSettings._minecraftRootFolder;
        private string skinUri = MineCraftSettings._skinUri;
        private string librariesFolder = MineCraftSettings._librariesFolder;
        private string assetsFolder = MineCraftSettings._assetsFolder;
        private string currentServerName = MineCraftSettings._defaultServerName;
        private string launcherMainFolder = MineCraftSettings._launcherMainFolder;
        private string launcherProfilesFolder = MineCraftSettings._launcherProfilesFolder;
        private string launcherStylesFolder = MineCraftSettings._launcherStylesFolder;
        private string launcherDownloadedFilesFolder = MineCraftSettings._launcherDownloadedFilesFolder;
        private string defaultMinecraftVersionsFolder = MineCraftSettings._defaultMinecraftVersionsFolder;
        private string currentMCJsonUri = MineCraftSettings._mcJsonUri;
        private string launcherUserFolder = MineCraftSettings._launcherUserFolder;
        private string launcherEncryptUserLoginFileName = MineCraftSettings._launcherEncryptUserLoginFileName;
        private string launcherEncryptUserLoginLenghtFileName = MineCraftSettings._launcherEncryptUserLoginLenghtFileName;
        private string additionalJVMArguments = MineCraftSettings._additionalJVMArguments;
        #endregion

        private string responseFromServer = "";
        private bool logIn = false;

        private FormSettings formSettings;
        private Profile currentProfile;
        private FormDownloadAndUpdateFiles formDownloadAndUpdateFiles;

        public bool allFilesWasDownloaded = false;

        public FormMainLauncher()
        {
            InitializeComponent();
            pictureBoxSkin.WaitOnLoad = false;
            responseFromServer = "";
            logIn = false;
            buttonRunGame.Enabled = false;
            labelHello.Text = "";
        }

        /// <summary>
        /// Метод определяет, пуста ли строка.
        /// </summary>
        /// <param name="field">Проверяемая строка.</param>
        /// <returns>Возвращает true, если строка пуста. False, если не пуста.</returns>
        public bool FieldIsEmpty(string field)
        {
            if (field == "")
                return true;
            return false;
        }

        /// <summary>
        /// Метод загружает данные из профиля лаунчера.
        /// </summary>
        /// <param name="profile">Профиль лаунчера.</param>
        public void LoadSettingsFromProfile(Profile profile)
        {
            if (profile != null)
            {
                string[] mcRootFolderSplit = profile.gameDirectory.Split('\\');
                this.minecraftRootFolder = mcRootFolderSplit[mcRootFolderSplit.Length - 1];
                this.appData = mcRootFolderSplit[0];
                for (int i = 1; i < mcRootFolderSplit.Length - 1; i++)
                {
                    this.appData += "\\" + mcRootFolderSplit[i];
                }
                //ToDo: !исправить, так как имя сервера не должно зависеть от имени профиля
                this.currentServerName = profile.serverName;

                this.currentProfile = profile;
            }
            ReloadServersNames();
        }

        //public bool CopyJsonFromTo<T>(string jsonPathFrom, string jsonPathTo)
        //{
        //    Profile tempProfile = Utils.Deserialize<Profile>(jsonPathFrom, Encoding.UTF8);
        //    return Utils.SaveClassObjectToJsonFile<Profile>(tempProfile, jsonPathTo + "\\" + tempProfile.name + ".json", Encoding.UTF8);
        //}

        private void buttonRunGame_Click(object sender, EventArgs e)
        {

            if (!checkBoxOfflineMode.Checked)
            {
                if (!FieldIsEmpty(alphaBlendTextBoxLogin.Text))
                {
                    if (!FieldIsEmpty(alphaBlendTextBoxPassword.Text))
                    {
                        if (comboBoxServer.SelectedItem != null && !FieldIsEmpty(comboBoxServer.SelectedItem.ToString()))
                        {
                            //string responseFromServerOffline = MineCraftSettings._lastGameBuild + ":" + Utils.MD5Hash.GetMd5Hash(MD5.Create(), userLogin) + ":" + userLogin + ":0:";
                            DownloadAndRunMinecraft(responseFromServer);
                        }
                        else
                            MessageBox.Show("Не выбран сервер.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Пароль не был введен", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Логин не был введен", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (!FieldIsEmpty(alphaBlendTextBoxLogin.Text))
                {
                    userLogin = alphaBlendTextBoxLogin.Text;
                    string responseFromServerOffline = MineCraftSettings._lastGameBuild + ":" + Utils.MD5Hash.GetMd5Hash(MD5.Create(), userLogin) + ":" + userLogin + ":0:";
                    DownloadAndRunMinecraft(responseFromServerOffline);
                }
                else
                    MessageBox.Show("Логин не был введен", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //ToDo: доделать!!!
        /// <summary>
        /// Метод для скачивания необходимых файлов и каталогов и запуска игры.
        /// </summary>
        /// <param name="responseWithSession">Строка с ответом сервера на авторизацию пользователя.</param>
        public void DownloadAndRunMinecraft(string responseWithSession)
        {
            string[] splitRes = responseWithSession.Split(':');
            lastGameBuild = splitRes[0];
            string loginmd5 = splitRes[1];
            sessionID = splitRes[3];

            //ToDo: сделать проверку на существование и совпадение файлов для запуска. Если их нет, то скачать
            allFilesWasDownloaded = false;
            bool allFilesWasChecked = false;
            if (!checkBoxOfflineMode.Checked)
            {
                formDownloadAndUpdateFiles = new FormDownloadAndUpdateFiles(this, currentProfile);
                formDownloadAndUpdateFiles.ShowDialog();

                //ToDo: сделать проверку скаченных фалйлов перед запуском!


                //ToDo: убрать комментарий при том что проверка прошла
                allFilesWasChecked = true;
            }

            if (allFilesWasDownloaded && allFilesWasChecked || checkBoxOfflineMode.Checked)
            {

                if (Utils.MD5Hash.VerifyMd5Hash(MD5.Create(), userLogin, loginmd5))
                {
                    //ToDo: проверить и добавить currentProfile.jvmArguments в строку из настроек (с предварительной проверкой, была ли она)
                    string consoleRunString = "-Xmx" + currentProfile.memory + "m " + " " + currentProfile.jvmArguments + " " + additionalJVMArguments + " -Djava.library.path=" + currentProfile.gameDirectory + "\\" + defaultMinecraftVersionsFolder + "\\" + currentProfile.serverName + "\\" + currentProfile.serverName + "-natives" + " -cp " + currentProfile.gameDirectory + "\\" + defaultMinecraftVersionsFolder + "\\" + currentProfile.serverName + "\\" + currentProfile.serverName + ".jar;";

                    MineCraftJsonSettings mineCraftJsonSettings;
                    try
                    {
                        mineCraftJsonSettings = Utils.Deserialize<MineCraftJsonSettings>(currentMCJsonUri, Encoding.UTF8);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось запустить minecraft. Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string[] librariesPath = mineCraftJsonSettings.ParseLibraries(appData, minecraftRootFolder, currentServerName, librariesFolder);

                    foreach (string libraryPath in librariesPath)
                        consoleRunString += libraryPath + ";";

                    consoleRunString += " " + mineCraftJsonSettings.mainClass;

                    string minecraftArguments = mineCraftJsonSettings.minecraftArguments;
                    minecraftArguments = minecraftArguments.Replace("${auth_player_name}", userLogin);
                    minecraftArguments = minecraftArguments.Replace("${auth_session}", sessionID);
                    minecraftArguments = minecraftArguments.Replace("${version_name}", launcherVersion);
                    minecraftArguments = minecraftArguments.Replace("${game_directory}", currentProfile.gameDirectory);
                    minecraftArguments = minecraftArguments.Replace("${game_assets}", assetsFolder);

                    consoleRunString += " " + minecraftArguments;

                    ProcessStartInfo mcStartInfo = new ProcessStartInfo(currentProfile.javaExecutable, consoleRunString);
                    if (checkBoxShowRunLog.Checked)
                        mcStartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    else
                        mcStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    try
                    {
                        Process.Start(mcStartInfo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось запустить minecraft. Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    this.Close();
                }
                else
                    MessageBox.Show("Полученный MD5-хэш логина не совпадает с вычисленным.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Файлы minecraft не совпадают с исходными или не все файлы были скачены с сервера.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //ToDo: Если режим оффлайн, то не загружать комбобокс и веб-браузер
        private void FormMainLauncher_Load(object sender, EventArgs e)
        {
            //ToDo: проверить статус сервера (вкл/выкл) и выставить индикатор вместе с лейблом о кол-ве игроков на сервере
            CheckAndCreateFolders();

            //ToDo: добавить загрузку стилей


            string profilesFullPathFolder = appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder + "\\" + launcherProfilesFolder;

            //try
            //{
            //    Profile profile1 = new Profile("HiTech", appData + "\\" + minecraftRootFolder, 768, 854, 480, MineCraftSettings._defaultJavaExecutable, "");
            //    if (!Utils.SaveClassObjectToJsonFile(profile1, profilesFullPathFolder + "\\" + profile1.name + ".json", Encoding.UTF8))
            //        MessageBox.Show("Косяк при создании файла");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}


            //ToDo: получить стандартный профиль лаунчера с сервера и загрузить его в profilesFullPathFolder

            ReloadLauncherProfiles(profilesFullPathFolder);

            //ToDo: нужно ли это? Ускоряет ли?
            WebRequest request = WebRequest.Create(newsServerUri);
            request.Proxy = new WebProxy();
            request.Method = "POST";

            webBrowserNews.Url = new Uri(newsServerUri);
            while (webBrowserNews.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            LoadLoginFromUserFile();
            ReloadServersNames();

            Utils.SetPlaceHolderToAlphaBlendTextBox(alphaBlendTextBoxLogin, "Логин");
            Utils.SetPlaceHolderToAlphaBlendTextBox(alphaBlendTextBoxPassword, "Пароль");

            try
            {
                pictureBoxSiteURLQRCode.Image = GenerateQR(siteUri, pictureBoxSiteURLQRCode.Width, pictureBoxSiteURLQRCode.Height);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при создании QR-кода: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region CreateQr-Code Bitmap
        //ToDo: добавить поддержку кириллицы дополнительно?
        /// <summary>
        /// Метод генерирует QR-код в виде <seealso cref="System.Drawning.Bitmap"/> с заданными размерами по заданному тексту. 
        /// </summary>
        /// <param name="text">Текст, который будет преобразован в QR-код.</param>
        /// <param name="width">Ширина изображения QR-кода.</param>
        /// <param name="height">Высота изображения QR-кода.</param>
        /// <returns>Возвращает QR-код в виде <seealso cref="System.Drawning.Bitmap"/> изображения.</returns>
        public Bitmap GenerateQR(string text, int width, int height)
        {
            var bw = new ZXing.BarcodeWriter();
            var encOptions = new ZXing.Common.EncodingOptions() { Width = width, Height = height, Margin = 0 };
            bw.Options = encOptions;
            bw.Format = ZXing.BarcodeFormat.QR_CODE;
            var result = new Bitmap(bw.Write(text));
            
            return result;
        }
        #endregion

        /// <summary>
        /// Метод очищает имена серверов и добавляет в <seealso cref="System.Windows.Forms.ComboBox"/> имена серверов, которые есть в папке с серверами.
        /// </summary>
        public void ReloadServersNames()
        {
            comboBoxServer.Items.Clear();
            if (currentProfile != null)
            {
                string[] serversNamesFullPath = Directory.GetDirectories(currentProfile.gameDirectory + "\\" + defaultMinecraftVersionsFolder);
                foreach (string serverNameFullPath in serversNamesFullPath)
                {
                    if (CheckServersFolderFolders(serverNameFullPath))
                        comboBoxServer.Items.Add(new DirectoryInfo(serverNameFullPath).Name);
                }
                comboBoxServer.SelectedIndex = comboBoxServer.Items.IndexOf(currentProfile.serverName);
            }
            else
            {
                string[] serversNamesFullPath = Directory.GetDirectories(appData + "\\" + minecraftRootFolder + "\\" + defaultMinecraftVersionsFolder);
                foreach (string serverNameFullPath in serversNamesFullPath)
                {
                    if (CheckServersFolderFolders(serverNameFullPath))
                        comboBoxServer.Items.Add(new DirectoryInfo(serverNameFullPath).Name);
                }
                comboBoxServer.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Метод проверяет наличие необходимых для сервера файлов в каталоге с именами серверов.
        /// </summary>
        /// <param name="serverNameFullPath">Полный путь к каталогу с сервером.</param>
        /// <returns>Возвращает результат, все ли необходимые файлы присутствуют.</returns>
        public bool CheckServersFolderFolders(string serverNameFullPath)
        {
            if (currentProfile != null)
            {
                if (File.Exists(serverNameFullPath + "\\" + currentProfile.serverName + ".jar") && File.Exists(serverNameFullPath + "\\" + currentProfile.serverName + ".json") && Directory.Exists(serverNameFullPath + "\\" + currentProfile.serverName + "-natives"))
                    return true;
            }
            else
            {
                if (File.Exists(serverNameFullPath + "\\" + currentServerName + ".jar") && File.Exists(serverNameFullPath + "\\" + currentServerName + ".json") && Directory.Exists(serverNameFullPath + "\\" + currentServerName + "-natives"))
                    return true;
            }
            
            return false;
        }

        /// <summary>
        /// Метод перезагружает профили лаунчера.
        /// </summary>
        /// <param name="profilesFullPathFolder">Полный путь к каталогу с файлами профиля лаунчера.</param>
        public void ReloadLauncherProfiles(string profilesFullPathFolder)
        {
            if (Directory.Exists(profilesFullPathFolder))
            {
                string[] profilesWithFullPath = Directory.GetFiles(profilesFullPathFolder);
                if (profilesWithFullPath.Length == 0)
                {
                    MessageBox.Show("Не найдены файлы профиля лаунчера в папке \"" + profilesFullPathFolder + "\".", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }

                comboBoxProfilesMain.Items.Clear();
                foreach (var profileWithFillPath in profilesWithFullPath)
                {
                    string profileName = Path.GetFileNameWithoutExtension(profileWithFillPath);
                    comboBoxProfilesMain.Items.Add(profileName);
                }

                if (currentProfile != null && comboBoxProfilesMain.Items.IndexOf(currentProfile.name) >= 0)
                    comboBoxProfilesMain.SelectedIndex = comboBoxProfilesMain.Items.IndexOf(currentProfile.name);
                else
                    comboBoxProfilesMain.SelectedIndex = 0;

                if (currentProfile != null)
                {
                    LoadSettingsFromProfile(currentProfile);
                    int serverIndex;
                    if ((serverIndex = comboBoxServer.Items.IndexOf(currentServerName)) >= 0)
                    {
                        comboBoxServer.SelectedIndex = serverIndex;
                    }
                    else
                    {
                        ReloadServersNames();
                    }
                }
                else
                {
                    MessageBox.Show("Не задан текущий профиль лаунчера.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(3);
                }

                CheckAndCreateFolders();
            }
            else
            {
                MessageBox.Show("Папка " + profilesFullPathFolder + " не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(2);
            }
        }

        //ToDo: доделать проверку и создание необходимых папок
        /// <summary>
        /// Метод для проверки существования необходимых каталогов в корневой папке игры. Если каталог не создан, то метод его создает.
        /// </summary>
        private void CheckAndCreateFolders()
        {
            if (!Directory.Exists(appData))
                Directory.CreateDirectory(appData);

            if (!Directory.Exists(appData + "\\" + minecraftRootFolder))
                Directory.CreateDirectory(appData + "\\" + minecraftRootFolder);

            if (!Directory.Exists(appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder))
                Directory.CreateDirectory(appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder);

            if (!Directory.Exists(appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder + "\\" + launcherProfilesFolder))
                Directory.CreateDirectory(appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder + "\\" + launcherProfilesFolder);

            if (!Directory.Exists(appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder + "\\" + launcherStylesFolder))
                Directory.CreateDirectory(appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder + "\\" + launcherStylesFolder);

            if (!Directory.Exists(appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder + "\\" + launcherUserFolder))
                Directory.CreateDirectory(appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder + "\\" + launcherUserFolder);

            if (!Directory.Exists(appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder + "\\" + launcherDownloadedFilesFolder))
                Directory.CreateDirectory(appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder + "\\" + launcherDownloadedFilesFolder);

            if (!Directory.Exists(appData + "\\" + minecraftRootFolder + "\\" + defaultMinecraftVersionsFolder))
                Directory.CreateDirectory(appData + "\\" + minecraftRootFolder + "\\" + defaultMinecraftVersionsFolder);

        }

        private void buttonMainSettings_Click(object sender, EventArgs e)
        {
            formSettings = new FormSettings(this, currentProfile, appData, minecraftRootFolder, launcherMainFolder, launcherProfilesFolder);
            formSettings.ShowDialog();
        }

        private void linkLabelSite_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(siteUri);
                linkLabelSite.LinkVisited = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabelRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(siteUri);
                linkLabelRegister.LinkVisited = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabelHowToStart_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(howToStartUri);
                linkLabelHowToStart.LinkVisited = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabelRules_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(rulesUri);
                linkLabelRules.LinkVisited = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ToDo: добавить заход на форум по ссылке
        private void linkLabelForum_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Форум в разработке", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Process.Start(forumUri);
                linkLabelForum.LinkVisited = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //ToDo: реализовать донат. Переход по ссылке
        private void linkLabelDonate_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Донат в разработке", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Process.Start(donateUri);
                linkLabelDonate.LinkVisited = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //ToDo: реализовать голосование. Перейти по ссылке
        private void linkLabelVote_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Голосование в разработке", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Process.Start(voteUri);
                linkLabelVote.LinkVisited = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(appData + "\\" + minecraftRootFolder + "\\" + librariesFolder);
            //MessageBox.Show(Utils.Deserialize<MineCraftJsonSettings>(currentMCJsonUri, Encoding.UTF8).ParseLibraries(appData, minecraftRootFolder, currentServerName, librariesFolder)[0]);
            //MessageBox.Show(Utils.Serialize(Utils.Deserialize<MineCraftJsonSettings>(currentMCJsonUri, Encoding.UTF8)));
            //MessageBox.Show(Utils.SaveClassObjectToJsonFile(Utils.Deserialize<MineCraftJsonSettings>(currentMCJsonUri, Encoding.UTF8), "d:\\1\\111.json", Encoding.UTF8).ToString());

            if (!logIn)
            {
                if (!FieldIsEmpty(alphaBlendTextBoxLogin.Text))
                {
                    if (checkBoxRememberPassword.Checked)
                    {
                        SaveLoginToUserFile();
                    }

                    if (!FieldIsEmpty(alphaBlendTextBoxPassword.Text))
                    {
                        if (comboBoxServer.SelectedItem != null && !FieldIsEmpty(comboBoxServer.SelectedItem.ToString()))
                        {
                            //ToDo: проверить, правильно ли задано authWithServerUri с помощью регулярного выражения?

                            userLogin = alphaBlendTextBoxLogin.Text;
                            userPassword = alphaBlendTextBoxPassword.Text;
                            responseFromServer = Utils.AuthOnServer(authWithServerUri, userLogin, Utils.MD5Hash.GetMd5Hash(MD5.Create(), userPassword), launcherVersion);

                            string goodAuthResponsePattern = @"\d*:\w*:\w*:\w*";
                            Regex regexGoodAuthResponsePattern = new Regex(goodAuthResponsePattern);

                            try
                            {
                                var match = regexGoodAuthResponsePattern.Match(responseFromServer);
                                if (responseFromServer.Contains("Bad login"))
                                {
                                    MessageBox.Show("Неправильный логин/пароль!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else if (responseFromServer.Contains("Old version"))
                                {
                                    MessageBox.Show("Не верная версия лаунчера!(Скачайте новую версию с сайта " + siteUri + ")", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else if (match.Success)
                                {
                                    pictureBoxSkin.ImageLocation = skinUri + "?m=1&user_name=" + userLogin;
                                    logIn = true;
                                    alphaBlendTextBoxLogin.ReadOnly = logIn;
                                    alphaBlendTextBoxPassword.ReadOnly = logIn;
                                    buttonRunGame.Enabled = logIn;
                                    buttonLogIn.Text = "Выйти";
                                    labelHello.Text = "Добро пожаловать,\n" + userLogin + "!";
                                }
                                else
                                    MessageBox.Show("Сервер вернул: " + responseFromServer, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                            MessageBox.Show("Не выбран сервер.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Пароль не был введен", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Логин не был введен", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                pictureBoxSkin.ImageLocation = "";
                userLogin = "";
                userPassword = "";
                responseFromServer = "";
                logIn = false;
                alphaBlendTextBoxLogin.ReadOnly = logIn;
                alphaBlendTextBoxPassword.ReadOnly = logIn;
                buttonRunGame.Enabled = logIn;
                buttonLogIn.Text = "Войти";
                labelHello.Text = "";
            }
        }

        /// <summary>
        /// Метод для запоминания логина пользователя в файл, чтобы при следующем запуске программы этот логин уже был вписан в соответствующее поле.
        /// </summary>
        private void SaveLoginToUserFile()
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] key = MineCraftSettings._keyLogin;
            byte[] encryptUserLogin = ProtectedData.Protect(ByteConverter.GetBytes(alphaBlendTextBoxLogin.Text), key, DataProtectionScope.CurrentUser);

            string launcherEncryptUserFileNameFullPath = appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder + "\\" + launcherUserFolder + "\\" + launcherEncryptUserLoginFileName;
            string launcherEncryptUserLoginLenghtFileNameFullPath = appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder + "\\" + launcherUserFolder + "\\" + launcherEncryptUserLoginLenghtFileName;
            FileStream fs = new FileStream(launcherEncryptUserFileNameFullPath, FileMode.Create, FileAccess.Write);
            FileStream fsLength = new FileStream(launcherEncryptUserLoginLenghtFileNameFullPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fsLength);
            BinaryWriter wr = new BinaryWriter(fs);
            try
            {
                sw.Write(encryptUserLogin.Length);
                wr.Write(encryptUserLogin);
                fs.Close();
                wr.Close();
                sw.Close();
                fsLength.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fs.Close();
                wr.Close();
                sw.Close();
                fsLength.Close();
            }
        }

        /// <summary>
        /// Метод для загрузки запомненного логина пользователя из файла в соответствующее поле.
        /// </summary>
        private void LoadLoginFromUserFile()
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] key = MineCraftSettings._keyLogin;
            byte[] decryptUserLogin;

            string launcherEncryptUserFileNameFullPath = appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder + "\\" + launcherUserFolder + "\\" + launcherEncryptUserLoginFileName;
            string launcherEncryptUserLoginLenghtFileNameFullPath = appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder + "\\" + launcherUserFolder + "\\" + launcherEncryptUserLoginLenghtFileName;
            if (!File.Exists(launcherEncryptUserFileNameFullPath) || !File.Exists(launcherEncryptUserLoginLenghtFileNameFullPath))
                return;
            FileStream fs = new FileStream(launcherEncryptUserFileNameFullPath, FileMode.Open, FileAccess.Read);
            FileStream fsLength = new FileStream(launcherEncryptUserLoginLenghtFileNameFullPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fsLength);
            BinaryReader br = new BinaryReader(fs);
            try
            {
                int encryptUserLoginLength = Convert.ToInt32(sr.ReadToEnd());
                decryptUserLogin = ProtectedData.Unprotect(br.ReadBytes(encryptUserLoginLength), key, DataProtectionScope.CurrentUser);
                alphaBlendTextBoxLogin.Text = ByteConverter.GetString(decryptUserLogin);
                checkBoxRememberPassword.Checked = true;
                fs.Close();
                sr.Close();
                fsLength.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fs.Close();
                sr.Close();
                fsLength.Close();
            }
        }

        private void comboBoxProfilesMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProfilesMain.SelectedItem != null)
            {
                string jsonUri = appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder + "\\" + launcherProfilesFolder + "\\" + comboBoxProfilesMain.SelectedItem.ToString() + ".json";
                if (File.Exists(jsonUri))
                    currentProfile = Utils.Deserialize<Profile>(jsonUri, Encoding.UTF8);
                else
                    MessageBox.Show("Файл профиля " + jsonUri + " не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxOfflineMode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOfflineMode.Checked)
            {
                buttonLogIn.Enabled = false;
                buttonRunGame.Enabled = true;
                if (logIn)
                {
                    buttonLogIn_Click(new object(), new EventArgs());
                    buttonRunGame.Enabled = true;
                }
            }
            else
            {
                buttonLogIn.Enabled = true;
                buttonRunGame.Enabled = false;
            }
        }

        private void comboBoxServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentProfile != null)
            {
                currentMCJsonUri = currentProfile.gameDirectory + "\\" + defaultMinecraftVersionsFolder + "\\" + currentProfile.serverName + "\\" + currentProfile.serverName + ".json";
            }
            else
            {
                currentMCJsonUri = appData + "\\" + minecraftRootFolder + "\\" + defaultMinecraftVersionsFolder + "\\" + comboBoxServer.SelectedItem.ToString() + "\\" + comboBoxServer.SelectedItem.ToString() + ".json";
            }
        }

    }
}

/////////////////
//ToDO:
// 1) Добавить папку Styles в каталог с программой, где будут храниться скины для лаунчера (возможно, с xml-настройками, например, с цветом linkLabel)
//    Добавить возможность изменить скин лаунчера и проверку загружаемого скина на размеры (должно совпадать с FormMainLauncher.Size)
// 2) Ограничить кол-во вводимых символов в логине пользователя
// 3) Реализовать запуск для разных версий лаунчера (узнать версию лаунчера из .jar)
// 4) Реализовать загрузку файлов с сервера (сначала загрузку файла minecraftFiles.json, в котором хранятся данные о всех файлах, которые нужно загрузить и откуда). Создать мини-приложение для
//    a) Создания и сохранения файла minecraftFiles.json
//    b) Чтения файла профиля, чтения файла настроек запуска в формате json. Парсинг в строку запуска и т.д.
// 5) Возможно, реализовать систему защиты, используя qr-коды
// 6) Загруженные библиотеки от .Net 4.5. Возможно, нужно загрузить более ранние и построить проект под ранними платформами, например .Net 2.0
// 7) Запихнуть все необходимые библиотеки в один файл, папку с модами и natives заархивировать 