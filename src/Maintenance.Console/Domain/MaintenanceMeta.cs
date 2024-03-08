using System.Text.Json;
using System.Text.Json.Serialization;

namespace Maintenance.Console.Domain
{
    public class MaintenanceMeta
    {
        public string Version { get; set; } = null!;
        public int VersionNum { get; set; }
        public string? Description { get; set; }
        private MaintenanceMeta() { }
        internal MaintenanceMeta(string version, int versionNum, string? description = null)
        {
            Version = version;
            VersionNum = versionNum;
            Description = description;
        }

        public static MaintenanceMeta Default()
        {
            return new MaintenanceMeta("1.0.0", 1);
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

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(MaintenanceMeta))]
    public partial class MaintenanceMetaContext : JsonSerializerContext
    {
    }

}
