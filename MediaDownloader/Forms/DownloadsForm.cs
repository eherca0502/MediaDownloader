using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaDownloader.Models;
using MediaDownloader.Services;

namespace MediaDownloader.Forms
{
    public partial class DownloadsForm : Form
    {
        private readonly HistoryService _historyService;


    private List<DownloadHistory> _downloads =
        new List<DownloadHistory>();

        public DownloadsForm()
        {
            InitializeComponent();

            _historyService =
                new HistoryService();

            Load += DownloadsForm_Load;
        }

        private async void DownloadsForm_Load(
            object? sender,
            EventArgs e)
        {
            await LoadDownloadsAsync();
        }

        private async Task LoadDownloadsAsync()
        {
            try
            {
                _downloads =
                    await _historyService.GetHistoryAsync();

                _downloads =
                    _downloads
                        .OrderByDescending(x => x.Date)
                        .ToList();

                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar las descargas.\n\n" +
                    ex.Message,
                    "Descargas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ApplyFilter()
        {
            string search =
                txtSearch.Text.Trim();

            IEnumerable<DownloadHistory> query =
                _downloads;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query =
                    query.Where(item =>
                        (item.Title ?? string.Empty)
                            .Contains(
                                search,
                                StringComparison.OrdinalIgnoreCase
                            )
                        ||
                        (item.Type ?? string.Empty)
                            .Contains(
                                search,
                                StringComparison.OrdinalIgnoreCase
                            )
                        ||
                        (item.Quality ?? string.Empty)
                            .Contains(
                                search,
                                StringComparison.OrdinalIgnoreCase
                            )
                        ||
                        (item.Format ?? string.Empty)
                            .Contains(
                                search,
                                StringComparison.OrdinalIgnoreCase
                            )
                        ||
                        (item.Status ?? string.Empty)
                            .Contains(
                                search,
                                StringComparison.OrdinalIgnoreCase
                            )
                    );
            }

            List<DownloadHistory> filtered =
                query.ToList();

            dgvDownloads.Rows.Clear();

            foreach (DownloadHistory item in filtered)
            {
                int rowIndex =
                    dgvDownloads.Rows.Add(
                        item.Title ?? "Sin título",
                        item.Type ?? "-",
                        item.Quality ?? "-",
                        item.Format ?? "-",
                        item.Date.ToString(
                            "dd/MM/yyyy HH:mm"
                        ),
                        item.Status ?? "-"
                    );

                dgvDownloads.Rows[rowIndex].Tag =
                    item;
            }

            lblCount.Text =
                $"{filtered.Count} descarga" +
                (filtered.Count == 1
                    ? string.Empty
                    : "s");

            lblEmpty.Visible =
                filtered.Count == 0;
        }

        private void txtSearch_TextChanged(
            object? sender,
            EventArgs e)
        {
            ApplyFilter();
        }

        private async void btnRefresh_Click(
            object? sender,
            EventArgs e)
        {
            await LoadDownloadsAsync();
        }

        private void dgvDownloads_CellContentClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
            {
                return;
            }

            if (dgvDownloads.Rows[e.RowIndex].Tag
                is not DownloadHistory item)
            {
                return;
            }

            string columnName =
                dgvDownloads.Columns[
                    e.ColumnIndex
                ].Name;

            switch (columnName)
            {
                case "colOpen":
                    OpenFile(item);
                    break;

                case "colFolder":
                    OpenFolder(item);
                    break;
            }
        }

        private void OpenFile(
            DownloadHistory item)
        {
            if (string.IsNullOrWhiteSpace(
                item.FilePath))
            {
                MessageBox.Show(
                    "No existe una ruta asociada a esta descarga.",
                    "Abrir archivo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            if (!File.Exists(item.FilePath))
            {
                MessageBox.Show(
                    "El archivo ya no existe en la ubicación indicada.",
                    "Archivo no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = item.FilePath,
                        UseShellExecute = true
                    }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible abrir el archivo.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void OpenFolder(
            DownloadHistory item)
        {
            if (string.IsNullOrWhiteSpace(
                item.FilePath))
            {
                MessageBox.Show(
                    "No existe una ruta asociada a esta descarga.",
                    "Abrir carpeta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            string? directory =
                Path.GetDirectoryName(
                    item.FilePath
                );

            if (string.IsNullOrWhiteSpace(directory) ||
                !Directory.Exists(directory))
            {
                MessageBox.Show(
                    "La carpeta ya no existe.",
                    "Carpeta no encontrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = "explorer.exe",
                        Arguments =
                            $"\"{directory}\"",
                        UseShellExecute = true
                    }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible abrir la carpeta.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }


}
