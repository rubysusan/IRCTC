using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IRCTC.Repository.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    CoachName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BaseCharge = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.CoachId);
                });

            migrationBuilder.CreateTable(
                name: "SeatStatus",
                columns: table => new
                {
                    SeatStatusId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatStatus", x => x.SeatStatusId);
                });

            migrationBuilder.CreateTable(
                name: "SeatType",
                columns: table => new
                {
                    SeatTypeId = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatType", x => x.SeatTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.StationId);
                });

            migrationBuilder.CreateTable(
                name: "TrainType",
                columns: table => new
                {
                    TrainTypeID = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainType", x => x.TrainTypeID);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Train",
                columns: table => new
                {
                    TrainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromStationId = table.Column<int>(type: "int", nullable: false),
                    ToStationId = table.Column<int>(type: "int", nullable: false),
                    TrainTypeID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReachingTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train", x => x.TrainId);
                    table.ForeignKey(
                        name: "FK_Train_Station_FromStationId",
                        column: x => x.FromStationId,
                        principalTable: "Station",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Train_Station_ToStationId",
                        column: x => x.ToStationId,
                        principalTable: "Station",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Train_TrainType_TrainTypeID",
                        column: x => x.TrainTypeID,
                        principalTable: "TrainType",
                        principalColumn: "TrainTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdentityCardID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_UserType_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "UserType",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainClass",
                columns: table => new
                {
                    TrainClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainClass", x => x.TrainClassId);
                    table.ForeignKey(
                        name: "FK_TrainClass_Coach_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Coach",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainClass_Train_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Train",
                        principalColumn: "TrainId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainStop",
                columns: table => new
                {
                    TrainStopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainId = table.Column<int>(type: "int", nullable: false),
                    StopStationId = table.Column<int>(type: "int", nullable: false),
                    ReachingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StationCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainStop", x => x.TrainStopId);
                    table.ForeignKey(
                        name: "FK_TrainStop_Station_StopStationId",
                        column: x => x.StopStationId,
                        principalTable: "Station",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainStop_Train_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Train",
                        principalColumn: "TrainId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeatTypeId = table.Column<int>(type: "int", nullable: false),
                    TrainClassId = table.Column<int>(type: "int", nullable: false),
                    SeatStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seat_SeatStatus_SeatStatusId",
                        column: x => x.SeatStatusId,
                        principalTable: "SeatStatus",
                        principalColumn: "SeatStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seat_SeatType_SeatTypeId",
                        column: x => x.SeatTypeId,
                        principalTable: "SeatType",
                        principalColumn: "SeatTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seat_TrainClass_TrainClassId",
                        column: x => x.TrainClassId,
                        principalTable: "TrainClass",
                        principalColumn: "TrainClassId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    SeatTypeId = table.Column<int>(type: "int", nullable: false),
                    TrainClassId = table.Column<int>(type: "int", nullable: false),
                    FromStop = table.Column<int>(type: "int", nullable: false),
                    ToStop = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Preference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Booking_SeatType_SeatTypeId",
                        column: x => x.SeatTypeId,
                        principalTable: "SeatType",
                        principalColumn: "SeatTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_TrainClass_TrainClassId",
                        column: x => x.TrainClassId,
                        principalTable: "TrainClass",
                        principalColumn: "TrainClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_TrainStop_FromStop",
                        column: x => x.FromStop,
                        principalTable: "TrainStop",
                        principalColumn: "TrainStopId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_TrainStop_ToStop",
                        column: x => x.ToStop,
                        principalTable: "TrainStop",
                        principalColumn: "TrainStopId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Coach",
                columns: new[] { "CoachId", "BaseCharge", "CoachName" },
                values: new object[,]
                {
                    { 1, 100.0, "ACFirstClass" },
                    { 2, 200.0, "ExecChairCar" },
                    { 3, 150.0, "ACChairCar" },
                    { 4, 80.0, "Sleeper" },
                    { 5, 50.0, "SecondSitting" },
                    { 6, 130.0, "ACSecondTier" },
                    { 7, 150.0, "ACThirdTier" },
                    { 8, 85.0, "ACThreeEconomy" }
                });

            migrationBuilder.InsertData(
                table: "SeatStatus",
                columns: new[] { "SeatStatusId", "Status" },
                values: new object[,]
                {
                    { 1, "Confirmed" },
                    { 2, "ReservationAgainstCancellation" },
                    { 3, "GeneralWaitingList" },
                    { 4, "TatkalWaitingList" },
                    { 5, "TicketCancelled" }
                });

            migrationBuilder.InsertData(
                table: "SeatType",
                columns: new[] { "SeatTypeId", "TypeName" },
                values: new object[,]
                {
                    { 1, "LowerBirth" },
                    { 2, "UpperBirth" },
                    { 3, "MiddleBirth" },
                    { 4, "WindowSeat" },
                    { 5, "AisleSeat" }
                });

            migrationBuilder.InsertData(
                table: "TrainType",
                columns: new[] { "TrainTypeID", "TypeName" },
                values: new object[,]
                {
                    { 1, "Janshatabdi" },
                    { 2, "Shatabdi" },
                    { 3, "Antyodaya" },
                    { 4, "Intercity" },
                    { 5, "Express" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "UserTypeId", "TypeName" },
                values: new object[,]
                {
                    { 1, "Passenger" },
                    { 2, "TTE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_FromStop",
                table: "Booking",
                column: "FromStop");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SeatId",
                table: "Booking",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SeatTypeId",
                table: "Booking",
                column: "SeatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ToStop",
                table: "Booking",
                column: "ToStop");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TrainClassId",
                table: "Booking",
                column: "TrainClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_SeatStatusId",
                table: "Seat",
                column: "SeatStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_SeatTypeId",
                table: "Seat",
                column: "SeatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_TrainClassId",
                table: "Seat",
                column: "TrainClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Train_FromStationId",
                table: "Train",
                column: "FromStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Train_ToStationId",
                table: "Train",
                column: "ToStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Train_TrainTypeID",
                table: "Train",
                column: "TrainTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainClass_ClassId",
                table: "TrainClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainClass_TrainId",
                table: "TrainClass",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainStop_StopStationId",
                table: "TrainStop",
                column: "StopStationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainStop_TrainId",
                table: "TrainStop",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeID",
                table: "User",
                column: "UserTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "TrainStop");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "SeatStatus");

            migrationBuilder.DropTable(
                name: "SeatType");

            migrationBuilder.DropTable(
                name: "TrainClass");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "Coach");

            migrationBuilder.DropTable(
                name: "Train");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "TrainType");
        }
    }
}
