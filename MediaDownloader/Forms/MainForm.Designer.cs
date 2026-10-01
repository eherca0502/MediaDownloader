namespace MediaDownloader.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlSidebar;
        private Panel pnlHeader;
        private Panel pnlContent;

        private Label lblLogo;
        private Label lblAppName;
        private Label lblPageTitle;
        private Label lblPageSubtitle;

        private Button btnHome;
        private Button btnDownloads;
        private Button btnHistory;
        private Button btnSettings;

        private Label lblUrl;
        private TextBox txtUrl;
        private Button btnAnalyze;

        private Panel pnlVideoInfo;
        private Panel pnlThumbnail;
        private PictureBox picThumbnail;
        private Label lblThumbnail;
        private Label lblVideoTitle;
        private Label lblDuration;
        private Label lblChannel;

        private Label lblDownloadType;
        private Button btnVideo;
        private Button btnAudio;
        private Button btnVideoAudio;

        private Label lblQuality;
        private ComboBox cmbQuality;

        private Label lblFormat;
        private ComboBox cmbFormat;

        private Label lblSavePath;
        private TextBox txtSavePath;
        private Button btnBrowse;

        private Button btnDownload;

        private Panel pnlProgress;
        private ProgressBar progressBar;
        private Label lblProgress;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pnlSidebar = new Panel();
            lblLogo = new Label();
            lblAppName = new Label();
            btnHome = new Button();
            btnDownloads = new Button();
            btnHistory = new Button();
            btnSettings = new Button();
            pnlHeader = new Panel();
            lblPageTitle = new Label();
            lblPageSubtitle = new Label();
            pnlContent = new Panel();
            btnCancel = new Button();
            lblUrl = new Label();
            txtUrl = new TextBox();
            btnAnalyze = new Button();
            pnlVideoInfo = new Panel();
            pnlThumbnail = new Panel();
            picThumbnail = new PictureBox();
            lblThumbnail = new Label();
            lblVideoTitle = new Label();
            lblDuration = new Label();
            lblChannel = new Label();
            lblDownloadType = new Label();
            btnVideo = new Button();
            btnAudio = new Button();
            btnVideoAudio = new Button();
            lblQuality = new Label();
            cmbQuality = new ComboBox();
            lblFormat = new Label();
            cmbFormat = new ComboBox();
            lblSavePath = new Label();
            txtSavePath = new TextBox();
            btnBrowse = new Button();
            btnDownload = new Button();
            pnlProgress = new Panel();
            progressBar = new ProgressBar();
            lblProgress = new Label();
            lblStatus = new Label();
            pnlSidebar.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlVideoInfo.SuspendLayout();
            pnlThumbnail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picThumbnail).BeginInit();
            pnlProgress.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(24, 24, 29);
            pnlSidebar.Controls.Add(lblLogo);
            pnlSidebar.Controls.Add(lblAppName);
            pnlSidebar.Controls.Add(btnHome);
            pnlSidebar.Controls.Add(btnDownloads);
            pnlSidebar.Controls.Add(btnHistory);
            pnlSidebar.Controls.Add(btnSettings);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Padding = new Padding(15, 20, 15, 20);
            pnlSidebar.Size = new Size(220, 749);
            pnlSidebar.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.BackColor = Color.FromArgb(70, 110, 255);
            lblLogo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(20, 25);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(50, 50);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "▶";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAppName
            // 
            lblAppName.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(80, 25);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(125, 50);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "MediaDownloader";
            lblAppName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(70, 110, 255);
            btnHome.Cursor = Cursors.Hand;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI Semibold", 10F);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(15, 125);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(15, 0, 0, 0);
            btnHome.Size = new Size(190, 45);
            btnHome.TabIndex = 2;
            btnHome.Text = "  Inicio";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = false;
            // 
            // btnDownloads
            // 
            btnDownloads.BackColor = Color.Transparent;
            btnDownloads.Cursor = Cursors.Hand;
            btnDownloads.FlatAppearance.BorderSize = 0;
            btnDownloads.FlatStyle = FlatStyle.Flat;
            btnDownloads.Font = new Font("Segoe UI Semibold", 10F);
            btnDownloads.ForeColor = Color.FromArgb(185, 185, 195);
            btnDownloads.Location = new Point(15, 175);
            btnDownloads.Name = "btnDownloads";
            btnDownloads.Padding = new Padding(15, 0, 0, 0);
            btnDownloads.Size = new Size(190, 45);
            btnDownloads.TabIndex = 3;
            btnDownloads.Text = " Descargas";
            btnDownloads.TextAlign = ContentAlignment.MiddleLeft;
            btnDownloads.UseVisualStyleBackColor = false;
            btnDownloads.Click += btnDownloads_Click;
            // 
            // btnHistory
            // 
            btnHistory.BackColor = Color.Transparent;
            btnHistory.Cursor = Cursors.Hand;
            btnHistory.FlatAppearance.BorderSize = 0;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Font = new Font("Segoe UI Semibold", 10F);
            btnHistory.ForeColor = Color.FromArgb(185, 185, 195);
            btnHistory.Location = new Point(15, 225);
            btnHistory.Name = "btnHistory";
            btnHistory.Padding = new Padding(15, 0, 0, 0);
            btnHistory.Size = new Size(190, 45);
            btnHistory.TabIndex = 4;
            btnHistory.Text = "  Historial";
            btnHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnHistory.UseVisualStyleBackColor = false;
            btnHistory.Click += btnHistory_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.Transparent;
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI Semibold", 10F);
            btnSettings.ForeColor = Color.FromArgb(185, 185, 195);
            btnSettings.Location = new Point(15, 275);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(15, 0, 0, 0);
            btnSettings.Size = new Size(190, 45);
            btnSettings.TabIndex = 5;
            btnSettings.Text = "  Ajustes";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(18, 18, 22);
            pnlHeader.Controls.Add(lblPageTitle);
            pnlHeader.Controls.Add(lblPageSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(220, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(980, 80);
            pnlHeader.TabIndex = 1;
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblPageTitle.ForeColor = Color.White;
            lblPageTitle.Location = new Point(35, 18);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(270, 37);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Descargar contenido";
            // 
            // lblPageSubtitle
            // 
            lblPageSubtitle.AutoSize = true;
            lblPageSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblPageSubtitle.ForeColor = Color.FromArgb(145, 145, 155);
            lblPageSubtitle.Location = new Point(38, 52);
            lblPageSubtitle.Name = "lblPageSubtitle";
            lblPageSubtitle.Size = new Size(320, 17);
            lblPageSubtitle.TabIndex = 1;
            lblPageSubtitle.Text = "Descarga videos y audio de tus plataformas favoritas";
            // 
            // pnlContent
            // 
            pnlContent.AutoScroll = true;
            pnlContent.BackColor = Color.FromArgb(18, 18, 22);
            pnlContent.Controls.Add(btnCancel);
            pnlContent.Controls.Add(lblUrl);
            pnlContent.Controls.Add(txtUrl);
            pnlContent.Controls.Add(btnAnalyze);
            pnlContent.Controls.Add(pnlVideoInfo);
            pnlContent.Controls.Add(lblDownloadType);
            pnlContent.Controls.Add(btnVideo);
            pnlContent.Controls.Add(btnAudio);
            pnlContent.Controls.Add(btnVideoAudio);
            pnlContent.Controls.Add(lblQuality);
            pnlContent.Controls.Add(cmbQuality);
            pnlContent.Controls.Add(lblFormat);
            pnlContent.Controls.Add(cmbFormat);
            pnlContent.Controls.Add(lblSavePath);
            pnlContent.Controls.Add(txtSavePath);
            pnlContent.Controls.Add(btnBrowse);
            pnlContent.Controls.Add(btnDownload);
            pnlContent.Controls.Add(pnlProgress);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(220, 80);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(35, 10, 35, 30);
            pnlContent.Size = new Size(980, 669);
            pnlContent.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(70, 110, 255);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(808, 498);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(160, 33);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "CANCELAR";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblUrl.ForeColor = Color.White;
            lblUrl.Location = new Point(35, 5);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(96, 19);
            lblUrl.TabIndex = 0;
            lblUrl.Text = "URL del video";
            // 
            // txtUrl
            // 
            txtUrl.BackColor = Color.FromArgb(30, 30, 36);
            txtUrl.BorderStyle = BorderStyle.FixedSingle;
            txtUrl.Font = new Font("Segoe UI", 10F);
            txtUrl.ForeColor = Color.FromArgb(230, 230, 235);
            txtUrl.Location = new Point(35, 32);
            txtUrl.Name = "txtUrl";
            txtUrl.PlaceholderText = "Pega aquí el enlace del video...";
            txtUrl.Size = new Size(650, 25);
            txtUrl.TabIndex = 1;
            // 
            // btnAnalyze
            // 
            btnAnalyze.BackColor = Color.FromArgb(70, 110, 255);
            btnAnalyze.Cursor = Cursors.Hand;
            btnAnalyze.FlatAppearance.BorderSize = 0;
            btnAnalyze.FlatStyle = FlatStyle.Flat;
            btnAnalyze.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnAnalyze.ForeColor = Color.White;
            btnAnalyze.Location = new Point(700, 31);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(125, 32);
            btnAnalyze.TabIndex = 2;
            btnAnalyze.Text = "ANALIZAR";
            btnAnalyze.UseVisualStyleBackColor = false;
            // 
            // pnlVideoInfo
            // 
            pnlVideoInfo.BackColor = Color.FromArgb(27, 27, 33);
            pnlVideoInfo.Controls.Add(pnlThumbnail);
            pnlVideoInfo.Controls.Add(lblVideoTitle);
            pnlVideoInfo.Controls.Add(lblDuration);
            pnlVideoInfo.Controls.Add(lblChannel);
            pnlVideoInfo.Location = new Point(35, 85);
            pnlVideoInfo.Name = "pnlVideoInfo";
            pnlVideoInfo.Size = new Size(790, 150);
            pnlVideoInfo.TabIndex = 3;
            // 
            // pnlThumbnail
            // 
            pnlThumbnail.BackColor = Color.FromArgb(38, 38, 45);
            pnlThumbnail.Controls.Add(picThumbnail);
            pnlThumbnail.Controls.Add(lblThumbnail);
            pnlThumbnail.Location = new Point(15, 15);
            pnlThumbnail.Name = "pnlThumbnail";
            pnlThumbnail.Size = new Size(190, 120);
            pnlThumbnail.TabIndex = 0;
            // 
            // picThumbnail
            // 
            picThumbnail.BackColor = Color.FromArgb(38, 38, 45);
            picThumbnail.Dock = DockStyle.Fill;
            picThumbnail.Location = new Point(0, 0);
            picThumbnail.Name = "picThumbnail";
            picThumbnail.Size = new Size(190, 120);
            picThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            picThumbnail.TabIndex = 0;
            picThumbnail.TabStop = false;
            picThumbnail.Visible = false;
            // 
            // lblThumbnail
            // 
            lblThumbnail.BackColor = Color.FromArgb(38, 38, 45);
            lblThumbnail.Dock = DockStyle.Fill;
            lblThumbnail.Font = new Font("Segoe UI", 9F);
            lblThumbnail.ForeColor = Color.FromArgb(120, 120, 130);
            lblThumbnail.Location = new Point(0, 0);
            lblThumbnail.Name = "lblThumbnail";
            lblThumbnail.Size = new Size(190, 120);
            lblThumbnail.TabIndex = 1;
            lblThumbnail.Text = "Vista previa";
            lblThumbnail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVideoTitle
            // 
            lblVideoTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblVideoTitle.ForeColor = Color.White;
            lblVideoTitle.Location = new Point(225, 20);
            lblVideoTitle.Name = "lblVideoTitle";
            lblVideoTitle.Size = new Size(540, 45);
            lblVideoTitle.TabIndex = 1;
            lblVideoTitle.Text = "Ningún video seleccionado";
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Segoe UI", 9.5F);
            lblDuration.ForeColor = Color.FromArgb(165, 165, 175);
            lblDuration.Location = new Point(225, 75);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(90, 17);
            lblDuration.TabIndex = 2;
            lblDuration.Text = "Duración: --:--";
            // 
            // lblChannel
            // 
            lblChannel.AutoSize = true;
            lblChannel.Font = new Font("Segoe UI", 9.5F);
            lblChannel.ForeColor = Color.FromArgb(165, 165, 175);
            lblChannel.Location = new Point(225, 100);
            lblChannel.Name = "lblChannel";
            lblChannel.Size = new Size(57, 17);
            lblChannel.TabIndex = 3;
            lblChannel.Text = "Canal: --";
            // 
            // lblDownloadType
            // 
            lblDownloadType.AutoSize = true;
            lblDownloadType.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblDownloadType.ForeColor = Color.White;
            lblDownloadType.Location = new Point(35, 255);
            lblDownloadType.Name = "lblDownloadType";
            lblDownloadType.Size = new Size(115, 19);
            lblDownloadType.TabIndex = 4;
            lblDownloadType.Text = "Tipo de descarga";
            // 
            // btnVideo
            // 
            btnVideo.BackColor = Color.FromArgb(70, 110, 255);
            btnVideo.Cursor = Cursors.Hand;
            btnVideo.FlatAppearance.BorderSize = 0;
            btnVideo.FlatStyle = FlatStyle.Flat;
            btnVideo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnVideo.ForeColor = Color.White;
            btnVideo.Location = new Point(35, 285);
            btnVideo.Name = "btnVideo";
            btnVideo.Size = new Size(150, 45);
            btnVideo.TabIndex = 5;
            btnVideo.Text = " Video";
            btnVideo.UseVisualStyleBackColor = false;
            // 
            // btnAudio
            // 
            btnAudio.BackColor = Color.FromArgb(30, 30, 36);
            btnAudio.Cursor = Cursors.Hand;
            btnAudio.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 70);
            btnAudio.FlatStyle = FlatStyle.Flat;
            btnAudio.Font = new Font("Segoe UI Semibold", 9.5F);
            btnAudio.ForeColor = Color.FromArgb(210, 210, 220);
            btnAudio.Location = new Point(195, 285);
            btnAudio.Name = "btnAudio";
            btnAudio.Size = new Size(150, 45);
            btnAudio.TabIndex = 6;
            btnAudio.Text = "  Audio";
            btnAudio.UseVisualStyleBackColor = false;
            // 
            // btnVideoAudio
            // 
            btnVideoAudio.BackColor = Color.FromArgb(30, 30, 36);
            btnVideoAudio.Cursor = Cursors.Hand;
            btnVideoAudio.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 70);
            btnVideoAudio.FlatStyle = FlatStyle.Flat;
            btnVideoAudio.Font = new Font("Segoe UI Semibold", 9.5F);
            btnVideoAudio.ForeColor = Color.FromArgb(210, 210, 220);
            btnVideoAudio.Location = new Point(355, 285);
            btnVideoAudio.Name = "btnVideoAudio";
            btnVideoAudio.Size = new Size(175, 45);
            btnVideoAudio.TabIndex = 7;
            btnVideoAudio.Text = " Video + Audio";
            btnVideoAudio.UseVisualStyleBackColor = false;
            // 
            // lblQuality
            // 
            lblQuality.AutoSize = true;
            lblQuality.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblQuality.ForeColor = Color.White;
            lblQuality.Location = new Point(35, 350);
            lblQuality.Name = "lblQuality";
            lblQuality.Size = new Size(56, 19);
            lblQuality.TabIndex = 8;
            lblQuality.Text = "Calidad";
            // 
            // cmbQuality
            // 
            cmbQuality.BackColor = Color.FromArgb(30, 30, 36);
            cmbQuality.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbQuality.FlatStyle = FlatStyle.Flat;
            cmbQuality.Font = new Font("Segoe UI", 9.5F);
            cmbQuality.ForeColor = Color.White;
            cmbQuality.Items.AddRange(new object[] { "Mejor calidad", "2160p - 4K", "1440p - 2K", "1080p - Full HD", "720p - HD", "480p", "360p" });
            cmbQuality.Location = new Point(35, 377);
            cmbQuality.Name = "cmbQuality";
            cmbQuality.Size = new Size(235, 25);
            cmbQuality.TabIndex = 9;
            // 
            // lblFormat
            // 
            lblFormat.AutoSize = true;
            lblFormat.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFormat.ForeColor = Color.White;
            lblFormat.Location = new Point(295, 350);
            lblFormat.Name = "lblFormat";
            lblFormat.Size = new Size(61, 19);
            lblFormat.TabIndex = 10;
            lblFormat.Text = "Formato";
            // 
            // cmbFormat
            // 
            cmbFormat.BackColor = Color.FromArgb(30, 30, 36);
            cmbFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormat.FlatStyle = FlatStyle.Flat;
            cmbFormat.Font = new Font("Segoe UI", 9.5F);
            cmbFormat.ForeColor = Color.White;
            cmbFormat.Items.AddRange(new object[] { "MP4", "MKV", "WEBM", "MP3", "M4A" });
            cmbFormat.Location = new Point(295, 377);
            cmbFormat.Name = "cmbFormat";
            cmbFormat.Size = new Size(235, 25);
            cmbFormat.TabIndex = 11;
            // 
            // lblSavePath
            // 
            lblSavePath.AutoSize = true;
            lblSavePath.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblSavePath.ForeColor = Color.White;
            lblSavePath.Location = new Point(35, 430);
            lblSavePath.Name = "lblSavePath";
            lblSavePath.Size = new Size(78, 19);
            lblSavePath.TabIndex = 12;
            lblSavePath.Text = "Guardar en";
            // 
            // txtSavePath
            // 
            txtSavePath.BackColor = Color.FromArgb(30, 30, 36);
            txtSavePath.BorderStyle = BorderStyle.FixedSingle;
            txtSavePath.Font = new Font("Segoe UI", 9.5F);
            txtSavePath.ForeColor = Color.FromArgb(210, 210, 220);
            txtSavePath.Location = new Point(35, 457);
            txtSavePath.Name = "txtSavePath";
            txtSavePath.Size = new Size(680, 24);
            txtSavePath.TabIndex = 13;
            txtSavePath.Text = "C:";
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.FromArgb(30, 30, 36);
            btnBrowse.Cursor = Cursors.Hand;
            btnBrowse.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 70);
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Segoe UI", 10F);
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point(725, 456);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(60, 30);
            btnBrowse.TabIndex = 14;
            btnBrowse.Text = "📁";
            btnBrowse.UseVisualStyleBackColor = false;
            // 
            // btnDownload
            // 
            btnDownload.BackColor = Color.FromArgb(70, 110, 255);
            btnDownload.Cursor = Cursors.Hand;
            btnDownload.FlatAppearance.BorderSize = 0;
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnDownload.ForeColor = Color.White;
            btnDownload.Location = new Point(808, 448);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(160, 33);
            btnDownload.TabIndex = 15;
            btnDownload.Text = " DESCARGAR";
            btnDownload.UseVisualStyleBackColor = false;
            // 
            // pnlProgress
            // 
            pnlProgress.BackColor = Color.FromArgb(27, 27, 33);
            pnlProgress.Controls.Add(progressBar);
            pnlProgress.Controls.Add(lblProgress);
            pnlProgress.Controls.Add(lblStatus);
            pnlProgress.Location = new Point(35, 555);
            pnlProgress.Name = "pnlProgress";
            pnlProgress.Size = new Size(790, 72);
            pnlProgress.TabIndex = 16;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(15, 18);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(760, 12);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 0;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Font = new Font("Segoe UI", 9F);
            lblProgress.ForeColor = Color.FromArgb(170, 170, 180);
            lblProgress.Location = new Point(15, 45);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(23, 15);
            lblProgress.TabIndex = 1;
            lblProgress.Text = "0%";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(170, 170, 180);
            lblStatus.Location = new Point(60, 45);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(112, 15);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Listo para descargar";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 22);
            ClientSize = new Size(1200, 749);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 650);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MediaDownloader";
            pnlSidebar.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            pnlVideoInfo.ResumeLayout(false);
            pnlVideoInfo.PerformLayout();
            pnlThumbnail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picThumbnail).EndInit();
            pnlProgress.ResumeLayout(false);
            pnlProgress.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCancel;
    }
}