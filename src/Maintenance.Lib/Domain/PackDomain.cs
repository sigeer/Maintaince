using System.IO.Compression;
using System.Text.Json;

namespace Maintenance.Lib.Domain
{
    public class PackDomain
    {
        public static event EventHandler<string>? OnLogInfo;
        public static event EventHandler<string>? OnLogError;
        public static event EventHandler<string>? OnLogSuccess;
        public static event EventHandler<string>? OnLogWarn;
        public static bool Generate(IPackOptions o, params string[] excepts)
        {
            if (string.IsNullOrWhiteSpace(o.Dir))
                o.Dir = Environment.CurrentDirectory;

            if (string.IsNullOrWhiteSpace(o.PackageConfig))
                o.PackageConfig = Path.Combine(o.Dir, Constants.MetaFileName);

            var meta = MaintenanceMeta.ReadPackageMeta(o.PackageConfig);
            return Generate(o, meta, excepts);
        }


        public static bool Generate(IPackOptions o, MaintenanceMeta meta, params string[] excepts)
        {
            if (string.IsNullOrWhiteSpace(o.Dir))
                o.Dir = Environment.CurrentDirectory;

            if (string.IsNullOrEmpty(o.OutPut))
                o.OutPut = $"{Path.GetFileNameWithoutExtension(o.Dir)}_{meta.Version}{Constants.PACKAGEEXTENSION}";

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
                        OnLogInfo?.Invoke(o, $"正在打包 {path}");
                        archive.CreateEntryFromFile(filePath, Path.Combine(Constants.ResourceDir, path));
                    }
                }
            }

            File.Delete(tempMetaFile);
            File.Delete(tempListFile);

            return true;
        }
    }

}
