using ExamMaster.Application.Common.Consts;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamMaster.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seedQuestionTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuestionType",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { QuestionTypeEnum.Choices,nameof(QuestionTypeEnum.Choices) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuestionType",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
