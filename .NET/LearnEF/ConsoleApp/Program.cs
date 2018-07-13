using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new MyDb();
            db.Menus.Add(new Menu {Name = "hello"});
            db.SaveChanges();
        }
    }
}
