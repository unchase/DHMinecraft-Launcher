using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZBobb;
//using ICSharpCode.SharpZipLib.Zip;
using System.Diagnostics;
using System.Threading;
using System.Security.Cryptography;

namespace DHMinecraft_Launcher_Configurator
{
    public partial class FormMainDHMinecraftLauncherConfigurator : Form
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

        private string siteUri = MineCraftConfiguratorSettings._siteUri;
        private string howToStartUri = MineCraftConfiguratorSettings._howToStartUri;
        private string rulesUri = MineCraftConfiguratorSettings._rulesUri;
        private string forumUri = MineCraftConfiguratorSettings._forumUri;
        private string donateUri = MineCraftConfiguratorSettings._donateUri;
        private string voteUri = MineCraftConfiguratorSettings._voteUri;
        private string authWithServerUri = MineCraftConfiguratorSettings._authWithServerUri;
        private string newsServerUri = MineCraftConfiguratorSettings._newsServerUri;
        private string launcherVersion = MineCraftConfiguratorSettings._launcherVersion;
        private string lastGameBuild = MineCraftConfiguratorSettings._lastGameBuild;
        private string sessionID = MineCraftConfiguratorSettings._sessionID;
        private string appData = MineCraftConfiguratorSettings._appData;
        private string minecraftRootFolder = MineCraftConfiguratorSettings._minecraftRootFolder;
        private string skinUri = MineCraftConfiguratorSettings._skinUri;
        private string librariesFolder = MineCraftConfiguratorSettings._librariesFolder;
        private string assetsFolder = MineCraftConfiguratorSettings._assetsFolder;
        private string currentServerName = MineCraftConfiguratorSettings._defaultServerName;
        private string launcherMainFolder = MineCraftConfiguratorSettings._launcherMainFolder;
        private string launcherProfilesFolder = MineCraftConfiguratorSettings._launcherProfilesFolder;
        private string launcherStylesFolder = MineCraftConfiguratorSettings._launcherStylesFolder;
        private string defaultMinecraftVersionsFolder = MineCraftConfiguratorSettings._defaultMinecraftVersionsFolder;
        private string currentMCJsonUri = MineCraftConfiguratorSettings._mcJsonUri;
        private string launcherUserFolder = MineCraftConfiguratorSettings._launcherUserFolder;
        private string launcherEncryptUserLoginFileName = MineCraftConfiguratorSettings._launcherEncryptUserLoginFileName;
        private string launcherEncryptUserLoginLenghtFileName = MineCraftConfiguratorSettings._launcherEncryptUserLoginLenghtFileName;
        private string additionalJVMArguments = MineCraftConfiguratorSettings._additionalJVMArguments;

        private string tempLibrariesJarFilesFolder = MineCraftConfiguratorSettings._tempLibrariesJarFilesFolder;
        private string fullPathFolderToCreatedBuild = MineCraftConfiguratorSettings._fullPathFolderToCreatedBuild;
        private string defaultCreatedBuildName = MineCraftConfiguratorSettings._defaultCreatedBuildName;
        private string configFolder = MineCraftConfiguratorSettings._configFolder;
        private string modsFolder = MineCraftConfiguratorSettings._modsFolder;
        private string resourcepacksFolder = MineCraftConfiguratorSettings._resourcepacksFolder;
        private string savesFolder = MineCraftConfiguratorSettings._savesFolder;
        private string tempLibrariesUnpackedCollectedFolder = MineCraftConfiguratorSettings._tempLibrariesUnpackedCollectedFolder;
        private string tempLibrariesUnpackedFolders = MineCraftConfiguratorSettings._tempLibrariesUnpackedFolders;

        private string launcherDownloadedFilesFolder = MineCraftConfiguratorSettings._launcherDownloadedFilesFolder;
        #endregion

        private bool buildWasCreated = false;
        private FormUploadBuildToServerWithFTP formUploadBuildToServerWithFTP;

        public FormMainDHMinecraftLauncherConfigurator()
        {
            InitializeComponent();
            buttonSetOldBuildFullPathFolder.Enabled = false;
            textBoxOldBuildFullPathFolder.Text = appData + "\\" + minecraftRootFolder;
            textBoxOldBuildFullPathFolder.ReadOnly = true;

            SetFullPathFoldersIntoTextBoxes();

            buttonSetCreatedBuildFullPathFolder.Enabled = false;
            textBoxCreatedBuildFullPathFolder.Text = fullPathFolderToCreatedBuild;
            textBoxCreatedBuildFullPathFolder.ReadOnly = true;
            textBoxNewCreatedBuildName.Text = defaultCreatedBuildName;
            textBoxNewCreatedBuildName.ReadOnly = true;
            buttonSetLibrariesFullPathFolder.Enabled = false;
            textBoxLibrariesFullPathFolder.ReadOnly = true;
            buttonSetAssetsFullPathFolder.Enabled = false;
            textBoxAssetsFullPathFolder.ReadOnly = true;
            buttonSetConfigFullPathFolder.Enabled = false;
            textBoxConfigFullPathFolder.ReadOnly = true;
            buttonSetModsFullPathFolder.Enabled = false;
            textBoxModsFullPathFolder.ReadOnly = true;
            buttonSetResourcePacksFullPathFolder.Enabled = false;
            textBoxResourcePacksFullPathFolder.ReadOnly = true;
            buttonSetSavesFullPathFolder.Enabled = false;
            textBoxSavesFullPathFolder.ReadOnly = true;
            buttonSetVersionsFullPathFolder.Enabled = false;
            textBoxVersionsFullPathFolder.ReadOnly = true;

            checkBoxHideUnZipLibraries.Checked = true;
            checkBoxParallelUnZip.Checked = true;

            checkBoxJsonForge.Checked = true;
            textBoxJsonMinecraftArguments.ReadOnly = true;
            textBoxJsonMinecraftArguments.Text = MineCraftConfiguratorSettings._defaultJsonMinecraftArguments;
            textBoxJsonMainClass.ReadOnly = true;
            textBoxJsonMainClass.Text = MineCraftConfiguratorSettings._defautJsonMainClass;
            textBoxJsonProcessArguments.ReadOnly = true;
            textBoxJsonProcessArguments.Text = MineCraftConfiguratorSettings._defaultJsonProcessArguments;
            buttonSetCustomerGameDirectory.Enabled = false;
            textBoxCustomerGameDirectory.ReadOnly = true;
            textBoxCustomerGameDirectory.Text = appData + "\\" + minecraftRootFolder;

            checkBoxDefaultLauncher.Checked = true;
            textBoxLauncherMainFolder.ReadOnly = true;
            textBoxLauncherMainFolder.Text = MineCraftConfiguratorSettings._launcherMainFolder;
            textBoxLauncherProfilesFolder.ReadOnly = true;
            textBoxLauncherProfilesFolder.Text = MineCraftConfiguratorSettings._launcherProfilesFolder;
            textBoxLauncherStylesFolder.ReadOnly = true;
            textBoxLauncherStylesFolder.Text = MineCraftConfiguratorSettings._launcherStylesFolder;
            textBoxLauncherUserFolder.ReadOnly = true;
            textBoxLauncherUserFolder.Text = MineCraftConfiguratorSettings._launcherUserFolder;

            textBoxDownloadToServer.ReadOnly = true;
            textBoxDownloadToServer.Text = MineCraftConfiguratorSettings._siteUri;
        }

