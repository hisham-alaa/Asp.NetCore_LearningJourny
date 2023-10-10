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
    class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d=>d.Id)
                .UseIdentityColumn(10,10);

            builder.Property(d => d.DateOfCreation)
                .HasComputedColumnSql("GetDate()");


        }
    }
}
