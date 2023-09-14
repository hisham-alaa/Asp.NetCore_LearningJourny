using DemoEFCore01.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore01.Configurations
{
    class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        ///the 4th way to map class to DB 
        public void Configure(EntityTypeBuilder<Department> d)
        {
            d.ToTable("Departments", "dbo");

            d.HasKey(D => D.DeptId);

            d.Property(D => D.DeptId)
             .UseIdentityColumn(10, 10);

            d.Property(D => D.Name)
             .IsRequired(true)
             .HasColumnType("varchar")
             .HasColumnName("DepartmentName")
             .HasMaxLength(50)
             .HasDefaultValue("Empty")
             .HasAnnotation("MaxLength", 50);

            d.Property(D => D.DateOfCreation)
             .HasComputedColumnSql("GetDate()")
             .HasColumnType("DateTime");

            d.Property(D => D.Description);

            d.Property(D => D.MgrId);
        }
    }
}