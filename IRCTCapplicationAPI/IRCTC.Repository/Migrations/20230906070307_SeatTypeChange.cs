using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRCTC.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeatTypeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SeatType",
                keyColumn: "SeatTypeId",
                keyValue: 5,
                column: "TypeName",
                value: "MiddleSeat");

            migrationBuilder.InsertData(
                table: "SeatType",
                columns: new[] { "SeatTypeId", "TypeName" },
                values: new object[] { 6, "AisleSeat" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeatType",
                keyColumn: "SeatTypeId",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "SeatType",
                keyColumn: "SeatTypeId",
                keyValue: 5,
                column: "TypeName",
                value: "AisleSeat");
        }
    }
}
