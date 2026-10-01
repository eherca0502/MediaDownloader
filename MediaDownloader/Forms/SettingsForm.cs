
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaDownloader.Models;
using MediaDownloader.Services;

namespace MediaDownloader.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly SettingsService _settingsService;

        private AppSettings _settings =
            new AppSettings();

        public SettingsForm()
        {
            InitializeComponent();

            _settingsService =
                new SettingsService();

            Load += SettingsForm_Load;
        }

        private async void SettingsForm_Load(
            object? sender,
            EventArgs e)
        {
            await LoadSettingsAsync();
        }

        private async Task LoadSettingsAsync()
        {
            try
            {
                _settings =
                    await _settingsService
                        .GetSettingsAsync();


                txtDownloadPath.Text =
                    _settings.DownloadPath;


                int typeIndex =
                    cmbDefaultType.Items.IndexOf(
                        _settings.DefaultType
                    );

                cmbDefaultType.SelectedIndex =
                    typeIndex >= 0
                        ? typeIndex
                        : 0;

                int qualityIndex =
                    cmbDefaultQuality.Items.IndexOf(
                        _settings.DefaultQuality
                    );

                cmbDefaultQuality.SelectedIndex =
                    qualityIndex >= 0
                        ? qualityIndex
                        : 0;

                int formatIndex =
                    cmbDefaultFormat.Items.IndexOf(
                        _settings.DefaultFormat
                    );

                cmbDefaultFormat.SelectedIndex =
                    formatIndex >= 0
                        ? formatIndex
                        : 0;


                chkSaveHistory.Checked =
                    _settings.SaveHistory;


                chkConfirmCancel.Checked =
                    _settings.ConfirmCancel;


                chkShowNotifications.Checked =
                    _settings.ShowNotifications;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar la configuración.\n\n" +
                    ex.Message,
                    "Ajustes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnBrowse_Click(
            object? sender,
            EventArgs e)
        {
            using FolderBrowserDialog dialog =
                new FolderBrowserDialog();

            dialog.Description =
                "Selecciona la carpeta predeterminada para las descargas";

            dialog.UseDescriptionForTitle =
                true;

            if (Directory.Exists(
                txtDownloadPath.Text))
            {
                dialog.SelectedPath =
                    txtDownloadPath.Text;
            }

            if (dialog.ShowDialog(this) ==
                DialogResult.OK)
            {
                txtDownloadPath.Text =
                    dialog.SelectedPath;
            }
        }

        private async void btnSave_Click(
            object? sender,
            EventArgs e)
        {
            string downloadPath =
                txtDownloadPath.Text.Trim();

            if (string.IsNullOrWhiteSpace(
                downloadPath))
            {
                MessageBox.Show(
                    "Selecciona una carpeta de descarga.",
                    "Ajustes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            if (!Directory.Exists(downloadPath))
            {
                DialogResult createResult =
                    MessageBox.Show(
                        "La carpeta seleccionada no existe.\n\n" +
                        "¿Deseas crearla?",
                        "Carpeta de descarga",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if (createResult !=
                    DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    Directory.CreateDirectory(
                        downloadPath
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No fue posible crear la carpeta.\n\n" +
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }
            }

            if (cmbDefaultType.SelectedItem == null)
            {
                MessageBox.Show(
                    "Selecciona un tipo de descarga predeterminado.",
                    "Ajustes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (cmbDefaultQuality.SelectedItem == null)
            {
                MessageBox.Show(
                    "Selecciona una calidad predeterminada.",
                    "Ajustes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (cmbDefaultFormat.SelectedItem == null)
            {
                MessageBox.Show(
                    "Selecciona un formato predeterminado.",
                    "Ajustes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {

                _settings.DownloadPath =
                    downloadPath;


                _settings.DefaultType =
                    cmbDefaultType.SelectedItem
                        .ToString()
                        ?? "Video";


                _settings.DefaultQuality =
                    cmbDefaultQuality.SelectedItem
                        .ToString()
                        ?? "Mejor calidad";


                _settings.DefaultFormat =
                    cmbDefaultFormat.SelectedItem
                        .ToString()
                        ?? "MP4";

                NormalizeDefaultFormatForType();

                _settings.SaveHistory =
                    chkSaveHistory.Checked;


                _settings.ConfirmCancel =
                    chkConfirmCancel.Checked;


                _settings.ShowNotifications =
                    chkShowNotifications.Checked;

                await _settingsService
                    .SaveSettingsAsync(
                        _settings
                    );

                MessageBox.Show(
                    "La configuración se guardó correctamente.",
                    "Ajustes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible guardar la configuración.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void NormalizeDefaultFormatForType()
        {
            string type =
                _settings.DefaultType.Trim();

            bool audio =
                type.Equals(
                    "Audio",
                    StringComparison.OrdinalIgnoreCase
                );

            bool valid = audio
                ? _settings.DefaultFormat.Equals("MP3", StringComparison.OrdinalIgnoreCase) ||
                  _settings.DefaultFormat.Equals("M4A", StringComparison.OrdinalIgnoreCase) ||
                  _settings.DefaultFormat.Equals("WAV", StringComparison.OrdinalIgnoreCase)
                : _settings.DefaultFormat.Equals("MP4", StringComparison.OrdinalIgnoreCase) ||
                  _settings.DefaultFormat.Equals("MKV", StringComparison.OrdinalIgnoreCase) ||
                  _settings.DefaultFormat.Equals("WEBM", StringComparison.OrdinalIgnoreCase);

            if (!valid)
            {
                _settings.DefaultFormat =
                    audio ? "MP3" : "MP4";

                int index =
                    cmbDefaultFormat.Items.IndexOf(
                        _settings.DefaultFormat
                    );

                if (index >= 0)
                {
                    cmbDefaultFormat.SelectedIndex = index;
                }
            }
        }

        private async void btnReset_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "¿Deseas restaurar todos los ajustes a sus valores predeterminados?",
                    "Restaurar ajustes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _settings =
                    await _settingsService
                        .ResetSettingsAsync();


                txtDownloadPath.Text =
                    _settings.DownloadPath;


                int typeIndex =
                    cmbDefaultType.Items.IndexOf(
                        _settings.DefaultType
                    );

                cmbDefaultType.SelectedIndex =
                    typeIndex >= 0
                        ? typeIndex
                        : 0;


                int qualityIndex =
                    cmbDefaultQuality.Items.IndexOf(
                        _settings.DefaultQuality
                    );

                cmbDefaultQuality.SelectedIndex =
                    qualityIndex >= 0
                        ? qualityIndex
                        : 0;


                int formatIndex =
                    cmbDefaultFormat.Items.IndexOf(
                        _settings.DefaultFormat
                    );

                cmbDefaultFormat.SelectedIndex =
                    formatIndex >= 0
                        ? formatIndex
                        : 0;


                chkSaveHistory.Checked =
                    _settings.SaveHistory;


                chkConfirmCancel.Checked =
                    _settings.ConfirmCancel;


                chkShowNotifications.Checked =
                    _settings.ShowNotifications;

                MessageBox.Show(
                    "Los ajustes fueron restaurados correctamente.",
                    "Ajustes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible restaurar los ajustes.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
