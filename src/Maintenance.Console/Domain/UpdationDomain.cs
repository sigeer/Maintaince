using System.IO.Compression;

namespace Maintenance.Console.Domain
{
    internal class UpdationDomain
    {
        public static void CoverDir(string patcher, string targetDir)
        {
            if (!File.Exists(patcher))
            {
                Message.ShowMessageWithColor(ConsoleColor.Red, "补丁文件不存在");
                return;
            }

            var fileName = Path.GetFileNameWithoutExtension(patcher);
            var rootTempDir = Path.Combine(Path.GetTempPath(), fileName);
            if (!Directory.Exists(rootTempDir))
                Directory.CreateDirectory(rootTempDir);

            using (ZipArchive archive = ZipFile.OpenRead(patcher))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    Message.ShowMessageWithColor(ConsoleColor.Blue, $"正在提取 {entry.FullName}");
                    string filePath = Path.Combine(rootTempDir, entry.FullName);
                    var fileDir = Path.GetDirectoryName(filePath);
                    if (fileDir != null && !Directory.Exists(fileDir))
                        Directory.CreateDirectory(fileDir);

                    entry.ExtractToFile(filePath, true);
                }
            }
            Message.ShowMessageWithColor(ConsoleColor.Blue, $"提取完成");

            // 这里备份
            var refFile = Path.Combine(rootTempDir, Constants.List);
            if (File.Exists(refFile))
            {
                var listContent = File.ReadAllLines(refFile);
                var allFiles = listContent.Select(x => x.Split(" ")[1]).ToList();
                var bkDir = Path.Combine(rootTempDir, Constants.BackupDir);
                if (!Directory.Exists(bkDir))
                    Directory.CreateDirectory(bkDir);
                CopyFileList(allFiles, targetDir, bkDir);
            }
            // //还原
            // CopyFileList(allFiles, bkDir, targetDir);

            Message.ShowMessageWithColor(ConsoleColor.Blue, $"正在更新文件...");
            CopyDirectory(Path.Combine(rootTempDir, Constants.ResourceDir), targetDir);
            Message.ShowMessageWithColor(ConsoleColor.Blue, $"更新完成");

            Message.ShowMessageWithColor(ConsoleColor.Blue, $"正在清理临时文件...");
            Directory.Delete(rootTempDir, true);
            Message.ShowMessageWithColor(ConsoleColor.Blue, $"清理完成");
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
                File.Copy(fullFromPath, fullToPath);
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

        public static async Task<string> DownloadPatcherAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var res = await httpClient.GetAsync(url);
                var fileBytes = await res.Content.ReadAsByteArrayAsync();
                var filePath = Path.GetTempFileName();
                File.WriteAllBytes(filePath, fileBytes);
                return filePath;
            }
        }
    }
}
