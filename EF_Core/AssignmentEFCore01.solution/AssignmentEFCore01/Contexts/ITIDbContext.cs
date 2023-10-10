using AssignmentEFCore01.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEFCore01.Contexts
{
    class ITIDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server = .; Database = ITI_EFCore; Trusted_Connection = True");




        
        //public DbSet<StudentCourse> studentCourses { get; set; }
        //public DbSet<CourseInstructor> courseInstructors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>(T => {
                T.ToTable("Topics","dbo");
                
                T.HasKey(t => t.Id);
                
                T.Property(t => t.Id)
                 .UseIdentityColumn();

                T.Property(t => t.Name)
                 .IsRequired(false);
            });

            modelBuilder.Entity<Student>(s =>
            {
                s.HasMany(s => s.StudentCourse)
                 .WithOne(sc => sc.Student);
            });

            modelBuilder.Entity<Course>(c =>
            {
                c.HasMany(c => c.CourseStudent)
                 .WithOne(sc => sc.Course);
            });
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new {sc.StudentId, sc.CourseId});
            modelBuilder.Entity<CourseInstructor>().HasKey(ci => new { ci.InstructorId, ci.CourseId });

        }

        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        // DbSet<Topic> topics { get; set; }

    }
}
