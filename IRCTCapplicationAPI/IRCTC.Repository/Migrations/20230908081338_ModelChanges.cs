using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRCTC.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_SeatType_SeatTypeId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Seat_SeatId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_SeatId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_SeatTypeId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Preference",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "SeatTypeId",
                table: "Booking");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Preference",
                table: "Booking",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeatTypeId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SeatId",
                table: "Booking",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SeatTypeId",
                table: "Booking",
                column: "SeatTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_SeatType_SeatTypeId",
                table: "Booking",
                column: "SeatTypeId",
                principalTable: "SeatType",
                principalColumn: "SeatTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Seat_SeatId",
                table: "Booking",
                column: "SeatId",
                principalTable: "Seat",
                principalColumn: "SeatId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
