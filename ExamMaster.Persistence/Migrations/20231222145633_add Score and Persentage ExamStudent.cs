using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamMaster.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addScoreandPersentageExamStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPoint",
                table: "StudentExams",
                newName: "Score");

            migrationBuilder.AddColumn<decimal>(
                name: "Percentage",
                table: "StudentExams",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "StudentExams");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "StudentExams",
                newName: "TotalPoint");
        }
    }
}
