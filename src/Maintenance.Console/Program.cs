using CommandLine;
using Maintenance.Console;
using Maintenance.Console.Domain;
using System.Diagnostics;

var mainModule = Process.GetCurrentProcess().MainModule;
if (mainModule == null)
{
    Console.WriteLine("===启动失败===");
    Console.WriteLine("原因1：权限不足，或其他安全策略限制；");
    Console.WriteLine("原因2：在服务进程或操作系统级别的进程中运行；");
    Console.WriteLine("原因3：未知。");
    return;
}

var currentExeFullName = mainModule.FileName;
Parser.Default.ParseArguments<UninstallationOptions, UpdationOptions, PackOptions>(args)
    .WithParsed<UpdationOptions>(async o =>
    {
        if (string.IsNullOrWhiteSpace(o.Url) && string.IsNullOrWhiteSpace(o.Path))
        {
            Console.WriteLine("至少需要传入一个url或者补丁文件路径path");
            return;
        }

        string patchFile = string.Empty;
        bool shoudDeleteTempFile = false;
        if (!string.IsNullOrWhiteSpace(o.Url))
        {
            patchFile = await UpdationDomain.DownloadPatcherAsync(o.Url);
            shoudDeleteTempFile = true;
        }
        else
            patchFile = o.Path!;

        UpdationDomain.CoverDir(patchFile, string.IsNullOrWhiteSpace(o.Dir) ? Environment.CurrentDirectory : o.Dir);
        Message.ShowMessageWithColor(ConsoleColor.DarkGreen, "更新成功！");
        if (shoudDeleteTempFile)
            File.Delete(patchFile);
    })
    .WithParsed<UninstallationOptions>(o =>
    {
        Console.WriteLine("即将卸载当前目录的应用，是否继续？(y/n)");
        if (Console.ReadLine()?.Trim() == "y")
        {
            UninstallationDomain.Core();
            Message.ShowMessageWithColor(ConsoleColor.DarkGreen, "卸载成功！");
        }
        else
            Console.WriteLine("操作取消");
    })
    .WithParsed<PackOptions>(o =>
    {
        if (string.IsNullOrWhiteSpace(o.Dir))
            o.Dir = Environment.CurrentDirectory;

        if (string.IsNullOrWhiteSpace(o.PackageConfig))
            o.PackageConfig = Path.Combine(o.Dir, Constants.MetaFileName);

        var meta = PackDomain.ReadPackageMeta(o.PackageConfig);

        var dir = new DirectoryInfo(o.Dir);

        if (string.IsNullOrEmpty(o.OutPut))
            o.OutPut = $"{dir.Name}_{meta.Version}.smm";

        if (!Path.IsPathRooted(o.OutPut))
            o.OutPut = Path.Combine(o.Dir, o.OutPut);

        PackDomain.Generate(meta, dir.FullName, o.OutPut, currentExeFullName);
        Message.ShowMessageWithColor(ConsoleColor.DarkGreen, "打包成功！");
    });