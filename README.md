# 🎬 MediaDownloader

**MediaDownloader** es una aplicación de escritorio para Windows desarrollada en **C# y .NET 10** que permite analizar y descargar contenido multimedia a partir de una URL.

La aplicación utiliza **yt-dlp** como motor de descarga y **FFmpeg** para el procesamiento y conversión de archivos multimedia.

Cuenta con una interfaz gráfica sencilla y moderna que permite seleccionar el tipo de descarga, calidad, formato y carpeta de destino.

---

## ✨ Características

* 🔗 Analizar contenido mediante una URL.
* 🖼️ Visualizar la miniatura del contenido.
* 🎬 Descargar video.
* 🎵 Descargar únicamente audio.
* 🎧 Descargar video + audio.
* 📺 Seleccionar calidad de video.
* 📦 Seleccionar formato de salida.
* 📁 Seleccionar carpeta de destino.
* 📊 Mostrar progreso de descarga.
* ⛔ Cancelar una descarga en progreso.
* 📜 Mantener un historial de descargas.
* ⚙️ Configurar preferencias de la aplicación.
* 🔔 Mostrar mensajes y notificaciones.
* 💾 Guardar configuración localmente.
* 🛡️ Manejo de errores durante las operaciones.

---

## 🖥️ Interfaz

La aplicación cuenta con diferentes ventanas para organizar sus funcionalidades:

### MainForm

Ventana principal desde donde se puede:

* Introducir una URL.
* Analizar el contenido.
* Visualizar información del video.
* Seleccionar tipo de descarga.
* Seleccionar calidad.
* Seleccionar formato.
* Elegir carpeta de destino.
* Iniciar una descarga.
* Cancelar una descarga.

### DownloadsForm

Permite visualizar y administrar las descargas realizadas o en proceso.

### HistoryForm

Permite consultar el historial de descargas.

### SettingsForm

Permite configurar las preferencias de la aplicación.

---

## 🛠️ Tecnologías utilizadas

| Tecnología        | Uso                       |
| ----------------- | ------------------------- |
| **C#**            | Lenguaje principal        |
| **.NET 10**       | Framework de desarrollo   |
| **Windows Forms** | Interfaz gráfica          |
| **yt-dlp**        | Motor de descarga         |
| **FFmpeg**        | Procesamiento multimedia  |
| **JSON**          | Configuración e historial |
| **Visual Studio** | Entorno de desarrollo     |
| **Git / GitHub**  | Control de versiones      |

---

## 📂 Estructura del proyecto

```text
MediaDownloader/
│
├── Forms/
│   ├── MainForm.cs
│   ├── MainForm.Designer.cs
│   ├── DownloadsForm.cs
│   ├── HistoryForm.cs
│   └── SettingsForm.cs
│
├── Models/
│   ├── AppSettings.cs
│   ├── DownloadHistory.cs
│   ├── DownloadTask.cs
│   ├── VideoFormat.cs
│   └── VideoInfo.cs
│
├── Services/
│   ├── HistoryService.cs
│   ├── ProcessService.cs
│   ├── SettingsService.cs
│   └── VideoService.cs
│
├── Tools/
│   ├── yt-dlp.exe
│   └── ffmpeg.exe
│
├── Program.cs
├── MediaDownloader.csproj
└── MediaDownloader.slnx
```

---

## ⚙️ Requisitos

Para ejecutar MediaDownloader necesitas:

* Windows 10 o superior.
* **.NET 10 SDK**.
* `yt-dlp.exe`.
* `ffmpeg.exe`.

### FFmpeg

El archivo **`ffmpeg.exe` no está incluido en este repositorio de GitHub debido a su tamaño**.

Sin embargo, **FFmpeg es necesario para algunas funciones de MediaDownloader**, principalmente para:

* Combinar video y audio.
* Convertir archivos multimedia.
* Generar determinados formatos de salida.

Para utilizar todas las funciones del programa, coloca `ffmpeg.exe` dentro de:

```text
MediaDownloader/Tools/
```

La carpeta debe quedar de la siguiente manera:

```text
Tools/
├── yt-dlp.exe
└── ffmpeg.exe
```

> ⚠️ Si `ffmpeg.exe` no se encuentra en la carpeta `Tools`, algunas funciones de procesamiento y conversión multimedia no estarán disponibles.

---

## 🚀 Instalación

### 1. Clonar el repositorio

```bash
git clone https://github.com/eherca0502/MediaDownloader.git
```

### 2. Entrar a la carpeta

```bash
cd MediaDownloader
```

### 3. Restaurar dependencias

```bash
dotnet restore
```

### 4. Compilar el proyecto

```bash
dotnet build
```

### 5. Ejecutar

```bash
dotnet run
```

También puedes abrir:

```text
MediaDownloader.slnx
```

directamente con Visual Studio.

---

## 📥 Uso

### 1. Introducir una URL

En la ventana principal introduce la URL del contenido que deseas descargar.

### 2. Analizar

Presiona el botón **Analizar**.

La aplicación obtendrá información del contenido, como:

* Título.
* Autor o canal.
* Duración.
* Miniatura.
* Información de los formatos disponibles.

### 3. Seleccionar el tipo de descarga

Puedes elegir entre:

#### 🎬 Video

Descarga el contenido en formato de video.

#### 🎵 Audio

Descarga únicamente el audio.

#### 🎧 Video + Audio

Descarga video y audio y utiliza FFmpeg para combinarlos.

### 4. Seleccionar calidad

