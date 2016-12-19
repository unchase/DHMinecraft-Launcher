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

namespace DHMinecraft_Launcher
{
    public partial class FormSettings : Form
    {
        private FormMainLauncher formMainLauncher;
        private Profile profile;
        private string appData;
        private string minecraftRootFolder;
        private string launcherMainFolder;
        private string launcherProfilesFolder;

        private int maxJavaUsageMemory = MineCraftSettings._maxJavaUsageMemory;
        private int minJavaUsageMemory = MineCraftSettings._minJavaUsageMemory;
        private int minWidthResolution = MineCraftSettings._minWidthResolution;
        private int maxWidthResolution = MineCraftSettings._maxWidthResolution;
        private int minHeightResolution = MineCraftSettings._minHeightResolution;
        private int maxHeightResolution = MineCraftSettings._maxHeightResolution;
        private string initialJavaFolder = MineCraftSettings._initialJavaFolder;

        public FormSettings(FormMainLauncher formMainLauncher) : this(formMainLauncher, null, MineCraftSettings._appData, MineCraftSettings._minecraftRootFolder, MineCraftSettings._launcherMainFolder, MineCraftSettings._launcherProfilesFolder) { }
        public FormSettings(FormMainLauncher formMainLauncher, Profile profile, string appData, string minecraftRootFolder, string launcherMainFolder, string launcherProfilesFolder)
        {
            InitializeComponent();
            textBoxProfile.ReadOnly = true;
            
            textBoxGameDirectory.ReadOnly = true;
            textBoxWidthResolution.ReadOnly = true;
            textBoxHeightResolution.ReadOnly = true;
            textBoxUsageMemory.ReadOnly = true;
            textBoxExecutableJava.ReadOnly = true;
            textBoxJVMArguments.ReadOnly = true;
            buttonSelectGameDirectory.Enabled = false;
            buttonSelectExecutableJava.Enabled = false;
            this.formMainLauncher = formMainLauncher;
            this.profile = profile;
            this.appData = appData;
            this.minecraftRootFolder = minecraftRootFolder;
            this.launcherMainFolder = launcherMainFolder;
            this.launcherProfilesFolder = launcherProfilesFolder;

            if (profile == null)
                MessageBox.Show("Профиль не был выбран.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                LoadProfileSettings(profile);
            }
        }

        /// <summary>
        /// Загружает данные из профиля лаунчера.
        /// </summary>
        /// <param name="profile">Профиль лаунчера.</param>
        private void LoadProfileSettings(Profile profile)
        {
            textBoxProfile.Text = profile.name;
            textBoxGameDirectory.Text = profile.gameDirectory;
            textBoxWidthResolution.Text = profile.resolution.widthResolution.ToString();
            textBoxHeightResolution.Text = profile.resolution.heightResolution.ToString();
            textBoxUsageMemory.Text = profile.memory.ToString();
            textBoxExecutableJava.Text = profile.javaExecutable;
            textBoxJVMArguments.Text = profile.jvmArguments;
        }

        private void checkBoxProfile_CheckedChanged(object sender, EventArgs e)
        {
            textBoxProfile.ReadOnly = !checkBoxProfile.Checked;
        }

        private void checkBoxGameDirectory_CheckedChanged(object sender, EventArgs e)
        {
            //textBoxGameDirectory.ReadOnly = !checkBoxProfile.Checked;
            buttonSelectGameDirectory.Enabled = checkBoxGameDirectory.Checked;
        }

        private void checkBoxResolution_CheckedChanged(object sender, EventArgs e)
        {
            textBoxWidthResolution.ReadOnly = !checkBoxResolution.Checked;
            textBoxHeightResolution.ReadOnly = !checkBoxResolution.Checked;
        }

        private void checkBoxUsageMemory_CheckedChanged(object sender, EventArgs e)
        {
            textBoxUsageMemory.ReadOnly = !checkBoxUsageMemory.Checked;
        }

        private void checkBoxExecutableJava_CheckedChanged(object sender, EventArgs e)
        {
            //textBoxExecutableJava.ReadOnly = !checkBoxExecutableJava.Checked;
            buttonSelectExecutableJava.Enabled = checkBoxExecutableJava.Checked;
        }

