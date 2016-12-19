namespace DHMinecraft_Launcher_Configurator
{
    partial class FormUploadBuildToServerWithFTP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxFTPSettings = new System.Windows.Forms.GroupBox();
            this.textBoxFTPPort = new System.Windows.Forms.TextBox();
            this.textBoxFTPPassword = new System.Windows.Forms.TextBox();
            this.textBoxFTPLogin = new System.Windows.Forms.TextBox();
            this.textBoxFTPHost = new System.Windows.Forms.TextBox();
            this.checkBoxFTPPort = new System.Windows.Forms.CheckBox();
            this.checkBoxFTPPassword = new System.Windows.Forms.CheckBox();
            this.checkBoxFTPLogin = new System.Windows.Forms.CheckBox();
            this.checkBoxFTPHost = new System.Windows.Forms.CheckBox();
            this.buttonUploadBuild = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxBuildPath = new System.Windows.Forms.CheckBox();
            this.textBoxBuildPath = new System.Windows.Forms.TextBox();
            this.buttonSetBuildPath = new System.Windows.Forms.Button();
            this.statusStripUploadProgress = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxFTPSettings.SuspendLayout();
            this.statusStripUploadProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFTPSettings
            // 
            this.groupBoxFTPSettings.Controls.Add(this.textBoxFTPPort);
            this.groupBoxFTPSettings.Controls.Add(this.textBoxFTPPassword);
            this.groupBoxFTPSettings.Controls.Add(this.textBoxFTPLogin);
            this.groupBoxFTPSettings.Controls.Add(this.textBoxFTPHost);
            this.groupBoxFTPSettings.Controls.Add(this.checkBoxFTPPort);
            this.groupBoxFTPSettings.Controls.Add(this.checkBoxFTPPassword);
            this.groupBoxFTPSettings.Controls.Add(this.checkBoxFTPLogin);
            this.groupBoxFTPSettings.Controls.Add(this.checkBoxFTPHost);
            this.groupBoxFTPSettings.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFTPSettings.Name = "groupBoxFTPSettings";
            this.groupBoxFTPSettings.Size = new System.Drawing.Size(394, 133);
            this.groupBoxFTPSettings.TabIndex = 0;
            this.groupBoxFTPSettings.TabStop = false;
            this.groupBoxFTPSettings.Text = "Настройки FTP соединения";
            // 
            // textBoxFTPPort
            // 
            this.textBoxFTPPort.Location = new System.Drawing.Point(109, 104);
            this.textBoxFTPPort.Name = "textBoxFTPPort";
            this.textBoxFTPPort.Size = new System.Drawing.Size(278, 20);
            this.textBoxFTPPort.TabIndex = 1;
            // 
            // textBoxFTPPassword
            // 
            this.textBoxFTPPassword.Location = new System.Drawing.Point(109, 76);
            this.textBoxFTPPassword.Name = "textBoxFTPPassword";
            this.textBoxFTPPassword.Size = new System.Drawing.Size(278, 20);
            this.textBoxFTPPassword.TabIndex = 6;
            this.textBoxFTPPassword.UseSystemPasswordChar = true;
            // 
            // textBoxFTPLogin
            // 
            this.textBoxFTPLogin.Location = new System.Drawing.Point(109, 48);
            this.textBoxFTPLogin.Name = "textBoxFTPLogin";
            this.textBoxFTPLogin.Size = new System.Drawing.Size(278, 20);
            this.textBoxFTPLogin.TabIndex = 5;
            // 
            // textBoxFTPHost
            // 
            this.textBoxFTPHost.Location = new System.Drawing.Point(109, 20);
            this.textBoxFTPHost.Name = "textBoxFTPHost";
            this.textBoxFTPHost.Size = new System.Drawing.Size(278, 20);
            this.textBoxFTPHost.TabIndex = 4;
            // 
            // checkBoxFTPPort
            // 
            this.checkBoxFTPPort.AutoSize = true;
            this.checkBoxFTPPort.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxFTPPort.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxFTPPort.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxFTPPort.Location = new System.Drawing.Point(38, 103);
            this.checkBoxFTPPort.Name = "checkBoxFTPPort";
            this.checkBoxFTPPort.Size = new System.Drawing.Size(65, 22);
            this.checkBoxFTPPort.TabIndex = 3;
            this.checkBoxFTPPort.Text = "Порт:";
            this.checkBoxFTPPort.UseVisualStyleBackColor = false;
            this.checkBoxFTPPort.CheckedChanged += new System.EventHandler(this.checkBoxFTPPort_CheckedChanged);
            // 
            // checkBoxFTPPassword
            // 
            this.checkBoxFTPPassword.AutoSize = true;
            this.checkBoxFTPPassword.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxFTPPassword.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxFTPPassword.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxFTPPassword.Location = new System.Drawing.Point(29, 75);
            this.checkBoxFTPPassword.Name = "checkBoxFTPPassword";
            this.checkBoxFTPPassword.Size = new System.Drawing.Size(74, 22);
            this.checkBoxFTPPassword.TabIndex = 2;
            this.checkBoxFTPPassword.Text = "Пароль:";
            this.checkBoxFTPPassword.UseVisualStyleBackColor = false;
            this.checkBoxFTPPassword.CheckedChanged += new System.EventHandler(this.checkBoxFTPPassword_CheckedChanged);
            // 
            // checkBoxFTPLogin
            // 
            this.checkBoxFTPLogin.AutoSize = true;
            this.checkBoxFTPLogin.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxFTPLogin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxFTPLogin.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxFTPLogin.Location = new System.Drawing.Point(36, 47);
            this.checkBoxFTPLogin.Name = "checkBoxFTPLogin";
            this.checkBoxFTPLogin.Size = new System.Drawing.Size(67, 22);
            this.checkBoxFTPLogin.TabIndex = 1;
            this.checkBoxFTPLogin.Text = "Логин:";
            this.checkBoxFTPLogin.UseVisualStyleBackColor = false;
            this.checkBoxFTPLogin.CheckedChanged += new System.EventHandler(this.checkBoxFTPLogin_CheckedChanged);
            // 
            // checkBoxFTPHost
            // 
            this.checkBoxFTPHost.AutoSize = true;
            this.checkBoxFTPHost.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxFTPHost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxFTPHost.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxFTPHost.Location = new System.Drawing.Point(6, 19);
            this.checkBoxFTPHost.Name = "checkBoxFTPHost";
            this.checkBoxFTPHost.Size = new System.Drawing.Size(97, 22);
            this.checkBoxFTPHost.TabIndex = 0;
            this.checkBoxFTPHost.Text = "Имя хоста:";
            this.checkBoxFTPHost.UseVisualStyleBackColor = false;
            this.checkBoxFTPHost.CheckedChanged += new System.EventHandler(this.checkBoxFTPHost_CheckedChanged);
            // 
            // buttonUploadBuild
            // 
            this.buttonUploadBuild.Location = new System.Drawing.Point(85, 205);
            this.buttonUploadBuild.Name = "buttonUploadBuild";
            this.buttonUploadBuild.Size = new System.Drawing.Size(118, 23);
            this.buttonUploadBuild.TabIndex = 1;
            this.buttonUploadBuild.Text = "Загрузить";
            this.buttonUploadBuild.UseVisualStyleBackColor = true;
            this.buttonUploadBuild.Click += new System.EventHandler(this.buttonUploadBuild_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(209, 205);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(118, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxBuildPath
            // 
            this.checkBoxBuildPath.AutoSize = true;
            this.checkBoxBuildPath.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxBuildPath.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxBuildPath.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxBuildPath.Location = new System.Drawing.Point(12, 151);
            this.checkBoxBuildPath.Name = "checkBoxBuildPath";
            this.checkBoxBuildPath.Size = new System.Drawing.Size(202, 22);
            this.checkBoxBuildPath.TabIndex = 3;
            this.checkBoxBuildPath.Text = "Путь к  каталогу со сборкой:";
            this.checkBoxBuildPath.UseVisualStyleBackColor = false;
            this.checkBoxBuildPath.CheckedChanged += new System.EventHandler(this.checkBoxBuildPath_CheckedChanged);
            // 
            // textBoxBuildPath
            // 
            this.textBoxBuildPath.Location = new System.Drawing.Point(18, 179);
            this.textBoxBuildPath.Name = "textBoxBuildPath";
            this.textBoxBuildPath.Size = new System.Drawing.Size(381, 20);
            this.textBoxBuildPath.TabIndex = 4;
            // 
            // buttonSetBuildPath
            // 
            this.buttonSetBuildPath.Location = new System.Drawing.Point(220, 150);
            this.buttonSetBuildPath.Name = "buttonSetBuildPath";
            this.buttonSetBuildPath.Size = new System.Drawing.Size(91, 23);
            this.buttonSetBuildPath.TabIndex = 5;
            this.buttonSetBuildPath.Text = "Выбрать";
            this.buttonSetBuildPath.UseVisualStyleBackColor = true;
            this.buttonSetBuildPath.Click += new System.EventHandler(this.buttonSetBuildPath_Click);
            // 
            // statusStripUploadProgress
            // 
            this.statusStripUploadProgress.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelProgress});
            this.statusStripUploadProgress.Location = new System.Drawing.Point(0, 257);
            this.statusStripUploadProgress.Name = "statusStripUploadProgress";
            this.statusStripUploadProgress.Size = new System.Drawing.Size(419, 22);
            this.statusStripUploadProgress.TabIndex = 6;
            this.statusStripUploadProgress.Text = "statusStrip1";
            // 
            // toolStripStatusLabelProgress
            // 
            this.toolStripStatusLabelProgress.Name = "toolStripStatusLabelProgress";
            this.toolStripStatusLabelProgress.Size = new System.Drawing.Size(0, 17);
            // 
            // FormUploadBuildToServerWithFTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 279);
            this.Controls.Add(this.statusStripUploadProgress);
            this.Controls.Add(this.buttonSetBuildPath);
            this.Controls.Add(this.textBoxBuildPath);
            this.Controls.Add(this.checkBoxBuildPath);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonUploadBuild);
            this.Controls.Add(this.groupBoxFTPSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUploadBuildToServerWithFTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Загрузка сборки на сервер по FTP";
            this.groupBoxFTPSettings.ResumeLayout(false);
            this.groupBoxFTPSettings.PerformLayout();
            this.statusStripUploadProgress.ResumeLayout(false);
            this.statusStripUploadProgress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFTPSettings;
        private System.Windows.Forms.CheckBox checkBoxFTPPort;
        private System.Windows.Forms.CheckBox checkBoxFTPPassword;
        private System.Windows.Forms.CheckBox checkBoxFTPLogin;
        private System.Windows.Forms.CheckBox checkBoxFTPHost;
        private System.Windows.Forms.TextBox textBoxFTPPort;
        private System.Windows.Forms.TextBox textBoxFTPPassword;
        private System.Windows.Forms.TextBox textBoxFTPLogin;
        private System.Windows.Forms.TextBox textBoxFTPHost;
        private System.Windows.Forms.Button buttonUploadBuild;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxBuildPath;
        private System.Windows.Forms.TextBox textBoxBuildPath;
        private System.Windows.Forms.Button buttonSetBuildPath;
        private System.Windows.Forms.StatusStrip statusStripUploadProgress;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelProgress;
    }
}