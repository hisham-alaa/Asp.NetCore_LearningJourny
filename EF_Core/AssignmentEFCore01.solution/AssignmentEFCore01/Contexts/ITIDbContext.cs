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


        DbSet<Student> students;
        DbSet<Course> courses;
        DbSet<Department> departments;
        DbSet<Instructor> Instructors;
        DbSet<Topic> topics;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>(T =>
            {
                T.ToTable("Topics","dbo");
                T.HasKey(t => t.Id);
                T.Property(t => t.Id)
                 .UseIdentityColumn();

                T.Property(t => t.Name)
                 .IsRequired(false);
            }

            );
        }



    }
}
