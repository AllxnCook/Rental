using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.Data.Migrations
{
    public partial class dbcontextUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PaymentType",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5823a78d-1b8e-42fb-a5c2-348bab10552d", "AQAAAAEAACcQAAAAEJN1PDOx00DKgCSeKX1OKBSRJqUHYCNfgHQk61Xhjd23yi1Pt89PWWJ4oTt1RiUBZg==", "3f1a0c2d-5f71-4986-811a-594b6f53e9fd" });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_UserId",
                table: "PaymentType",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentType_AspNetUsers_UserId",
                table: "PaymentType",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentType_AspNetUsers_UserId",
                table: "PaymentType");

            migrationBuilder.DropIndex(
                name: "IX_PaymentType_UserId",
                table: "PaymentType");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PaymentType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a478e6e0-523c-454d-9664-bc33b59d2a00", "AQAAAAEAACcQAAAAEGkZVcE8rS/cgncwXHFIvObivJByo3bSKcSLUYdrEeljfq3itsWCEI10PP+utEhNaQ==", "68924479-ce3c-4751-80c6-ff0320f1c228" });
        }
    }
}
