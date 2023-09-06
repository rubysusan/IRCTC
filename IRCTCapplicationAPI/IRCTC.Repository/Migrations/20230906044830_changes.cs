using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IRCTC.Repository.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeatStatus",
                keyColumn: "SeatStatusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SeatStatus",
                keyColumn: "SeatStatusId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "SeatStatus",
                keyColumn: "SeatStatusId",
                keyValue: 2,
                column: "Status",
                value: "NotConfirmed");

            migrationBuilder.UpdateData(
                table: "SeatStatus",
                keyColumn: "SeatStatusId",
                keyValue: 3,
                column: "Status",
                value: "TicketCancelled");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SeatStatus",
                keyColumn: "SeatStatusId",
                keyValue: 2,
                column: "Status",
                value: "ReservationAgainstCancellation");

            migrationBuilder.UpdateData(
                table: "SeatStatus",
                keyColumn: "SeatStatusId",
                keyValue: 3,
                column: "Status",
                value: "GeneralWaitingList");

            migrationBuilder.InsertData(
                table: "SeatStatus",
                columns: new[] { "SeatStatusId", "Status" },
                values: new object[,]
                {
                    { 4, "TatkalWaitingList" },
                    { 5, "TicketCancelled" }
                });
        }
    }
}
