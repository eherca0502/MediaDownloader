<div align="center">

<img src="MediaDownloader/assets/MediaDownloader.png" alt="MediaDownloader" width="180">

# MediaDownloader

### Aplicación de escritorio para Windows desarrollada con C# y .NET 10

Aplicación multimedia para **analizar y descargar contenido mediante una URL**, con soporte para diferentes formatos, calidades y tipos de descarga.

<br>

<img src="https://img.shields.io/badge/C%23-.NET%2010-512BD4?style=for-the-badge&logo=.net&logoColor=white" alt="C# .NET 10">
<img src="https://img.shields.io/badge/Windows%20Forms-WinForms-0078D4?style=for-the-badge&logo=windows&logoColor=white" alt="Windows Forms">
<img src="https://img.shields.io/badge/Platform-Windows-0078D4?style=for-the-badge&logo=windows&logoColor=white" alt="Windows">
<img src="https://img.shields.io/badge/Version-1.0.0-2EA44F?style=for-the-badge" alt="Versión 1.0.0">

</div>

---

## Descripción

**MediaDownloader** es una aplicación de escritorio para Windows desarrollada en **C#**, utilizando **.NET 10** y **Windows Forms**.

La aplicación permite analizar contenido multimedia a partir de una URL y realizar diferentes tipos de descarga de acuerdo con los formatos y calidades disponibles.

El procesamiento multimedia se realiza mediante herramientas especializadas:

* **yt-dlp** para el análisis del contenido y las operaciones de descarga.
* **FFmpeg** para el procesamiento, combinación y conversión de archivos multimedia.

El proyecto utiliza una arquitectura organizada en **Forms, Services y Models**, buscando mantener una separación clara entre la interfaz de usuario, la lógica de aplicación y los modelos de datos.

---

## Características

MediaDownloader incluye las siguientes funciones:

* Análisis de contenido mediante URL.
* Visualización de información y miniaturas.
* Descarga de video.
* Descarga únicamente de audio.
* Descarga de video con audio.
* Selección de calidad de video.
* Selección de formato de salida.
* Selección de carpeta de destino.
* Visualización del progreso de descarga.
* Cancelación de descargas.
* Historial de descargas.
* Configuración de preferencias.
* Notificaciones de estado.
* Mensajes de finalización.
* Almacenamiento local de configuración.
* Manejo de errores.
* Integración con yt-dlp.
* Integración con FFmpeg.

---

## Flujo de funcionamiento

El funcionamiento general de la aplicación se puede resumir de la siguiente manera:

```text
┌──────────────────────────┐
│       URL del contenido  │
└─────────────┬────────────┘
              │
              ▼
┌──────────────────────────┐
│     Análisis con yt-dlp  │
└─────────────┬────────────┘
              │
              ▼
┌──────────────────────────┐
│ Información del contenido│
│ • Título                 │
│ • Miniatura              │
│ • Formatos               │
│ • Calidades              │
└─────────────┬────────────┘
              │
              ▼
┌──────────────────────────┐
│ Selección de descarga    │
│ • Video                  │
│ • Audio                  │
│ • Video + Audio          │
└─────────────┬────────────┘
              │
              ▼
┌──────────────────────────┐
│      yt-dlp + FFmpeg     │
└─────────────┬────────────┘
              │
              ▼
┌──────────────────────────┐
│     Archivo descargado   │
└──────────────────────────┘
```

---

