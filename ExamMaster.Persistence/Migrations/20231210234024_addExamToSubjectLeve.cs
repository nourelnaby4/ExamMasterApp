using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamMaster.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addExamToSubjectLeve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPoint",
                table: "SubjectLevels");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "SubjectLevels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Exam",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectLevels_ExamId",
                table: "SubjectLevels",
                column: "ExamId",
                unique: true,
                filter: "[ExamId] IS NOT NULL");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectLevels_Exam_ExamId",
                table: "SubjectLevels",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Levels_LevelId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectLevels_Exam_ExamId",
                table: "SubjectLevels");

            migrationBuilder.DropIndex(
                name: "IX_SubjectLevels_ExamId",
                table: "SubjectLevels");

            migrationBuilder.DropIndex(
                name: "IX_Exam_LevelId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "SubjectLevels");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Exam");

            migrationBuilder.AddColumn<int>(
                name: "TotalPoint",
                table: "SubjectLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
