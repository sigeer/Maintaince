using System.Diagnostics;
using System.IO;

namespace Maintenance.Lib.Domain.ScriptExecutor
{
    internal class Executor
    {
        public static string Run(string batPath)
        {
            using Process process = new Process();
            process.StartInfo.WorkingDirectory = Path.GetDirectoryName(batPath);
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.UseShellExecute = false; // 不使用操作系统外壳程序启动进程
            process.StartInfo.RedirectStandardOutput = true; // 重定向标准输出，以便从进程读取输出信息
            process.StartInfo.RedirectStandardInput = true;

            string script = """
                                $WORKDIR='{0}'
                                & '{1}'
                                """;
            script = string.Format(script, Environment.CurrentDirectory, batPath);

            process.StartInfo.Arguments = "-NoLogo -NoProfile -Command \"" + script + "\"";

            process.Start();

            return process.StandardOutput.ReadToEnd();
        }
    }
}
