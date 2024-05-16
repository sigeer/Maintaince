using Maintenance.Lib.Domain.ScriptExecutor;
using Serilog;
using System.IO.Compression;

namespace Maintenance.Lib.Domain
{
    public class UpdationDomain
    {
        public async static Task<bool> Core(IUpdationOptions o, Action<long, long>? downloadCallback = null)
        {
            string? patchFile = o.Path;
            bool shoudDeleteTempFile = false;
            if (o.Path.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                shoudDeleteTempFile = true;
                Log.Logger.Information($"正在从 {o.Path} 下载更新包");
                patchFile = await DownloadAsync(o.Path, downloadCallback);
                if (patchFile == null)
                    return false;

                Log.Logger.Information($"下载完成");
            }

            if (!File.Exists(patchFile))
            {
                Log.Logger.Error($"更新包不存在");
                return false;
            }

            var randomFolderName = Guid.NewGuid().ToString();
            var rootTempDir = Path.Combine(Path.GetTempPath(), randomFolderName);
            if (!Directory.Exists(rootTempDir))
                Directory.CreateDirectory(rootTempDir);
            Log.Logger.Debug($"临时目录：{rootTempDir}");

            var updateDir = string.IsNullOrWhiteSpace(o.Dir) ? Environment.CurrentDirectory : o.Dir;
            if (!Directory.Exists(updateDir))
            {
                Log.Logger.Error( $"更新目录不存在");
                return false;
            }

            try
            {
                using (ZipArchive archive = ZipFile.OpenRead(patchFile))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        Log.Logger.Information($"正在提取 {entry.FullName}");
                        string filePath = Path.Combine(rootTempDir, entry.FullName);
                        var fileDir = Path.GetDirectoryName(filePath);
                        if (fileDir != null && !Directory.Exists(fileDir))
                            Directory.CreateDirectory(fileDir);

                        entry.ExtractToFile(filePath, true);
                    }
                }
                Log.Logger.Information($"提取完成");
            }
            catch (Exception ex)
            {
                Log.Logger.Error( $"提取失败：{ex.Message}");
                Log.Logger.Information($"正在清理临时文件...");
                Directory.Delete(rootTempDir, true);
                if (shoudDeleteTempFile)
                    File.Delete(patchFile);
                Log.Logger.Information($"清理完成");
            }


            // 这里备份
            var refFile = Path.Combine(rootTempDir, Constants.List);
            List<string> allFiles = new List<string>();
            if (!File.Exists(refFile))
            {
                Log.Logger.Warning($"补丁包文件缺失--{Constants.List}");
                allFiles = ListReader.GenerateFileList(Path.Combine(rootTempDir, Constants.ResourceDir));
            }
            else
            {
                var listContent = File.ReadAllLines(refFile);
                allFiles = File.ReadAllLines(refFile).Select(x => x.Split(" ")[1]).ToList();
            }
            var bkDir = Path.Combine(rootTempDir, Constants.BackupDir);
            if (!Directory.Exists(bkDir))
                Directory.CreateDirectory(bkDir);
            CopyFileList(allFiles, updateDir, bkDir);

            try
            {
                var script1 = Path.Combine(rootTempDir, Constants.ScriptsBeforeReplace);
                if (File.Exists(script1))
                    Log.Logger.Information(Executor.Run(script1));

                Log.Logger.Information($"正在更新文件...");
                CopyDirectory(Path.Combine(rootTempDir, Constants.ResourceDir), updateDir);
                Log.Logger.Information($"更新完成");

                var script0 = Path.Combine(rootTempDir, Constants.ScriptsFinally);
                if (File.Exists(script0))
                    Log.Logger.Information(Executor.Run(script0));

                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Error( $"更新失败，即将回滚。失败原因：{ex.Message}");
                CopyFileList(allFiles, bkDir, updateDir);
                return false;
            }
            finally
            {
                Log.Logger.Information($"正在清理临时文件...");
                if (Directory.Exists(rootTempDir))
                    Directory.Delete(rootTempDir, true);

                if (shoudDeleteTempFile)
                    File.Delete(patchFile);
                Log.Logger.Information($"清理完成");
            }
        }

        static void CopyFileList(List<string> fileList, string from, string to)
        {
            foreach (var file in fileList)
            {
                var fullToPath = Path.Combine(to, file);

                var fullFromPath = Path.Combine(from, file);
                var fullFromDir = Path.GetDirectoryName(fullFromPath);
                if (!string.IsNullOrEmpty(fullFromDir) && !Directory.Exists(fullFromDir))
                    Directory.CreateDirectory(fullFromDir);

                if (File.Exists(fullFromPath))
                    File.Copy(fullFromPath, fullToPath, true);
            }
        }

        static void CopyDirectory(string sourceDir, string targetDir)
        {
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string targetFile = Path.Combine(targetDir, Path.GetFileName(file));
                File.Copy(file, targetFile, true);
            }

            foreach (var subDir in Directory.GetDirectories(sourceDir))
            {
                string newTargetDir = Path.Combine(targetDir, Path.GetFileName(subDir));
                CopyDirectory(subDir, newTargetDir);
            }
        }

        public static async Task<string?> DownloadAsync(string url, Action<long, long>? downloadCallback = null)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();

                        long totalBytes = response.Content.Headers.ContentLength ?? -1;
                        long downloadedBytes = 0;
                        var filePath = Path.GetTempFileName();
                        using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            byte[] buffer = new byte[8192];
                            int bytesRead;
                            while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);

                                downloadedBytes += bytesRead;
                                if (totalBytes != -1)
                                {
                                    downloadCallback?.Invoke(totalBytes, downloadedBytes);
                                }
                            }
                            return filePath;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"下载失败：{ex.Message}");
                return null;
            }
        }
    }
}
