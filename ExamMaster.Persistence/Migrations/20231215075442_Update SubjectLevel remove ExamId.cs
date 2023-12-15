using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamMaster.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSubjectLevelremoveExamId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectLevels_Exam_ExamId",
                table: "SubjectLevels");

            migrationBuilder.DropIndex(
                name: "IX_SubjectLevels_ExamId",
                table: "SubjectLevels");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "SubjectLevels");

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Exam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Exam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_LevelId",
                table: "Exam",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_SubjectId",
                table: "Exam",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Levels_LevelId",
                table: "Exam",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Subjects_SubjectId",
                table: "Exam",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Levels_LevelId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Subjects_SubjectId",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Exam_LevelId",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Exam_SubjectId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Exam");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "SubjectLevels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectLevels_ExamId",
                table: "SubjectLevels",
                column: "ExamId",
                unique: true,
                filter: "[ExamId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectLevels_Exam_ExamId",
                table: "SubjectLevels",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id");
        }
    }
}
