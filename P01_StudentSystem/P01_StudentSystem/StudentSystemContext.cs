using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem
{
    internal class StudentSystemContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EF02;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(s => s.Name).HasMaxLength(100);
            modelBuilder.Entity<Student>().Property(s => s.Name).IsUnicode(true);
            modelBuilder.Entity<Student>().Property(s => s.PhoneNumber).HasMaxLength(10);
            modelBuilder.Entity<Student>().Property(s => s.PhoneNumber).IsUnicode(false);
            modelBuilder.Entity<Student>().Property(s => s.PhoneNumber).IsRequired(false);
            modelBuilder.Entity<Course>().Property(c => c.Name).IsUnicode(true);
            modelBuilder.Entity<Course>().Property(c => c.Description).IsUnicode(true);
            modelBuilder.Entity<Course>().Property(c => c.Description).IsRequired();
            modelBuilder.Entity<Course>().Property(c => c.Name).HasMaxLength(80);
            modelBuilder.Entity<Resource>().Property(r => r.Name).HasMaxLength(50);
            modelBuilder.Entity<Resource>().Property(r => r.Name).IsUnicode();
            modelBuilder.Entity<Resource>().Property(r => r.Url).IsUnicode(false);
            modelBuilder.Entity<Homework>().Property(h => h.Content).IsUnicode(false);
            modelBuilder.Entity<Student>()
                .HasMany(e => e.Homeworks)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .IsRequired();
            modelBuilder.Entity<Course>()
                .HasMany(e => e.Resources)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId)
                .IsRequired();
            modelBuilder.Entity<Course>()
               .HasMany(e => e.Homeworks)
               .WithOne(e => e.Course)
               .HasForeignKey(e => e.CourseId)
               .IsRequired();
            modelBuilder.Entity<Student>()
                .HasMany(e => e.Courses)
                .WithMany(e => e.Students);
            modelBuilder.Entity<Student>().HasData(
            new { StudentId = 1, Name = "khalid", PhoneNumber ="200000" , RegisteredOn = "2:30", Birthday= "20-2-2001",  });
            
            modelBuilder.Entity<Course>().HasData(
            new { CourseId = 1, Name = "database", Description = "good course", StartDate = "22-2-2023", EndDate = "22-2-2024", Price= "3000LE",  });

            modelBuilder.Entity<Resource>().HasData(
            new { ResourceId = 1, Name = "anything", Url = "https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding", ResourceType = "video", EndDate = "2022, 1, 1", CourseId = 1, });

            modelBuilder.Entity<Homework>().HasData(
           new { HomeworkId = 1, Content = "data",  ContentType = "Pdf", SubmissionTime = "3:30", CourseId = 1,StudentId=1 });










        }
    }
}
