using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Registrar.Migrations
{
    public partial class AddDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "CourseStudent",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentCourse",
                columns: table => new
                {
                    DepartmentCourseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentCourse", x => x.DepartmentCourseId);
                    table.ForeignKey(
                        name: "FK_DepartmentCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentCourse_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_DepartmentId",
                table: "CourseStudent",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCourse_CourseId",
                table: "DepartmentCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCourse_DepartmentId",
                table: "DepartmentCourse",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Departments_DepartmentId",
                table: "CourseStudent",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Departments_DepartmentId",
                table: "CourseStudent");

            migrationBuilder.DropTable(
                name: "DepartmentCourse");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudent_DepartmentId",
                table: "CourseStudent");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "CourseStudent");
        }
    }
}
