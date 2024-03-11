using CommandLine;
using Maintenance.Console.Domain;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Maintenance.Console;

public class Program
{
    [DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(PackOptions))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(UpdationOptions))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(UninstallationOptions))]
    public static void Main(string[] args)
    {

        var mainModule = Process.GetCurrentProcess().MainModule;
        if (mainModule == null)
        {
            System.Console.WriteLine("===启动失败===");
            System.Console.WriteLine("原因1：权限不足，或其他安全策略限制；");
            System.Console.WriteLine("原因2：在服务进程或操作系统级别的进程中运行；");
            System.Console.WriteLine("原因3：未知。");
            return;
        }

        var currentExeFullName = mainModule.FileName;
        Parser.Default.ParseArguments<UninstallationOptions, UpdationOptions, PackOptions>(args)
            .WithParsed<UpdationOptions>(async o =>
            {
                await UpdationDomain.Core(o);
                Message.ShowMessageWithColor(ConsoleColor.DarkGreen, "更新成功！");
            })
            .WithParsed<UninstallationOptions>(o =>
            {
                System.Console.WriteLine("即将卸载当前目录的应用，是否继续？(y/n)");
                if (System.Console.ReadLine()?.Trim() == "y")
                {
                    UninstallationDomain.Core();
                    Message.ShowMessageWithColor(ConsoleColor.DarkGreen, "卸载成功！");
                }
                else
                    System.Console.WriteLine("操作取消");
            })
            .WithParsed<PackOptions>(o =>
            {
                PackDomain.Generate(o, currentExeFullName);
                Message.ShowMessageWithColor(ConsoleColor.DarkGreen, "打包成功！");
            });
    }
}
