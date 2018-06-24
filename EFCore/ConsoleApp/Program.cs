using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new MyDbContext();
            db.Users.Add(new User{
                Name = "hello"
            });
            db.SaveChanges();

            Console.WriteLine("Hello World!");
        }
    }
}
