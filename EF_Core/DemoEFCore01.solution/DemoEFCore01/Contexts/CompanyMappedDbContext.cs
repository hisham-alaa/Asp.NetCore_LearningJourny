using DemoEFCore01.Configurations;
using DemoEFCore01.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore01.Contexts
{
    class CompanyMappedDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            =>optionsBuilder.UseSqlServer("Server = ETCH; Database = CompanyMapped; Trusted_Connection = true; TrustServerCertificate=true");

        public DbSet<Employee> employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            ///The 3rd way to map class to DB
            ///the same but we will choose someone that has no chance to throw error
            ///modelBuilder.Entity<Department>().ToTable("Departments", "dbo");
            ///modelBuilder.Entity<Department>().HasKey("DeptId");//MayThrow Error If not existed 
            ///modelBuilder.Entity<Department>().HasKey(d => d.DeptId);
            ///modelBuilder.Entity<Department>().HasKey(nameof(Department.DeptId));
            ///
            ///modelBuilder.Entity<Department>(d =>
            ///{
            ///    d.Property(D => D.DeptId)
            ///     .UseIdentityColumn(10, 10);
            ///
            ///    d.Property(D => D.Name)
            ///     .IsRequired(true)
            ///     .HasColumnType("varchar")
            ///     .HasColumnName("DepartmentName")
            ///     .HasMaxLength(50)
            ///     .HasDefaultValue("Empty")
            ///     .HasAnnotation("MaxLength", 50);
            ///
            ///    d.Property(D => D.DateOfCreation)
            ///     .HasComputedColumnSql("GetDate()");
            ///
            ///    d.Property(D => D.Description);
            ///
            ///    d.Property(D => D.MgrId);
            ///
            ///});

            ///OR (With The 4th WayConfiguration Class Written)

            modelBuilder.ApplyConfiguration(new DepartmentConfigurations());
        }
    }
}