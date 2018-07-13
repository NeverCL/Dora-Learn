using System;
using StackExchange.Redis;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ip = "wdora.com";
            var serviceName = "mymaster";

            ConfigurationOptions sentinelConfig = new ConfigurationOptions();
            sentinelConfig.ServiceName = serviceName;
            sentinelConfig.EndPoints.Add(ip, 26379);
            sentinelConfig.EndPoints.Add(ip, 26380);
            sentinelConfig.EndPoints.Add(ip, 26381);
            sentinelConfig.TieBreaker = "";//这行在sentinel模式必须加上
            sentinelConfig.CommandMap = CommandMap.Sentinel;
            // Need Version 3.0 for the INFO command?
            sentinelConfig.DefaultVersion = new Version(3, 0);
            var conn = ConnectionMultiplexer.Connect(sentinelConfig);
            // 获取 master 节点信息
            var master = conn.GetServer(ip,26379).SentinelGetMasterAddressByName(serviceName);
            var slaves = conn.GetServer(ip,26379).SentinelSlaves(serviceName);
            var sentinelsub= conn.GetSubscriber();
            sentinelsub.Subscribe("+switch-master",(channel, message) =>
            {
                Console.WriteLine((string)message);
            });
            Console.Read();
            Console.WriteLine("Hello World!");
        }
    }
}
