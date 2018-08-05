using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace DHMinecraft_Launcher_Configurator
{
    public partial class FormUploadBuildToServerWithFTP : Form
    {
        private int defaultPort = 21;
        private string buildName;

        public FormUploadBuildToServerWithFTP(string hostName, string buildPath, string buildName)
        {
            InitializeComponent();
            this.buildName = buildName;

            textBoxFTPHost.ReadOnly = true;
            textBoxFTPHost.Text = hostName;
            checkBoxFTPLogin.Checked = true;
            textBoxFTPLogin.ReadOnly = false;
            checkBoxFTPPassword.Checked = true;
            textBoxFTPPassword.ReadOnly = false;
            textBoxFTPPort.ReadOnly = true;
            textBoxFTPPort.Text = defaultPort.ToString();

            buttonSetBuildPath.Enabled = false;
            textBoxBuildPath.ReadOnly = true;
            textBoxBuildPath.Text = buildPath;
        }

        private void checkBoxFTPHost_CheckedChanged(object sender, EventArgs e)
        {
            textBoxFTPHost.ReadOnly = !checkBoxFTPHost.Checked;
        }

        private void checkBoxFTPLogin_CheckedChanged(object sender, EventArgs e)
        {
            textBoxFTPLogin.ReadOnly = !checkBoxFTPLogin.Checked;
        }

        private void checkBoxFTPPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxFTPPassword.ReadOnly = !checkBoxFTPPassword.Checked;
        }

        private void checkBoxFTPPort_CheckedChanged(object sender, EventArgs e)
        {
            textBoxFTPPort.ReadOnly = !checkBoxFTPPort.Checked;
        }

        private void checkBoxBuildPath_CheckedChanged(object sender, EventArgs e)
        {
            buttonSetBuildPath.Enabled = checkBoxBuildPath.Checked;
            textBoxBuildPath.ReadOnly = !checkBoxBuildPath.Checked;
        }

        private void buttonSetBuildPath_Click(object sender, EventArgs e)
        {
            var fbDialogBuildDirectory =
                new FolderBrowserDialog
                {
                    Description = @"Выберите каталог со сборкой Minecraft",
                    ShowNewFolderButton = true
                };
            //fbDialogBuildDirectory.RootFolder = Environment.SpecialFolder.ApplicationData;
            if (fbDialogBuildDirectory.ShowDialog() != DialogResult.OK) return;
            textBoxBuildPath.Text = fbDialogBuildDirectory.SelectedPath;
            MessageBox.Show("Выбрана директория со сборкой: " + textBoxBuildPath.Text, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //ToDo: !!исправить, чтобы создавались все промежуточные пути
        private void buttonUploadBuild_Click(object sender, EventArgs e)
        {
            //ToDO: сделать проверку на пустоту текстбоксов

            try
            {
                toolStripStatusLabelProgress.Text = "Загрузка файлов на сервер ...";
                if (FtpCreateFolder("/" + buildName, textBoxFTPHost.Text, textBoxFTPLogin.Text, textBoxFTPPassword.Text))
                {
                    var buildAllFiles = Utils.GetAllFiles(textBoxBuildPath.Text, "*.*", new string[1]);
                    var countOfAllFiles = buildAllFiles.Count;
                    var countOfUploadedFiles = 0;
                    foreach (var buildFile in buildAllFiles)
                    {
                        var relativeFileName = buildFile.Remove(0, textBoxBuildPath.Text.Length);
                        relativeFileName = relativeFileName.Replace("\\", "/");


                        var fi = new FileInfo(buildFile);
                        var relativeFilePath = relativeFileName.Remove(relativeFileName.Length - fi.Name.Length, fi.Name.Length);

                        FtpCreateFolder("/" + buildName + relativeFilePath, textBoxFTPHost.Text, textBoxFTPLogin.Text, textBoxFTPPassword.Text);

                        FtpUploadFile(buildFile, "/" + buildName + relativeFilePath, textBoxFTPHost.Text, textBoxFTPLogin.Text, textBoxFTPPassword.Text);

                        countOfUploadedFiles++;

                        toolStripStatusLabelProgress.Text = "Загружено " + countOfUploadedFiles + "/" + countOfAllFiles + " файлов ...";
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке файлов на ftp-сервер. Текст ошибки:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public bool FtpCreateFolder(string relativeFilePath, string ftpHostName, string ftpLogin, string ftpPassword)
        {
            try
            {
                //ToDo: добавить проверку существования папки
                var request = (FtpWebRequest)WebRequest.Create("ftp://" + ftpHostName + relativeFilePath);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(ftpLogin, ftpPassword);
                request.EnableSsl = true;
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    if (resp.StatusCode == FtpStatusCode.PathnameCreated)
                        return true;
                    else
                    {
                        MessageBox.Show("Ошибка при создании каталога на ftp-сервере: " + "ftp://" + ftpHostName + relativeFilePath + ". Вернулся сатус-код: " + resp.StatusCode.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (WebException wex)
            {
                //MessageBox.Show("Ошибка при создании каталога на ftp-сервере: " + "ftp://" + ftpHostName + relativeFilePath + ". Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return false;
                return true;
            }
        }

        public bool FtpUploadFile(string filename, string relativeFilePath, string ftpHostName, string ftpLogin, string ftpPassword)
        {
            var fileInf = new FileInfo(filename);
            var reqFTP = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + ftpHostName + relativeFilePath + fileInf.Name));
            reqFTP.Credentials = new NetworkCredential(ftpLogin, ftpPassword);
            reqFTP.EnableSsl = true;
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            var buffLength = 2048;
            var buff = new byte[buffLength];
            var fs = fileInf.OpenRead();
            try
            {
                var strm = reqFTP.GetRequestStream();
                var contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке файла: " + fileInf.FullName + ". Текст ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
