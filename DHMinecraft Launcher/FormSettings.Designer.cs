namespace DHMinecraft_Launcher
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.checkBoxProfile = new System.Windows.Forms.CheckBox();
            this.checkBoxGameDirectory = new System.Windows.Forms.CheckBox();
            this.checkBoxResolution = new System.Windows.Forms.CheckBox();
            this.checkBoxUsageMemory = new System.Windows.Forms.CheckBox();
            this.checkBoxExecutableJava = new System.Windows.Forms.CheckBox();
            this.checkBoxJVMArguments = new System.Windows.Forms.CheckBox();
            this.textBoxGameDirectory = new System.Windows.Forms.TextBox();
            this.textBoxWidthResolution = new System.Windows.Forms.TextBox();
            this.textBoxHeightResolution = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.textBoxUsageMemory = new System.Windows.Forms.TextBox();
            this.labelMB = new System.Windows.Forms.Label();
            this.textBoxExecutableJava = new System.Windows.Forms.TextBox();
            this.textBoxJVMArguments = new System.Windows.Forms.TextBox();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.buttonCancleSettings = new System.Windows.Forms.Button();
            this.buttonSelectGameDirectory = new System.Windows.Forms.Button();
            this.buttonSelectExecutableJava = new System.Windows.Forms.Button();
            this.textBoxProfile = new System.Windows.Forms.TextBox();
            this.comboBoxServersNames = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // checkBoxProfile
            // 
            this.checkBoxProfile.AutoSize = true;
            this.checkBoxProfile.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxProfile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxProfile.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxProfile.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.checkBoxProfile.Location = new System.Drawing.Point(122, 29);
            this.checkBoxProfile.Name = "checkBoxProfile";
            this.checkBoxProfile.Size = new System.Drawing.Size(81, 22);
            this.checkBoxProfile.TabIndex = 7;
            this.checkBoxProfile.Text = "Профиль";
            this.checkBoxProfile.UseVisualStyleBackColor = false;
            this.checkBoxProfile.CheckedChanged += new System.EventHandler(this.checkBoxProfile_CheckedChanged);
            // 
            // checkBoxGameDirectory
            // 
            this.checkBoxGameDirectory.AutoSize = true;
            this.checkBoxGameDirectory.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxGameDirectory.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxGameDirectory.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxGameDirectory.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.checkBoxGameDirectory.Location = new System.Drawing.Point(52, 56);
            this.checkBoxGameDirectory.Name = "checkBoxGameDirectory";
            this.checkBoxGameDirectory.Size = new System.Drawing.Size(151, 22);
            this.checkBoxGameDirectory.TabIndex = 8;
            this.checkBoxGameDirectory.Text = "Директория с игрой";
            this.checkBoxGameDirectory.UseVisualStyleBackColor = false;
            this.checkBoxGameDirectory.CheckedChanged += new System.EventHandler(this.checkBoxGameDirectory_CheckedChanged);
            // 
            // checkBoxResolution
            // 
            this.checkBoxResolution.AutoSize = true;
            this.checkBoxResolution.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxResolution.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxResolution.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxResolution.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.checkBoxResolution.Location = new System.Drawing.Point(63, 82);
            this.checkBoxResolution.Name = "checkBoxResolution";
            this.checkBoxResolution.Size = new System.Drawing.Size(140, 22);
            this.checkBoxResolution.TabIndex = 9;
            this.checkBoxResolution.Text = "Разрешение экрана";
            this.checkBoxResolution.UseVisualStyleBackColor = false;
            this.checkBoxResolution.CheckedChanged += new System.EventHandler(this.checkBoxResolution_CheckedChanged);
            // 
            // checkBoxUsageMemory
            // 
            this.checkBoxUsageMemory.AutoSize = true;
            this.checkBoxUsageMemory.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxUsageMemory.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxUsageMemory.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxUsageMemory.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.checkBoxUsageMemory.Location = new System.Drawing.Point(12, 108);
            this.checkBoxUsageMemory.Name = "checkBoxUsageMemory";
            this.checkBoxUsageMemory.Size = new System.Drawing.Size(191, 22);
            this.checkBoxUsageMemory.TabIndex = 10;
            this.checkBoxUsageMemory.Text = "Используемая Java память";
            this.checkBoxUsageMemory.UseVisualStyleBackColor = false;
            this.checkBoxUsageMemory.CheckedChanged += new System.EventHandler(this.checkBoxUsageMemory_CheckedChanged);
            // 
            // checkBoxExecutableJava
            // 
            this.checkBoxExecutableJava.AutoSize = true;
            this.checkBoxExecutableJava.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxExecutableJava.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxExecutableJava.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxExecutableJava.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.checkBoxExecutableJava.Location = new System.Drawing.Point(28, 134);
            this.checkBoxExecutableJava.Name = "checkBoxExecutableJava";
            this.checkBoxExecutableJava.Size = new System.Drawing.Size(175, 22);
            this.checkBoxExecutableJava.TabIndex = 11;
            this.checkBoxExecutableJava.Text = "Исполняемый файл Java";
            this.checkBoxExecutableJava.UseVisualStyleBackColor = false;
            this.checkBoxExecutableJava.CheckedChanged += new System.EventHandler(this.checkBoxExecutableJava_CheckedChanged);
            // 
            // checkBoxJVMArguments
            // 
            this.checkBoxJVMArguments.AutoSize = true;
            this.checkBoxJVMArguments.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxJVMArguments.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxJVMArguments.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxJVMArguments.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.checkBoxJVMArguments.Location = new System.Drawing.Point(71, 160);
            this.checkBoxJVMArguments.Name = "checkBoxJVMArguments";
            this.checkBoxJVMArguments.Size = new System.Drawing.Size(132, 22);
            this.checkBoxJVMArguments.TabIndex = 12;
            this.checkBoxJVMArguments.Text = "Аргументы JVM";
            this.checkBoxJVMArguments.UseVisualStyleBackColor = false;
            this.checkBoxJVMArguments.CheckedChanged += new System.EventHandler(this.checkBoxJVMArguments_CheckedChanged);
            // 
            // textBoxGameDirectory
            // 
            this.textBoxGameDirectory.BackColor = System.Drawing.Color.LightBlue;
            this.textBoxGameDirectory.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxGameDirectory.Location = new System.Drawing.Point(220, 54);
            this.textBoxGameDirectory.Name = "textBoxGameDirectory";
            this.textBoxGameDirectory.Size = new System.Drawing.Size(143, 25);
            this.textBoxGameDirectory.TabIndex = 13;
            // 
            // textBoxWidthResolution
            // 
            this.textBoxWidthResolution.BackColor = System.Drawing.Color.LightBlue;
            this.textBoxWidthResolution.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxWidthResolution.Location = new System.Drawing.Point(220, 80);
            this.textBoxWidthResolution.Name = "textBoxWidthResolution";
            this.textBoxWidthResolution.Size = new System.Drawing.Size(57, 25);
            this.textBoxWidthResolution.TabIndex = 14;
            // 
            // textBoxHeightResolution
            // 
            this.textBoxHeightResolution.BackColor = System.Drawing.Color.LightBlue;
            this.textBoxHeightResolution.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxHeightResolution.Location = new System.Drawing.Point(306, 79);
            this.textBoxHeightResolution.Name = "textBoxHeightResolution";
            this.textBoxHeightResolution.Size = new System.Drawing.Size(57, 25);
            this.textBoxHeightResolution.TabIndex = 15;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.BackColor = System.Drawing.Color.Transparent;
            this.labelX.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.labelX.Location = new System.Drawing.Point(283, 83);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(17, 18);
            this.labelX.TabIndex = 16;
            this.labelX.Text = "X";
            // 
            // textBoxUsageMemory
            // 
            this.textBoxUsageMemory.BackColor = System.Drawing.Color.LightBlue;
            this.textBoxUsageMemory.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUsageMemory.Location = new System.Drawing.Point(220, 106);
            this.textBoxUsageMemory.Name = "textBoxUsageMemory";
            this.textBoxUsageMemory.Size = new System.Drawing.Size(57, 25);
            this.textBoxUsageMemory.TabIndex = 17;
            // 
            // labelMB
            // 
            this.labelMB.AutoSize = true;
            this.labelMB.BackColor = System.Drawing.Color.Transparent;
            this.labelMB.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMB.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.labelMB.Location = new System.Drawing.Point(279, 109);
            this.labelMB.Name = "labelMB";
            this.labelMB.Size = new System.Drawing.Size(31, 18);
            this.labelMB.TabIndex = 18;
            this.labelMB.Text = "MB";
            // 
            // textBoxExecutableJava
            // 
            this.textBoxExecutableJava.BackColor = System.Drawing.Color.LightBlue;
            this.textBoxExecutableJava.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxExecutableJava.Location = new System.Drawing.Point(220, 132);
            this.textBoxExecutableJava.Name = "textBoxExecutableJava";
            this.textBoxExecutableJava.Size = new System.Drawing.Size(143, 25);
            this.textBoxExecutableJava.TabIndex = 19;
            // 
            // textBoxJVMArguments
            // 
            this.textBoxJVMArguments.BackColor = System.Drawing.Color.LightBlue;
            this.textBoxJVMArguments.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxJVMArguments.Location = new System.Drawing.Point(220, 158);
            this.textBoxJVMArguments.Name = "textBoxJVMArguments";
            this.textBoxJVMArguments.Size = new System.Drawing.Size(210, 25);
            this.textBoxJVMArguments.TabIndex = 20;
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.BackgroundImage = global::DHMinecraft_Launcher.Properties.Resources.DHMinecraftLauncherSettingsBigButtonBackground;
            this.buttonSaveSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSaveSettings.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveSettings.Location = new System.Drawing.Point(106, 218);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(120, 35);
            this.buttonSaveSettings.TabIndex = 21;
            this.buttonSaveSettings.Text = "Сохранить";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // buttonCancleSettings
            // 
            this.buttonCancleSettings.BackgroundImage = global::DHMinecraft_Launcher.Properties.Resources.DHMinecraftLauncherSettingsBigButtonBackground;
            this.buttonCancleSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCancleSettings.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancleSettings.Location = new System.Drawing.Point(238, 218);
            this.buttonCancleSettings.Name = "buttonCancleSettings";
            this.buttonCancleSettings.Size = new System.Drawing.Size(120, 35);
            this.buttonCancleSettings.TabIndex = 22;
            this.buttonCancleSettings.Text = "Отмена";
            this.buttonCancleSettings.UseVisualStyleBackColor = true;
            this.buttonCancleSettings.Click += new System.EventHandler(this.buttonCancleSettings_Click);
            // 
            // buttonSelectGameDirectory
            // 
            this.buttonSelectGameDirectory.BackgroundImage = global::DHMinecraft_Launcher.Properties.Resources.DHMinecraftLauncherSettingsSmallButtonBackground;
            this.buttonSelectGameDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSelectGameDirectory.Font = new System.Drawing.Font("Monotype Corsiva", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelectGameDirectory.Location = new System.Drawing.Point(369, 55);
            this.buttonSelectGameDirectory.Name = "buttonSelectGameDirectory";
            this.buttonSelectGameDirectory.Size = new System.Drawing.Size(61, 23);
            this.buttonSelectGameDirectory.TabIndex = 23;
            this.buttonSelectGameDirectory.Text = "Выбрать";
            this.buttonSelectGameDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectGameDirectory.Click += new System.EventHandler(this.buttonSelectGameDirectory_Click);
            // 
            // buttonSelectExecutableJava
            // 
            this.buttonSelectExecutableJava.BackgroundImage = global::DHMinecraft_Launcher.Properties.Resources.DHMinecraftLauncherSettingsSmallButtonBackground;
            this.buttonSelectExecutableJava.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSelectExecutableJava.Font = new System.Drawing.Font("Monotype Corsiva", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelectExecutableJava.Location = new System.Drawing.Point(369, 133);
            this.buttonSelectExecutableJava.Name = "buttonSelectExecutableJava";
            this.buttonSelectExecutableJava.Size = new System.Drawing.Size(61, 23);
            this.buttonSelectExecutableJava.TabIndex = 24;
            this.buttonSelectExecutableJava.Text = "Выбрать";
            this.buttonSelectExecutableJava.UseVisualStyleBackColor = true;
            this.buttonSelectExecutableJava.Click += new System.EventHandler(this.buttonSelectExecutableJava_Click);
            // 
            // textBoxProfile
            // 
            this.textBoxProfile.BackColor = System.Drawing.Color.LightBlue;
            this.textBoxProfile.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProfile.Location = new System.Drawing.Point(220, 27);
            this.textBoxProfile.Name = "textBoxProfile";
            this.textBoxProfile.Size = new System.Drawing.Size(210, 25);
            this.textBoxProfile.TabIndex = 25;
            // 
            // comboBoxServersNames
            // 
            this.comboBoxServersNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServersNames.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxServersNames.FormattingEnabled = true;
            this.comboBoxServersNames.Location = new System.Drawing.Point(219, 184);
            this.comboBoxServersNames.Name = "comboBoxServersNames";
            this.comboBoxServersNames.Size = new System.Drawing.Size(211, 26);
            this.comboBoxServersNames.TabIndex = 26;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DHMinecraft_Launcher.Properties.Resources.DHMinecraftLauncherSettingsBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(469, 262);
            this.Controls.Add(this.comboBoxServersNames);
            this.Controls.Add(this.textBoxProfile);
            this.Controls.Add(this.buttonSelectExecutableJava);
            this.Controls.Add(this.buttonSelectGameDirectory);
            this.Controls.Add(this.buttonCancleSettings);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.textBoxJVMArguments);
            this.Controls.Add(this.textBoxExecutableJava);
            this.Controls.Add(this.labelMB);
            this.Controls.Add(this.textBoxUsageMemory);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.textBoxHeightResolution);
            this.Controls.Add(this.textBoxWidthResolution);
            this.Controls.Add(this.textBoxGameDirectory);
            this.Controls.Add(this.checkBoxJVMArguments);
            this.Controls.Add(this.checkBoxExecutableJava);
            this.Controls.Add(this.checkBoxUsageMemory);
            this.Controls.Add(this.checkBoxResolution);
            this.Controls.Add(this.checkBoxGameDirectory);
            this.Controls.Add(this.checkBoxProfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки профилей DHMinecraft Launcher";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxProfile;
        private System.Windows.Forms.CheckBox checkBoxGameDirectory;
        private System.Windows.Forms.CheckBox checkBoxResolution;
        private System.Windows.Forms.CheckBox checkBoxUsageMemory;
        private System.Windows.Forms.CheckBox checkBoxExecutableJava;
        private System.Windows.Forms.CheckBox checkBoxJVMArguments;
        private System.Windows.Forms.TextBox textBoxGameDirectory;
        private System.Windows.Forms.TextBox textBoxWidthResolution;
        private System.Windows.Forms.TextBox textBoxHeightResolution;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.TextBox textBoxUsageMemory;
        private System.Windows.Forms.Label labelMB;
        private System.Windows.Forms.TextBox textBoxExecutableJava;
        private System.Windows.Forms.TextBox textBoxJVMArguments;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.Button buttonCancleSettings;
        private System.Windows.Forms.Button buttonSelectGameDirectory;
        private System.Windows.Forms.Button buttonSelectExecutableJava;
        private System.Windows.Forms.TextBox textBoxProfile;
        private System.Windows.Forms.ComboBox comboBoxServersNames;
    }
}