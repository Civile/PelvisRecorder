namespace TXRXText
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BTN_Rec = new System.Windows.Forms.Button();
            this.TXT_Display = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LAB_AuthorLink = new System.Windows.Forms.LinkLabel();
            this.radioButton1_BitRate320 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_PlayRecording = new System.Windows.Forms.Button();
            this.CHK_RecordSilence = new System.Windows.Forms.CheckBox();
            this.LBL_FoundSpotify = new System.Windows.Forms.Label();
            this.CHK_SingleTrackRecording = new System.Windows.Forms.CheckBox();
            this.BTN_OpenFolder = new System.Windows.Forms.Button();
            this.PBOX_Cover = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton1_BitRate128 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1_BitRate190 = new System.Windows.Forms.RadioButton();
            this.CBOX_Hertz = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RAD_SpotifySelect = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RAD_MP3 = new System.Windows.Forms.RadioButton();
            this.RAD_WAV = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.BTN_SkipTrack = new System.Windows.Forms.Button();
            this.BTN_PauseRec = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBOX_Cover)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_Rec
            // 
            this.BTN_Rec.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Rec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Rec.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BTN_Rec.FlatAppearance.BorderSize = 0;
            this.BTN_Rec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.BTN_Rec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Rec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Rec.ForeColor = System.Drawing.Color.Transparent;
            this.BTN_Rec.Image = ((System.Drawing.Image)(resources.GetObject("BTN_Rec.Image")));
            this.BTN_Rec.Location = new System.Drawing.Point(185, 30);
            this.BTN_Rec.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_Rec.Name = "BTN_Rec";
            this.BTN_Rec.Size = new System.Drawing.Size(59, 50);
            this.BTN_Rec.TabIndex = 0;
            this.BTN_Rec.UseVisualStyleBackColor = false;
            this.BTN_Rec.Click += new System.EventHandler(this.Record_Click);
            // 
            // TXT_Display
            // 
            this.TXT_Display.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.TXT_Display.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXT_Display.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.TXT_Display.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TXT_Display.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Display.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.TXT_Display.Location = new System.Drawing.Point(244, 44);
            this.TXT_Display.Margin = new System.Windows.Forms.Padding(4);
            this.TXT_Display.Multiline = true;
            this.TXT_Display.Name = "TXT_Display";
            this.TXT_Display.ReadOnly = true;
            this.TXT_Display.Size = new System.Drawing.Size(484, 21);
            this.TXT_Display.TabIndex = 1;
            this.TXT_Display.Text = "<- click to begin recording";
            this.TXT_Display.TextChanged += new System.EventHandler(this.TXT_Display_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pelvis Spotify ripper";
            // 
            // LAB_AuthorLink
            // 
            this.LAB_AuthorLink.AutoSize = true;
            this.LAB_AuthorLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.45F);
            this.LAB_AuthorLink.LinkColor = System.Drawing.Color.Silver;
            this.LAB_AuthorLink.Location = new System.Drawing.Point(473, 5);
            this.LAB_AuthorLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LAB_AuthorLink.Name = "LAB_AuthorLink";
            this.LAB_AuthorLink.Size = new System.Drawing.Size(234, 16);
            this.LAB_AuthorLink.TabIndex = 6;
            this.LAB_AuthorLink.TabStop = true;
            this.LAB_AuthorLink.Text = "PelvisRecorder v1.2.7.0 (c) 2014 Civile";
            this.LAB_AuthorLink.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LAB_AuthorLink_Click);
            // 
            // radioButton1_BitRate320
            // 
            this.radioButton1_BitRate320.AutoSize = true;
            this.radioButton1_BitRate320.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1_BitRate320.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1_BitRate320.ForeColor = System.Drawing.Color.Gray;
            this.radioButton1_BitRate320.Location = new System.Drawing.Point(8, 17);
            this.radioButton1_BitRate320.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1_BitRate320.Name = "radioButton1_BitRate320";
            this.radioButton1_BitRate320.Size = new System.Drawing.Size(89, 20);
            this.radioButton1_BitRate320.TabIndex = 7;
            this.radioButton1_BitRate320.Text = "320 kbit/s";
            this.radioButton1_BitRate320.UseVisualStyleBackColor = true;
            this.radioButton1_BitRate320.CheckedChanged += new System.EventHandler(this.RAD_BitRate_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(20, 158);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "BitRate";
            // 
            // BTN_PlayRecording
            // 
            this.BTN_PlayRecording.AutoEllipsis = true;
            this.BTN_PlayRecording.BackColor = System.Drawing.Color.Transparent;
            this.BTN_PlayRecording.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_PlayRecording.BackgroundImage")));
            this.BTN_PlayRecording.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_PlayRecording.Enabled = false;
            this.BTN_PlayRecording.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BTN_PlayRecording.FlatAppearance.BorderSize = 0;
            this.BTN_PlayRecording.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_PlayRecording.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_PlayRecording.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTN_PlayRecording.Location = new System.Drawing.Point(53, 2);
            this.BTN_PlayRecording.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_PlayRecording.Name = "BTN_PlayRecording";
            this.BTN_PlayRecording.Size = new System.Drawing.Size(27, 25);
            this.BTN_PlayRecording.TabIndex = 10;
            this.BTN_PlayRecording.UseVisualStyleBackColor = false;
            this.BTN_PlayRecording.Visible = false;
            this.BTN_PlayRecording.Click += new System.EventHandler(this.BTN_PlayRecording_Click);
            // 
            // CHK_RecordSilence
            // 
            this.CHK_RecordSilence.AutoSize = true;
            this.CHK_RecordSilence.Enabled = false;
            this.CHK_RecordSilence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHK_RecordSilence.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHK_RecordSilence.ForeColor = System.Drawing.Color.Gray;
            this.CHK_RecordSilence.Location = new System.Drawing.Point(18, 310);
            this.CHK_RecordSilence.Margin = new System.Windows.Forms.Padding(4);
            this.CHK_RecordSilence.Name = "CHK_RecordSilence";
            this.CHK_RecordSilence.Size = new System.Drawing.Size(120, 20);
            this.CHK_RecordSilence.TabIndex = 11;
            this.CHK_RecordSilence.Text = "Record silence";
            this.CHK_RecordSilence.UseVisualStyleBackColor = true;
            this.CHK_RecordSilence.Visible = false;
            this.CHK_RecordSilence.CheckedChanged += new System.EventHandler(this.CHK_RecordSilence_Change);
            // 
            // LBL_FoundSpotify
            // 
            this.LBL_FoundSpotify.AutoSize = true;
            this.LBL_FoundSpotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_FoundSpotify.ForeColor = System.Drawing.Color.White;
            this.LBL_FoundSpotify.Location = new System.Drawing.Point(627, 7);
            this.LBL_FoundSpotify.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_FoundSpotify.Name = "LBL_FoundSpotify";
            this.LBL_FoundSpotify.Size = new System.Drawing.Size(96, 15);
            this.LBL_FoundSpotify.TabIndex = 12;
            this.LBL_FoundSpotify.Text = "I found SPOTIFY";
            this.LBL_FoundSpotify.Visible = false;
            // 
            // CHK_SingleTrackRecording
            // 
            this.CHK_SingleTrackRecording.AutoSize = true;
            this.CHK_SingleTrackRecording.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHK_SingleTrackRecording.ForeColor = System.Drawing.Color.Gray;
            this.CHK_SingleTrackRecording.Location = new System.Drawing.Point(18, 287);
            this.CHK_SingleTrackRecording.Margin = new System.Windows.Forms.Padding(4);
            this.CHK_SingleTrackRecording.Name = "CHK_SingleTrackRecording";
            this.CHK_SingleTrackRecording.Size = new System.Drawing.Size(364, 21);
            this.CHK_SingleTrackRecording.TabIndex = 13;
            this.CHK_SingleTrackRecording.Text = "Single track (uncheck to record the tracks separately)";
            this.CHK_SingleTrackRecording.UseVisualStyleBackColor = true;
            this.CHK_SingleTrackRecording.CheckedChanged += new System.EventHandler(this.CHK_SingleTrackRecording_Change);
            // 
            // BTN_OpenFolder
            // 
            this.BTN_OpenFolder.BackColor = System.Drawing.Color.Transparent;
            this.BTN_OpenFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_OpenFolder.BackgroundImage")));
            this.BTN_OpenFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_OpenFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BTN_OpenFolder.FlatAppearance.BorderSize = 0;
            this.BTN_OpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_OpenFolder.ForeColor = System.Drawing.Color.Transparent;
            this.BTN_OpenFolder.Location = new System.Drawing.Point(15, 5);
            this.BTN_OpenFolder.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_OpenFolder.Name = "BTN_OpenFolder";
            this.BTN_OpenFolder.Size = new System.Drawing.Size(27, 18);
            this.BTN_OpenFolder.TabIndex = 14;
            this.BTN_OpenFolder.UseVisualStyleBackColor = false;
            this.BTN_OpenFolder.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BTN_OpenFolder_Click);
            // 
            // PBOX_Cover
            // 
            this.PBOX_Cover.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PBOX_Cover.BackgroundImage")));
            this.PBOX_Cover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PBOX_Cover.Location = new System.Drawing.Point(15, 39);
            this.PBOX_Cover.Margin = new System.Windows.Forms.Padding(4);
            this.PBOX_Cover.Name = "PBOX_Cover";
            this.PBOX_Cover.Size = new System.Drawing.Size(164, 113);
            this.PBOX_Cover.TabIndex = 15;
            this.PBOX_Cover.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.LAB_AuthorLink);
            this.panel1.Controls.Add(this.BTN_OpenFolder);
            this.panel1.Controls.Add(this.BTN_PlayRecording);
            this.panel1.Location = new System.Drawing.Point(0, 336);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 30);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(207)))), ((int)(((byte)(58)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.LBL_FoundSpotify);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(728, 30);
            this.panel2.TabIndex = 17;
            // 
            // radioButton1_BitRate128
            // 
            this.radioButton1_BitRate128.AutoSize = true;
            this.radioButton1_BitRate128.Checked = true;
            this.radioButton1_BitRate128.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1_BitRate128.Font = new System.Drawing.Font("Arial", 8.25F);
            this.radioButton1_BitRate128.ForeColor = System.Drawing.Color.Gray;
            this.radioButton1_BitRate128.Location = new System.Drawing.Point(8, 63);
            this.radioButton1_BitRate128.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1_BitRate128.Name = "radioButton1_BitRate128";
            this.radioButton1_BitRate128.Size = new System.Drawing.Size(89, 20);
            this.radioButton1_BitRate128.TabIndex = 18;
            this.radioButton1_BitRate128.TabStop = true;
            this.radioButton1_BitRate128.Text = "128 kbit/s";
            this.radioButton1_BitRate128.UseVisualStyleBackColor = true;
            this.radioButton1_BitRate128.CheckedChanged += new System.EventHandler(this.RAD_BitRate_Changed);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.radioButton1_BitRate190);
            this.groupBox1.Controls.Add(this.CBOX_Hertz);
            this.groupBox1.Controls.Add(this.radioButton1_BitRate320);
            this.groupBox1.Controls.Add(this.radioButton1_BitRate128);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(16, 156);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(164, 123);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // radioButton1_BitRate190
            // 
            this.radioButton1_BitRate190.AutoSize = true;
            this.radioButton1_BitRate190.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1_BitRate190.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1_BitRate190.ForeColor = System.Drawing.Color.Gray;
            this.radioButton1_BitRate190.Location = new System.Drawing.Point(8, 39);
            this.radioButton1_BitRate190.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1_BitRate190.Name = "radioButton1_BitRate190";
            this.radioButton1_BitRate190.Size = new System.Drawing.Size(89, 20);
            this.radioButton1_BitRate190.TabIndex = 19;
            this.radioButton1_BitRate190.TabStop = true;
            this.radioButton1_BitRate190.Text = "190 kbit/s";
            this.radioButton1_BitRate190.UseVisualStyleBackColor = true;
            this.radioButton1_BitRate190.CheckedChanged += new System.EventHandler(this.RAD_BitRate_Changed);
            // 
            // CBOX_Hertz
            // 
            this.CBOX_Hertz.DisplayMember = "0";
            this.CBOX_Hertz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBOX_Hertz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBOX_Hertz.FormattingEnabled = true;
            this.CBOX_Hertz.Items.AddRange(new object[] {
            "auto hz",
            "96000 hz",
            "48000 hz",
            "44100 hz",
            "32000 hz"});
            this.CBOX_Hertz.Location = new System.Drawing.Point(1, 96);
            this.CBOX_Hertz.Margin = new System.Windows.Forms.Padding(4);
            this.CBOX_Hertz.Name = "CBOX_Hertz";
            this.CBOX_Hertz.Size = new System.Drawing.Size(160, 24);
            this.CBOX_Hertz.TabIndex = 21;
            this.CBOX_Hertz.SelectedIndexChanged += new System.EventHandler(this.CBOX_Hertz_Changed);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RAD_SpotifySelect);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(185, 156);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(175, 75);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // RAD_SpotifySelect
            // 
            this.RAD_SpotifySelect.AutoSize = true;
            this.RAD_SpotifySelect.Enabled = false;
            this.RAD_SpotifySelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RAD_SpotifySelect.ForeColor = System.Drawing.Color.Gray;
            this.RAD_SpotifySelect.Location = new System.Drawing.Point(57, 20);
            this.RAD_SpotifySelect.Margin = new System.Windows.Forms.Padding(4);
            this.RAD_SpotifySelect.Name = "RAD_SpotifySelect";
            this.RAD_SpotifySelect.Size = new System.Drawing.Size(71, 21);
            this.RAD_SpotifySelect.TabIndex = 2;
            this.RAD_SpotifySelect.TabStop = true;
            this.RAD_SpotifySelect.Text = "Spotify";
            this.RAD_SpotifySelect.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(4, -4);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Specialization";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 31);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RAD_MP3);
            this.groupBox3.Controls.Add(this.RAD_WAV);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Gray;
            this.groupBox3.Location = new System.Drawing.Point(184, 238);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(176, 43);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Format";
            // 
            // RAD_MP3
            // 
            this.RAD_MP3.AutoSize = true;
            this.RAD_MP3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RAD_MP3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RAD_MP3.Location = new System.Drawing.Point(84, 17);
            this.RAD_MP3.Margin = new System.Windows.Forms.Padding(4);
            this.RAD_MP3.Name = "RAD_MP3";
            this.RAD_MP3.Size = new System.Drawing.Size(56, 20);
            this.RAD_MP3.TabIndex = 1;
            this.RAD_MP3.Text = "MP3";
            this.RAD_MP3.UseVisualStyleBackColor = true;
            this.RAD_MP3.CheckedChanged += new System.EventHandler(this.RAD_AudioFormat_Changed);
            // 
            // RAD_WAV
            // 
            this.RAD_WAV.AutoSize = true;
            this.RAD_WAV.Checked = true;
            this.RAD_WAV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RAD_WAV.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RAD_WAV.Location = new System.Drawing.Point(12, 17);
            this.RAD_WAV.Margin = new System.Windows.Forms.Padding(4);
            this.RAD_WAV.Name = "RAD_WAV";
            this.RAD_WAV.Size = new System.Drawing.Size(57, 20);
            this.RAD_WAV.TabIndex = 0;
            this.RAD_WAV.TabStop = true;
            this.RAD_WAV.Text = "WAV";
            this.RAD_WAV.UseVisualStyleBackColor = true;
            this.RAD_WAV.CheckedChanged += new System.EventHandler(this.RAD_AudioFormat_Changed);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.ForeColor = System.Drawing.Color.Gray;
            this.checkBox1.Location = new System.Drawing.Point(146, 310);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(194, 21);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Mutes the other processes";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CHK_MutesProcesses_Changed);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "PelvisRecorder";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // BTN_SkipTrack
            // 
            this.BTN_SkipTrack.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.BTN_SkipTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SkipTrack.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_SkipTrack.ForeColor = System.Drawing.Color.Gray;
            this.BTN_SkipTrack.Location = new System.Drawing.Point(349, 69);
            this.BTN_SkipTrack.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_SkipTrack.Name = "BTN_SkipTrack";
            this.BTN_SkipTrack.Size = new System.Drawing.Size(84, 30);
            this.BTN_SkipTrack.TabIndex = 25;
            this.BTN_SkipTrack.Text = "skip track";
            this.BTN_SkipTrack.UseVisualStyleBackColor = true;
            this.BTN_SkipTrack.Visible = false;
            this.BTN_SkipTrack.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BTN_SkipTrack_Clicked);
            // 
            // BTN_PauseRec
            // 
            this.BTN_PauseRec.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BTN_PauseRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_PauseRec.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_PauseRec.ForeColor = System.Drawing.Color.Gray;
            this.BTN_PauseRec.Location = new System.Drawing.Point(244, 69);
            this.BTN_PauseRec.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_PauseRec.Name = "BTN_PauseRec";
            this.BTN_PauseRec.Size = new System.Drawing.Size(107, 30);
            this.BTN_PauseRec.TabIndex = 26;
            this.BTN_PauseRec.Text = "pause rec";
            this.BTN_PauseRec.UseVisualStyleBackColor = true;
            this.BTN_PauseRec.Visible = false;
            this.BTN_PauseRec.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BTN_PauseRec_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.richTextBox1.Location = new System.Drawing.Point(382, 162);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(331, 167);
            this.richTextBox1.TabIndex = 27;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(727, 364);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.BTN_PauseRec);
            this.Controls.Add(this.BTN_SkipTrack);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BTN_Rec);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PBOX_Cover);
            this.Controls.Add(this.CHK_SingleTrackRecording);
            this.Controls.Add(this.CHK_RecordSilence);
            this.Controls.Add(this.TXT_Display);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "PelvisRecorder";
            this.TransparencyKey = System.Drawing.Color.Linen;
            this.Resize += new System.EventHandler(this.Window_OnResize);
            ((System.ComponentModel.ISupportInitialize)(this.PBOX_Cover)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Rec;
        private System.Windows.Forms.TextBox TXT_Display;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LAB_AuthorLink;
        private System.Windows.Forms.RadioButton radioButton1_BitRate320;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_PlayRecording;
        private System.Windows.Forms.CheckBox CHK_RecordSilence;
        private System.Windows.Forms.Label LBL_FoundSpotify;
        private System.Windows.Forms.CheckBox CHK_SingleTrackRecording;
        private System.Windows.Forms.Button BTN_OpenFolder;
        private System.Windows.Forms.PictureBox PBOX_Cover;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton1_BitRate128;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CBOX_Hertz;
        private System.Windows.Forms.RadioButton radioButton1_BitRate190;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton RAD_SpotifySelect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RAD_WAV;
        private System.Windows.Forms.RadioButton RAD_MP3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button BTN_SkipTrack;
        private System.Windows.Forms.Button BTN_PauseRec;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

