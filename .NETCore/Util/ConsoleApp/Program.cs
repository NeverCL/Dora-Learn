using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = NameBuilder.GetRandomName();
            System.Console.WriteLine(name);
        }
    }
}
