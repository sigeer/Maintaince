using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace Maintenance.Lib.Domain.ScriptExecutor
{
    internal class Executor
    {
        internal static void RunPowerShell(string path)
        {
            using (PowerShell ps = PowerShell.Create())
            {
                // 初始化一个Runspace，这是PowerShell执行环境
                using (Runspace runspace = RunspaceFactory.CreateRunspace())
                {
                    runspace.Open();

                    // 设置PowerShell的执行环境为刚创建的Runspace
                    ps.Runspace = runspace;

                    // 添加要执行的PowerShell脚本内容
                    ps.AddScript($"$WORKDIR=\"{Environment.CurrentDirectory}\"");
                    ps.AddScript(File.ReadAllText(path));

                    // 执行脚本并获取结果集合
                    var results = ps.Invoke();

                    // 遍历并输出结果
                    foreach (var result in results)
                    {
                        Console.WriteLine(result);
                    }

                    // 检查是否有错误发生
                    if (ps.Streams.Error.Count > 0)
                    {
                        foreach (var err in ps.Streams.Error)
                        {
                            Console.WriteLine("Error: " + err.ToString());
                        }
                    }
                }
            }
        }
    }
}
