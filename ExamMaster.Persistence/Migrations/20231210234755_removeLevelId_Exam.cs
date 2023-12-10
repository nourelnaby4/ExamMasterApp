using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamMaster.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removeLevelId_Exam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Levels_LevelId",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Exam_LevelId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "TotalPoint",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Exam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalPoint",
                table: "Levels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Exam",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_LevelId",
                table: "Exam",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Levels_LevelId",
                table: "Exam",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id");
        }
    }
}
