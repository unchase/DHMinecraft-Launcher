namespace DHMinecraft_Launcher
{
    partial class FormDownloadAndUpdateFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDownloadAndUpdateFiles));
            this.progressBarDownloadFile = new System.Windows.Forms.ProgressBar();
            this.labelSpeedText = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelPercents = new System.Windows.Forms.Label();
            this.labelDownloadedText = new System.Windows.Forms.Label();
            this.labelDownloaded = new System.Windows.Forms.Label();
            this.labelLastDownloadingFile = new System.Windows.Forms.Label();
            this.labelCurrentDownloadingFile = new System.Windows.Forms.Label();
            this.buttonCloseForm = new System.Windows.Forms.Button();
            this.buttonCheckAndDownloadFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBarDownloadFile
            // 
            this.progressBarDownloadFile.Location = new System.Drawing.Point(12, 39);
            this.progressBarDownloadFile.Name = "progressBarDownloadFile";
            this.progressBarDownloadFile.Size = new System.Drawing.Size(388, 23);
            this.progressBarDownloadFile.TabIndex = 0;
            // 
            // labelSpeedText
            // 
            this.labelSpeedText.AutoSize = true;
            this.labelSpeedText.BackColor = System.Drawing.Color.Transparent;
            this.labelSpeedText.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSpeedText.Location = new System.Drawing.Point(247, 75);
            this.labelSpeedText.Name = "labelSpeedText";
            this.labelSpeedText.Size = new System.Drawing.Size(123, 18);
            this.labelSpeedText.TabIndex = 1;
            this.labelSpeedText.Text = "Скорость загрузки:";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.BackColor = System.Drawing.Color.Transparent;
            this.labelSpeed.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSpeed.Location = new System.Drawing.Point(368, 75);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(43, 18);
            this.labelSpeed.TabIndex = 2;
            this.labelSpeed.Text = "0 kb/s";
            // 
            // labelPercents
            // 
            this.labelPercents.AutoSize = true;
            this.labelPercents.BackColor = System.Drawing.Color.Transparent;
            this.labelPercents.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPercents.Location = new System.Drawing.Point(408, 44);
            this.labelPercents.Name = "labelPercents";
            this.labelPercents.Size = new System.Drawing.Size(26, 18);
            this.labelPercents.TabIndex = 3;
            this.labelPercents.Text = "0%";
            // 
            // labelDownloadedText
            // 
            this.labelDownloadedText.AutoSize = true;
            this.labelDownloadedText.BackColor = System.Drawing.Color.Transparent;
            this.labelDownloadedText.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDownloadedText.Location = new System.Drawing.Point(21, 75);
            this.labelDownloadedText.Name = "labelDownloadedText";
            this.labelDownloadedText.Size = new System.Drawing.Size(74, 18);
            this.labelDownloadedText.TabIndex = 4;
            this.labelDownloadedText.Text = "Загружено:";
            // 
            // labelDownloaded
            // 
            this.labelDownloaded.AutoSize = true;
            this.labelDownloaded.BackColor = System.Drawing.Color.Transparent;
            this.labelDownloaded.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDownloaded.Location = new System.Drawing.Point(95, 75);
            this.labelDownloaded.Name = "labelDownloaded";
            this.labelDownloaded.Size = new System.Drawing.Size(105, 18);
            this.labelDownloaded.TabIndex = 5;
            this.labelDownloaded.Text = "0 MB\'s / 0 MB\'s";
            // 
            // labelLastDownloadingFile
            // 
            this.labelLastDownloadingFile.AutoSize = true;
            this.labelLastDownloadingFile.BackColor = System.Drawing.Color.Transparent;
            this.labelLastDownloadingFile.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLastDownloadingFile.Location = new System.Drawing.Point(21, 93);
            this.labelLastDownloadingFile.Name = "labelLastDownloadingFile";
            this.labelLastDownloadingFile.Size = new System.Drawing.Size(42, 18);
            this.labelLastDownloadingFile.TabIndex = 7;
            this.labelLastDownloadingFile.Text = "Файл";
            // 
            // labelCurrentDownloadingFile
            // 
            this.labelCurrentDownloadingFile.AutoSize = true;
            this.labelCurrentDownloadingFile.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentDownloadingFile.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCurrentDownloadingFile.Location = new System.Drawing.Point(21, 18);
            this.labelCurrentDownloadingFile.Name = "labelCurrentDownloadingFile";
            this.labelCurrentDownloadingFile.Size = new System.Drawing.Size(108, 18);
            this.labelCurrentDownloadingFile.TabIndex = 8;
            this.labelCurrentDownloadingFile.Text = "Загрузка файла: ";
            // 
            // buttonCloseForm
            // 
            this.buttonCloseForm.Location = new System.Drawing.Point(222, 136);
            this.buttonCloseForm.Name = "buttonCloseForm";
            this.buttonCloseForm.Size = new System.Drawing.Size(106, 23);
            this.buttonCloseForm.TabIndex = 9;
            this.buttonCloseForm.Text = "Начать игру";
            this.buttonCloseForm.UseVisualStyleBackColor = true;
            this.buttonCloseForm.Click += new System.EventHandler(this.buttonCloseForm_Click);
            // 
            // buttonCheckAndDownloadFiles
            // 
            this.buttonCheckAndDownloadFiles.Location = new System.Drawing.Point(110, 136);
            this.buttonCheckAndDownloadFiles.Name = "buttonCheckAndDownloadFiles";
            this.buttonCheckAndDownloadFiles.Size = new System.Drawing.Size(106, 23);
            this.buttonCheckAndDownloadFiles.TabIndex = 10;
            this.buttonCheckAndDownloadFiles.Text = "Проверить";
            this.buttonCheckAndDownloadFiles.UseVisualStyleBackColor = true;
            this.buttonCheckAndDownloadFiles.Click += new System.EventHandler(this.buttonCheckAndDownloadFiles_Click);
            // 
            // FormDownloadAndUpdateFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 171);
            this.Controls.Add(this.buttonCheckAndDownloadFiles);
            this.Controls.Add(this.buttonCloseForm);
            this.Controls.Add(this.labelCurrentDownloadingFile);
            this.Controls.Add(this.labelLastDownloadingFile);
            this.Controls.Add(this.labelDownloaded);
            this.Controls.Add(this.labelDownloadedText);
            this.Controls.Add(this.labelPercents);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.labelSpeedText);
            this.Controls.Add(this.progressBarDownloadFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDownloadAndUpdateFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Обновление файлов...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarDownloadFile;
        private System.Windows.Forms.Label labelSpeedText;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelPercents;
        private System.Windows.Forms.Label labelDownloadedText;
        private System.Windows.Forms.Label labelDownloaded;
        private System.Windows.Forms.Label labelLastDownloadingFile;
        private System.Windows.Forms.Label labelCurrentDownloadingFile;
        private System.Windows.Forms.Button buttonCloseForm;
        private System.Windows.Forms.Button buttonCheckAndDownloadFiles;
    }
}