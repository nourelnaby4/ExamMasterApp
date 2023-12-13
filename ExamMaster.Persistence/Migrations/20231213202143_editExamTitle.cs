using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamMaster.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editExamTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Exam",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Exam",
                newName: "Name");
        }
    }
}
