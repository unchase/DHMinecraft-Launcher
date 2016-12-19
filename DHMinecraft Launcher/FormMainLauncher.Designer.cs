namespace DHMinecraft_Launcher
{
    partial class FormMainLauncher
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainLauncher));
            this.alphaBlendTextBoxLogin = new ZBobb.AlphaBlendTextBox();
            this.alphaBlendTextBoxPassword = new ZBobb.AlphaBlendTextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.checkBoxRememberPassword = new System.Windows.Forms.CheckBox();
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.webBrowserNews = new System.Windows.Forms.WebBrowser();
            this.labelMainInfo = new System.Windows.Forms.Label();
            this.linkLabelSite = new System.Windows.Forms.LinkLabel();
            this.linkLabelRegister = new System.Windows.Forms.LinkLabel();
            this.linkLabelHowToStart = new System.Windows.Forms.LinkLabel();
            this.linkLabelRules = new System.Windows.Forms.LinkLabel();
            this.linkLabelForum = new System.Windows.Forms.LinkLabel();
            this.labelServices = new System.Windows.Forms.Label();
            this.linkLabelDonate = new System.Windows.Forms.LinkLabel();
            this.linkLabelVote = new System.Windows.Forms.LinkLabel();
            this.labelHello = new System.Windows.Forms.Label();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.pictureBoxSkin = new System.Windows.Forms.PictureBox();
            this.buttonMainSettings = new System.Windows.Forms.Button();
            this.buttonRunGame = new System.Windows.Forms.Button();
            this.comboBoxProfilesMain = new System.Windows.Forms.ComboBox();
            this.labelProfileMain = new System.Windows.Forms.Label();
            this.checkBoxOfflineMode = new System.Windows.Forms.CheckBox();
            this.pictureBoxSiteURLQRCode = new System.Windows.Forms.PictureBox();
            this.checkBoxShowRunLog = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSiteURLQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // alphaBlendTextBoxLogin
            // 
            this.alphaBlendTextBoxLogin.BackAlpha = 10;
            this.alphaBlendTextBoxLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.alphaBlendTextBoxLogin.Font = new System.Drawing.Font("OpenSymbol", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alphaBlendTextBoxLogin.Location = new System.Drawing.Point(66, 323);
            this.alphaBlendTextBoxLogin.Name = "alphaBlendTextBoxLogin";
            this.alphaBlendTextBoxLogin.Size = new System.Drawing.Size(128, 27);
            this.alphaBlendTextBoxLogin.TabIndex = 1;
            // 
            // alphaBlendTextBoxPassword
            // 
            this.alphaBlendTextBoxPassword.BackAlpha = 10;
            this.alphaBlendTextBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.alphaBlendTextBoxPassword.Font = new System.Drawing.Font("OpenSymbol", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alphaBlendTextBoxPassword.Location = new System.Drawing.Point(66, 354);
            this.alphaBlendTextBoxPassword.Name = "alphaBlendTextBoxPassword";
            this.alphaBlendTextBoxPassword.PasswordChar = '*';
            this.alphaBlendTextBoxPassword.Size = new System.Drawing.Size(128, 27);
            this.alphaBlendTextBoxPassword.TabIndex = 2;
            this.alphaBlendTextBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.Transparent;
            this.labelLogin.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogin.Location = new System.Drawing.Point(12, 330);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(48, 18);
            this.labelLogin.TabIndex = 3;
            this.labelLogin.Text = "Логин:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.Location = new System.Drawing.Point(12, 358);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(55, 18);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Пароль:";
            // 
            // checkBoxRememberPassword
            // 
            this.checkBoxRememberPassword.AutoSize = true;
            this.checkBoxRememberPassword.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxRememberPassword.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxRememberPassword.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxRememberPassword.Location = new System.Drawing.Point(82, 383);
            this.checkBoxRememberPassword.Name = "checkBoxRememberPassword";
            this.checkBoxRememberPassword.Size = new System.Drawing.Size(95, 22);
            this.checkBoxRememberPassword.TabIndex = 5;
            this.checkBoxRememberPassword.Text = "Запомнить";
            this.checkBoxRememberPassword.UseVisualStyleBackColor = false;
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServer.DropDownWidth = 188;
            this.comboBoxServer.Font = new System.Drawing.Font("Monotype Corsiva", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxServer.ForeColor = System.Drawing.Color.Red;
            this.comboBoxServer.FormattingEnabled = true;
            this.comboBoxServer.Location = new System.Drawing.Point(271, 324);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.Size = new System.Drawing.Size(94, 23);
            this.comboBoxServer.Sorted = true;
            this.comboBoxServer.TabIndex = 7;
            this.comboBoxServer.SelectedIndexChanged += new System.EventHandler(this.comboBoxServer_SelectedIndexChanged);
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.BackColor = System.Drawing.Color.Transparent;
            this.labelServer.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelServer.Location = new System.Drawing.Point(200, 325);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(52, 18);
            this.labelServer.TabIndex = 8;
            this.labelServer.Text = "Сервер:";
            // 
            // webBrowserNews
            // 
            this.webBrowserNews.AllowNavigation = false;
            this.webBrowserNews.AllowWebBrowserDrop = false;
            this.webBrowserNews.Location = new System.Drawing.Point(12, 104);
            this.webBrowserNews.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserNews.Name = "webBrowserNews";
            this.webBrowserNews.Size = new System.Drawing.Size(505, 201);
            this.webBrowserNews.TabIndex = 10;
            this.webBrowserNews.WebBrowserShortcutsEnabled = false;
            // 
            // labelMainInfo
            // 
            this.labelMainInfo.AutoSize = true;
            this.labelMainInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelMainInfo.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMainInfo.Location = new System.Drawing.Point(555, 14);
            this.labelMainInfo.Name = "labelMainInfo";
            this.labelMainInfo.Size = new System.Drawing.Size(122, 25);
            this.labelMainInfo.TabIndex = 11;
            this.labelMainInfo.Text = "Информация:";
            // 
            // linkLabelSite
            // 
            this.linkLabelSite.AutoSize = true;
            this.linkLabelSite.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelSite.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelSite.LinkColor = System.Drawing.Color.Moccasin;
            this.linkLabelSite.Location = new System.Drawing.Point(564, 43);
            this.linkLabelSite.Name = "linkLabelSite";
            this.linkLabelSite.Size = new System.Drawing.Size(98, 18);
            this.linkLabelSite.TabIndex = 12;
            this.linkLabelSite.TabStop = true;
            this.linkLabelSite.Text = "Зайти на сайт";
            this.linkLabelSite.VisitedLinkColor = System.Drawing.Color.SaddleBrown;
            this.linkLabelSite.Click += new System.EventHandler(this.linkLabelSite_Click);
            // 
            // linkLabelRegister
            // 
            this.linkLabelRegister.AutoSize = true;
            this.linkLabelRegister.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelRegister.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelRegister.LinkColor = System.Drawing.Color.Moccasin;
            this.linkLabelRegister.Location = new System.Drawing.Point(548, 64);
            this.linkLabelRegister.Name = "linkLabelRegister";
            this.linkLabelRegister.Size = new System.Drawing.Size(131, 18);
            this.linkLabelRegister.TabIndex = 13;
            this.linkLabelRegister.TabStop = true;
            this.linkLabelRegister.Text = "Зарегистрироваться";
            this.linkLabelRegister.VisitedLinkColor = System.Drawing.Color.SaddleBrown;
            this.linkLabelRegister.Click += new System.EventHandler(this.linkLabelRegister_Click);
            // 
            // linkLabelHowToStart
            // 
            this.linkLabelHowToStart.AutoSize = true;
            this.linkLabelHowToStart.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelHowToStart.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelHowToStart.LinkColor = System.Drawing.Color.Moccasin;
            this.linkLabelHowToStart.Location = new System.Drawing.Point(574, 88);
            this.linkLabelHowToStart.Name = "linkLabelHowToStart";
            this.linkLabelHowToStart.Size = new System.Drawing.Size(78, 18);
            this.linkLabelHowToStart.TabIndex = 14;
            this.linkLabelHowToStart.TabStop = true;
            this.linkLabelHowToStart.Text = "Как начать";
            this.linkLabelHowToStart.VisitedLinkColor = System.Drawing.Color.SaddleBrown;
            this.linkLabelHowToStart.Click += new System.EventHandler(this.linkLabelHowToStart_Click);
            // 
            // linkLabelRules
            // 
            this.linkLabelRules.AutoSize = true;
            this.linkLabelRules.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelRules.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelRules.LinkColor = System.Drawing.Color.Moccasin;
            this.linkLabelRules.Location = new System.Drawing.Point(548, 109);
            this.linkLabelRules.Name = "linkLabelRules";
            this.linkLabelRules.Size = new System.Drawing.Size(130, 18);
            this.linkLabelRules.TabIndex = 15;
            this.linkLabelRules.TabStop = true;
            this.linkLabelRules.Text = "Прочитать правила";
            this.linkLabelRules.VisitedLinkColor = System.Drawing.Color.SaddleBrown;
            this.linkLabelRules.Click += new System.EventHandler(this.linkLabelRules_Click);
            // 
            // linkLabelForum
            // 
            this.linkLabelForum.AutoSize = true;
            this.linkLabelForum.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelForum.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelForum.LinkColor = System.Drawing.Color.Moccasin;
            this.linkLabelForum.Location = new System.Drawing.Point(560, 134);
            this.linkLabelForum.Name = "linkLabelForum";
            this.linkLabelForum.Size = new System.Drawing.Size(108, 18);
            this.linkLabelForum.TabIndex = 16;
            this.linkLabelForum.TabStop = true;
            this.linkLabelForum.Text = "Зайти на форум";
            this.linkLabelForum.VisitedLinkColor = System.Drawing.Color.SaddleBrown;
            this.linkLabelForum.Click += new System.EventHandler(this.linkLabelForum_Click);
            // 
            // labelServices
            // 
            this.labelServices.AutoSize = true;
            this.labelServices.BackColor = System.Drawing.Color.Transparent;
            this.labelServices.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelServices.Location = new System.Drawing.Point(574, 159);
            this.labelServices.Name = "labelServices";
            this.labelServices.Size = new System.Drawing.Size(82, 25);
            this.labelServices.TabIndex = 17;
            this.labelServices.Text = "Сервисы:";
            // 
            // linkLabelDonate
            // 
            this.linkLabelDonate.AutoSize = true;
            this.linkLabelDonate.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelDonate.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelDonate.LinkColor = System.Drawing.Color.Lime;
            this.linkLabelDonate.Location = new System.Drawing.Point(590, 186);
            this.linkLabelDonate.Name = "linkLabelDonate";
            this.linkLabelDonate.Size = new System.Drawing.Size(48, 18);
            this.linkLabelDonate.TabIndex = 18;
            this.linkLabelDonate.TabStop = true;
            this.linkLabelDonate.Text = "Донат";
            this.linkLabelDonate.VisitedLinkColor = System.Drawing.Color.LimeGreen;
            this.linkLabelDonate.Click += new System.EventHandler(this.linkLabelDonate_Click);
            // 
            // linkLabelVote
            // 
            this.linkLabelVote.AutoSize = true;
            this.linkLabelVote.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelVote.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelVote.LinkColor = System.Drawing.Color.Lime;
            this.linkLabelVote.Location = new System.Drawing.Point(578, 209);
            this.linkLabelVote.Name = "linkLabelVote";
            this.linkLabelVote.Size = new System.Drawing.Size(75, 18);
            this.linkLabelVote.TabIndex = 19;
            this.linkLabelVote.TabStop = true;
            this.linkLabelVote.Text = "Голосовать";
            this.linkLabelVote.VisitedLinkColor = System.Drawing.Color.LimeGreen;
            this.linkLabelVote.Click += new System.EventHandler(this.linkLabelVote_Click);
            // 
            // labelHello
            // 
            this.labelHello.AutoSize = true;
            this.labelHello.BackColor = System.Drawing.Color.Transparent;
            this.labelHello.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHello.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelHello.Location = new System.Drawing.Point(12, 38);
            this.labelHello.Name = "labelHello";
            this.labelHello.Size = new System.Drawing.Size(0, 25);
            this.labelHello.TabIndex = 22;
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLogIn.BackgroundImage")));
            this.buttonLogIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLogIn.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogIn.Location = new System.Drawing.Point(371, 317);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(160, 70);
            this.buttonLogIn.TabIndex = 21;
            this.buttonLogIn.Text = "Войти";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // pictureBoxSkin
            // 
            this.pictureBoxSkin.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSkin.BackgroundImage = global::DHMinecraft_Launcher.Properties.Resources.DHMinecraftSkinBackground;
            this.pictureBoxSkin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxSkin.ErrorImage = global::DHMinecraft_Launcher.Properties.Resources.DHMinecraftSkinNothing;
            this.pictureBoxSkin.InitialImage = global::DHMinecraft_Launcher.Properties.Resources.DHMinecraftSkinLoading;
            this.pictureBoxSkin.Location = new System.Drawing.Point(431, 12);
            this.pictureBoxSkin.Name = "pictureBoxSkin";
            this.pictureBoxSkin.Size = new System.Drawing.Size(86, 86);
            this.pictureBoxSkin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSkin.TabIndex = 20;
            this.pictureBoxSkin.TabStop = false;
            // 
            // buttonMainSettings
            // 
            this.buttonMainSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMainSettings.BackgroundImage")));
            this.buttonMainSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMainSettings.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMainSettings.Location = new System.Drawing.Point(537, 235);
            this.buttonMainSettings.Name = "buttonMainSettings";
            this.buttonMainSettings.Size = new System.Drawing.Size(160, 70);
            this.buttonMainSettings.TabIndex = 9;
            this.buttonMainSettings.Text = "Настройки";
            this.buttonMainSettings.UseVisualStyleBackColor = true;
            this.buttonMainSettings.Click += new System.EventHandler(this.buttonMainSettings_Click);
            // 
            // buttonRunGame
            // 
            this.buttonRunGame.BackColor = System.Drawing.Color.Transparent;
            this.buttonRunGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRunGame.BackgroundImage")));
            this.buttonRunGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRunGame.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRunGame.Location = new System.Drawing.Point(537, 317);
            this.buttonRunGame.Name = "buttonRunGame";
            this.buttonRunGame.Size = new System.Drawing.Size(160, 70);
            this.buttonRunGame.TabIndex = 6;
            this.buttonRunGame.Text = "Играть";
            this.buttonRunGame.UseVisualStyleBackColor = false;
            this.buttonRunGame.Click += new System.EventHandler(this.buttonRunGame_Click);
            // 
            // comboBoxProfilesMain
            // 
            this.comboBoxProfilesMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProfilesMain.DropDownWidth = 188;
            this.comboBoxProfilesMain.Font = new System.Drawing.Font("Monotype Corsiva", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxProfilesMain.FormattingEnabled = true;
            this.comboBoxProfilesMain.Location = new System.Drawing.Point(271, 355);
            this.comboBoxProfilesMain.Name = "comboBoxProfilesMain";
            this.comboBoxProfilesMain.Size = new System.Drawing.Size(94, 23);
            this.comboBoxProfilesMain.TabIndex = 23;
            this.comboBoxProfilesMain.SelectedIndexChanged += new System.EventHandler(this.comboBoxProfilesMain_SelectedIndexChanged);
            // 
            // labelProfileMain
            // 
            this.labelProfileMain.AutoSize = true;
            this.labelProfileMain.BackColor = System.Drawing.Color.Transparent;
            this.labelProfileMain.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProfileMain.Location = new System.Drawing.Point(200, 358);
            this.labelProfileMain.Name = "labelProfileMain";
            this.labelProfileMain.Size = new System.Drawing.Size(66, 18);
            this.labelProfileMain.TabIndex = 24;
            this.labelProfileMain.Text = "Профиль:";
            // 
            // checkBoxOfflineMode
            // 
            this.checkBoxOfflineMode.AutoSize = true;
            this.checkBoxOfflineMode.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxOfflineMode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxOfflineMode.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxOfflineMode.Location = new System.Drawing.Point(576, 386);
            this.checkBoxOfflineMode.Name = "checkBoxOfflineMode";
            this.checkBoxOfflineMode.Size = new System.Drawing.Size(83, 22);
            this.checkBoxOfflineMode.TabIndex = 25;
            this.checkBoxOfflineMode.Text = "Оффлайн";
            this.checkBoxOfflineMode.UseVisualStyleBackColor = false;
            this.checkBoxOfflineMode.CheckedChanged += new System.EventHandler(this.checkBoxOfflineMode_CheckedChanged);
            // 
            // pictureBoxSiteURLQRCode
            // 
            this.pictureBoxSiteURLQRCode.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSiteURLQRCode.Location = new System.Drawing.Point(339, 12);
            this.pictureBoxSiteURLQRCode.Name = "pictureBoxSiteURLQRCode";
            this.pictureBoxSiteURLQRCode.Size = new System.Drawing.Size(86, 86);
            this.pictureBoxSiteURLQRCode.TabIndex = 26;
            this.pictureBoxSiteURLQRCode.TabStop = false;
            // 
            // checkBoxShowRunLog
            // 
            this.checkBoxShowRunLog.AutoSize = true;
            this.checkBoxShowRunLog.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxShowRunLog.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxShowRunLog.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxShowRunLog.Location = new System.Drawing.Point(362, 387);
            this.checkBoxShowRunLog.Name = "checkBoxShowRunLog";
            this.checkBoxShowRunLog.Size = new System.Drawing.Size(171, 22);
            this.checkBoxShowRunLog.TabIndex = 27;
            this.checkBoxShowRunLog.Text = "Показывать лог запуска";
            this.checkBoxShowRunLog.UseVisualStyleBackColor = false;
            // 
            // FormMainLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(704, 412);
            this.Controls.Add(this.checkBoxShowRunLog);
            this.Controls.Add(this.pictureBoxSiteURLQRCode);
            this.Controls.Add(this.checkBoxOfflineMode);
            this.Controls.Add(this.labelProfileMain);
            this.Controls.Add(this.comboBoxProfilesMain);
            this.Controls.Add(this.labelHello);
            this.Controls.Add(this.buttonLogIn);
            this.Controls.Add(this.pictureBoxSkin);
            this.Controls.Add(this.linkLabelVote);
            this.Controls.Add(this.linkLabelDonate);
            this.Controls.Add(this.labelServices);
            this.Controls.Add(this.linkLabelForum);
            this.Controls.Add(this.linkLabelRules);
            this.Controls.Add(this.linkLabelHowToStart);
            this.Controls.Add(this.linkLabelRegister);
            this.Controls.Add(this.linkLabelSite);
            this.Controls.Add(this.labelMainInfo);
            this.Controls.Add(this.webBrowserNews);
            this.Controls.Add(this.buttonMainSettings);
            this.Controls.Add(this.labelServer);
            this.Controls.Add(this.comboBoxServer);
            this.Controls.Add(this.buttonRunGame);
            this.Controls.Add(this.checkBoxRememberPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.alphaBlendTextBoxPassword);
            this.Controls.Add(this.alphaBlendTextBoxLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMainLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DHMinecraft Launcher";
            this.Load += new System.EventHandler(this.FormMainLauncher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSiteURLQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZBobb.AlphaBlendTextBox alphaBlendTextBoxLogin;
        private ZBobb.AlphaBlendTextBox alphaBlendTextBoxPassword;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.CheckBox checkBoxRememberPassword;
        private System.Windows.Forms.Button buttonRunGame;
        private System.Windows.Forms.ComboBox comboBoxServer;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.Button buttonMainSettings;
        private System.Windows.Forms.WebBrowser webBrowserNews;
        private System.Windows.Forms.Label labelMainInfo;
        private System.Windows.Forms.LinkLabel linkLabelSite;
        private System.Windows.Forms.LinkLabel linkLabelRegister;
        private System.Windows.Forms.LinkLabel linkLabelHowToStart;
        private System.Windows.Forms.LinkLabel linkLabelRules;
        private System.Windows.Forms.LinkLabel linkLabelForum;
        private System.Windows.Forms.Label labelServices;
        private System.Windows.Forms.LinkLabel linkLabelDonate;
        private System.Windows.Forms.LinkLabel linkLabelVote;
        private System.Windows.Forms.PictureBox pictureBoxSkin;
        private System.Windows.Forms.Button buttonLogIn;
        private System.Windows.Forms.Label labelHello;
        private System.Windows.Forms.ComboBox comboBoxProfilesMain;
        private System.Windows.Forms.Label labelProfileMain;
        private System.Windows.Forms.CheckBox checkBoxOfflineMode;
        private System.Windows.Forms.PictureBox pictureBoxSiteURLQRCode;
        private System.Windows.Forms.CheckBox checkBoxShowRunLog;


    }
}

