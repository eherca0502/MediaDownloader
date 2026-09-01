namespace MediaDownloader.Forms
{
    partial class DownloadsForm
    {
        private System.ComponentModel.IContainer components = null;


    private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblCount;

        private TextBox txtSearch;
        private Button btnRefresh;

        private Panel pnlContent;
        private DataGridView dgvDownloads;
        private Label lblEmpty;

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
            lblCount = new Label();

            txtSearch = new TextBox();
            btnRefresh = new Button();

            pnlContent = new Panel();
            dgvDownloads = new DataGridView();
            lblEmpty = new Label();

            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDownloads).BeginInit();
            SuspendLayout();

           
            pnlHeader.BackColor =
                Color.FromArgb(24, 24, 29);

            pnlHeader.Controls.Add(
                lblTitle
            );

            pnlHeader.Controls.Add(
                lblSubtitle
            );

            pnlHeader.Controls.Add(
                lblCount
            );

            pnlHeader.Controls.Add(
                txtSearch
            );

            pnlHeader.Controls.Add(
                btnRefresh
            );

            pnlHeader.Dock =
                DockStyle.Top;

            pnlHeader.Location =
                new Point(0, 0);

            pnlHeader.Name =
                "pnlHeader";

            pnlHeader.Size =
                new Size(1180, 125);

            pnlHeader.TabIndex =
                0;

            lblTitle.AutoSize =
                true;

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
                new Size(170, 37);

            lblTitle.TabIndex =
                0;

            lblTitle.Text =
                "Descargas";

            
            lblSubtitle.AutoSize =
                true;

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
                new Point(33, 55);

            lblSubtitle.Name =
                "lblSubtitle";

            lblSubtitle.Size =
                new Size(380, 17);

            lblSubtitle.TabIndex =
                1;

            lblSubtitle.Text =
                "Consulta las descargas realizadas recientemente";

            
            lblCount.AutoSize =
                true;

            lblCount.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold
                );

            lblCount.ForeColor =
                Color.FromArgb(
                    120,
                    145,
                    255
                );

            lblCount.Location =
                new Point(33, 83);

            lblCount.Name =
                "lblCount";

            lblCount.Size =
                new Size(72, 15);

            lblCount.TabIndex =
                2;

            lblCount.Text =
                "0 descargas";

            
            txtSearch.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            txtSearch.BackColor =
                Color.FromArgb(
                    30,
                    30,
                    36
                );

            txtSearch.BorderStyle =
                BorderStyle.FixedSingle;

            txtSearch.Font =
                new Font(
                    "Segoe UI",
                    10F
                );

            txtSearch.ForeColor =
                Color.White;

            txtSearch.Location =
                new Point(650, 27);

            txtSearch.Name =
                "txtSearch";

            txtSearch.PlaceholderText =
                "Buscar descarga...";

            txtSearch.Size =
                new Size(250, 25);

            txtSearch.TabIndex =
                3;

            txtSearch.TextChanged +=
                txtSearch_TextChanged;

    
            btnRefresh.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnRefresh.BackColor =
                Color.FromArgb(
                    70,
                    110,
                    255
                );

            btnRefresh.Cursor =
                Cursors.Hand;

            btnRefresh.FlatAppearance.BorderSize =
                0;

            btnRefresh.FlatStyle =
                FlatStyle.Flat;

            btnRefresh.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold
                );

            btnRefresh.ForeColor =
                Color.White;

            btnRefresh.Location =
                new Point(915, 24);

            btnRefresh.Name =
                "btnRefresh";

            btnRefresh.Size =
                new Size(120, 32);

            btnRefresh.TabIndex =
                4;

            btnRefresh.Text =
                " Actualizar";

            btnRefresh.UseVisualStyleBackColor =
                false;

            btnRefresh.Click +=
                btnRefresh_Click;

            
            pnlContent.BackColor =
                Color.FromArgb(
                    18,
                    18,
                    22
                );

            pnlContent.Controls.Add(
                dgvDownloads
            );

            pnlContent.Controls.Add(
                lblEmpty
            );

            pnlContent.Dock =
                DockStyle.Fill;

            pnlContent.Location =
                new Point(0, 125);

            pnlContent.Name =
                "pnlContent";

            pnlContent.Padding =
                new Padding(
                    30,
                    20,
                    30,
                    30
                );

            pnlContent.Size =
                new Size(1180, 575);

            pnlContent.TabIndex =
                1;

            
            dgvDownloads.AllowUserToAddRows =
                false;

            dgvDownloads.AllowUserToDeleteRows =
                false;

            dgvDownloads.AllowUserToResizeRows =
                false;

            dgvDownloads.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvDownloads.BackgroundColor =
                Color.FromArgb(
                    18,
                    18,
                    22
                );

            dgvDownloads.BorderStyle =
                BorderStyle.None;

            dgvDownloads.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvDownloads.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvDownloads.ColumnHeadersHeight =
                42;

            dgvDownloads.EnableHeadersVisualStyles =
                false;

            dgvDownloads.GridColor =
                Color.FromArgb(
                    42,
                    42,
                    50
                );

            dgvDownloads.Location =
                new Point(
                    30,
                    20
                );

            dgvDownloads.MultiSelect =
                false;

            dgvDownloads.Name =
                "dgvDownloads";

            dgvDownloads.ReadOnly =
                true;

            dgvDownloads.RowHeadersVisible =
                false;

            dgvDownloads.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvDownloads.Size =
                new Size(
                    1120,
                    500
                );

            dgvDownloads.TabIndex =
                5;

            dgvDownloads.CellContentClick +=
                dgvDownloads_CellContentClick;

            
            dgvDownloads.ColumnHeadersDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.FromArgb(
                            30,
                            30,
                            36
                        ),

                    ForeColor =
                        Color.FromArgb(
                            190,
                            190,
                            200
                        ),

                    Font =
                        new Font(
                            "Segoe UI Semibold",
                            9F,
                            FontStyle.Bold
                        ),

                    Alignment =
                        DataGridViewContentAlignment.MiddleLeft,

                    Padding =
                        new Padding(
                            8,
                            0,
                            8,
                            0
                        )
                };

            
            dgvDownloads.DefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.FromArgb(
                            24,
                            24,
                            29
                        ),

                    ForeColor =
                        Color.FromArgb(
                            220,
                            220,
                            225
                        ),

                    SelectionBackColor =
                        Color.FromArgb(
                            45,
                            55,
                            85
                        ),

                    SelectionForeColor =
                        Color.White,

                    Font =
                        new Font(
                            "Segoe UI",
                            9F
                        ),

                    Padding =
                        new Padding(
                            8,
                            5,
                            8,
                            5
                        ),

                    NullValue =
                        "-"
                };

            dgvDownloads.RowTemplate.Height =
                48;

            
            dgvDownloads.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name =
                        "colTitle",

                    HeaderText =
                        "Título",

                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill,

                    FillWeight =
                        220
                }
            );

           
            dgvDownloads.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name =
                        "colType",

                    HeaderText =
                        "Tipo",

                    Width =
                        100
                }
            );

            
            dgvDownloads.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name =
                        "colQuality",

                    HeaderText =
                        "Calidad",

                    Width =
                        120
                }
            );

           
            dgvDownloads.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name =
                        "colFormat",

                    HeaderText =
                        "Formato",

                    Width =
                        90
                }
            );

           
            dgvDownloads.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name =
                        "colDate",

                    HeaderText =
                        "Fecha",

                    Width =
                        135
                }
            );

            
            dgvDownloads.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name =
                        "colStatus",

                    HeaderText =
                        "Estado",

                    Width =
                        105
                }
            );

            
            dgvDownloads.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name =
                        "colOpen",

                    HeaderText =
                        "",

                    Text =
                        "Abrir",

                    UseColumnTextForButtonValue =
                        true,

                    Width =
                        70
                }
            );

            
            dgvDownloads.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name =
                        "colFolder",

                    HeaderText =
                        "",

                    Text =
                        "Carpeta",

                    UseColumnTextForButtonValue =
                        true,

                    Width =
                        80
                }
            );

            
            lblEmpty.AutoSize =
                false;

            lblEmpty.Dock =
                DockStyle.Fill;

            lblEmpty.Font =
                new Font(
                    "Segoe UI",
                    12F
                );

            lblEmpty.ForeColor =
                Color.FromArgb(
                    120,
                    120,
                    130
                );

            lblEmpty.Location =
                new Point(
                    30,
                    20
                );

            lblEmpty.Name =
                "lblEmpty";

            lblEmpty.Size =
                new Size(
                    1120,
                    500
                );

            lblEmpty.TabIndex =
                6;

            lblEmpty.Text =
                "No hay descargas disponibles";

            lblEmpty.TextAlign =
                ContentAlignment.MiddleCenter;

            lblEmpty.Visible =
                false;

            
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
                    1180,
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
                    1000,
                    600
                );

            Name =
                "DownloadsForm";

            StartPosition =
                FormStartPosition.CenterScreen;

            Text =
                "MediaDownloader - Descargas";

            pnlHeader.ResumeLayout(
                false
            );

            pnlHeader.PerformLayout();

            pnlContent.ResumeLayout(
                false
            );

            ((System.ComponentModel.ISupportInitialize)
                dgvDownloads).EndInit();

            ResumeLayout(
                false
            );
        }

        #endregion
    }


}
