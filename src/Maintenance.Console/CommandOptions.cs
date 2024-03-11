using CommandLine;
using Maintenance.Lib;

namespace Maintenance.Console
{
    [Verb("update", HelpText = "更新应用")]
    public class UpdationOptions: IUpdationOptions
    {
        [Option('p', "path", HelpText = "资源路径，可支持HTTP资源", Required = true)]
        public string Path { get; set; } = null!;
        /// <summary>
        /// 待更新文件目录，默认为当前工作目录
        /// </summary>
        [Option('d', "dir", HelpText = "待更新文件目录，默认为当前工作目录")]
        public string? Dir { get; set; }
    }
    [Verb("uninstall", HelpText = "卸载当前目录的应用")]
    public class UninstallationOptions: IUninstallationOptions
    {

    }
    /// <summary>
    /// mtnc pack --dir=""
    /// </summary>
    [Verb("pack", HelpText = "生成更新用资源包")]
    public class PackOptions : IPackOptions
    {
        /// <summary>
        /// 资源文件目录，默认为当前目录
        /// </summary>
        [Option('d', "dir", HelpText = "资源文件目录")]
        public string? Dir { get; set; }
        /// <summary>
        /// 生成的zip文件，默认为当前工作目录
        /// </summary>
        [Option('o', "output", HelpText = "生成的补丁文件，默认生成在当前目录")]
        public string? OutPut { get; set; }
        [Option('c', "config", HelpText = "读取配置文件，默认为当前目录下的package.mtncc文件")]
        public string? PackageConfig { get; set; }
        //[Option('v', "version", HelpText = "补丁包的版本号")]
        //public string? Version { get; set; } = "1.0.0";
        //public int VersionNumber { get; set; } = 1;

        [Option("s1")]
        public string? S1Script { get; set; }
        [Option("s0")]
        public string? S0Script { get; set; }
    }
}