## Arquitectura

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
│               Models                │
│                                     │
│  VideoInfo                          │
│  VideoFormat                        │
│  DownloadTask                        │
│  DownloadHistory                    │
│  AppSettings                        │
└─────────────────────────────────────┘
```

Esta estructura permite mantener separadas las responsabilidades principales de la aplicación y facilita el mantenimiento y evolución del proyecto.

---

## Tecnologías utilizadas

| Tecnología        | Función                        |
| ----------------- | ------------------------------ |
| **C#**            | Lenguaje principal             |
| **.NET 10**       | Plataforma de desarrollo       |
| **Windows Forms** | Interfaz gráfica               |
| **yt-dlp**        | Análisis y descarga multimedia |
| **FFmpeg**        | Procesamiento multimedia       |

---

## Herramientas externas

### yt-dlp

**yt-dlp** es el motor utilizado para analizar las URLs proporcionadas y gestionar las operaciones de descarga.

Se encarga principalmente de:

* Analizar contenido multimedia.
* Obtener información de formatos.
* Identificar calidades disponibles.
* Gestionar descargas.
* Obtener información del contenido.

### FFmpeg

**FFmpeg** se utiliza para las tareas de procesamiento multimedia que requieren combinación, conversión o manipulación de archivos.

Entre sus funciones dentro del proyecto se encuentran:

* Procesamiento de audio y video.
* Combinación de pistas.
* Conversión de formatos.
* Generación del archivo final.

---

## Configuración

MediaDownloader permite almacenar determinadas preferencias de usuario localmente.

Entre las opciones configurables se encuentran:

* Carpeta de descarga.
* Tipo de descarga predeterminado.
* Calidad predeterminada.
* Formato predeterminado.
* Guardado del historial.
* Confirmación antes de cancelar.
* Notificaciones.
* Mensaje de finalización.

La configuración se almacena localmente y puede modificarse desde la sección correspondiente de la aplicación.

---

## Historial de descargas

La aplicación incorpora un sistema de historial para conservar información relacionada con las descargas realizadas.

Esto permite consultar posteriormente información de las operaciones realizadas sin necesidad de volver a analizar el contenido.

---

## Manejo de descargas

Durante una descarga, la aplicación proporciona información sobre el progreso de la operación.

El usuario puede:

* Consultar el progreso.
* Cancelar la operación.
* Recibir información sobre el resultado.
* Consultar posteriormente el historial.

---

## Requisitos

Para ejecutar el proyecto desde el código fuente se recomienda contar con:

* Windows 10 o superior.
* Windows de 64 bits.
* Visual Studio 2022.
* .NET 10 SDK.

Las herramientas externas utilizadas por la aplicación, como **yt-dlp** y **FFmpeg**, forman parte de la distribución correspondiente del proyecto.

---

## Compilación

Clona el repositorio y abre la solución en **Visual Studio 2022**.

También puedes compilar el proyecto desde la terminal:

```powershell
dotnet restore
dotnet build -c Release
```

Para ejecutar la aplicación:

```powershell
dotnet run
```

---

## Publicación

Para generar una versión publicada para Windows x64:

```powershell
dotnet publish -c Release -r win-x64 --self-contained true
```

Los archivos generados pueden utilizarse posteriormente para crear una distribución o instalador de la aplicación.

---

## Seguridad

El proyecto fue revisado durante el proceso de preparación de la versión para identificar patrones comunes relacionados con seguridad, incluyendo:

* Credenciales incrustadas.
* Claves API.
* Tokens.
* Ejecución inesperada de procesos.
* Comunicación de red no relacionada con la funcionalidad principal.
* Acceso al registro de Windows.
* Carga de bibliotecas nativas no justificada.
* Código ofuscado.

Las herramientas externas utilizadas por el proyecto, como **yt-dlp** y **FFmpeg**, deben mantenerse actualizadas de acuerdo con sus respectivas versiones y recomendaciones de seguridad.

---

## Estructura del proyecto

```text
MediaDownloader/
│
├── MediaDownloader/
│   │
│   ├── Assets/
│   │
│   ├── Forms/
│   │   ├── MainForm.cs
│   │   ├── DownloadsForm.cs
│   │   ├── HistoryForm.cs
│   │   └── SettingsForm.cs
│   │
│   ├── Models/
│   │   ├── VideoInfo.cs
│   │   ├── VideoFormat.cs
│   │   ├── DownloadTask.cs
│   │   ├── DownloadHistory.cs
│   │   └── AppSettings.cs
│   │
│   ├── Services/
│   │   ├── VideoService.cs
│   │   ├── ProcessService.cs
│   │   ├── HistoryService.cs
│   │   └── SettingsService.cs
│   │
│   ├── Program.cs
│   └── MediaDownloader.csproj
│
├── MediaDownloader.slnx
└── README.md
```

---

## Versión

### MediaDownloader v1.0.0

Primera versión estable del proyecto.

Esta versión incluye las funciones principales de análisis, selección y descarga de contenido multimedia, además de administración de historial y configuración.

---

## Código fuente

El código fuente completo de **MediaDownloader** se encuentra disponible en este repositorio.

El proyecto está desarrollado con fines de aprendizaje, desarrollo y demostración de aplicaciones de escritorio utilizando **C# y .NET**.

---

## Autor

**Eduardo Hernández**

Desarrollador de software.

---

<div align="center">

**MediaDownloader v1.0.0**

Aplicación multimedia para Windows desarrollada con **C# y .NET 10**

</div>