        private void checkBoxJVMArguments_CheckedChanged(object sender, EventArgs e)
        {
            textBoxJVMArguments.ReadOnly = !checkBoxJVMArguments.Checked;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            comboBoxServersNames.Items.Clear();
            if (profile != null)
            {
                string[] serversNamesFullPath = Directory.GetDirectories(profile.gameDirectory + "\\" + MineCraftSettings._defaultMinecraftVersionsFolder);
                foreach(string serverNameFullPath in serversNamesFullPath)
                {
                    comboBoxServersNames.Items.Add(new DirectoryInfo(serverNameFullPath).Name);
                }
                comboBoxServersNames.SelectedIndex = comboBoxServersNames.Items.IndexOf(profile.serverName);
            }
            else
            {
                string[] serversNamesFullPath = Directory.GetDirectories(appData + "\\" + minecraftRootFolder + "\\" + MineCraftSettings._defaultMinecraftVersionsFolder);
                foreach (string serverNameFullPath in serversNamesFullPath)
                {
                    comboBoxServersNames.Items.Add(new DirectoryInfo(serverNameFullPath).Name);
                }
                comboBoxServersNames.SelectedIndex = 0;
            }
        }

        private void buttonCancleSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            string profileName = textBoxProfile.Text;

            //ToDo: сделать проверку profileName на регулярном выражении, что это путь (добавить в if)
            if (profileName == "")
            {
                MessageBox.Show("Не верно задано значение \"" + checkBoxProfile.Text + "\"", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string profileGameDirectory = textBoxGameDirectory.Text;

            //ToDo: сделать проверку profileGameDirectory на регулярном выражении, что это путь (добавить в if)
            if (profileGameDirectory == "")
            {
                MessageBox.Show("Не верно задано значение \"" + checkBoxGameDirectory.Text + "\"", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int profileMemory;
            try
            {
                profileMemory = Convert.ToInt32(textBoxUsageMemory.Text);
                //ToDo: сделать проверку profileMemory на регулярном выражении, что это путь (добавить в if)
                if (profileMemory < minJavaUsageMemory || profileMemory > maxJavaUsageMemory)
                {
                    MessageBox.Show("Не верно задано значение \"" + checkBoxUsageMemory.Text + "\". Должно быть " + minJavaUsageMemory.ToString() + " <= Java Usage Memory <= " + maxJavaUsageMemory.ToString() + ".", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Не верно задано значение \"" + checkBoxUsageMemory.Text + "\"", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int profileWidthResolution;
            try
            {
                profileWidthResolution = Convert.ToInt32(textBoxWidthResolution.Text);
                //ToDo: сделать проверку profileWidthResolution на регулярном выражении, что это путь (добавить в if)
                if (profileWidthResolution < minWidthResolution || profileWidthResolution > maxWidthResolution)
                {
                    MessageBox.Show("Не верно задано значение \"" + checkBoxResolution.Text + "\". Должно быть " + minWidthResolution.ToString() + " <= Resolution <= " + maxWidthResolution.ToString() + ".", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Не верно задано значение \"" + checkBoxResolution.Text + "\"", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int profileHeightResolution;
            try
            {
                profileHeightResolution = Convert.ToInt32(textBoxHeightResolution.Text);
                //ToDo: сделать проверку profileHeightResolution на регулярном выражении, что это путь (добавить в if)
                if (profileHeightResolution < minHeightResolution || profileHeightResolution > maxHeightResolution)
                {
                    MessageBox.Show("Не верно задано значение \"" + checkBoxResolution.Text + "\". Должно быть " + minHeightResolution.ToString() + " <= Resolution <= " + maxHeightResolution.ToString() + ".", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Не верно задано значение \"" + checkBoxResolution.Text + "\"", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string profileJavaExecutable = textBoxExecutableJava.Text;

            //ToDo: сделать проверку profileJavaExecutable на регулярном выражении, что это путь (добавить в if)
            if (profileJavaExecutable == "")
            {
                MessageBox.Show("Не верно задано значение \"" + checkBoxExecutableJava.TabIndex + "\"", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //ToDo: сделать проверку аргументов JVM через регулярные выражения
            string profileJVMArguments = textBoxJVMArguments.Text;

            string serverName = comboBoxServersNames.SelectedItem.ToString();

            if (profile != null)
            {
                profile.name = profileName;
                profile.gameDirectory = profileGameDirectory;
                profile.memory = profileMemory;
                profile.resolution.widthResolution = profileWidthResolution;
                profile.resolution.heightResolution = profileHeightResolution;
                profile.javaExecutable = profileJavaExecutable;
                profile.jvmArguments = profileJVMArguments;
                profile.serverName = serverName;
            }
            else
                profile = new Profile(profileName, profileGameDirectory, profileMemory, profileWidthResolution, profileHeightResolution, profileJavaExecutable, profileJVMArguments, serverName);

            string jSonFullFileName = profile.gameDirectory + "\\" + launcherMainFolder + "\\" + launcherProfilesFolder + "\\" + profile.name + ".json";
            try
            {
                string jSonOldFullFileName = appData + "\\" + minecraftRootFolder + "\\" + launcherMainFolder + "\\" + launcherProfilesFolder + "\\" + profile.name + ".json";

                if (Utils.SaveClassObjectToJsonFile<Profile>(profile, jSonFullFileName, Encoding.UTF8))
                {
                    string profilesFullPathFolder = profile.gameDirectory + "\\" + launcherMainFolder + "\\" + launcherProfilesFolder;
                    formMainLauncher.LoadSettingsFromProfile(profile);
                    //formMainLauncher.CopyJsonFromTo<Profile>(jSonFullFileName, profile.gameDirectory + "\\" + launcherMainFolder + "\\" + launcherProfilesFolder);
                    //profilesFullPathFolder = profile.gameDirectory + "\\" + launcherMainFolder + "\\" + launcherProfilesFolder;
                    formMainLauncher.ReloadLauncherProfiles(profilesFullPathFolder);

                    if (jSonOldFullFileName != jSonFullFileName && Path.GetFileNameWithoutExtension(jSonOldFullFileName) == Path.GetFileNameWithoutExtension(jSonFullFileName))
                    {
                        if (MessageBox.Show("Удалить старый файл профиля " + jSonOldFullFileName + "\n(Новый файл профиля будет создан в " + jSonFullFileName + ")", "Удалить старый файл профиля?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            File.Delete(jSonOldFullFileName);
                            MessageBox.Show("Старый файл профиля " + jSonOldFullFileName + " был удален.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        MessageBox.Show("Новый файл профиля " + jSonFullFileName + " был сохранен.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Файл профиля " + jSonFullFileName + " был сохранен.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Файл профиля " + jSonFullFileName + "не был сохранен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сохранении в файл профиля " + jSonFullFileName + ".\nТекст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //ToDo: выбрать корневую папку майнкрафта
        private void buttonSelectGameDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbDialogGameDirectory = new FolderBrowserDialog();
            fbDialogGameDirectory.Description = "Выберите директорию с игрой Minecraft";
            fbDialogGameDirectory.RootFolder = Environment.SpecialFolder.ApplicationData;
            fbDialogGameDirectory.ShowNewFolderButton = true;
            if (fbDialogGameDirectory.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxGameDirectory.Text = fbDialogGameDirectory.SelectedPath;
                MessageBox.Show("Выбрана директория с игрой: " + textBoxGameDirectory.Text, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSelectExecutableJava_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialogExecutableJava = new OpenFileDialog();
            ofDialogExecutableJava.AddExtension = true;
            ofDialogExecutableJava.CheckFileExists = true;
            ofDialogExecutableJava.CheckPathExists = true;
            ofDialogExecutableJava.DefaultExt = "exe";
            ofDialogExecutableJava.DereferenceLinks = true;
            ofDialogExecutableJava.Filter = "exe файлы (*.exe)|*.exe|bat файлы (*.bat)|*.bat";
            ofDialogExecutableJava.FilterIndex = 0;
            ofDialogExecutableJava.InitialDirectory = initialJavaFolder;
            ofDialogExecutableJava.Multiselect = false;
            ofDialogExecutableJava.RestoreDirectory = true;
            ofDialogExecutableJava.ShowHelp = true;

            if (ofDialogExecutableJava.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxExecutableJava.Text = ofDialogExecutableJava.FileName;
                MessageBox.Show("Выбран исполняемый файл Java: " + textBoxExecutableJava.Text, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
