using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.Infrastructure.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "Nigeria", "NG" },
                    { 2, "Ghana", "GH" },
                    { 3, "Benin", "BJ" },
                    { 4, "Cameroon", "CM" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "Lagos", 1, "Radisson Bleu Anchorage Hotel" },
                    { 2, "Accra", 2, "Alisa Hotel North Ridge" },
                    { 3, "Porto-Novo", 3, "White Horse Hotel Port0-Novo" },
                    { 4, "Douala", 4, "K Hotel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
