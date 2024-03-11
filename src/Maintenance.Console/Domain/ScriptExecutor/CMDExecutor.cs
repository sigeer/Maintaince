using System.Diagnostics;

namespace Maintenance.Console.Domain.ScriptExecutor
{
    internal class CMDExecutor
    {
        public static string Run(string batPath)
        {
            Process process = new Process();
            process.StartInfo.WorkingDirectory = Path.GetDirectoryName(batPath);
            process.StartInfo.FileName = "cmd.exe"; // 指定要执行的命令解释器（这里是 cmd）
            process.StartInfo.UseShellExecute = false; // 不使用操作系统外壳程序启动进程
            process.StartInfo.RedirectStandardOutput = true; // 重定向标准输出，以便从进程读取输出信息
            process.StartInfo.RedirectStandardInput = true;

            process.Start();

            // 使用： %WORKDIR%
            process.StandardInput.WriteLine($"set WORKDIR={Environment.CurrentDirectory}");
            process.StandardInput.Flush();

            process.StandardInput.WriteLine(batPath);
            process.StandardInput.Flush();

            // 读取进程的输出
            string output = process.StandardOutput.ReadToEnd();
            var err = process.StandardError.ReadToEnd();

            process.WaitForExit(); // 等待进程执行完成
            process.Close(); // 关闭进程
            return output;
        }
    }
}
