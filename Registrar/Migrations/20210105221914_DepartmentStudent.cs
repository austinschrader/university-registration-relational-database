using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Registrar.Migrations
{
    public partial class DepartmentStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Departments_DepartmentId",
                table: "CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudent_DepartmentId",
                table: "CourseStudent");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "CourseStudent");

            migrationBuilder.CreateTable(
                name: "DepartmentStudent",
                columns: table => new
                {
                    DepartmentStudentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentStudent", x => x.DepartmentStudentId);
                    table.ForeignKey(
                        name: "FK_DepartmentStudent_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentStudent_DepartmentId",
                table: "DepartmentStudent",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentStudent_StudentId",
                table: "DepartmentStudent",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentStudent");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "CourseStudent",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_DepartmentId",
                table: "CourseStudent",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Departments_DepartmentId",
                table: "CourseStudent",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
