using DemoEF_Core03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF_Core03.Configurations
{
    class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.HasOne(e => e.Department)
                .WithMany(d=>d.Emps);

            builder.Property(e=>e.DepartmentId)
                .IsRequired(false);
        }
    }
}
