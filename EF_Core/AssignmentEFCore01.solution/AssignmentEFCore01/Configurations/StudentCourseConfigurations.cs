using AssignmentEFCore01.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEFCore01.Configurations
{
    class StudentCourseConfigurations : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> b)
        {
            b.ToTable("StudentCourse");
            b.HasKey(b => new { b.StudentId, b.CourseId });
            b.Property(t => t.Grade)
             .HasColumnType("float");
        }
    }
}
