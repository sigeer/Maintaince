using System.Diagnostics;

namespace Maintenance.Console.Domain.ScriptExecutor
{
    internal class CMDExecutor
    {
        public static string Run(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe"; // 指定要执行的命令解释器（这里是 cmd）
            process.StartInfo.Arguments = $"/c {command}"; // 指定要执行的命令及参数，/c 表示执行完命令后关闭 cmd 窗口
            process.StartInfo.UseShellExecute = false; // 不使用操作系统外壳程序启动进程
            process.StartInfo.RedirectStandardOutput = true; // 重定向标准输出，以便从进程读取输出信息

            process.Start(); // 启动进程

            // 读取进程的输出
            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit(); // 等待进程执行完成
            process.Close(); // 关闭进程
            return output;
        }
    }
}
