using Maintenance.Lib;

namespace Maintenance.Win.Options
{
    public class PackOptions : IPackOptions
    {
        /// <summary>
        /// 资源文件目录，默认为当前目录
        /// </summary>
        public string? Dir { get; set; }
        /// <summary>
        /// 生成的zip文件，默认为当前工作目录
        /// </summary>
        public string? OutPut { get; set; }
        public string? PackageConfig { get; set; }

        public string? S1Script { get; set; }
        public string? S0Script { get; set; }
    }
}
