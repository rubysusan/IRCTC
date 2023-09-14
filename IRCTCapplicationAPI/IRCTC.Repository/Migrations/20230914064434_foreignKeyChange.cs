using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRCTC.Repository.Migrations
{
    /// <inheritdoc />
    public partial class foreignKeyChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passenger_SeatId",
                table: "Passenger");

            migrationBuilder.CreateIndex(
                name: "IX_Passenger_SeatId",
                table: "Passenger",
                column: "SeatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passenger_SeatId",
                table: "Passenger");

            migrationBuilder.CreateIndex(
                name: "IX_Passenger_SeatId",
                table: "Passenger",
                column: "SeatId",
                unique: true);
        }
    }
}
