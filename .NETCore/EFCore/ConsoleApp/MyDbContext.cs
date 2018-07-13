using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    public class MyDbContext : DbContext {

        public MyDbContext(DbContextOptions options):base(options){

        }

        public MyDbContext(){

        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySql("server=wdora.com;database=MyDb;uid=root;password=123123");
        }
    }

    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}