        /// <summary>
        /// Метод для обновления всех путей исходя из выбранного пути старой сборки (создаваемой, не этой программой), из которой нужно составить новую.
        /// </summary>
        private void SetFullPathFoldersIntoTextBoxes()
        {
            textBoxLibrariesFullPathFolder.Text = textBoxOldBuildFullPathFolder.Text + "\\" + librariesFolder;
            textBoxAssetsFullPathFolder.Text = textBoxOldBuildFullPathFolder.Text + "\\" + assetsFolder;
            textBoxConfigFullPathFolder.Text = textBoxOldBuildFullPathFolder.Text + "\\" + configFolder;
            textBoxModsFullPathFolder.Text = textBoxOldBuildFullPathFolder.Text + "\\" + modsFolder;
            textBoxResourcePacksFullPathFolder.Text = textBoxOldBuildFullPathFolder.Text + "\\" + resourcepacksFolder;
            textBoxSavesFullPathFolder.Text = textBoxOldBuildFullPathFolder.Text + "\\" + savesFolder;
            textBoxVersionsFullPathFolder.Text = textBoxOldBuildFullPathFolder.Text + "\\" + defaultMinecraftVersionsFolder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateLibraryJarFile(new string[1]);
            MessageBox.Show("Файл библиотек " + textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + textBoxNewCreatedBuildName.Text + ".jar" + " был создан.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool CreateLibraryJarFile(string[] ignoreFolders)
        {
            try
            {
                toolStripStatusLabelProgressOutput.Text = "Удаление файлов и каталогов временной папки ...";
                if (Directory.Exists(textBoxCreatedBuildFullPathFolder.Text + "\\" + tempLibrariesJarFilesFolder))
                    Directory.Delete(textBoxCreatedBuildFullPathFolder.Text + "\\" + tempLibrariesJarFilesFolder, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось удалить все файлы из каталога " + textBoxCreatedBuildFullPathFolder.Text + "\\" + tempLibrariesJarFilesFolder + ". Удалите оставшиеся файлы вручную.\nТекст ошибки: " + ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ToDo: проверить
                if (checkBoxHideUnZipLibraries.Checked)
                    return false;
            }

            List<string> librariesFiles = Utils.GetAllFiles(textBoxLibrariesFullPathFolder.Text, "*.*", ignoreFolders);
            if (librariesFiles.Count > 0)
            {
                List<string> librariesFilesInTempFolderWithZipExtension = CopyJarFilesToTempFolderWithZipExtension(librariesFiles, textBoxCreatedBuildFullPathFolder.Text + "\\" + tempLibrariesJarFilesFolder);
                if (librariesFilesInTempFolderWithZipExtension.Count > 0)
                {
                    if (UnpackZipFilesToFolders(librariesFilesInTempFolderWithZipExtension, textBoxCreatedBuildFullPathFolder.Text + "\\" + tempLibrariesJarFilesFolder + "\\" + tempLibrariesUnpackedFolders, ""))
                    {
                        toolStripStatusLabelProgressOutput.Text = "Распаковка всех файлов завершена.";
                        if (PackFolderContentsFolderToZip(textBoxCreatedBuildFullPathFolder.Text + "\\" + tempLibrariesJarFilesFolder + "\\" + tempLibrariesUnpackedFolders, textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + librariesFolder + "\\" + textBoxNewCreatedBuildName.Text + "Library.jar", false))
                        {
                            try
                            {
                                toolStripStatusLabelProgressOutput.Text = "Удаление файлов и каталогов временной папки ...";
                                if (Directory.Exists(textBoxCreatedBuildFullPathFolder.Text + "\\" + tempLibrariesJarFilesFolder))
                                    Directory.Delete(textBoxCreatedBuildFullPathFolder.Text + "\\" + tempLibrariesJarFilesFolder, true);
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show("Не удалось удалить все файлы из каталога " + textBoxCreatedBuildFullPathFolder.Text + "\\" + tempLibrariesJarFilesFolder + ". Удалите оставшиеся файлы вручную.\nТекст ошибки: " + ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            toolStripStatusLabelProgressOutput.Text = "Упаковка файлов в библиотеку завершена.";
                            return true;
                        }
                    }
                }
            }

            try
            {
                if (Directory.Exists(textBoxCreatedBuildFullPathFolder.Text + "\\" + tempLibrariesJarFilesFolder))
                    Directory.Delete(textBoxCreatedBuildFullPathFolder.Text + "\\" + tempLibrariesJarFilesFolder, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось удалить все файлы из каталога " + textBoxCreatedBuildFullPathFolder.Text + "\\" + tempLibrariesJarFilesFolder + ". Удалите оставшиеся файлы вручную.\nТекст ошибки: " + ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }

        private void checkBoxCreatedBuildFullPathFolder_CheckedChanged(object sender, EventArgs e)
        {
            buttonSetCreatedBuildFullPathFolder.Enabled = checkBoxCreatedBuildFullPathFolder.Checked;
            textBoxCreatedBuildFullPathFolder.ReadOnly = !checkBoxCreatedBuildFullPathFolder.Checked;
        }

        private void checkBoxNewCreatedBuildName_CheckedChanged(object sender, EventArgs e)
        {
            textBoxNewCreatedBuildName.ReadOnly = !checkBoxNewCreatedBuildName.Checked;
        }

        private void checkBoxLibrariesFullPathFolder_CheckedChanged(object sender, EventArgs e)
        {
            buttonSetLibrariesFullPathFolder.Enabled = checkBoxLibrariesFullPathFolder.Checked;
            textBoxLibrariesFullPathFolder.ReadOnly = !checkBoxLibrariesFullPathFolder.Checked;
        }

        private void checkBoxAssetsFullPathFolder_CheckedChanged(object sender, EventArgs e)
        {
            buttonSetAssetsFullPathFolder.Enabled = checkBoxAssetsFullPathFolder.Checked;
            textBoxAssetsFullPathFolder.ReadOnly = !checkBoxAssetsFullPathFolder.Checked;
        }

        private void checkBoxConfigFullPathFolder_CheckedChanged(object sender, EventArgs e)
        {
            buttonSetConfigFullPathFolder.Enabled = checkBoxConfigFullPathFolder.Checked;
            textBoxConfigFullPathFolder.ReadOnly = !checkBoxConfigFullPathFolder.Checked;
        }

        private void checkBoxModsFullPathFolder_CheckedChanged(object sender, EventArgs e)
        {
            buttonSetModsFullPathFolder.Enabled = checkBoxModsFullPathFolder.Checked;
            textBoxModsFullPathFolder.ReadOnly = !checkBoxModsFullPathFolder.Checked;
        }

        private void checkBoxResourcePacksFullPathFolder_CheckedChanged(object sender, EventArgs e)
        {
            buttonSetResourcePacksFullPathFolder.Enabled = checkBoxResourcePacksFullPathFolder.Checked;
            textBoxResourcePacksFullPathFolder.ReadOnly = !checkBoxResourcePacksFullPathFolder.Checked;
        }

        private void checkBoxSavesFullPathFolder_CheckedChanged(object sender, EventArgs e)
        {
            buttonSetSavesFullPathFolder.Enabled = checkBoxSavesFullPathFolder.Checked;
            textBoxSavesFullPathFolder.ReadOnly = !checkBoxSavesFullPathFolder.Checked;
        }

        //ToDo: нужно ли выбирать RootFolder?
        /// <summary>
        /// Метод позволяет выбирать полный путь к каталогу и выводить его в <seealso cref="System.Windos.Forms.TextBox"/>.
        /// </summary>
        /// <param name="description">Описание просмотрщика каталогов.</param>
        /// <param name="tb"><seealso cref="System.Windows.Forms.TextBox"/>, в который будет выведет полный путь к выбранному каталогу.</param>
        private void SetFullPathFolder(string description, TextBox tb)
        {
            FolderBrowserDialog fbDirectory = new FolderBrowserDialog();
            fbDirectory.Description = description;
            //fbDirectory.RootFolder = Environment.SpecialFolder.ApplicationData;
            fbDirectory.ShowNewFolderButton = true;
            if (fbDirectory.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tb.Text = fbDirectory.SelectedPath;
                MessageBox.Show("Выбрана директория: " + tb.Text, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSetCreatedBuildFullPathFolder_Click(object sender, EventArgs e)
        {
            SetFullPathFolder("Выберите каталог для создаваемых сборок.", textBoxCreatedBuildFullPathFolder);
        }

        private void buttonSetLibrariesFullPathFolder_Click(object sender, EventArgs e)
        {
            SetFullPathFolder("Выберите каталог с libraries.", textBoxLibrariesFullPathFolder);
        }

        private void buttonSetAssetsFullPathFolder_Click(object sender, EventArgs e)
        {
            SetFullPathFolder("Выберите каталог с assets.", textBoxAssetsFullPathFolder);
        }

        private void buttonSetConfigFullPathFolder_Click(object sender, EventArgs e)
        {
            SetFullPathFolder("Выберите каталог с config.", textBoxConfigFullPathFolder);
        }

        private void buttonSetModsFullPathFolder_Click(object sender, EventArgs e)
        {
            SetFullPathFolder("Выберите каталог с mods.", textBoxModsFullPathFolder);
        }

        private void buttonSetResourcePacksFullPathFolder_Click(object sender, EventArgs e)
        {
            SetFullPathFolder("Выберите каталог с resourcepacks.", textBoxResourcePacksFullPathFolder);
        }

        private void buttonSetSavesFullPathFolder_Click(object sender, EventArgs e)
        {
            SetFullPathFolder("Выберите каталог с saves.", textBoxSavesFullPathFolder);
        }

        private void checkBoxOldBuildFullPathFolder_CheckedChanged(object sender, EventArgs e)
        {
            buttonSetOldBuildFullPathFolder.Enabled = checkBoxOldBuildFullPathFolder.Checked;
            textBoxOldBuildFullPathFolder.ReadOnly = !checkBoxOldBuildFullPathFolder.Checked;

            checkBoxCreatedBuildFullPathFolder.Checked = checkBoxOldBuildFullPathFolder.Checked;
            checkBoxNewCreatedBuildName.Checked = checkBoxOldBuildFullPathFolder.Checked;
            checkBoxLibrariesFullPathFolder.Checked = checkBoxOldBuildFullPathFolder.Checked;
            checkBoxAssetsFullPathFolder.Checked = checkBoxOldBuildFullPathFolder.Checked;
            checkBoxConfigFullPathFolder.Checked = checkBoxOldBuildFullPathFolder.Checked;
            checkBoxModsFullPathFolder.Checked = checkBoxOldBuildFullPathFolder.Checked;
            checkBoxResourcePacksFullPathFolder.Checked = checkBoxOldBuildFullPathFolder.Checked;
            checkBoxSavesFullPathFolder.Checked = checkBoxOldBuildFullPathFolder.Checked;
            checkBoxVersionsFullPathFolder.Checked = checkBoxOldBuildFullPathFolder.Checked;
        }

        private void buttonSetOldBuildFullPathFolder_Click(object sender, EventArgs e)
        {
            SetFullPathFolder("Выберите корневой каталог сборки, из которой хотите составить новую сборку.", textBoxOldBuildFullPathFolder);
            SetFullPathFoldersIntoTextBoxes();
        }

        private void checkBoxVersionsFullPathFolder_CheckedChanged(object sender, EventArgs e)
        {
            buttonSetVersionsFullPathFolder.Enabled = checkBoxVersionsFullPathFolder.Checked;
            textBoxVersionsFullPathFolder.ReadOnly = !checkBoxVersionsFullPathFolder.Checked;
        }

        //ToDo: исправить слишком длинный путь (или добавлять в архив через 7za прямо из всех папок)
        /// <summary>
        /// Метод копирует все файлы с подкаталогами из заданного каталога в каталог назначения, кроме тех файлов, которые находятся в каталоге с именем "META-INF".
        /// </summary>
        /// <param name="fullPathFolderWithLibrariesFolders">Исходный каталог с каталогами библиотек.</param>
        /// <param name="destinationFullPathFolder">Каталог назначения, куда будут копироваться все файлы.</param>
        /// <returns>Возвращает true, если при копировании не возникло ошибок и исклчений.</returns>
        public bool CopyAllFromLibrariesFoldersToFolder(string fullPathFolderWithLibrariesFolders, string destinationFullPathFolder)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(fullPathFolderWithLibrariesFolders);
                DirectoryInfo[] librariesFolders = di.GetDirectories();
                DirectoryInfo libraryFolderManiFestInfo;
                foreach (DirectoryInfo libraryFolder in librariesFolders)
                {
                    libraryFolderManiFestInfo = new DirectoryInfo(fullPathFolderWithLibrariesFolders + "\\" + libraryFolder + "\\" + "META-INF");
                    if (Directory.Exists(libraryFolderManiFestInfo.FullName))
                        Directory.Delete(libraryFolderManiFestInfo.FullName, true);

                    CopyDirectoryWithAllFiles(libraryFolder.FullName, destinationFullPathFolder);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сборе всех папок библиотек в одну папку. Текст ошибки: " + ex.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Метод копирует все файлы с подкаталогами из заданного каталога в каталог назначения.
        /// </summary>
        /// <param name="sourceDirectory">Исходный каталог, откуда будут копироваться его файлы и файлы его подкаталогов.</param>
        /// <param name="destinationDirectory">Каталог назначения, куда будут копироваться все файлы.</param>
        public void CopyDirectoryWithAllFiles(string sourceDirectory, string destinationDirectory)
        {
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);
            foreach (string sourceDirectoryFile in Directory.GetFiles(sourceDirectory))
            {
                string destinationDirectoryFile = destinationDirectory + "\\" + Path.GetFileName(sourceDirectoryFile);
                if (File.Exists(destinationDirectoryFile))
                {
                    if (MessageBox.Show("Файл " + sourceDirectoryFile + " уже существует в " + destinationDirectoryFile + ". Перезаписать его?", "Файл уже существует", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        File.Copy(sourceDirectoryFile, destinationDirectoryFile, true);
                }
                else
                    File.Copy(sourceDirectoryFile, destinationDirectoryFile);
            }
            foreach (string sourceSubDirectory in Directory.GetDirectories(sourceDirectory))
            {
                CopyDirectoryWithAllFiles(sourceSubDirectory, destinationDirectory + "\\" + Path.GetFileName(sourceSubDirectory));
            }
        }

        /// <summary>
        /// Копирует все jar-файлы из заданного списка с полными путями к ним в каталог назначния, при этом меняя расширение с jar на zip.
        /// </summary>
        /// <param name="jarFilesFullPath">Список с полными путями к jar-файлам.</param>
        /// <param name="unpackingFolderFullPath">Каталог назначения, куда будут скопированы jar-файлы с измененным расширением на zip.</param>
        /// <returns>Возвращает список с полными путями к сохраненным zip-файлам.</returns>
        public static List<string> CopyJarFilesToTempFolderWithZipExtension(List<string> jarFilesFullPath, string destinationTempJarFilesWithZipExtensionFolderFullPath)
        {
            try
            {
                List<string> listOfZipFilesInTempFolder = new List<string>();
                FileInfo jarFile;
                string newJarFileWithZipExtension;
                if (!Directory.Exists(destinationTempJarFilesWithZipExtensionFolderFullPath))
                    Directory.CreateDirectory(destinationTempJarFilesWithZipExtensionFolderFullPath);

                //ToDo: добавить удаление всех файлов в данной директории перед копированием?
                foreach (string jarFileFullPath in jarFilesFullPath)
                {
                    jarFile = new FileInfo(jarFileFullPath);
                    newJarFileWithZipExtension = Path.GetFileName(jarFileFullPath.Replace(".jar", ".zip"));
                    jarFile.CopyTo(destinationTempJarFilesWithZipExtensionFolderFullPath + "\\" + newJarFileWithZipExtension, true);
                    listOfZipFilesInTempFolder.Add(destinationTempJarFilesWithZipExtensionFolderFullPath + "\\" + newJarFileWithZipExtension);
                }
                return listOfZipFilesInTempFolder;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при копировании всех jar-библиотек с новым расширением zip. Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }

        //ToDo: убрать?
        /// <summary>
        /// Распаковывает все архивы из заданного каталога в каталог назначния. При этом в каталоге назначения создаются каталоги с именами архивов из заданного каталога, внутри которых будут находиться файлы, которые были в архиве. 
        /// </summary>
        /// <param name="zipFilesFolderFullPath">Каталог, в котором хранятся архивы в формате zip.</param>
        /// <param name="unpackingFolderFullPath">Каталог назначения, куда будут распкованы архивы.</param>
        /// <returns>Возвращает результат, были ли распакованы все архивы.</returns>
        //public bool UnpackZipFilesToFolders(string zipFilesFolderFullPath, string unpackingFolderFullPath)
        //{
        //    try
        //    {
        //        if (!Directory.Exists(zipFilesFolderFullPath))
        //            return false;
        //        if (!Directory.Exists(unpackingFolderFullPath))
        //            Directory.CreateDirectory(unpackingFolderFullPath);
        //        DirectoryInfo di = new DirectoryInfo(zipFilesFolderFullPath);
        //        FileInfo[] zipFilesFileInfo = di.GetFiles("*.zip");
        //        foreach (FileInfo zipFileFileInfo in zipFilesFileInfo)
        //        {
        //            //using (ZipFile zip = ZipFile.Read(zipFileFileInfo.FullName))
        //            //{
        //            //    foreach (ZipEntry e in zip)
        //            //    {
        //            //        e.Extract(unpackingFolderFullPath + "\\" + zipFileFileInfo.Name.Replace(".zip", ""));
        //            //    }
        //            //}


                    

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Произошла ошибка при распаковке zip-архивов в папки. Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}



        //ToDo: исправить ignoreFolderName
        /// <summary>
        /// Распаковывает все архивы из заданного списка с полными путями в каталог назначения. При этом в каталоге назначения создаются каталоги с именами архивов из заданного каталога, внутри которых будут находиться файлы, которые были в архиве. 
        /// </summary>
        /// <param name="zipFilesFullPath">Список с полными путями к архивам в формате zip.</param>
        /// <param name="unpackingFolderFullPath">Каталог назначения, куда будут распкованы архивы.</param>
        /// <returns>Возвращает результат, были ли распакованы все архивы.</returns>
        public bool UnpackZipFilesToFolders(List<string> zipFilesFullPath, string unpackingFolderFullPath, string ignoreFolderName)
        {
            try
            {
                if (!Directory.Exists(unpackingFolderFullPath))
                    Directory.CreateDirectory(unpackingFolderFullPath);

                if (!checkBoxParallelUnZip.Checked)
                {
                    int countOfAllZipFiles = zipFilesFullPath.Count();
                    int countOfCurrentExtractingZipFile = 1;
                    foreach (string zipFileFullPath in zipFilesFullPath)
                    {
                        if (!File.Exists(zipFileFullPath))
                            return false;

                        string arguments7Zip = "x -tzip " + zipFileFullPath + " -x!META-INF -o" + unpackingFolderFullPath + "\\" + Path.GetFileName(zipFileFullPath).Replace(".zip", "");

                        ProcessStartInfo unpackProcessStartInfo = new ProcessStartInfo("7za.exe", arguments7Zip);
                        if (checkBoxHideUnZipLibraries.Checked)
                            unpackProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                        Process unpackProcess = new Process();
                        try
                        {
                            toolStripStatusLabelProgressOutput.Text = "Распаковка " + Path.GetFileName(zipFileFullPath) + " (файл " + countOfCurrentExtractingZipFile + "/" + countOfAllZipFiles + ") ...";

                            unpackProcess.StartInfo = unpackProcessStartInfo;
                            unpackProcess.Start();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Произошла ошибка при распаковке zip-архивов в папки. Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        unpackProcess.WaitForExit();
                        countOfCurrentExtractingZipFile++;
                    }
                }
                else
                {
                    bool wasBad = false;
                    toolStripStatusLabelProgressOutput.Text = "Параллельная распаковка файлов библиотек ...";
                    int countOfNotExtractedZipFiles = zipFilesFullPath.Count();
                    Parallel.ForEach(zipFilesFullPath, zipFileFullPath =>
                    {
                        string arguments7Zip = "x -tzip " + zipFileFullPath + " -x!META-INF -o" + unpackingFolderFullPath + "\\" + Path.GetFileName(zipFileFullPath).Replace(".zip", "");

                        ProcessStartInfo unpackProcessStartInfo = new ProcessStartInfo("7za.exe", arguments7Zip);
                        if (checkBoxHideUnZipLibraries.Checked)
                            unpackProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                        Process unpackProcess = new Process();
                        try
                        {
                            unpackProcess.StartInfo = unpackProcessStartInfo;
                            unpackProcess.Start();
                        }
                        catch (Exception ex)
                        {
                            wasBad = true;
                            //ToDo: заменить чем-нибудь
                            //MessageBox.Show("Произошла ошибка при распаковке zip-архивов в папки. Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        unpackProcess.WaitForExit();
                        countOfNotExtractedZipFiles--;
                        toolStripStatusLabelProgressOutput.Text = "Параллельная распаковка файлов библиотек (осталось " + countOfNotExtractedZipFiles + " файлов) ...";
                    });

                    return !wasBad;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при распаковке zip-архивов в папки. Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //ToDo: привести в соответствие с таким же методом (поправить вывод в строку снизу)
        //public bool PackFolderToZip(string sourceFullPathFolder, string zipFileFullPath)
        //{
        //    try
        //    {
        //        if (Directory.Exists(sourceFullPathFolder))
        //        {
        //            if (!Directory.Exists(Path.GetDirectoryName(zipFileFullPath)))
        //                Directory.CreateDirectory(Path.GetDirectoryName(zipFileFullPath));

        //            if (File.Exists(zipFileFullPath))
        //                if (MessageBox.Show("Файл " + zipFileFullPath + "уже существует. Продолжить?\nПри этом старый файл будет удален и перезаписан.", "Файл существует", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
        //                    File.Delete(zipFileFullPath);
        //                else
        //                    return false;

        //            DirectoryInfo di = new DirectoryInfo(sourceFullPathFolder);
        //            string arguments7Zip = "a -tzip " + zipFileFullPath + " " + di.FullName + @"\*";

        //            ProcessStartInfo packProcessStartInfo = new ProcessStartInfo("7za.exe", arguments7Zip);
        //            if (checkBoxHideZipLibraries.Checked)
        //                packProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

        //            Process packProcess = new Process();
        //            try
        //            {
        //                toolStripStatusLabelProgressOutput.Text = "Упаковка " + di.FullName.Remove(0, sourceFullPathFolder.Length) + " ...";
        //                packProcess.StartInfo = packProcessStartInfo;
        //                packProcess.Start();
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Произошла ошибка при упаковке в zip-архив. Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return false;
        //            }
        //            packProcess.WaitForExit();

        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Произошла ошибка при распаковке zip-архивов в папки. Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}

        //ToDo: проверить с packFiles = true
        public bool PackFolderContentsFolderToZip(string sourceFullPathFolder, string zipFileFullPath, bool packFiles)
        {
            try
            {
                if (Directory.Exists(sourceFullPathFolder))
                {
                    if (!Directory.Exists(Path.GetDirectoryName(zipFileFullPath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(zipFileFullPath));
                    
                    if(File.Exists(zipFileFullPath))
                        if (MessageBox.Show("Файл " + zipFileFullPath + "уже существует. Продолжить?\nПри этом старый файл будет удален и перезаписан.", "Файл существует", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            File.Delete(zipFileFullPath);
                        else
                            return false;

                    DirectoryInfo di = new DirectoryInfo(sourceFullPathFolder);
                    int countOfCurrentFolder = 1;
                    foreach (DirectoryInfo sourceLibraryFullPathFolder in di.GetDirectories())
                    {
                        string arguments7Zip = "a -tzip " + zipFileFullPath + " " + sourceLibraryFullPathFolder.FullName + @"\*";

                        ProcessStartInfo packProcessStartInfo = new ProcessStartInfo("7za.exe", arguments7Zip);
                        if (checkBoxHideZipLibraries.Checked)
                            packProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        
                        Process packProcess = new Process();
                        try
                        {
                            toolStripStatusLabelProgressOutput.Text = "Упаковка " + sourceLibraryFullPathFolder.FullName.Remove(0, sourceFullPathFolder.Length) + " (каталог " + countOfCurrentFolder + "/" + di.GetDirectories().Count() + ") ...";
                            packProcess.StartInfo = packProcessStartInfo;
                            packProcess.Start();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Произошла ошибка при упаковке в zip-архив. Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        packProcess.WaitForExit();
                        countOfCurrentFolder++;
                    }

                    if (packFiles)
                    {
                        int countOfCurrentFile = 1;
                        foreach(FileInfo sourceLibraryFullPathFile in di.GetFiles())
                        {
                            string arguments7Zip = "a -tzip " + zipFileFullPath + " " + sourceLibraryFullPathFile.FullName;

                            ProcessStartInfo packProcessStartInfo = new ProcessStartInfo("7za.exe", arguments7Zip);
                            if (checkBoxHideZipLibraries.Checked)
                                packProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                            Process packProcess = new Process();
                            try
                            {
                                toolStripStatusLabelProgressOutput.Text = "Упаковка " + sourceLibraryFullPathFile.FullName.Remove(0, sourceFullPathFolder.Length) + " (файл " + countOfCurrentFile + "/" + di.GetFiles().Count() + ") ...";
                                packProcess.StartInfo = packProcessStartInfo;
                                packProcess.Start();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Произошла ошибка при упаковке в zip-архив. Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            packProcess.WaitForExit();
                            countOfCurrentFile++;
                        }
                    }

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при распаковке zip-архивов в папки. Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public void ExtractFile(string zipToUnpack, string unpackDirectory, ProgressBar progressBarExtract)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += (o, e) =>
            {
                if (e.ProgressPercentage > 100)
                    progressBarExtract.Value = 100;
                else
                    progressBarExtract.Value = e.ProgressPercentage;
            };
            worker.DoWork += (o, e) =>
            {
                using (ZipFile zip = ZipFile.Read(zipToUnpack))
                {
                    int step = (int)(zip.Count / 100.0);
                    int percentComplete = 0;
                    foreach (ZipEntry file in zip)
                    {
                        file.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                        percentComplete += step;
                        worker.ReportProgress(percentComplete);
                    }
                }
            };

            worker.RunWorkerAsync();
        }

        private void buttonCreateNewBuild_Click(object sender, EventArgs e)
        {
            buildWasCreated = false;
            try
            {
                if (!Directory.Exists(textBoxAssetsFullPathFolder.Text))
                {
                    MessageBox.Show("Папка с assets не выбрана или не существует.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Directory.Exists(textBoxVersionsFullPathFolder.Text))
                {
                    MessageBox.Show("Папка с versions не выбрана или не существует.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                toolStripStatusLabelProgressOutput.Text = "Копирование каталога с assets ...";
                CopyDirectoryWithAllFiles(textBoxAssetsFullPathFolder.Text, textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + assetsFolder);
                if (Directory.Exists(textBoxConfigFullPathFolder.Text))
                {
                    toolStripStatusLabelProgressOutput.Text = "Копирование каталога с config ...";
                    CopyDirectoryWithAllFiles(textBoxConfigFullPathFolder.Text, textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + configFolder);   
                }
                if (Directory.Exists(textBoxModsFullPathFolder.Text))
                {
                    toolStripStatusLabelProgressOutput.Text = "Копирование каталога с mods ...";
                    CopyDirectoryWithAllFiles(textBoxModsFullPathFolder.Text, textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + modsFolder);
                }
                if (Directory.Exists(textBoxResourcePacksFullPathFolder.Text))
                {
                    toolStripStatusLabelProgressOutput.Text = "Копирование каталога с resourcepacks ...";
                    CopyDirectoryWithAllFiles(textBoxResourcePacksFullPathFolder.Text, textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + resourcepacksFolder);
                }
                if (Directory.Exists(textBoxSavesFullPathFolder.Text))
                {
                    toolStripStatusLabelProgressOutput.Text = "Копирование каталога с saves ...";
                    CopyDirectoryWithAllFiles(textBoxSavesFullPathFolder.Text, textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + savesFolder);
                }

                if (Directory.Exists(textBoxVersionsFullPathFolder.Text))
                {
                    DirectoryInfo di = new DirectoryInfo(textBoxVersionsFullPathFolder.Text);
                    switch (di.GetDirectories().Count())
                    {
                        case 0:
                            //ToDo: добавить удаление перенесенных файлов?

                            MessageBox.Show("В папке с versions нет ни одного каталога.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        case 1:
                            toolStripStatusLabelProgressOutput.Text = "Копирование каталога с versions ...";
                            CopyDirectoryWithAllFiles(textBoxVersionsFullPathFolder.Text, textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder);
                            break;
                        default:
                            if (MessageBox.Show("В папке с versions несколько каталогов. Выбрать один?", "Обнаружено несколько каталогов", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                FolderBrowserDialog fbDialogVersionsDirectory = new FolderBrowserDialog();
                                fbDialogVersionsDirectory.Description = "Выберите одну папку из versions";
                                //fbDialogVersionsDirectory.RootFolder = Environment.SpecialFolder.MyComputer;
                                fbDialogVersionsDirectory.SelectedPath = textBoxVersionsFullPathFolder.Text;
                                fbDialogVersionsDirectory.ShowNewFolderButton = true;
                                if (fbDialogVersionsDirectory.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    toolStripStatusLabelProgressOutput.Text = "Копирование каталога с versions ...";
                                    DirectoryInfo diVersions = new DirectoryInfo(fbDialogVersionsDirectory.SelectedPath);
                                    CopyDirectoryWithAllFiles(fbDialogVersionsDirectory.SelectedPath, textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + "\\" + diVersions.Name);
                                }
                                else
                                {
                                    //ToDo: добавить удаление перенесенных файлов?

                                    MessageBox.Show("Сборка не может быть создана с несколькими или ни одной version.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                //ToDo: добавить удаление перенесенных файлов?

                                MessageBox.Show("Сборка не может быть создана с несколькими или ни одной version.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            break;
                    }
                }
                else
                {
                    //ToDo: добавить удаление перенесенных файлов?

                    MessageBox.Show("Папка с versions не выбрана или не существует.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //ToDo: добавить создание конфигурационных файлов лаунчера и архивирование всего в один файл. После чего удалить остальное (временные файлы)
                if (CreateLibraryJarFile(new string[1]))
                {
                    toolStripStatusLabelProgressOutput.Text = "Файлы сборки были собраны в " + textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text;

                    if (CreateJsonConfigurationFiles())
                    {
                        CreateJsonConfigurationFileToDownloadedFiles(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + launcherMainFolder + "\\" + launcherDownloadedFilesFolder + "\\DownloadedFiles.json");




                        buildWasCreated = true;
                        toolStripStatusLabelProgressOutput.Text = "Сборка была создана в " + textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "!";
                    }
                    else
                    {
                        MessageBox.Show("Файлы конфигурации сборки не были созданы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void checkBoxJsonForge_CheckedChanged(object sender, EventArgs e)
        {
            textBoxJsonMinecraftArguments.ReadOnly = checkBoxJsonForge.Checked;
            textBoxJsonMainClass.ReadOnly = checkBoxJsonForge.Checked;
            textBoxJsonProcessArguments.ReadOnly = checkBoxJsonForge.Checked;
        }

        private void checkBoxCustomerGameDirectory_CheckedChanged(object sender, EventArgs e)
        {
            buttonSetCustomerGameDirectory.Enabled = checkBoxCustomerGameDirectory.Checked;
            textBoxCustomerGameDirectory.ReadOnly = !checkBoxCustomerGameDirectory.Checked;
        }

        private void buttonSetCustomerGameDirectory_Click(object sender, EventArgs e)
        {
            SetFullPathFolder("Выберите игровой каталог minecraft заказчика.", textBoxCustomerGameDirectory);
        }

        private bool CreateJsonConfigurationFiles()
        {
            try
            {
                toolStripStatusLabelProgressOutput.Text = "Создание конфигурационных файлов json ...";
                DirectoryInfo di = new DirectoryInfo(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder);
                if (!Directory.Exists(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder) || di.GetDirectories().Count() == 0)
                {
                    MessageBox.Show("Папка " + textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + " не существует или пуста.\nНевозможно создать конфигурационный файл minecraft.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (di.GetDirectories().Count() > 1)
                {
                    MessageBox.Show("Папка " + textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + " содержит более одого подкаталога (должен быть один).\nНевозможно создать конфигурационный файл minecraft.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                DirectoryInfo diServer = di.GetDirectories().First();
                if (diServer.GetDirectories().Count() != 1)
                {
                    MessageBox.Show("Папка " + diServer.FullName + " не содержит подкаталогов или содержит более одого подкаталога (должен быть один).\nНевозможно создать конфигурационный файл minecraft.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    DirectoryInfo diNativesServerFolder = diServer.GetDirectories().First();
                    if (diNativesServerFolder.Name.Contains("-natives"))
                    {
                        if (!Directory.Exists(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + "\\" + textBoxNewCreatedBuildName.Text))
                            Directory.CreateDirectory(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + "\\" + textBoxNewCreatedBuildName.Text);
                        diNativesServerFolder.MoveTo(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + "\\" + textBoxNewCreatedBuildName.Text + "\\" + textBoxNewCreatedBuildName.Text + "-natives");
                    }
                    else
                    {
                        if (MessageBox.Show("Папка " + diNativesServerFolder.FullName + " имеет неверное название. Переименовать?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (!Directory.Exists(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + "\\" + textBoxNewCreatedBuildName.Text))
                                Directory.CreateDirectory(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + "\\" + textBoxNewCreatedBuildName.Text);
                            diNativesServerFolder.MoveTo(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + "\\" + textBoxNewCreatedBuildName.Text + "\\" + textBoxNewCreatedBuildName.Text + "-natives");
                        }
                        else
                        {
                            MessageBox.Show("Папка " + diNativesServerFolder.FullName + " имеет неверное название.\nНевозможно создать конфигурационный файл minecraft.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
                if (diServer.GetFiles().Count() != 2)
                {
                    MessageBox.Show("Папка " + diServer.FullName + " не содержит файлов, содержит один или более двух файлов (должен содержать ровно два).\nНевозможно создать конфигурационный файл minecraft.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    foreach (FileInfo diServerFile in diServer.GetFiles())
                    {
                        if (Path.GetFileName(diServerFile.FullName).Contains(".jar"))
                        {
                            if (!Directory.Exists(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + "\\" + textBoxNewCreatedBuildName.Text))
                                Directory.CreateDirectory(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + "\\" + textBoxNewCreatedBuildName.Text);
                            diServerFile.MoveTo(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + "\\" + textBoxNewCreatedBuildName.Text + "\\" + textBoxNewCreatedBuildName.Text + ".jar");
                        }
                        else
                            if (Path.GetFileName(diServerFile.FullName).Contains(".json"))
                            {
                                if (!Directory.Exists(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + "\\" + textBoxNewCreatedBuildName.Text))
                                    Directory.CreateDirectory(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + "\\" + textBoxNewCreatedBuildName.Text);
                                
                                MineCraftJsonSettings minecraftJsonSettings;
                                if (checkBoxJsonForge.Checked)
                                {
                                    //ToDo: добавить вычисление чек-суммы файла библиотек!
                                    MineCraftJsonSettings.Library minecraftMainLibrary = new MineCraftJsonSettings.Library(textBoxNewCreatedBuildName.Text + "Library", "Created by Lovecmuh.", new string[1]);
                                    minecraftJsonSettings = new MineCraftJsonSettings(minecraftMainLibrary, DateTime.Now.ToLongDateString(), textBoxNewCreatedBuildName.Text, DateTime.Now.ToLongDateString());
                                }
                                else
                                {
                                    //ToDo: добавить вычисление чек-суммы файла библиотек!
                                    MineCraftJsonSettings.Library minecraftMainLibrary = new MineCraftJsonSettings.Library(textBoxNewCreatedBuildName.Text + "Library", "Created by Lovecmuh.", new string[1]);
                                    minecraftJsonSettings = new MineCraftJsonSettings(textBoxJsonMinecraftArguments.Text, minecraftMainLibrary, textBoxJsonMainClass.Text, MineCraftConfiguratorSettings._defaultJsonMinimumLauncherVersion, DateTime.Now.ToLongDateString(), textBoxNewCreatedBuildName.Text, MineCraftConfiguratorSettings._defaultJsonType, textBoxJsonProcessArguments.Text, DateTime.Now.ToLongDateString());
                                }
                                Utils.SaveClassObjectToJsonFile<MineCraftJsonSettings>(minecraftJsonSettings, textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + "\\" + textBoxNewCreatedBuildName.Text + "\\" + textBoxNewCreatedBuildName.Text + ".json", Encoding.UTF8);
                            }
                            else
                            {
                                MessageBox.Show("Папка " + diServer.FullName + " содержит недопустимый файл " + diServerFile.FullName + ".\nНевозможно создать конфигурационный файл minecraft.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                    }
                }
                if (diServer.FullName != textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + defaultMinecraftVersionsFolder + "\\" + textBoxNewCreatedBuildName.Text)
                {
                    Directory.Delete(diServer.FullName, true);
                }

                if (!checkBoxDefaultLauncher.Checked)
                {
                    launcherMainFolder = textBoxLauncherMainFolder.Text;
                    launcherProfilesFolder = textBoxLauncherProfilesFolder.Text;
                    launcherStylesFolder = textBoxLauncherStylesFolder.Text;
                    launcherUserFolder = textBoxLauncherUserFolder.Text;
                }
                else
                {

                }
                CheckAndCreateFoldersForLauncher(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text);
                Profile launcherProfile = new Profile(textBoxNewCreatedBuildName.Text + "Profile", textBoxCustomerGameDirectory.Text, MineCraftConfiguratorSettings._minJavaUsageMemory, textBoxNewCreatedBuildName.Text);
                Utils.SaveClassObjectToJsonFile<Profile>(launcherProfile, textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + launcherMainFolder + "\\" + launcherProfilesFolder + "\\" + launcherProfile.name + ".json", Encoding.UTF8);

                toolStripStatusLabelProgressOutput.Text = "Создание конфигурационных файлов json завершено.";
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void checkBoxDefaultLauncher_CheckedChanged(object sender, EventArgs e)
        {
            textBoxLauncherMainFolder.ReadOnly = checkBoxDefaultLauncher.Checked;
            textBoxLauncherProfilesFolder.ReadOnly = checkBoxDefaultLauncher.Checked;
            textBoxLauncherStylesFolder.ReadOnly = checkBoxDefaultLauncher.Checked;
            textBoxLauncherUserFolder.ReadOnly = checkBoxDefaultLauncher.Checked;
        }

        private void buttonCreateJsonConfigurationFiles_Click(object sender, EventArgs e)
        {
            toolStripStatusLabelProgressOutput.Text = "Создание конфигурационных файлов json ...";
            if (CreateJsonConfigurationFiles())
            {
                MessageBox.Show("Файлы конфигурации сборки были созданы.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Файлы конфигурации сборки не были созданы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //ToDo: доделать проверку и создание необходимых папок
        /// <summary>
        /// Метод для проверки существования необходимых каталогов в корневой папке игры. Если каталог не создан, то метод его создает.
        /// </summary>
        private void CheckAndCreateFoldersForLauncher(string newBuildGameDirectory)
        {
            if (!Directory.Exists(newBuildGameDirectory + "\\" + launcherMainFolder))
            {
                toolStripStatusLabelProgressOutput.Text = "Создание главного каталога лаунчера ...";
                Directory.CreateDirectory(newBuildGameDirectory + "\\" + launcherMainFolder);
            }

            if (!Directory.Exists(newBuildGameDirectory + "\\" + launcherMainFolder + "\\" + launcherProfilesFolder))
            {
                toolStripStatusLabelProgressOutput.Text = "Создание каталога профилей лаунчера ...";
                Directory.CreateDirectory(newBuildGameDirectory + "\\" + launcherMainFolder + "\\" + launcherProfilesFolder);
            }

            if (!Directory.Exists(newBuildGameDirectory + "\\" + launcherMainFolder + "\\" + launcherStylesFolder))
            {
                toolStripStatusLabelProgressOutput.Text = "Создание каталога стилей лаунчера ...";
                Directory.CreateDirectory(newBuildGameDirectory + "\\" + launcherMainFolder + "\\" + launcherStylesFolder);
            }

            if (!Directory.Exists(newBuildGameDirectory + "\\" + launcherMainFolder + "\\" + launcherUserFolder))
            {
                toolStripStatusLabelProgressOutput.Text = "Создание каталога пользователя лаунчера ...";
                Directory.CreateDirectory(newBuildGameDirectory + "\\" + launcherMainFolder + "\\" + launcherUserFolder);
            }

            if (!Directory.Exists(newBuildGameDirectory + "\\" + launcherMainFolder + "\\" + launcherDownloadedFilesFolder))
            {
                toolStripStatusLabelProgressOutput.Text = "Создание каталога с конфигурацией загружаемых файлов лаунчера ...";
                Directory.CreateDirectory(newBuildGameDirectory + "\\" + launcherMainFolder + "\\" + launcherDownloadedFilesFolder);
            }
        }

        private void checkBoxDownloadToServer_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDownloadToServer.ReadOnly = !checkBoxDownloadToServer.Checked;
        }

        private void buttonDownloadToServer_Click(object sender, EventArgs e)
        {
            if (buildWasCreated)
            {
                //ToDo: сделать загрузку сборки на сервер (создать новое окно, где будет указано относительное расположение файлов, сохраняемых на сервер, логин и пароль для ftp для соединения)
                formUploadBuildToServerWithFTP = new FormUploadBuildToServerWithFTP(siteUri.Replace("http://", ""), textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text, textBoxNewCreatedBuildName.Text);
                formUploadBuildToServerWithFTP.ShowDialog();
            }
            else
            {
                if (MessageBox.Show("Сборка не была создана или создана частично. Все равно начать загрузку?", "Начать загрузку", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    formUploadBuildToServerWithFTP = new FormUploadBuildToServerWithFTP(siteUri.Replace("http://", ""), textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text, textBoxNewCreatedBuildName.Text);
                    formUploadBuildToServerWithFTP.ShowDialog();
                }
            }
        }

        private void buttonCreateJsonConfigurationDownloadedFiles_Click(object sender, EventArgs e)
        {
            //ToDo: !!!доделать выбор каталога для сохранения файла настроек скачеваемых файлов в диалоговом окне + добавить название этого файла из общих настроек и передать функции
            if (buildWasCreated)
            {
                CreateJsonConfigurationFileToDownloadedFiles(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + launcherMainFolder + "\\" + launcherDownloadedFilesFolder + "\\DownloadedFiles.json");
            }
            else
            {
                if (MessageBox.Show("Сборка не была создана или создана частично. Все равно создать конфигурационный файл для скачиваемых файлов сборки?", "Продолжить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    CreateJsonConfigurationFileToDownloadedFiles(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text + "\\" + launcherMainFolder + "\\" + launcherDownloadedFilesFolder + "\\DownloadedFiles.json");
                }
            }
        }

        private void CreateJsonConfigurationFileToDownloadedFiles(string jsonFileFullPath)
        {
            toolStripStatusLabelProgressOutput.Text = "Формирование конфигурационного файла для скачиваемых файлов ...";
            List<string> buildFiles = Utils.GetAllFiles(textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text, "*.*", new string[1]);
            //ToDo: удалить?
            int countOfBuildFiles = buildFiles.Count();

            List<DownloadedFiles.DownloadedFile> allDownloadedBuildFiles = new List<DownloadedFiles.DownloadedFile>();

            string downloadedFileName;
            string downloadedFileUri;
            bool downloadedFileDownloadIfExist;
            string downloadedFileLocalRelativePath;
            string downloadedFileSourceRelativePath;
            string downloadedFileMD5CheckSum;
            DownloadedFiles.DownloadedFile downloadedBuildFile;
            int currentBuildFileCount = 1;
            foreach (string buildFile in buildFiles)
            {
                toolStripStatusLabelProgressOutput.Text = "Добавление скачиваемых файлов в конфигурационный файл (" + currentBuildFileCount + "/" + countOfBuildFiles + ") ...";
                //ToDo: !!!определить переменные
                downloadedFileName = Path.GetFileName(buildFile);
                //ToDo: исправить, чтобы некоторые файлы не перекчивало заново!
                downloadedFileDownloadIfExist = true;
                //ToDo: исправить на нормальное имя
                string sss = textBoxCreatedBuildFullPathFolder.Text + "\\" + textBoxNewCreatedBuildName.Text;
                downloadedFileLocalRelativePath = buildFile.Remove(0, sss.Length);
                downloadedFileSourceRelativePath = "/" + textBoxNewCreatedBuildName.Text + "/" + downloadedFileLocalRelativePath.Replace("\\", "/");
                downloadedFileUri = siteUri + downloadedFileSourceRelativePath;
                downloadedFileMD5CheckSum = Utils.GetFileChecksum(buildFile, new MD5CryptoServiceProvider());
                downloadedBuildFile = new DownloadedFiles.DownloadedFile(downloadedFileName, downloadedFileUri, downloadedFileDownloadIfExist, downloadedFileLocalRelativePath, downloadedFileSourceRelativePath, downloadedFileMD5CheckSum);

                allDownloadedBuildFiles.Add(downloadedBuildFile);
                currentBuildFileCount++;
            }

            DownloadedFiles completeDownloadedBuildFiles = new DownloadedFiles(allDownloadedBuildFiles);
            if (!Utils.SaveClassObjectToJsonFile<DownloadedFiles>(completeDownloadedBuildFiles, jsonFileFullPath, Encoding.UTF8))
                MessageBox.Show("Файл конфигурации скачиваемых файлов не был создан.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                toolStripStatusLabelProgressOutput.Text = "Файл конфигурации скачиваемых файлов был сохранен в " + jsonFileFullPath;
        }
    }
}

//ToDo:
// 1) Добавить возможность составить json файл конфигурации сервера (отдельная форма)
// 2) Добавить возможность собрать все необходимые библиотеки в одну или пару-тройку библиотек (отдельная форма)
// 3) Добавить возможность составления архива со стилем лаунчера, проверяя изображения для стиля и изменяя га соответствующие имена (отдельная форма)
// 4) Добавить возможность сохранения в json сериализуемых классов из решения DHMinecraft Launcher (отдельные формы)
// 5) Можно ли обращаться как-то к классам из другого решения этого же проекта?
// 6) Добавить возможность загружать на сервер готовую сборку (через ftp? или POST-запросы? или WebClient?)
// 7) Добавить возможность вычисления различий между текущей сборкой и сборкой, которая установлена на сервере
// 8) Добавить возможность запускать сервер майнкрафта и редактировать его настройки
// 9) Автоматизировать по возможности весь процесс
// 10)
// 11)