using System;
using System.Threading;

namespace Timing
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer(obj => Console.Write("hello"), new Object(), 0, 1000);
            Console.ReadLine();
        }
    }
}