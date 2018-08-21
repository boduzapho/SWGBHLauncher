namespace SWGBHLauncher
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblNetSpeed = new System.Windows.Forms.Label();
            this.fileDownload = new System.Windows.Forms.Button();
            this.lblCNT = new System.Windows.Forms.Label();
            this.pnlControls = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ibtnOWB = new SWGBHLauncher.PictureButton();
            this.pbPatchNotes = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbPPDonate = new System.Windows.Forms.PictureBox();
            this.pbVoteforUs = new System.Windows.Forms.PictureBox();
            this.pbMantisWeb = new System.Windows.Forms.PictureBox();
            this.pbSkill = new System.Windows.Forms.PictureBox();
            this.pbGH = new System.Windows.Forms.PictureBox();
            this.picExpand = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbLogoLink = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PercentComplete = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblQuotes = new System.Windows.Forms.Label();
            this.tmrQuote = new System.Windows.Forms.Timer(this.components);
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pbPlay = new SWGBHLauncher.PictureButton();
            this.pbtnDiscord = new SWGBHLauncher.PictureButton();
            this.pbtnFacebook = new SWGBHLauncher.PictureButton();
            this.pictureButton1 = new SWGBHLauncher.PictureButton();
            this.pbWebsite = new SWGBHLauncher.PictureButton();
            this.pbswgOptions = new SWGBHLauncher.PictureButton();
            this.pbGameConfig = new SWGBHLauncher.PictureButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPatchNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPPDonate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVoteforUs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMantisWeb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSkill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExpand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNetSpeed
            // 
            this.lblNetSpeed.AutoSize = true;
            this.lblNetSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetSpeed.Location = new System.Drawing.Point(1134, 27);
            this.lblNetSpeed.Name = "lblNetSpeed";
            this.lblNetSpeed.Size = new System.Drawing.Size(85, 20);
            this.lblNetSpeed.TabIndex = 1;
            this.lblNetSpeed.Text = "Speed : kb";
            this.lblNetSpeed.Visible = false;
            // 
            // fileDownload
            // 
            this.fileDownload.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fileDownload.Location = new System.Drawing.Point(378, 48);
            this.fileDownload.Name = "fileDownload";
            this.fileDownload.Size = new System.Drawing.Size(75, 23);
            this.fileDownload.TabIndex = 4;
            this.fileDownload.Text = "Begin";
            this.fileDownload.UseVisualStyleBackColor = true;
            this.fileDownload.Click += new System.EventHandler(this.FileDownload_Click);
            // 
            // lblCNT
            // 
            this.lblCNT.AutoSize = true;
            this.lblCNT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCNT.Location = new System.Drawing.Point(468, -4);
            this.lblCNT.Name = "lblCNT";
            this.lblCNT.Size = new System.Drawing.Size(36, 20);
            this.lblCNT.TabIndex = 5;
            this.lblCNT.Text = "000";
            this.lblCNT.Visible = false;
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.Transparent;
            this.pnlControls.Location = new System.Drawing.Point(472, 48);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(563, 275);
            this.pnlControls.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(398, 375);
            this.webBrowser1.TabIndex = 12;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ibtnOWB);
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Location = new System.Drawing.Point(54, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 377);
            this.panel1.TabIndex = 13;
            // 
            // ibtnOWB
            // 
            this.ibtnOWB.BackgroundImage = global::SWGBHLauncher.Properties.Resources.btn_open_web;
            this.ibtnOWB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ibtnOWB.Location = new System.Drawing.Point(-1, 352);
            this.ibtnOWB.Name = "ibtnOWB";
            this.ibtnOWB.PressedImage = global::SWGBHLauncher.Properties.Resources.btn_open_web_hover;
            this.ibtnOWB.Size = new System.Drawing.Size(130, 23);
            this.ibtnOWB.TabIndex = 33;
            this.ibtnOWB.Click += new System.EventHandler(this.ibtnOWB_Click);
            // 
            // pbPatchNotes
            // 
            this.pbPatchNotes.BackgroundImage = global::SWGBHLauncher.Properties.Resources.text_patch_notes;
            this.pbPatchNotes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbPatchNotes.Location = new System.Drawing.Point(54, 103);
            this.pbPatchNotes.Name = "pbPatchNotes";
            this.pbPatchNotes.Size = new System.Drawing.Size(114, 24);
            this.pbPatchNotes.TabIndex = 16;
            this.pbPatchNotes.TabStop = false;
            this.pbPatchNotes.Click += new System.EventHandler(this.pbPatchNotes_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::SWGBHLauncher.Properties.Resources.seperator1;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(174, 101);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(10, 27);
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::SWGBHLauncher.Properties.Resources.seperator1;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Location = new System.Drawing.Point(262, 101);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(10, 27);
            this.pictureBox4.TabIndex = 19;
            this.pictureBox4.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::SWGBHLauncher.Properties.Resources.bh_sr_launcher_btns;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.pbPPDonate);
            this.panel2.Controls.Add(this.pbVoteforUs);
            this.panel2.Controls.Add(this.pbMantisWeb);
            this.panel2.Controls.Add(this.pbSkill);
            this.panel2.Controls.Add(this.pbGH);
            this.panel2.Location = new System.Drawing.Point(515, 420);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(520, 100);
            this.panel2.TabIndex = 27;
            // 
            // pbPPDonate
            // 
            this.pbPPDonate.Location = new System.Drawing.Point(428, 3);
            this.pbPPDonate.Name = "pbPPDonate";
            this.pbPPDonate.Size = new System.Drawing.Size(89, 93);
            this.pbPPDonate.TabIndex = 4;
            this.pbPPDonate.TabStop = false;
            this.pbPPDonate.Click += new System.EventHandler(this.pbPPDonate_Click);
            // 
            // pbVoteforUs
            // 
            this.pbVoteforUs.Location = new System.Drawing.Point(320, 7);
            this.pbVoteforUs.Name = "pbVoteforUs";
            this.pbVoteforUs.Size = new System.Drawing.Size(89, 93);
            this.pbVoteforUs.TabIndex = 3;
            this.pbVoteforUs.TabStop = false;
            this.pbVoteforUs.Click += new System.EventHandler(this.pbVoteforUs_Click);
            // 
            // pbMantisWeb
            // 
            this.pbMantisWeb.Location = new System.Drawing.Point(216, 4);
            this.pbMantisWeb.Name = "pbMantisWeb";
            this.pbMantisWeb.Size = new System.Drawing.Size(89, 93);
            this.pbMantisWeb.TabIndex = 2;
            this.pbMantisWeb.TabStop = false;
            this.pbMantisWeb.Click += new System.EventHandler(this.pbMantisWeb_Click);
            // 
            // pbSkill
            // 
            this.pbSkill.Location = new System.Drawing.Point(108, 3);
            this.pbSkill.Name = "pbSkill";
            this.pbSkill.Size = new System.Drawing.Size(89, 93);
            this.pbSkill.TabIndex = 1;
            this.pbSkill.TabStop = false;
            this.pbSkill.Click += new System.EventHandler(this.pbSkill_Click);
            // 
            // pbGH
            // 
            this.pbGH.Location = new System.Drawing.Point(4, 4);
            this.pbGH.Name = "pbGH";
            this.pbGH.Size = new System.Drawing.Size(89, 93);
            this.pbGH.TabIndex = 0;
            this.pbGH.TabStop = false;
            this.pbGH.Click += new System.EventHandler(this.pbGH_Click);
            // 
            // picExpand
            // 
            this.picExpand.BackColor = System.Drawing.Color.Transparent;
            this.picExpand.BackgroundImage = global::SWGBHLauncher.Properties.Resources.btn_expand;
            this.picExpand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picExpand.Location = new System.Drawing.Point(424, 101);
            this.picExpand.Name = "picExpand";
            this.picExpand.Size = new System.Drawing.Size(29, 27);
            this.picExpand.TabIndex = 28;
            this.picExpand.TabStop = false;
            this.picExpand.Click += new System.EventHandler(this.picExpand_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SWGBHLauncher.Properties.Resources.seperator1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(350, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 27);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // pbLogoLink
            // 
            this.pbLogoLink.BackColor = System.Drawing.Color.Transparent;
            this.pbLogoLink.Location = new System.Drawing.Point(54, 12);
            this.pbLogoLink.Name = "pbLogoLink";
            this.pbLogoLink.Size = new System.Drawing.Size(306, 73);
            this.pbLogoLink.TabIndex = 32;
            this.pbLogoLink.TabStop = false;
            this.pbLogoLink.Click += new System.EventHandler(this.LogoLink_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressBar1.ForeColor = System.Drawing.Color.Red;
            this.progressBar1.Location = new System.Drawing.Point(-3, -2);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(787, 18);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 33;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Location = new System.Drawing.Point(844, 542);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 22);
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // PercentComplete
            // 
            this.PercentComplete.AutoSize = true;
            this.PercentComplete.BackColor = System.Drawing.Color.Red;
            this.PercentComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PercentComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PercentComplete.ForeColor = System.Drawing.Color.White;
            this.PercentComplete.Location = new System.Drawing.Point(0, 0);
            this.PercentComplete.Margin = new System.Windows.Forms.Padding(0);
            this.PercentComplete.Name = "PercentComplete";
            this.PercentComplete.Size = new System.Drawing.Size(27, 13);
            this.PercentComplete.TabIndex = 35;
            this.PercentComplete.Text = "00%";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel3.Controls.Add(this.PercentComplete);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Location = new System.Drawing.Point(54, 547);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(786, 13);
            this.panel3.TabIndex = 36;
            // 
            // lblQuotes
            // 
            this.lblQuotes.BackColor = System.Drawing.Color.Transparent;
            this.lblQuotes.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblQuotes.Location = new System.Drawing.Point(51, 527);
            this.lblQuotes.Name = "lblQuotes";
            this.lblQuotes.Size = new System.Drawing.Size(705, 19);
            this.lblQuotes.TabIndex = 37;
            this.lblQuotes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tmrQuote
            // 
            this.tmrQuote.Interval = 40000;
            this.tmrQuote.Tick += new System.EventHandler(this.tmrQuote_Tick);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BackgroundImage = global::SWGBHLauncher.Properties.Resources.window_minimize1;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMinimize.Location = new System.Drawing.Point(1030, 24);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(37, 30);
            this.btnMinimize.TabIndex = 38;
            this.btnMinimize.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::SWGBHLauncher.Properties.Resources.window_close1;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Location = new System.Drawing.Point(1058, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(37, 30);
            this.btnClose.TabIndex = 39;
            this.btnClose.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(681, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Bar Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbPlay
            // 
            this.pbPlay.BackgroundImage = global::SWGBHLauncher.Properties.Resources.btn_play;
            this.pbPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbPlay.Location = new System.Drawing.Point(874, 529);
            this.pbPlay.Name = "pbPlay";
            this.pbPlay.PressedImage = global::SWGBHLauncher.Properties.Resources.btn_play_hover;
            this.pbPlay.Size = new System.Drawing.Size(143, 54);
            this.pbPlay.TabIndex = 0;
            // 
            // pbtnDiscord
            // 
            this.pbtnDiscord.BackgroundImage = global::SWGBHLauncher.Properties.Resources.link_discord;
            this.pbtnDiscord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbtnDiscord.Location = new System.Drawing.Point(370, 106);
            this.pbtnDiscord.Name = "pbtnDiscord";
            this.pbtnDiscord.PressedImage = global::SWGBHLauncher.Properties.Resources.link_discord_hover;
            this.pbtnDiscord.Size = new System.Drawing.Size(18, 18);
            this.pbtnDiscord.TabIndex = 29;
            this.pbtnDiscord.Click += new System.EventHandler(this.pbtnDiscord_Click);
            // 
            // pbtnFacebook
            // 
            this.pbtnFacebook.BackgroundImage = global::SWGBHLauncher.Properties.Resources.link_facebook;
            this.pbtnFacebook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbtnFacebook.Location = new System.Drawing.Point(394, 106);
            this.pbtnFacebook.Name = "pbtnFacebook";
            this.pbtnFacebook.PressedImage = global::SWGBHLauncher.Properties.Resources.link_facebook_hover;
            this.pbtnFacebook.Size = new System.Drawing.Size(18, 18);
            this.pbtnFacebook.TabIndex = 30;
            this.pbtnFacebook.Click += new System.EventHandler(this.pbtnFacebook_Click);
            // 
            // pictureButton1
            // 
            this.pictureButton1.BackgroundImage = global::SWGBHLauncher.Properties.Resources.link_forums;
            this.pictureButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureButton1.Location = new System.Drawing.Point(278, 104);
            this.pictureButton1.Name = "pictureButton1";
            this.pictureButton1.PressedImage = global::SWGBHLauncher.Properties.Resources.link_forums_hover;
            this.pictureButton1.Size = new System.Drawing.Size(66, 21);
            this.pictureButton1.TabIndex = 17;
            this.pictureButton1.Click += new System.EventHandler(this.pictureButton1_Click);
            // 
            // pbWebsite
            // 
            this.pbWebsite.BackgroundImage = global::SWGBHLauncher.Properties.Resources.link_website;
            this.pbWebsite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbWebsite.Location = new System.Drawing.Point(190, 104);
            this.pbWebsite.Name = "pbWebsite";
            this.pbWebsite.PressedImage = global::SWGBHLauncher.Properties.Resources.link_website_hover;
            this.pbWebsite.Size = new System.Drawing.Size(66, 21);
            this.pbWebsite.TabIndex = 15;
            this.pbWebsite.Click += new System.EventHandler(this.pbWebsite_Click);
            // 
            // pbswgOptions
            // 
            this.pbswgOptions.BackgroundImage = global::SWGBHLauncher.Properties.Resources.btn_swg_options1;
            this.pbswgOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbswgOptions.Location = new System.Drawing.Point(528, 353);
            this.pbswgOptions.Name = "pbswgOptions";
            this.pbswgOptions.PressedImage = global::SWGBHLauncher.Properties.Resources.btn_swg_options_hover1;
            this.pbswgOptions.Size = new System.Drawing.Size(178, 46);
            this.pbswgOptions.TabIndex = 10;
            // 
            // pbGameConfig
            // 
            this.pbGameConfig.BackgroundImage = global::SWGBHLauncher.Properties.Resources.btn_game_config1;
            this.pbGameConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbGameConfig.Location = new System.Drawing.Point(839, 353);
            this.pbGameConfig.Name = "pbGameConfig";
            this.pbGameConfig.PressedImage = global::SWGBHLauncher.Properties.Resources.btn_game_config_hover1;
            this.pbGameConfig.Size = new System.Drawing.Size(178, 46);
            this.pbGameConfig.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::SWGBHLauncher.Properties.Resources.LatestBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1120, 600);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.pbPlay);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblQuotes);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbtnDiscord);
            this.Controls.Add(this.pbtnFacebook);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pbLogoLink);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picExpand);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureButton1);
            this.Controls.Add(this.pbPatchNotes);
            this.Controls.Add(this.pbWebsite);
            this.Controls.Add(this.lblCNT);
            this.Controls.Add(this.fileDownload);
            this.Controls.Add(this.lblNetSpeed);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pbswgOptions);
            this.Controls.Add(this.pbGameConfig);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SWGEmu Client Launcher Updater";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPatchNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPPDonate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVoteforUs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMantisWeb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSkill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExpand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNetSpeed;
        private System.Windows.Forms.Button fileDownload;
        private System.Windows.Forms.Label lblCNT;
        private System.Windows.Forms.FlowLayoutPanel pnlControls;
        private System.Windows.Forms.Timer timer1;
        private PictureButton pbPlay;
        private PictureButton pbGameConfig;
        private PictureButton pbswgOptions;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel1;
        private PictureButton pbWebsite;
        private System.Windows.Forms.PictureBox pbPatchNotes;
        private PictureButton pictureButton1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picExpand;
        private PictureButton pbtnDiscord;
        private PictureButton pbtnFacebook;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbLogoLink;
        private System.Windows.Forms.PictureBox pbGH;
        private System.Windows.Forms.PictureBox pbSkill;
        private System.Windows.Forms.PictureBox pbMantisWeb;
        private System.Windows.Forms.PictureBox pbVoteforUs;
        private System.Windows.Forms.PictureBox pbPPDonate;
        private PictureButton ibtnOWB;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label PercentComplete;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblQuotes;
        private System.Windows.Forms.Timer tmrQuote;
        private System.Windows.Forms.PictureBox btnMinimize;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Button button1;
    }
}

