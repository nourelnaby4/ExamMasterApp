using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExamMaster.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedApplicationRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "371f1f02-80b2-4815-abb8-b3b2c5a4ea4d", null, "Student", "STUDENT" },
                    { "693de636-d8a8-4001-8dc7-e6b1a6fb849b", null, "Teacher", "TEACHER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "371f1f02-80b2-4815-abb8-b3b2c5a4ea4d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "693de636-d8a8-4001-8dc7-e6b1a6fb849b");
        }
    }
}
