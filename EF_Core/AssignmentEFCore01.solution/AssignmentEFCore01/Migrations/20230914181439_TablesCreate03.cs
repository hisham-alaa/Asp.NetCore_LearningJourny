using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentEFCore01.Migrations
{
    public partial class TablesCreate03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "instructors",
                newName: "InsId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "instructors",
                type: "money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsId",
                table: "instructors",
                newName: "Id");

            migrationBuilder.AlterColumn<double>(
                name: "Salary",
                table: "instructors",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
