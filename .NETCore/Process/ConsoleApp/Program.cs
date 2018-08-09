using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // BEGIN:VCARD
            // VERSION:3.0
            // N:张总;;;;
            // TEL;TYPE=cell:15212345432
            // END:VCARD

            var str = new StringBuilder();
            var phones = File.ReadAllLines("1.txt");
            foreach (var item in phones)
            {
                str.Append($"BEGIN:VCARD\r\nVERSION:3.0\r\nN:{NameBuilder.GetRandomName()};;;;\r\nTEL;TYPE=cell:{item}\r\nEND:VCARD\r\n");
            }
            File.WriteAllText("contacts.vcf",str.ToString());

            // while (string.IsNullOrEmpty(NoxConfig.ProcessPath))
            // {
            //     var process = Process.GetProcessesByName(NoxConfig.ProcessName).FirstOrDefault();
            //     if (process == null){
            //         System.Console.WriteLine("等待启动进程....");
            //         Thread.Sleep(3000);
            //     }else{
            //         NoxConfig.ProcessId = process.Id;
            //         NoxConfig.ProcessPath = Path.GetDirectoryName(process.MainModule.FileName);
            //     }
            // }
            // Console.WriteLine("检测到进程！");
        }
    }
}
