using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRCTC.Repository.Migrations
{
    /// <inheritdoc />
    public partial class seattype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SeatType",
                keyColumn: "SeatTypeId",
                keyValue: 1,
                column: "TypeName",
                value: "LowerBerth");

            migrationBuilder.UpdateData(
                table: "SeatType",
                keyColumn: "SeatTypeId",
                keyValue: 2,
                column: "TypeName",
                value: "UpperBerth");

            migrationBuilder.UpdateData(
                table: "SeatType",
                keyColumn: "SeatTypeId",
                keyValue: 3,
                column: "TypeName",
                value: "MiddleBerth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SeatType",
                keyColumn: "SeatTypeId",
                keyValue: 1,
                column: "TypeName",
                value: "LowerBirth");

            migrationBuilder.UpdateData(
                table: "SeatType",
                keyColumn: "SeatTypeId",
                keyValue: 2,
                column: "TypeName",
                value: "UpperBirth");

            migrationBuilder.UpdateData(
                table: "SeatType",
                keyColumn: "SeatTypeId",
                keyValue: 3,
                column: "TypeName",
                value: "MiddleBirth");
        }
    }
}
