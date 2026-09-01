namespace MediaDownloader.Forms
{
    partial class HistoryForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblCount;

        private TextBox txtSearch;
        private Button btnRefresh;
        private Button btnClear;

        private Panel pnlContent;
        private DataGridView dgvHistory;
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
            btnClear = new Button();

            pnlContent = new Panel();
            dgvHistory = new DataGridView();
            lblEmpty = new Label();

            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
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

            pnlHeader.Controls.Add(
                btnClear
            );

            pnlHeader.Dock =
                DockStyle.Top;

            pnlHeader.Location =
                new Point(0, 0);

            pnlHeader.Name =
                "pnlHeader";

            pnlHeader.Size =
                new Size(1180, 125);

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

            lblTitle.Text =
                "Historial de descargas";

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

            lblSubtitle.Text =
                "Consulta y administra tus descargas anteriores";


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
                new Point(550, 27);

            txtSearch.Name =
                "txtSearch";

            txtSearch.PlaceholderText =
                "Buscar descarga...";

            txtSearch.Size =
                new Size(250, 25);

            txtSearch.TabIndex =
                0;

            txtSearch.TextChanged +=
                txtSearch_TextChanged;


            btnRefresh.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnRefresh.BackColor =
                Color.FromArgb(
                    30,
                    30,
                    36
                );

            btnRefresh.Cursor =
                Cursors.Hand;

            btnRefresh.FlatAppearance.BorderColor =
                Color.FromArgb(
                    60,
                    60,
                    70
                );

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
                new Point(815, 24);

            btnRefresh.Name =
                "btnRefresh";

            btnRefresh.Size =
                new Size(100, 32);

            btnRefresh.TabIndex =
                1;

            btnRefresh.Text =
                "↻ Actualizar";

            btnRefresh.UseVisualStyleBackColor =
                false;

            btnRefresh.Click +=
                btnRefresh_Click;


            btnClear.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnClear.BackColor =
                Color.FromArgb(
                    145,
                    55,
                    65
                );

            btnClear.Cursor =
                Cursors.Hand;

            btnClear.FlatAppearance.BorderSize =
                0;

            btnClear.FlatStyle =
                FlatStyle.Flat;

            btnClear.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold
                );

            btnClear.ForeColor =
                Color.White;

            btnClear.Location =
                new Point(925, 24);

            btnClear.Name =
                "btnClear";

            btnClear.Size =
                new Size(120, 32);

            btnClear.TabIndex =
                2;

            btnClear.Text =
                "🗑 Limpiar";

            btnClear.UseVisualStyleBackColor =
                false;

            btnClear.Click +=
                btnClear_Click;


            pnlContent.BackColor =
                Color.FromArgb(
                    18,
                    18,
                    22
                );

            pnlContent.Controls.Add(
                dgvHistory
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


            dgvHistory.AllowUserToAddRows =
                false;

            dgvHistory.AllowUserToDeleteRows =
                false;

            dgvHistory.AllowUserToResizeRows =
                false;

            dgvHistory.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvHistory.BackgroundColor =
                Color.FromArgb(
                    18,
                    18,
                    22
                );

            dgvHistory.BorderStyle =
                BorderStyle.None;

            dgvHistory.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvHistory.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvHistory.ColumnHeadersHeight =
                42;

            dgvHistory.EnableHeadersVisualStyles =
                false;

            dgvHistory.GridColor =
                Color.FromArgb(
                    42,
                    42,
                    50
                );

            dgvHistory.Location =
                new Point(
                    30,
                    20
                );

            dgvHistory.MultiSelect =
                false;

            dgvHistory.Name =
                "dgvHistory";

            dgvHistory.ReadOnly =
                true;

            dgvHistory.RowHeadersVisible =
                false;

            dgvHistory.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvHistory.Size =
                new Size(
                    1120,
                    500
                );

            dgvHistory.TabIndex =
                3;

            dgvHistory.CellContentClick +=
                dgvHistory_CellContentClick;


            dgvHistory.ColumnHeadersDefaultCellStyle =
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


            dgvHistory.DefaultCellStyle =
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

            dgvHistory.RowTemplate.Height =
                48;


            dgvHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colTitle",
                    HeaderText = "Título",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 220
                }
            );

            dgvHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colType",
                    HeaderText = "Tipo",
                    Width = 90
                }
            );

            dgvHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colQuality",
                    HeaderText = "Calidad",
                    Width = 120
                }
            );

            dgvHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colFormat",
                    HeaderText = "Formato",
                    Width = 90
                }
            );

            dgvHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDate",
                    HeaderText = "Fecha",
                    Width = 135
                }
    
                );

            dgvHistory.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colStatus",
                    HeaderText = "Estado",
                    Width = 105
                }
            );

            dgvHistory.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colOpen",
                    HeaderText = "",
                    Text = "Abrir",
                    UseColumnTextForButtonValue = true,
                    Width = 70
                }
            );

            dgvHistory.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colFolder",
                    HeaderText = "",
                    Text = "Carpeta",
                    UseColumnTextForButtonValue = true,
                    Width = 80
                }
            );

            dgvHistory.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colDelete",
                    HeaderText = "",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true,
                    Width = 85
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

            lblEmpty.Text =
                "No hay descargas en el historial";

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
                "HistoryForm";

            StartPosition =
                FormStartPosition.CenterScreen;

            Text =
                "MediaDownloader - Historial";

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlContent.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                dgvHistory).EndInit();

            ResumeLayout(false);
        }

        #endregion
    }


}
