using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Task> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Task;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().Property(r => r.Date).IsRequired();
            modelBuilder.Entity<Task>().ToTable("NewTask");
            modelBuilder.Entity<Task>().Property(n => n.Date).HasColumnName("Deadline");
        }

    }
}
