using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentEFCore01.Migrations
{
    public partial class Relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentDepartmentId",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstructorDepartmentId",
                table: "instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_students_StudentDepartmentId",
                table: "students",
                column: "StudentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_instructors_InstructorDepartmentId",
                table: "instructors",
                column: "InstructorDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_courses_TopicId",
                table: "courses",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_Topics_TopicId",
                table: "courses",
                column: "TopicId",
                principalSchema: "dbo",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_departments_InstructorDepartmentId",
                table: "instructors",
                column: "InstructorDepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_departments_StudentDepartmentId",
                table: "students",
                column: "StudentDepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_Topics_TopicId",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_instructors_departments_InstructorDepartmentId",
                table: "instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_students_departments_StudentDepartmentId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_StudentDepartmentId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_instructors_InstructorDepartmentId",
                table: "instructors");

            migrationBuilder.DropIndex(
                name: "IX_courses_TopicId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "StudentDepartmentId",
                table: "students");

            migrationBuilder.DropColumn(
                name: "InstructorDepartmentId",
                table: "instructors");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "courses");
        }
    }
}
