using EFCore1.Models;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore1.Infra
{
    public class Context : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BlogConnection"].ToString();

            //Usando VS 2015 LocalDB - Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Blog.mdf;Integrated Security=True
            //Usando VS 2013 LocalDB - Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Blog.mdf;Integrated Security=True
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasKey(x => x.Id);
            modelBuilder.Entity<Post>().Property(x => x.Id);
            modelBuilder.Entity<Post>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<Post>().Property(x => x.Content).IsRequired();

            modelBuilder.Entity<Comment>().HasKey(x => x.Id);
            modelBuilder.Entity<Comment>().Property(x => x.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<Comment>().Property(x => x.Text).IsRequired();
            modelBuilder.Entity<Comment>().Property(x => x.CreateDate).ForSqlServerHasDefaultValue<DateTime>(DateTime.Now);

            modelBuilder.Entity<Post>().HasMany<Comment>(x=> x.Comments).WithOne();
        }
    }
}
