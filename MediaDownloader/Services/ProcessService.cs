using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediaDownloader.Services
{
    public class ProcessService
    {
        public async Task<ProcessResult> ExecuteAsync(
            string fileName,
            IReadOnlyList<string> arguments,
            CancellationToken cancellationToken = default)
        {
            using Process process = CreateProcess(fileName, arguments);

            if (!process.Start())
            {
                throw new InvalidOperationException(
                    $"No fue posible iniciar el proceso: {fileName}"
                );
            }

            try
            {
                Task<string> outputTask =
                    process.StandardOutput.ReadToEndAsync(cancellationToken);

                Task<string> errorTask =
                    process.StandardError.ReadToEndAsync(cancellationToken);

                await process.WaitForExitAsync(cancellationToken);

                string output = await outputTask;
                string error = await errorTask;

                return new ProcessResult
                {
                    ExitCode = process.ExitCode,
                    Output = output,
                    Error = error
                };
            }
            catch (OperationCanceledException)
            {
                TryKillProcess(process);
                throw;
            }
        }

        public async Task<ProcessResult> ExecuteWithProgressAsync(
            string fileName,
            IReadOnlyList<string> arguments,
            Action<string>? outputReceived = null,
            CancellationToken cancellationToken = default)
        {
            using Process process = CreateProcess(fileName, arguments);

            StringBuilder outputBuilder = new StringBuilder();
            StringBuilder errorBuilder = new StringBuilder();

            process.OutputDataReceived += (sender, e) =>
            {
                if (e.Data == null)
                {
                    return;
                }

                outputBuilder.AppendLine(e.Data);
                outputReceived?.Invoke(e.Data);
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (e.Data == null)
                {
                    return;
                }

                errorBuilder.AppendLine(e.Data);
            };

            if (!process.Start())
            {
                throw new InvalidOperationException(
                    $"No fue posible iniciar el proceso: {fileName}"
                );
            }

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            try
            {
                await process.WaitForExitAsync(cancellationToken);

                process.WaitForExit();

                return new ProcessResult
                {
                    ExitCode = process.ExitCode,
                    Output = outputBuilder.ToString(),
                    Error = errorBuilder.ToString()
                };
            }
            catch (OperationCanceledException)
            {
                TryKillProcess(process);
                throw;
            }
        }

        private static Process CreateProcess(
            string fileName,
            IReadOnlyList<string> arguments)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException(
                    "El nombre del ejecutable no puede estar vacío.",
                    nameof(fileName)
                );
            }

            if (arguments == null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WorkingDirectory = AppContext.BaseDirectory
            };

            foreach (string argument in arguments)
            {
                startInfo.ArgumentList.Add(argument);
            }

            return new Process
            {
                StartInfo = startInfo
            };
        }

        private static void TryKillProcess(Process process)
        {
            try
            {
                if (!process.HasExited)
                {
                    process.Kill(entireProcessTree: true);
                }
            }
            catch
            {
            }
        }
    }

    public class ProcessResult
    {
        public int ExitCode { get; set; }

        public string Output { get; set; } = string.Empty;

        public string Error { get; set; } = string.Empty;

        public bool Success => ExitCode == 0;
    }
}
