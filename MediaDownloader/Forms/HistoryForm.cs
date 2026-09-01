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
    public partial class HistoryForm : Form
    {
        private readonly HistoryService _historyService;


    private List<DownloadHistory> _history =
        new List<DownloadHistory>();

        public HistoryForm()
        {
            InitializeComponent();

            _historyService = new HistoryService();

            Load += HistoryForm_Load;
        }

        private async void HistoryForm_Load(
            object? sender,
            EventArgs e)
        {
            await LoadHistoryAsync();
        }

        private async Task LoadHistoryAsync()
        {
            try
            {
                _history =
                    await _historyService.GetHistoryAsync();

                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar el historial.\n\n" +
                    ex.Message,
                    "Historial",
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
                _history;

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

            dgvHistory.Rows.Clear();

            foreach (DownloadHistory item in filtered)
            {
                int rowIndex =
                    dgvHistory.Rows.Add(
                        item.Title ?? "Sin título",
                        item.Type ?? "-",
                        item.Quality ?? "-",
                        item.Format ?? "-",
                        item.Date.ToString(
                            "dd/MM/yyyy HH:mm"
                        ),
                        item.Status ?? "-"
                    );

                dgvHistory.Rows[rowIndex].Tag =
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
            await LoadHistoryAsync();
        }


        private async void btnClear_Click(
            object? sender,
            EventArgs e)
        {
            if (_history.Count == 0)
            {
                MessageBox.Show(
                    "El historial ya está vacío.",
                    "Historial",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "¿Deseas eliminar todo el historial?",
                    "Limpiar historial",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await _historyService.ClearAsync();

                _history.Clear();

                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible limpiar el historial.\n\n" +
                    ex.Message,
                    "Historial",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void dgvHistory_CellContentClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
            {
                return;
            }

            if (dgvHistory.Rows[e.RowIndex].Tag
                is not DownloadHistory item)
            {
                return;
            }

            string columnName =
                dgvHistory.Columns[
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

                case "colDelete":
                    _ = DeleteItemAsync(item);
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

        private async Task DeleteItemAsync(
            DownloadHistory item)
        {
            DialogResult result =
                MessageBox.Show(
                    $"¿Eliminar esta descarga del historial?\n\n" +
                    $"{item.Title}",
                    "Eliminar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await _historyService.DeleteAsync(
                    item
                );

                _history.Remove(item);

                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible eliminar la descarga.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }


}
