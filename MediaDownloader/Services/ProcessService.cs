using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MediaDownloader.Services
{
    public class ProcessService
    {
        public async Task<ProcessResult> ExecuteAsync(
            string fileName,
            string arguments,
            CancellationToken cancellationToken = default)
        {
            using Process process = new Process();

            process.StartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            process.Start();

            try
            {
                Task<string> outputTask =
                    process.StandardOutput.ReadToEndAsync(
                        cancellationToken);

                Task<string> errorTask =
                    process.StandardError.ReadToEndAsync(
                        cancellationToken);

                await process.WaitForExitAsync(
                    cancellationToken);

                string output =
                    await outputTask;

                string error =
                    await errorTask;

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
            string arguments,
            Action<string>? outputReceived = null,
            CancellationToken cancellationToken = default)
        {
            using Process process = new Process();

            process.StartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.Data))
                {
                    outputReceived?.Invoke(e.Data);
                }
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.Data))
                {
                    outputReceived?.Invoke(e.Data);
                }
            };

            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            try
            {
                await process.WaitForExitAsync(
                    cancellationToken);

                return new ProcessResult
                {
                    ExitCode = process.ExitCode,
                    Output = string.Empty,
                    Error = string.Empty
                };
            }
            catch (OperationCanceledException)
            {
                TryKillProcess(process);

                throw;
            }
        }

        private static void TryKillProcess(
            Process process)
        {
            try
            {
                if (!process.HasExited)
                {
                    process.Kill(
                        entireProcessTree: true
                    );
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

        public string Output { get; set; } =
            string.Empty;

        public string Error { get; set; } =
            string.Empty;

        public bool Success =>
            ExitCode == 0;
    }
}