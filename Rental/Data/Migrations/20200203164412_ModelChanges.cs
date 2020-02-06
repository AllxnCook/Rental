using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.Data.Migrations
{
    public partial class ModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "VehicleRentals",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "930e24f7-54b7-4e7d-8a27-46f0ad44770a", "AQAAAAEAACcQAAAAECrvbHSZ445uaTlwIACfcu38LNjqDV66HBvkBXg90xvo016Ht+y9PxWjLm5scyTylQ==", "6f71a310-5777-4aa3-a11d-04b2b71f08aa" });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRentals_ApplicationUserId",
                table: "VehicleRentals",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleRentals_AspNetUsers_ApplicationUserId",
                table: "VehicleRentals",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleRentals_AspNetUsers_ApplicationUserId",
                table: "VehicleRentals");

            migrationBuilder.DropIndex(
                name: "IX_VehicleRentals_ApplicationUserId",
                table: "VehicleRentals");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "VehicleRentals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5823a78d-1b8e-42fb-a5c2-348bab10552d", "AQAAAAEAACcQAAAAEJN1PDOx00DKgCSeKX1OKBSRJqUHYCNfgHQk61Xhjd23yi1Pt89PWWJ4oTt1RiUBZg==", "3f1a0c2d-5f71-4986-811a-594b6f53e9fd" });
        }
    }
}
