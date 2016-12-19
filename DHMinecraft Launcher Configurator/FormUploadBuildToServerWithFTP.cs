using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
            FolderBrowserDialog fbDialogBuildDirectory = new FolderBrowserDialog();
            fbDialogBuildDirectory.Description = "Выберите каталог со сборкой Minecraft";
            //fbDialogBuildDirectory.RootFolder = Environment.SpecialFolder.ApplicationData;
            fbDialogBuildDirectory.ShowNewFolderButton = true;
            if (fbDialogBuildDirectory.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxBuildPath.Text = fbDialogBuildDirectory.SelectedPath;
                MessageBox.Show("Выбрана директория со сборкой: " + textBoxBuildPath.Text, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    List<string> buildAllFiles = Utils.GetAllFiles(textBoxBuildPath.Text, "*.*", new string[1]);
                    int countOfAllFiles = buildAllFiles.Count;
                    int countOfUploadedFiles = 0;
                    foreach (string buildFile in buildAllFiles)
                    {
                        string relativeFileName = buildFile.Remove(0, textBoxBuildPath.Text.Length);
                        relativeFileName = relativeFileName.Replace("\\", "/");


                        FileInfo fi = new FileInfo(buildFile);
                        string relativeFilePath = relativeFileName.Remove(relativeFileName.Length - fi.Name.Length, fi.Name.Length);

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
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + ftpHostName + relativeFilePath);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(ftpLogin, ftpPassword);
                request.EnableSsl = true;
                using (FtpWebResponse resp = (FtpWebResponse)request.GetResponse())
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
            FileInfo fileInf = new FileInfo(filename);
            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpHostName + relativeFilePath + fileInf.Name));
            reqFTP.Credentials = new NetworkCredential(ftpLogin, ftpPassword);
            reqFTP.EnableSsl = true;
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
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