Puedes elegir entre diferentes calidades:

```text
Mejor calidad
2160p - 4K
1440p - 2K
1080p - Full HD
720p - HD
480p
360p
```

### 5. Seleccionar formato

Puedes elegir diferentes formatos de salida:

```text
MP4
MKV
WEBM
MP3
M4A
```

### 6. Elegir carpeta de destino

Selecciona la carpeta donde deseas guardar el archivo descargado.

### 7. Descargar

Presiona **Descargar** para iniciar el proceso.

Durante la descarga se mostrará el progreso de la operación.

### 8. Cancelar

Si necesitas detener una descarga, puedes presionar el botón **Cancelar**.

La aplicación utiliza un `CancellationToken` para detener la operación de manera controlada.

---

## 📜 Historial

MediaDownloader cuenta con un sistema de historial que permite consultar las descargas realizadas.

El historial puede almacenar información como:

* Título.
* URL.
* Tipo de descarga.
* Calidad.
* Formato.
* Ruta del archivo.
* Fecha de descarga.
* Estado de la descarga.

La información se almacena localmente en formato JSON.

---

## ⚙️ Configuración

Desde la sección **Ajustes** puedes configurar diferentes preferencias de la aplicación.

Entre ellas:

* 📁 Carpeta de descarga.
* 🎬 Tipo de descarga predeterminado.
* 📺 Calidad predeterminada.
* 📦 Formato predeterminado.
* 📜 Historial.
* 🔔 Notificaciones.
* ⛔ Opciones relacionadas con la cancelación.

---

## 🧩 Servicios principales

El proyecto separa la lógica de la aplicación mediante diferentes servicios.

### VideoService

Se encarga principalmente de:

* Analizar URLs.
* Obtener información del contenido.
* Obtener miniaturas.
* Gestionar las descargas.
* Ejecutar yt-dlp.
* Utilizar FFmpeg cuando es necesario.
* Reportar el progreso.
* Gestionar la cancelación.

### ProcessService

Se encarga de administrar la ejecución de procesos externos utilizados por la aplicación.

Principalmente:

```text
yt-dlp.exe
ffmpeg.exe
```

### HistoryService

Gestiona el historial de descargas y su almacenamiento local.

### SettingsService

Gestiona las preferencias y configuración de MediaDownloader.

---

## 🏗️ Arquitectura

La aplicación mantiene separadas las responsabilidades principales:

```text
┌─────────────────────────────┐
│            Forms            │
│                             │
│ MainForm                    │
│ DownloadsForm               │
│ HistoryForm                 │
│ SettingsForm                │
└──────────────┬──────────────┘
               │
               ▼
┌─────────────────────────────┐
│          Services           │
│                             │
│ VideoService                │
│ ProcessService              │
│ HistoryService              │
│ SettingsService             │
└──────────────┬──────────────┘
               │
               ▼
┌─────────────────────────────┐
│           Models            │
│                             │
│ VideoInfo                   │
│ VideoFormat                 │
│ DownloadTask                │
│ DownloadHistory             │
│ AppSettings                 │
└─────────────────────────────┘
```

Esta organización permite mantener el código más limpio y facilita futuras mejoras.

---

## 🔧 Herramientas externas

MediaDownloader utiliza:

### yt-dlp

Se utiliza como motor principal para obtener información y descargar contenido multimedia.

### FFmpeg

Se utiliza para el procesamiento multimedia, combinación de audio y video y conversión de formatos.

**Nota:** `ffmpeg.exe` no se incluye directamente en este repositorio debido a su tamaño, pero debe estar disponible en la carpeta `Tools` para utilizar las funciones que lo requieren.

---

## 🔐 Privacidad

MediaDownloader no requiere crear una cuenta dentro de la aplicación.

La configuración y el historial se almacenan localmente.

La aplicación procesa las URLs proporcionadas por el usuario y utiliza las herramientas externas necesarias para realizar las operaciones de descarga y procesamiento.

---

## ⚠️ Uso responsable

Utiliza MediaDownloader únicamente con contenido que tengas permiso para descargar y de acuerdo con las leyes aplicables y los términos de servicio de las plataformas correspondientes.


---

## 📌 Estado del proyecto

**Versión:** 1.0

**Estado:** 🟢 Funcional

Actualmente MediaDownloader cuenta con las principales funciones de:

* Análisis de contenido.
* Descarga de video.
* Descarga de audio.
* Descarga de video + audio.
* Selección de calidad.
* Selección de formato.
* Progreso de descarga.
* Cancelación.
* Historial.
* Configuración.

---

## 🔮 Próximas mejoras

Algunas mejoras que podrían incorporarse en futuras versiones:

* ⏬ Cola de múltiples descargas.
* 📊 Mostrar velocidad de descarga.
* ⏱️ Mostrar tiempo restante.
* 📋 Soporte para múltiples URLs.
* 🌙 Tema claro y oscuro.
* 🔄 Actualización automática de yt-dlp.
* 📈 Estadísticas de descargas.
* 🔔 Notificaciones de Windows.
* 📦 Crear instalador para Windows.
* 🖥️ Mejoras adicionales en la interfaz.


## ⭐ Contribuciones

Las contribuciones y sugerencias son bienvenidas.

Si encuentras un problema o tienes alguna idea para mejorar MediaDownloader, puedes abrir un **Issue** o realizar un **Pull Request**.

---



⭐ **Si MediaDownloader te resulta útil, considera darle una estrella al repositorio.**
