# 🎬 MediaDownloader

<p align="center">
  <strong>Aplicación de escritorio para Windows desarrollada en C# y .NET 10 para analizar y descargar contenido multimedia mediante una URL.</strong>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/C%23-.NET%2010-512BD4?style=for-the-badge&logo=.net&logoColor=white" alt="C# .NET 10">
  <img src="https://img.shields.io/badge/Windows%20Forms-WinForms-0078D4?style=for-the-badge&logo=windows&logoColor=white" alt="Windows Forms">
  <img src="https://img.shields.io/badge/Platform-Windows-0078D4?style=for-the-badge&logo=windows&logoColor=white" alt="Windows">
  <img src="https://img.shields.io/badge/Version-1.0.0-2EA44F?style=for-the-badge" alt="Version">
</p>

<p align="center">
  <a href="https://github.com/eherca0502/MediaDownloader/releases">
    📥 Versiones compiladas
  </a>
</p>

---

## 📌 Descripción

**MediaDownloader** es una aplicación de escritorio para Windows desarrollada en **C#**, utilizando **.NET 10** y **Windows Forms**.

El proyecto permite analizar contenido multimedia a partir de una URL y realizar diferentes tipos de descarga, dependiendo de los formatos y calidades disponibles.

Para las operaciones multimedia, la aplicación utiliza:

- **yt-dlp** como motor principal para analizar contenido y realizar descargas.
- **FFmpeg** para procesamiento, combinación y conversión de archivos multimedia.

El proyecto fue desarrollado con una arquitectura basada en **Forms, Services y Models**, buscando mantener una separación clara entre la interfaz de usuario, la lógica de negocio y los modelos de datos.

---

# ✨ Características

Actualmente MediaDownloader incluye:

- 🔗 Análisis de contenido mediante URL.
- 🖼️ Visualización de miniaturas.
- 🎬 Descarga de video.
- 🎵 Descarga únicamente de audio.
- 🎧 Descarga de video + audio.
- 📺 Selección de calidad de video.
- 📦 Selección de formato de salida.
- 📁 Selección de carpeta de destino.
- 📊 Visualización del progreso de descarga.
- ⛔ Cancelación de descargas.
- 📜 Historial de descargas.
- ⚙️ Configuración de preferencias.
- 🔔 Mensajes y notificaciones.
- 💾 Almacenamiento local de configuración.
- 🛡️ Manejo de errores.
- 🔧 Integración con yt-dlp.
- 🎞️ Integración con FFmpeg.

---

# 🏗️ Arquitectura

El proyecto utiliza una separación de responsabilidades basada principalmente en tres componentes:

```text
┌─────────────────────────────────────┐
│                Forms                │
│                                     │
│  MainForm                           │
│  DownloadsForm                      │
│  HistoryForm                        │
│  SettingsForm                       │
└────────────────┬────────────────────┘
                 │
                 ▼
┌─────────────────────────────────────┐
│              Services               │
│                                     │
│  VideoService                       │
│  ProcessService                     │
│  HistoryService                     │
│  SettingsService                    │
└────────────────┬────────────────────┘
                 │
                 ▼
┌─────────────────────────────────────┐
│               Models               │
│                                     │
│  VideoInfo                          │
│  VideoFormat                        │
│  DownloadTask                       │
│  DownloadHistory                    │
│  AppSettings                        │
└─────────────────────────────────────┘
