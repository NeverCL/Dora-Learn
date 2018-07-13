using System;
using StackExchange.Redis;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationOptions sentinelConfig = new ConfigurationOptions();
            sentinelConfig.ServiceName = "mymaster";
            sentinelConfig.EndPoints.Add("192.168.0.51", 26379);
            sentinelConfig.EndPoints.Add("192.168.0.51", 26380);
            sentinelConfig.EndPoints.Add("192.168.0.51", 26381);
            sentinelConfig.TieBreaker = "";//这行在sentinel模式必须加上
            sentinelConfig.CommandMap = CommandMap.Sentinel;
            // Need Version 3.0 for the INFO command?
            sentinelConfig.DefaultVersion = new Version(3, 0);
            var conn = ConnectionMultiplexer.Connect(sentinelConfig);
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
