using System.IO.Compression;
using System.Text.Json;

namespace Maintenance.Console.Domain
{
    internal class PackDomain
    {
        public static void Generate(PackOptions o, params string[] excepts)
        {
            if (string.IsNullOrWhiteSpace(o.Dir))
                o.Dir = Environment.CurrentDirectory;

            if (string.IsNullOrWhiteSpace(o.PackageConfig))
                o.PackageConfig = Path.Combine(o.Dir, Constants.MetaFileName);

            var meta = ReadPackageMeta(o.PackageConfig);

            if (string.IsNullOrEmpty(o.OutPut))
                o.OutPut = $"{Path.GetFileNameWithoutExtension(o.Dir)}_{meta.Version}.smm";

            if (!Path.IsPathRooted(o.OutPut))
                o.OutPut = Path.Combine(o.Dir, o.OutPut);

            if (File.Exists(o.OutPut))
                File.Delete(o.OutPut);

            var tempMetaFile = Path.GetTempFileName();
            var tempListFile = Path.GetTempFileName();

            File.WriteAllLines(tempListFile, ListReader.GenerateListContent(o.Dir));
            File.WriteAllText(tempMetaFile, JsonSerializer.Serialize(meta, MaintenanceMetaContext.Default.MaintenanceMeta));

            var allFiles = Directory.EnumerateFiles(o.Dir, "*", SearchOption.AllDirectories).ToList();
            using (ZipArchive archive = ZipFile.Open(o.OutPut, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(tempListFile, Constants.List);
                archive.CreateEntryFromFile(tempMetaFile, Constants.MetaFileName);
                if (!string.IsNullOrWhiteSpace(o.S0Script) && File.Exists(o.S0Script))
                    archive.CreateEntryFromFile(Path.GetFullPath(o.S0Script), Constants.ScriptsFinally);
                if (!string.IsNullOrWhiteSpace(o.S1Script) && File.Exists(o.S1Script))
                    archive.CreateEntryFromFile(Path.GetFullPath(o.S1Script), Constants.ScriptsBeforeReplace);

                foreach (string filePath in allFiles)
                {
                    if (!excepts.Contains(filePath))
                    {
                        var path = Path.GetRelativePath(o.Dir, filePath);
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
