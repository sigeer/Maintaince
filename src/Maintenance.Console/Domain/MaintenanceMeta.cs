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
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(MaintenanceMeta))]
    public partial class MaintenanceMetaContext : JsonSerializerContext
    {
    }
}
