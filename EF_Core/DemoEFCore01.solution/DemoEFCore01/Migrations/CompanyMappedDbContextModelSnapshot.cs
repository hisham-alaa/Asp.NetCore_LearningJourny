﻿// <auto-generated />
using System;
using DemoEFCore01.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoEFCore01.Migrations
{
    [DbContext(typeof(CompanyMappedDbContext))]
    partial class CompanyMappedDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DemoEFCore01.Entities.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeptId"), 10L, 10);

                    b.Property<DateTime>("DateOfCreation")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("DateTime")
                        .HasComputedColumnSql("GetDate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MgrId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("Empty")
                        .HasColumnName("DepartmentName");

                    b.HasKey("DeptId");

                    b.ToTable("Departments", "dbo");
                });

            modelBuilder.Entity("DemoEFCore01.Entities.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpId"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.HasKey("EmpId");

                    b.ToTable("Employees", "dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
