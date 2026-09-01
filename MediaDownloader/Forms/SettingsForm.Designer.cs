namespace MediaDownloader.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private Panel pnlContent;

        private Label lblGeneral;
        private Label lblDownloadPath;
        private TextBox txtDownloadPath;
        private Button btnBrowse;

        private Label lblDefaultType;
        private ComboBox cmbDefaultType;

        private Label lblDefaultQuality;
        private ComboBox cmbDefaultQuality;

        private Label lblDefaultFormat;
        private ComboBox cmbDefaultFormat;

        private Label lblHistory;
        private CheckBox chkSaveHistory;

        private Label lblInterface;
        private CheckBox chkConfirmCancel;
        private CheckBox chkShowNotifications;

        private Button btnSave;
        private Button btnReset;

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
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();

            pnlContent = new Panel();

            lblGeneral = new Label();

            lblDownloadPath = new Label();
            txtDownloadPath = new TextBox();
            btnBrowse = new Button();

            lblDefaultType = new Label();
            cmbDefaultType = new ComboBox();

            lblDefaultQuality = new Label();
            cmbDefaultQuality = new ComboBox();

            lblDefaultFormat = new Label();
            cmbDefaultFormat = new ComboBox();

            lblHistory = new Label();
            chkSaveHistory = new CheckBox();

            lblInterface = new Label();
            chkConfirmCancel = new CheckBox();
            chkShowNotifications = new CheckBox();

            btnSave = new Button();
            btnReset = new Button();

            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();

            // 
            // pnlHeader
            // 
            pnlHeader.BackColor =
                Color.FromArgb(24, 24, 29);

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);

            pnlHeader.Dock =
                DockStyle.Top;

            pnlHeader.Location =
                new Point(0, 0);

            pnlHeader.Name =
                "pnlHeader";

            pnlHeader.Size =
                new Size(900, 105);

            pnlHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;

            lblTitle.Font =
                new Font(
                    "Segoe UI Semibold",
                    20F,
                    FontStyle.Bold
                );

            lblTitle.ForeColor =
                Color.White;

            lblTitle.Location =
                new Point(30, 18);

            lblTitle.Name =
                "lblTitle";

            lblTitle.Size =
                new Size(105, 37);

            lblTitle.TabIndex = 0;

            lblTitle.Text =
                "Ajustes";

            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;

            lblSubtitle.Font =
                new Font(
                    "Segoe UI",
                    9.5F
                );

            lblSubtitle.ForeColor =
                Color.FromArgb(
                    145,
                    145,
                    155
                );

            lblSubtitle.Location =
                new Point(33, 57);

            lblSubtitle.Name =
                "lblSubtitle";

            lblSubtitle.Size =
                new Size(370, 17);

            lblSubtitle.TabIndex = 1;

            lblSubtitle.Text =
                "Personaliza el comportamiento de MediaDownloader";

            // 
            // pnlContent
            // 
            pnlContent.AutoScroll = true;

            pnlContent.BackColor =
                Color.FromArgb(18, 18, 22);

            pnlContent.Controls.Add(lblGeneral);

            pnlContent.Controls.Add(lblDownloadPath);
            pnlContent.Controls.Add(txtDownloadPath);
            pnlContent.Controls.Add(btnBrowse);

            pnlContent.Controls.Add(lblDefaultType);
            pnlContent.Controls.Add(cmbDefaultType);

            pnlContent.Controls.Add(lblDefaultQuality);
            pnlContent.Controls.Add(cmbDefaultQuality);

            pnlContent.Controls.Add(lblDefaultFormat);
            pnlContent.Controls.Add(cmbDefaultFormat);

            pnlContent.Controls.Add(lblHistory);
            pnlContent.Controls.Add(chkSaveHistory);

            pnlContent.Controls.Add(lblInterface);
            pnlContent.Controls.Add(chkConfirmCancel);
            pnlContent.Controls.Add(chkShowNotifications);

            pnlContent.Controls.Add(btnSave);
            pnlContent.Controls.Add(btnReset);

            pnlContent.Dock =
                DockStyle.Fill;

            pnlContent.Location =
                new Point(0, 105);

            pnlContent.Name =
                "pnlContent";

            pnlContent.Padding =
                new Padding(
                    30,
                    25,
                    30,
                    30
                );

            pnlContent.Size =
                new Size(900, 595);

            pnlContent.TabIndex = 1;

            // 
            // lblGeneral
            // 
            lblGeneral.AutoSize = true;

            lblGeneral.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold
                );

            lblGeneral.ForeColor =
                Color.White;

            lblGeneral.Location =
                new Point(30, 20);

            lblGeneral.Name =
                "lblGeneral";

            lblGeneral.Size =
                new Size(152, 23);

            lblGeneral.TabIndex = 0;

            lblGeneral.Text =
                "Configuración general";

            // 
            // lblDownloadPath
            // 
            lblDownloadPath.AutoSize = true;

            lblDownloadPath.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold
                );

            lblDownloadPath.ForeColor =
                Color.White;

            lblDownloadPath.Location =
                new Point(30, 70);

            lblDownloadPath.Name =
                "lblDownloadPath";

            lblDownloadPath.Size =
                new Size(135, 19);

            lblDownloadPath.TabIndex = 1;

            lblDownloadPath.Text =
                "Carpeta de descargas";

            // 
            // txtDownloadPath
            // 
            txtDownloadPath.BackColor =
                Color.FromArgb(
                    30,
                    30,
                    36
                );

            txtDownloadPath.BorderStyle =
                BorderStyle.FixedSingle;

            txtDownloadPath.Font =
                new Font(
                    "Segoe UI",
                    9.5F
                );

            txtDownloadPath.ForeColor =
                Color.FromArgb(
                    220,
                    220,
                    225
                );

            txtDownloadPath.Location =
                new Point(30, 98);

            txtDownloadPath.Name =
                "txtDownloadPath";

            txtDownloadPath.Size =
                new Size(650, 24);

            txtDownloadPath.TabIndex = 2;

            // 
            // btnBrowse
            // 
            btnBrowse.BackColor =
                Color.FromArgb(
                    30,
                    30,
                    36
                );

            btnBrowse.Cursor =
                Cursors.Hand;

            btnBrowse.FlatAppearance.BorderColor =
                Color.FromArgb(
                    60,
                    60,
                    70
                );

            btnBrowse.FlatStyle =
                FlatStyle.Flat;

            btnBrowse.Font =
                new Font(
                    "Segoe UI",
                    10F
                );

            btnBrowse.ForeColor =
                Color.White;

            btnBrowse.Location =
                new Point(695, 94);

            btnBrowse.Name =
                "btnBrowse";

            btnBrowse.Size =
                new Size(75, 32);

            btnBrowse.TabIndex = 3;

            btnBrowse.Text =
                "📁";

            btnBrowse.UseVisualStyleBackColor =
                false;

            btnBrowse.Click +=
                btnBrowse_Click;

            // 
            // lblDefaultType
            // 
            lblDefaultType.AutoSize = true;

            lblDefaultType.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold
                );

            lblDefaultType.ForeColor =
                Color.White;

            lblDefaultType.Location =
                new Point(30, 150);

            lblDefaultType.Name =
                "lblDefaultType";

            lblDefaultType.Size =
                new Size(120, 19);

            lblDefaultType.TabIndex = 4;

            lblDefaultType.Text =
                "Tipo predeterminado";

            // 
            // cmbDefaultType
            // 
            cmbDefaultType.BackColor =
                Color.FromArgb(
                    30,
                    30,
                    36
                );

            cmbDefaultType.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbDefaultType.FlatStyle =
                FlatStyle.Flat;

            cmbDefaultType.Font =
                new Font(
                    "Segoe UI",
                    9.5F
                );

            cmbDefaultType.ForeColor =
                Color.White;

            cmbDefaultType.Items.AddRange(
                new object[]
                {
                    "Video",
                    "Audio",
                    "Video + Audio"
                }
            );

            cmbDefaultType.Location =
                new Point(30, 178);

            cmbDefaultType.Name =
                "cmbDefaultType";

            cmbDefaultType.Size =
                new Size(230, 25);

            cmbDefaultType.TabIndex = 5;

            // 
            // lblDefaultQuality
            // 
            lblDefaultQuality.AutoSize = true;

            lblDefaultQuality.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold
                );

            lblDefaultQuality.ForeColor =
                Color.White;

            lblDefaultQuality.Location =
                new Point(290, 150);

            lblDefaultQuality.Name =
                "lblDefaultQuality";

            lblDefaultQuality.Size =
                new Size(135, 19);

            lblDefaultQuality.TabIndex = 6;

            lblDefaultQuality.Text =
                "Calidad predeterminada";

            // 
            // cmbDefaultQuality
            // 
            cmbDefaultQuality.BackColor =
                Color.FromArgb(
                    30,
                    30,
                    36
                );

            cmbDefaultQuality.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbDefaultQuality.FlatStyle =
                FlatStyle.Flat;

            cmbDefaultQuality.Font =
                new Font(
                    "Segoe UI",
                    9.5F
                );

            cmbDefaultQuality.ForeColor =
                Color.White;

            cmbDefaultQuality.Items.AddRange(
                new object[]
                {
                    "Mejor calidad",
                    "2160p - 4K",
                    "1440p - 2K",
                    "1080p - Full HD",
                    "720p - HD",
                    "480p",
                    "360p"
                }
            );

            cmbDefaultQuality.Location =
                new Point(290, 178);

            cmbDefaultQuality.Name =
                "cmbDefaultQuality";

            cmbDefaultQuality.Size =
                new Size(230, 25);

            cmbDefaultQuality.TabIndex = 7;

            // 
            // lblDefaultFormat
            // 
            lblDefaultFormat.AutoSize = true;

            lblDefaultFormat.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold
                );

            lblDefaultFormat.ForeColor =
                Color.White;

            lblDefaultFormat.Location =
                new Point(550, 150);

            lblDefaultFormat.Name =
                "lblDefaultFormat";

            lblDefaultFormat.Size =
                new Size(142, 19);

            lblDefaultFormat.TabIndex = 8;

            lblDefaultFormat.Text =
                "Formato predeterminado";

            // 
            // cmbDefaultFormat
            // 
            cmbDefaultFormat.BackColor =
                Color.FromArgb(
                    30,
                    30,
                    36
                );

            cmbDefaultFormat.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbDefaultFormat.FlatStyle =
                FlatStyle.Flat;

            cmbDefaultFormat.Font =
                new Font(
                    "Segoe UI",
                    9.5F
                );

            cmbDefaultFormat.ForeColor =
                Color.White;

            cmbDefaultFormat.Items.AddRange(
                new object[]
                {
                    "MP4",
                    "MKV",
                    "WEBM",
                    "MP3",
                    "M4A"
                }
            );

            cmbDefaultFormat.Location =
                new Point(550, 178);

            cmbDefaultFormat.Name =
                "cmbDefaultFormat";

            cmbDefaultFormat.Size =
                new Size(220, 25);

            cmbDefaultFormat.TabIndex = 9;

            // 
            // lblHistory
            // 
            lblHistory.AutoSize = true;

            lblHistory.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold
                );

            lblHistory.ForeColor =
                Color.White;

            lblHistory.Location =
                new Point(30, 235);

            lblHistory.Name =
                "lblHistory";

            lblHistory.Size =
                new Size(192, 23);

            lblHistory.TabIndex = 10;

            lblHistory.Text =
                "Historial de descargas";

            // 
            // chkSaveHistory
            // 
            chkSaveHistory.AutoSize = true;

            chkSaveHistory.Font =
                new Font(
                    "Segoe UI",
                    10F
                );

            chkSaveHistory.ForeColor =
                Color.FromArgb(
                    215,
                    215,
                    220
                );

            chkSaveHistory.Location =
                new Point(30, 275);

            chkSaveHistory.Name =
                "chkSaveHistory";

            chkSaveHistory.Size =
                new Size(310, 23);

            chkSaveHistory.TabIndex = 11;

            chkSaveHistory.Text =
                "Guardar automáticamente las descargas";

            chkSaveHistory.UseVisualStyleBackColor =
                true;

            // 
            // lblInterface
            // 
            lblInterface.AutoSize = true;

            lblInterface.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold
                );

            lblInterface.ForeColor =
                Color.White;

            lblInterface.Location =
                new Point(30, 325);

            lblInterface.Name =
                "lblInterface";

            lblInterface.Size =
                new Size(171, 23);

            lblInterface.TabIndex = 12;

            lblInterface.Text =
                "Interfaz y comportamiento";

            // 
            // chkConfirmCancel
            // 
            chkConfirmCancel.AutoSize = true;

            chkConfirmCancel.Font =
                new Font(
                    "Segoe UI",
                    10F
                );

            chkConfirmCancel.ForeColor =
                Color.FromArgb(
                    215,
                    215,
                    220
                );

            chkConfirmCancel.Location =
                new Point(30, 365);

            chkConfirmCancel.Name =
                "chkConfirmCancel";

            chkConfirmCancel.Size =
                new Size(360, 23);

            chkConfirmCancel.TabIndex = 13;

            chkConfirmCancel.Text =
                "Confirmar antes de cancelar una descarga";

            chkConfirmCancel.UseVisualStyleBackColor =
                true;

            // 
            // chkShowNotifications
            // 
            chkShowNotifications.AutoSize = true;

            chkShowNotifications.Font =
                new Font(
                    "Segoe UI",
                    10F
                );

            chkShowNotifications.ForeColor =
                Color.FromArgb(
                    215,
                    215,
                    220
                );

            chkShowNotifications.Location =
                new Point(30, 400);

            chkShowNotifications.Name =
                "chkShowNotifications";

            chkShowNotifications.Size =
                new Size(300, 23);

            chkShowNotifications.TabIndex = 14;

            chkShowNotifications.Text =
                "Mostrar notificaciones al completar";

            chkShowNotifications.UseVisualStyleBackColor =
                true;

            // 
            // btnSave
            // 
            btnSave.BackColor =
                Color.FromArgb(
                    70,
                    110,
                    255
                );

            btnSave.Cursor =
                Cursors.Hand;

            btnSave.FlatAppearance.BorderSize =
                0;

            btnSave.FlatStyle =
                FlatStyle.Flat;

            btnSave.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold
                );

            btnSave.ForeColor =
                Color.White;

            btnSave.Location =
                new Point(570, 465);

            btnSave.Name =
                "btnSave";

            btnSave.Size =
                new Size(200, 40);

            btnSave.TabIndex = 15;

            btnSave.Text =
                "GUARDAR CAMBIOS";

            btnSave.UseVisualStyleBackColor =
                false;

            btnSave.Click +=
                btnSave_Click;

            // 
            // btnReset
            // 
            btnReset.BackColor =
                Color.FromArgb(
                    30,
                    30,
                    36
                );

            btnReset.Cursor =
                Cursors.Hand;

            btnReset.FlatAppearance.BorderColor =
                Color.FromArgb(
                    60,
                    60,
                    70
                );

            btnReset.FlatStyle =
                FlatStyle.Flat;

            btnReset.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F
                );

            btnReset.ForeColor =
                Color.FromArgb(
                    220,
                    220,
                    225
                );

            btnReset.Location =
                new Point(350, 465);

            btnReset.Name =
                "btnReset";

            btnReset.Size =
                new Size(200, 40);

            btnReset.TabIndex = 16;

            btnReset.Text =
                "RESTABLECER";

            btnReset.UseVisualStyleBackColor =
                false;

            btnReset.Click +=
                btnReset_Click;

            // 
            // SettingsForm
            // 
            AutoScaleDimensions =
                new SizeF(
                    7F,
                    15F
                );

            AutoScaleMode =
                AutoScaleMode.Font;

            BackColor =
                Color.FromArgb(
                    18,
                    18,
                    22
                );

            ClientSize =
                new Size(
                    900,
                    700
                );

            Controls.Add(
                pnlContent
            );

            Controls.Add(
                pnlHeader
            );

            MinimumSize =
                new Size(
                    800,
                    600
                );

            Name =
                "SettingsForm";

            StartPosition =
                FormStartPosition.CenterScreen;

            Text =
                "MediaDownloader - Ajustes";

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();

            ResumeLayout(false);
        }

        #endregion
    }
}