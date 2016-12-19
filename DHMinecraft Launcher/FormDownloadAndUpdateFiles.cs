using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;

namespace DHMinecraft_Launcher
{
    public partial class FormDownloadAndUpdateFiles : Form
    {
        private WebClient webClient;               // Веб-клиент, который будет загружать файлы
        private Stopwatch sw = new Stopwatch();    // stopwatch будет использован для вычисления скорости загрузки
        private string currentDownloadedFile = "";
        private WebProxy webProxy;
        private FormMainLauncher formMainLauncher;
        private Profile currentProfile;
        private string currLocation;

        private string downloadedFilesJsonConfigurationUri = MineCraftSettings._downloadedFilesJsonConfigurationUri;
        private string launcherMainFolder = MineCraftSettings._launcherMainFolder;
        private string launcherDownloadedFilesFolder = MineCraftSettings._launcherDownloadedFilesFolder;

        private string tempLocation = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));

        public FormDownloadAndUpdateFiles(FormMainLauncher formMainLauncher, Profile currentProfile)
        {
            InitializeComponent();
            buttonCloseForm.Enabled = false;
            labelCurrentDownloadingFile.Text = "";
            labelLastDownloadingFile.Text = "";
            this.formMainLauncher = formMainLauncher;
            this.currentProfile = currentProfile;

            webClient = new WebClient();
            webProxy = new WebProxy();
            webClient.Proxy = webProxy;
        }

        private void BeginDownload()
        {
            try
            {
                DownloadedFiles downloadedFiles = Utils.Deserialize<DownloadedFiles>(downloadedFilesJsonConfigurationUri, Encoding.UTF8);
                this.formMainLauncher.allFilesWasDownloaded = true;
                foreach (DownloadedFiles.DownloadedFile downloadedFile in downloadedFiles.downloadedFiles)
                {

                    currLocation = currentProfile.gameDirectory + downloadedFile.localRelativePath;
                    labelCurrentDownloadingFile.Text = "Проверка файла: " + Path.GetFileName(downloadedFile.name);

                    if (!File.Exists(currentProfile.gameDirectory + downloadedFile.localRelativePath) || (File.Exists(currentProfile.gameDirectory + downloadedFile.localRelativePath) && GetFileChecksum(currentProfile.gameDirectory + downloadedFile.localRelativePath, new MD5CryptoServiceProvider()) != downloadedFile.md5CheckSum))
                    {
                        //ToDo: переделать метод DownloadFile, чтобы возвращал bool, чтобы потом проверять, все ли файлы были скачены
                        try
                        {
                            DownloadFile(downloadedFile.uri, currLocation);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при скачивании файла из " + downloadedFile.uri + ". Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.formMainLauncher.allFilesWasDownloaded = false;
                            break;
                        }
                    }

                }

                if (Directory.Exists(tempLocation))
                    Directory.Delete(tempLocation, true);

                buttonCloseForm.Enabled = this.formMainLauncher.allFilesWasDownloaded;
            }
            catch (Exception ex)
            {
                this.formMainLauncher.allFilesWasDownloaded = false;
                MessageBox.Show("Произошла ошибка при обновлении файлов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // a3ccfd0aa0b17fd23aa9fd0d84b86c05
        //string MD5checksum = GetFileChecksum("c:\\myfile.exe", new MD5CryptoServiceProvider());
        private string GetFileChecksum(string filePath, HashAlgorithm algorithm)
        {
            string result = string.Empty;
            using (FileStream fs = File.OpenRead(filePath))
            {
                result = BitConverter.ToString(algorithm.ComputeHash(fs)).ToLower().Replace("-", "");
            }

            return result;
        }

        /// <summary>
        /// Метод загружает файл в заданный каталог.
        /// </summary>
        /// <param name="urlAddress">Url к загружаемому файлу.</param>
        /// <param name="location"></param>
        public void DownloadFile(string urlAddress, string location)
        {
            using (webClient)
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // переменная, которая должна содержать url адрес (делает так, чтобы она начиналась с http://)
                Uri URL = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);

                if (!CheckURL(URL.ToString()))
                    throw new Exception("Файл " + urlAddress + "не существует.");

                // запустить stopwatch, который будет использоваться для вычисления скорости загрузки
                sw.Start();

                // начать загрузку файла
                currentDownloadedFile = Path.GetFileName(location);
                labelCurrentDownloadingFile.Text = "Загрузка файла: " + currentDownloadedFile;

                if (!Directory.Exists(tempLocation))
                    Directory.CreateDirectory(tempLocation);

                webClient.DownloadFileAsync(URL, tempLocation + "\\" + currentDownloadedFile);

                while (webClient.IsBusy)
                {
                    Application.DoEvents();
                }
            }
        }

        private static bool CheckURL(String url) 
        { 
            if(String.IsNullOrEmpty(url)) 
                return false; 
            
            WebRequest request = WebRequest.Create(url);
            request.Proxy = new WebProxy();
            try 
            { 
                HttpWebResponse res = request.GetResponse() as HttpWebResponse; 
                if (res.StatusDescription == "OK") 
                    return true; 
            } 
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            } 
            return false; 
        }

        /// <summary>
        /// The event that will fire whenever the progress of the WebClient is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // вычисляет скорость загрузки и выводит в метку
            labelSpeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));

            // обновляет progressbar только когда значение не то же самое
            progressBarDownloadFile.Value = e.ProgressPercentage;

            // отображает проценты загрузки файла
            labelPercents.Text = e.ProgressPercentage.ToString() + "%";

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            labelDownloaded.Text = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
        }

        /// <summary>
        /// The event that will trigger when the WebClient is completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // сброс stopwatch.
            sw.Reset();

            labelCurrentDownloadingFile.Text = "";
            labelLastDownloadingFile.Text = "Файл " + currentDownloadedFile + " был загружен.";

            if (!Directory.Exists(Path.GetDirectoryName(currLocation)))
                Directory.CreateDirectory(Path.GetDirectoryName(currLocation));

            File.Move(tempLocation + "\\" + currentDownloadedFile, currLocation);
            //if (e.Cancelled == true)
            //{
            //    MessageBox.Show("Download has been canceled.");
            //}
            //else
            //{
            //    MessageBox.Show("Download completed!");
            //}
        }

        private void buttonCloseForm_Click(object sender, EventArgs e)
        {
            try
            {
                DownloadedFiles downloadedFiles = Utils.Deserialize<DownloadedFiles>(downloadedFilesJsonConfigurationUri, Encoding.UTF8);
                foreach (DownloadedFiles.DownloadedFile downloadedFile in downloadedFiles.downloadedFiles)
                {
                    if (File.Exists(currentProfile.gameDirectory + downloadedFile.localRelativePath) && GetFileChecksum(currentProfile.gameDirectory + downloadedFile.localRelativePath, new MD5CryptoServiceProvider()) != downloadedFile.md5CheckSum)
                    {
                        this.formMainLauncher.allFilesWasDownloaded = false;
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                this.formMainLauncher.allFilesWasDownloaded = false;
                MessageBox.Show("Произошла ошибка при проверке файлов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void buttonCheckAndDownloadFiles_Click(object sender, EventArgs e)
        {
            buttonCheckAndDownloadFiles.Enabled = false;
            BeginDownload();
            buttonCheckAndDownloadFiles.Enabled = true;
        }
    }
}
