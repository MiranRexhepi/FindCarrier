using Microsoft.EntityFrameworkCore.Migrations;

namespace FindCarrier.Migrations
{
    public partial class JobTypeDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Economics" },
                    { 2, "Engineering" },
                    { 3, "HealthCare" },
                    { 4, "Law" },
                    { 5, "Science" },
                    { 6, "Arts" },
                    { 7, "Social Sciences" },
                    { 8, "Education" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JobType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "JobType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "JobType",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "JobType",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
