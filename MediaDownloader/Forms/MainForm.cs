
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaDownloader.Models;
using MediaDownloader.Services;

namespace MediaDownloader.Forms
{
    public partial class MainForm : Form
    {
        private readonly VideoService _videoService;
        private readonly HistoryService _historyService;
        private readonly SettingsService _settingsService;

        private AppSettings _settings =
            new AppSettings();

        private CancellationTokenSource? _downloadCancellationTokenSource;
        private VideoInfo? _currentVideo;

        private string _downloadType = "video";

        public MainForm()
        {
            InitializeComponent();

            ProcessService processService = new ProcessService();

            _videoService = new VideoService(processService);
            _historyService = new HistoryService();
            _settingsService = new SettingsService();

            InitializeForm();
            ConfigureEvents();

            Load += MainForm_Load;
        }

        private void InitializeForm()
        {
            cmbQuality.SelectedIndex = 0;

            txtSavePath.Text =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyVideos
                );

            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            lblProgress.Text = "0%";
            lblStatus.Text = "Listo para descargar";

            btnCancel.Enabled = false;
            btnDownload.Enabled = false;

            SelectDownloadType("video");
        }

        private async void MainForm_Load(
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
                    await _settingsService.GetSettingsAsync();

                txtSavePath.Text =
                    _settings.DownloadPath;

                string defaultType =
                    _settings.DefaultType.Trim();

                if (defaultType.Equals(
                    "Audio",
                    StringComparison.OrdinalIgnoreCase))
                {
                    SelectDownloadType("audio");
                }
                else if (defaultType.Equals(
                    "Video + Audio",
                    StringComparison.OrdinalIgnoreCase) ||
                    defaultType.Equals(
                    "VideoAudio",
                    StringComparison.OrdinalIgnoreCase))
                {
                    SelectDownloadType("videoaudio");
                }
                else
                {
                    SelectDownloadType("video");
                }

                int qualityIndex =
                    cmbQuality.Items.IndexOf(
                        _settings.DefaultQuality
                    );

                cmbQuality.SelectedIndex =
                    qualityIndex >= 0
                        ? qualityIndex
                        : 0;

                int formatIndex =
                    cmbFormat.Items.IndexOf(
                        _settings.DefaultFormat
                    );

                cmbFormat.SelectedIndex =
                    formatIndex >= 0
                        ? formatIndex
                        : 0;
            }
            catch (Exception ex)
            {
                lblStatus.Text =
                    "No fue posible cargar los ajustes.";

                MessageBox.Show(
                    "No fue posible cargar la configuración." + "\n\n" +
                    ex.Message,
                    "Ajustes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void ConfigureEvents()
        {
            btnAnalyze.Click += btnAnalyze_Click;
            btnDownload.Click += btnDownload_Click;
            btnCancel.Click += btnCancel_Click;
            btnBrowse.Click += btnBrowse_Click;

            btnVideo.Click += btnVideo_Click;
            btnAudio.Click += btnAudio_Click;
            btnVideoAudio.Click += btnVideoAudio_Click;

            FormClosing += MainForm_FormClosing;
        }


        private async void btnAnalyze_Click(
            object? sender,
            EventArgs e)
        {
            string url = txtUrl.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show(
                    "Ingresa la URL del video.",
                    "URL requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtUrl.Focus();
                return;
            }

            try
            {
                SetAnalyzingState(true);

                lblStatus.Text = "Analizando video...";
                lblProgress.Text = "0%";
                progressBar.Value = 0;

                ClearVideoInfo();

                _currentVideo =
                    await _videoService.GetVideoInfoAsync(url);

                if (_currentVideo == null)
                {
                    throw new Exception(
                        "No se pudo obtener información del video."
                    );
                }

                lblVideoTitle.Text =
                    string.IsNullOrWhiteSpace(_currentVideo.Title)
                        ? "Sin título"
                        : _currentVideo.Title;

                lblChannel.Text =
                    "Canal: " +
                    (
                        string.IsNullOrWhiteSpace(
                            _currentVideo.Channel
                        )
                            ? "--"
                            : _currentVideo.Channel
                    );

                lblDuration.Text =
                    "Duración: " +
                    FormatDuration(
                        _currentVideo.Duration
                    );

                await LoadThumbnailAsync(url);

                lblStatus.Text =
                    "Video analizado correctamente.";

                btnDownload.Enabled = true;
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text =
                    "Análisis cancelado.";
            }
            catch (Exception ex)
            {
                _currentVideo = null;
                btnDownload.Enabled = false;

                lblStatus.Text =
                    "Error al analizar.";

                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                SetAnalyzingState(false);
            }
        }

        private async Task LoadThumbnailAsync(
            string url)
        {
            string? thumbnailPath = null;

            try
            {
                thumbnailPath =
                    await _videoService.DownloadThumbnailAsync(url);

                if (string.IsNullOrWhiteSpace(thumbnailPath) ||
                    !File.Exists(thumbnailPath))
                {
                    return;
                }

                using Image image =
                    Image.FromFile(thumbnailPath);

                Image thumbnail =
                    new Bitmap(image);

                Image? oldImage =
                    picThumbnail.Image;

                picThumbnail.Image =
                    thumbnail;

                picThumbnail.Visible =
                    true;

                lblThumbnail.Visible =
                    false;

                oldImage?.Dispose();
            }
            catch
            {
                picThumbnail.Visible = false;
                lblThumbnail.Visible = true;
            }
            finally
            {
                if (!string.IsNullOrWhiteSpace(thumbnailPath))
                {
                    try
                    {
                        string? directory =
                            Path.GetDirectoryName(thumbnailPath);

                        if (File.Exists(thumbnailPath))
                        {
                            File.Delete(thumbnailPath);
                        }

                        if (!string.IsNullOrWhiteSpace(directory) &&
                            Directory.Exists(directory))
                        {
                            Directory.Delete(directory, recursive: true);
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }


        private async void btnDownload_Click(
            object? sender,
            EventArgs e)
        {
            if (_currentVideo == null)
            {
                MessageBox.Show(
                    "Primero analiza un video.",
                    "Descarga",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            string url =
                txtUrl.Text.Trim();

            string savePath =
                txtSavePath.Text.Trim();

            string downloadType;

            if (_downloadType == "audio")
            {
                downloadType = "Audio";
            }
            else if (_downloadType == "videoaudio")
            {
                downloadType = "Video + Audio";
            }
            else
            {
                downloadType = "Video";
            }

            string quality =
                cmbQuality.SelectedItem?.ToString()
                ?? "Mejor calidad";

            string format =
                cmbFormat.SelectedItem?.ToString()
                ?? "MP4";

            if (string.IsNullOrWhiteSpace(savePath))
            {
                MessageBox.Show(
                    "Selecciona una carpeta de destino.",
                    "Descarga",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                SetDownloadingState(true);

                progressBar.Value = 0;
                lblProgress.Text = "0%";
                lblStatus.Text =
                    "Iniciando descarga...";

                _downloadCancellationTokenSource?.Dispose();

                _downloadCancellationTokenSource =
                    new CancellationTokenSource();

                string downloadedFile =
                    await _videoService.DownloadAsync(
                        url,
                        savePath,
                        downloadType,
                        quality,
                        format,


                    progress =>
                    {
                        if (IsDisposed)
                        {
                            return;
                        }

                        if (InvokeRequired)
                        {
                            try
                            {
                                Invoke(
                                    new Action<double>(
                                        UpdateProgress
                                    ),
                                    progress
                                );
                            }
                            catch
                            {
                            }

                            return;
                        }

                        UpdateProgress(progress);
                    },

                    status =>
                    {
                        if (IsDisposed)
                        {
                            return;
                        }

                        if (InvokeRequired)
                        {
                            try
                            {
                                Invoke(
                                    new Action<string>(
                                        UpdateStatus
                                    ),
                                    status
                                );
                            }
                            catch
                            {
                            }

                            return;
                        }

                        UpdateStatus(status);
                    },

                    _downloadCancellationTokenSource.Token
                );


                DownloadHistory history =
                    new DownloadHistory
                    {
                        Title =
                            string.IsNullOrWhiteSpace(
                                _currentVideo.Title
                            )
                                ? "Sin título"
                                : _currentVideo.Title,

                        Url =
                            url,

                        Type =
                            downloadType,

                        Quality =
                            quality,

                        Format =
                            format,

                        FilePath =
                            downloadedFile,

                        Date =
                            DateTime.Now,

                        Status =
                            "Completada"
                    };

                if (_settings.SaveHistory)
                {
                    await _historyService.AddAsync(history);
                }

                progressBar.Value = 100;
                lblProgress.Text = "100%";

                lblStatus.Text =
                    _settings.SaveHistory
                        ? "Descarga completada y guardada en historial."
                        : "Descarga completada.";

                if (_settings.ShowNotifications)
                {
                    string historyMessage =
                        _settings.SaveHistory
                            ? "\n\nTambién fue agregada al historial."
                            : string.Empty;

                    MessageBox.Show(
                        "La descarga se completó correctamente." +
                        historyMessage,
                        "MediaDownloader",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (OperationCanceledException)
            {
                progressBar.Value = 0;
                lblProgress.Text = "0%";

                lblStatus.Text =
                    "Descarga cancelada.";
            }
            catch (Exception ex)
            {
                lblStatus.Text =
                    "Error en la descarga.";

                MessageBox.Show(
                    "No fue posible completar la descarga.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                _downloadCancellationTokenSource?.Dispose();
                _downloadCancellationTokenSource = null;

                SetDownloadingState(false);
            }
        }


        private void btnCancel_Click(
            object? sender,
            EventArgs e)
        {
            if (_downloadCancellationTokenSource == null)
            {
                return;
            }

            if (_downloadCancellationTokenSource.IsCancellationRequested)
            {
                return;
            }

            if (_settings.ConfirmCancel)
            {
                DialogResult result =
                    MessageBox.Show(
                        "¿Seguro que deseas cancelar la descarga?",
                        "Cancelar descarga",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            lblStatus.Text =
                "Cancelando descarga...";

            btnCancel.Enabled = false;

            try
            {
                _downloadCancellationTokenSource.Cancel();
            }
            catch (ObjectDisposedException)
            {
            }
        }


        private void btnVideo_Click(
            object? sender,
            EventArgs e)
        {
            SelectDownloadType("video");
        }

        private void btnAudio_Click(
            object? sender,
            EventArgs e)
        {
            SelectDownloadType("audio");
        }

        private void btnVideoAudio_Click(
            object? sender,
            EventArgs e)
        {
            SelectDownloadType("videoaudio");
        }

        private void SelectDownloadType(
            string type)
        {
            _downloadType =
                type;

            Color activeColor =
                Color.FromArgb(
                    70,
                    110,
                    255
                );

            Color inactiveColor =
                Color.FromArgb(
                    30,
                    30,
                    36
                );

            Color activeText =
                Color.White;

            Color inactiveText =
                Color.FromArgb(
                    210,
                    210,
                    220
                );


            if (type == "video")
            {
                btnVideo.BackColor =
                    activeColor;

                btnVideo.ForeColor =
                    activeText;

                btnAudio.BackColor =
                    inactiveColor;

                btnAudio.ForeColor =
                    inactiveText;

                btnVideoAudio.BackColor =
                    inactiveColor;

                btnVideoAudio.ForeColor =
                    inactiveText;

                cmbFormat.Items.Clear();

                cmbFormat.Items.Add("MP4");
                cmbFormat.Items.Add("MKV");
                cmbFormat.Items.Add("WEBM");

                cmbFormat.SelectedIndex = 0;

                cmbQuality.Enabled =
                    true;
            }


            else if (type == "audio")
            {
                btnAudio.BackColor =
                    activeColor;

                btnAudio.ForeColor =
                    activeText;

                btnVideo.BackColor =
                    inactiveColor;

                btnVideo.ForeColor =
                    inactiveText;

                btnVideoAudio.BackColor =
                    inactiveColor;

                btnVideoAudio.ForeColor =
                    inactiveText;

                cmbFormat.Items.Clear();

                cmbFormat.Items.Add("MP3");
                cmbFormat.Items.Add("M4A");
                cmbFormat.Items.Add("WAV");

                cmbFormat.SelectedIndex = 0;

                cmbQuality.Enabled =
                    false;
            }


            else if (type == "videoaudio")
            {
                btnVideoAudio.BackColor =
                    activeColor;

                btnVideoAudio.ForeColor =
                    activeText;

                btnVideo.BackColor =
                    inactiveColor;

                btnVideo.ForeColor =
                    inactiveText;

                btnAudio.BackColor =
                    inactiveColor;

                btnAudio.ForeColor =
                    inactiveText;

                cmbFormat.Items.Clear();

                cmbFormat.Items.Add("MP4");
                cmbFormat.Items.Add("MKV");
                cmbFormat.Items.Add("WEBM");

                cmbFormat.SelectedIndex = 0;

                cmbQuality.Enabled =
                    true;
            }
        }


        private void btnBrowse_Click(
            object? sender,
            EventArgs e)
        {
            using FolderBrowserDialog dialog =
                new FolderBrowserDialog();

            dialog.Description =
                "Selecciona la carpeta donde guardar el archivo";

            dialog.UseDescriptionForTitle =
                true;

            if (Directory.Exists(
                txtSavePath.Text))
            {
                dialog.SelectedPath =
                    txtSavePath.Text;
            }

            if (dialog.ShowDialog(this) ==
                DialogResult.OK)
            {
                txtSavePath.Text =
                    dialog.SelectedPath;
            }
        }


        private void UpdateProgress(
            double progress)
        {
            if (IsDisposed)
            {
                return;
            }

            if (InvokeRequired)
            {
                try
                {
                    Invoke(
                        new Action<double>(
                            UpdateProgress
                        ),
                        progress
                    );
                }
                catch
                {
                }

                return;
            }

            int value =
                (int)Math.Clamp(
                    progress,
                    0,
                    100
                );

            progressBar.Value =
                value;

            lblProgress.Text =
                $"{value}%";
        }


        private void UpdateStatus(
            string status)
        {
            if (IsDisposed)
            {
                return;
            }

            if (InvokeRequired)
            {
                try
                {
                    Invoke(
                        new Action<string>(
                            UpdateStatus
                        ),
                        status
                    );
                }
                catch
                {
                }

                return;
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                lblStatus.Text =
                    status;
            }
        }


        private void SetAnalyzingState(
            bool analyzing)
        {
            if (InvokeRequired)
            {
                Invoke(
                    new Action<bool>(
                        SetAnalyzingState
                    ),
                    analyzing
                );

                return;
            }

            btnAnalyze.Enabled =
                !analyzing;

            txtUrl.Enabled =
                !analyzing;

            if (analyzing)
            {
                btnDownload.Enabled =
                    false;
            }
            else
            {
                btnDownload.Enabled =
                    _currentVideo != null;
            }
        }


        private void SetDownloadingState(
            bool downloading)
        {
            if (InvokeRequired)
            {
                Invoke(
                    new Action<bool>(
                        SetDownloadingState
                    ),
                    downloading
                );

                return;
            }

            btnDownload.Enabled =
                !downloading &&
                _currentVideo != null;

            btnCancel.Enabled =
                downloading;

            btnAnalyze.Enabled =
                !downloading;

            btnBrowse.Enabled =
                !downloading;

            txtUrl.Enabled =
                !downloading;

            cmbQuality.Enabled =
                !downloading &&
                _downloadType != "audio";

            cmbFormat.Enabled =
                !downloading;

            btnVideo.Enabled =
                !downloading;

            btnAudio.Enabled =
                !downloading;

            btnVideoAudio.Enabled =
                !downloading;
        }


        private void ClearVideoInfo()
        {
            lblVideoTitle.Text =
                "Analizando...";

            lblDuration.Text =
                "Duración: --:--";

            lblChannel.Text =
                "Canal: --";

            lblThumbnail.Visible =
                true;

            picThumbnail.Visible =
                false;

            Image? oldImage =
                picThumbnail.Image;

            picThumbnail.Image =
                null;

            oldImage?.Dispose();

            _currentVideo =
                null;
        }


        private static string FormatDuration(
            TimeSpan duration)
        {
            if (duration.TotalHours >= 1)
            {
                return duration.ToString(
                    @"hh\:mm\:ss"
                );
            }

            return duration.ToString(
                @"mm\:ss"
            );
        }


        private void MainForm_FormClosing(
            object? sender,
            FormClosingEventArgs e)
        {
            try
            {
                if (_downloadCancellationTokenSource != null &&
                    !_downloadCancellationTokenSource.IsCancellationRequested)
                {
                    _downloadCancellationTokenSource.Cancel();
                }
            }
            catch
            {
            }
        }


        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            try
            {
                picThumbnail.Image?.Dispose();
                picThumbnail.Image = null;

                _downloadCancellationTokenSource?.Dispose();
                _downloadCancellationTokenSource = null;
            }
            catch
            {
            }

            base.OnFormClosed(e);
        }


        private void btnHistory_Click(
            object? sender,
            EventArgs e)
        {
            using HistoryForm historyForm =
                new HistoryForm();

            historyForm.ShowDialog(this);
        }

        private void btnDownloads_Click(object sender, EventArgs e)
        {
            using DownloadsForm downloadsForm = new DownloadsForm();
            downloadsForm.ShowDialog(this);
        }

        private async void btnSettings_Click(object sender, EventArgs e)
        {
            using SettingsForm settingsForm = new SettingsForm();

            if (settingsForm.ShowDialog(this) == DialogResult.OK)
            {
                await LoadSettingsAsync();
            }
        }
    }
}
