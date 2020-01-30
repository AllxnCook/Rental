using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.Data.Migrations
{
    public partial class RenameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.CreateTable(
                name: "VehicleRentals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleRentals_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a478e6e0-523c-454d-9664-bc33b59d2a00", "AQAAAAEAACcQAAAAEGkZVcE8rS/cgncwXHFIvObivJByo3bSKcSLUYdrEeljfq3itsWCEI10PP+utEhNaQ==", "68924479-ce3c-4751-80c6-ff0320f1c228" });

            migrationBuilder.InsertData(
                table: "VehicleRentals",
                columns: new[] { "Id", "ApplicationUserId", "EndTime", "PaymentTypeId", "StartTime", "VehicleId" },
                values: new object[,]
                {
                    { 1, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2020, 1, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 1, 22, 16, 13, 37, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2020, 1, 23, 18, 13, 12, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 1, 23, 12, 16, 33, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2020, 1, 24, 20, 10, 17, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 1, 24, 13, 12, 11, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRentals_PaymentTypeId",
                table: "VehicleRentals",
                column: "PaymentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleRentals");

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4cad7b1-8235-49f0-8264-224f03fa0018", "AQAAAAEAACcQAAAAEAOCVBbiZCVr2yTdA6REtoZTcjXtBjwDueBWxNJuCLDzIcv5sf6xH3Kmp1Pxr/EWSg==", "6d177989-8001-49b4-bb14-cb5df9b770a2" });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "ApplicationUserId", "EndTime", "PaymentTypeId", "StartTime", "VehicleId" },
                values: new object[,]
                {
                    { 1, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2020, 1, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 1, 22, 16, 13, 37, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2020, 1, 23, 18, 13, 12, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 1, 23, 12, 16, 33, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2020, 1, 24, 20, 10, 17, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 1, 24, 13, 12, 11, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_PaymentTypeId",
                table: "Rentals",
                column: "PaymentTypeId");
        }
    }
}
