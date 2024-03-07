using System.IO.Compression;
using System.Text.Json;

namespace Maintenance.Console.Domain
{
    internal class PackDomain
    {
        public static void Generate(MaintenanceMeta meta, string dir, string zipPath, params string[] excepts)
        {
            if (File.Exists(zipPath))
                File.Delete(zipPath);

            var tempMetaFile = Path.GetTempFileName();
            var tempListFile = Path.GetTempFileName();

            File.WriteAllLines(tempListFile, ListReader.GenerateListContent(dir));
            File.WriteAllText(tempMetaFile, JsonSerializer.Serialize(meta, MaintenanceMetaContext.Default.MaintenanceMeta));

            var allFiles = Directory.EnumerateFiles(dir, "*", SearchOption.AllDirectories).ToList();
            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(tempListFile, Constants.List);
                archive.CreateEntryFromFile(tempMetaFile, Constants.MetaFileName);

                foreach (string filePath in allFiles)
                {
                    if (!excepts.Contains(filePath))
                    {
                        var path = Path.GetRelativePath(dir, filePath);
                        Message.ShowMessageWithColor(ConsoleColor.Blue, $"正在打包 {path}");
                        archive.CreateEntryFromFile(filePath, Path.Combine(Constants.ResourceDir, path));
                    }
                }
            }

            File.Delete(tempMetaFile);
            File.Delete(tempListFile);
        }

        public static MaintenanceMeta ReadPackageMeta(string metaFile)
        {
            if (!File.Exists(metaFile))
                return MaintenanceMeta.Default();

            var content = File.ReadAllText(metaFile);
            if (string.IsNullOrWhiteSpace(content))
                return MaintenanceMeta.Default();

            try
            {
                var model = JsonSerializer.Deserialize<MaintenanceMeta>(content, MaintenanceMetaContext.Default.MaintenanceMeta);
                if (model == null)
                    return MaintenanceMeta.Default();
                return model;
            }
            catch (Exception ex)
            {
                Message.ShowMessageWithColor(ConsoleColor.Yellow, "配置文件格式不正确，读取失败:" + ex.Message);
                return MaintenanceMeta.Default();
            }
        }
    }

}
