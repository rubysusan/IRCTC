using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRCTC.Repository.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainTypeID",
                table: "Train",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Train_TrainTypeID",
                table: "Train",
                column: "TrainTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Train_TrainType_TrainTypeID",
                table: "Train",
                column: "TrainTypeID",
                principalTable: "TrainType",
                principalColumn: "TrainTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Train_TrainType_TrainTypeID",
                table: "Train");

            migrationBuilder.DropIndex(
                name: "IX_Train_TrainTypeID",
                table: "Train");

            migrationBuilder.DropColumn(
                name: "TrainTypeID",
                table: "Train");
        }
    }
}
