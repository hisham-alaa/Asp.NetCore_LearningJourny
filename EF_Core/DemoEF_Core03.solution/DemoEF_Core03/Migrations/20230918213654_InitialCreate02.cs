using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEF_Core03.Migrations
{
    public partial class InitialCreate02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfCreation",
                table: "Departments",
                type: "date",
                nullable: false,
                computedColumnSql: "GetDate()",
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfCreation",
                table: "Departments",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldComputedColumnSql: "GetDate()");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
