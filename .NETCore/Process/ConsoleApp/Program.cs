using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (string.IsNullOrEmpty(NoxConfig.ProcessPath))
            {
                var process = Process.GetProcessesByName(NoxConfig.ProcessName).FirstOrDefault();
                if (process == null){
                    System.Console.WriteLine("等待启动进程....");
                    Thread.Sleep(3000);
                }else{
                    NoxConfig.ProcessId = process.Id;
                    NoxConfig.ProcessPath = Path.GetDirectoryName(process.MainModule.FileName);
                }
            }
            Console.WriteLine("检测到进程！");
        }
    }
}
