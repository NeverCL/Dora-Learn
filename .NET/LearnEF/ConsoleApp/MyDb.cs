using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class MyDb : DbContext
    {
        public MyDb():base("DefaultConnection")
        {
            
        }
        public DbSet<Menu> Menus { get; set; }
    }
}
