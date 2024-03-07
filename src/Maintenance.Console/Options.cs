using CommandLine;

namespace Maintenance.Console
{
    [Verb("update", HelpText = "更新应用")]
    public class UpdationOptions
    {
        [Option('u', "url", HelpText = "远程资源")]
        public string? Url { get; set; }
        [Option('p', "path", HelpText = "资源压缩包")]
        public string? Path { get; set; }
        /// <summary>
        /// 待更新文件目录，默认为当前工作目录
        /// </summary>
        [Option('d', "dir", HelpText = "待更新文件目录，默认为当前工作目录")]
        public string? Dir { get; set; }
    }
    [Verb("uninstall", HelpText = "卸载当前目录的应用")]
    public class UninstallationOptions
    {

    }
    /// <summary>
    /// mtnc pack --dir=""
    /// </summary>
    [Verb("pack", HelpText = "生成更新用资源包")]
    public class PackOptions
    {
        /// <summary>
        /// 资源文件目录
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
    }

    public class PatchOptions
    {

    }
}
