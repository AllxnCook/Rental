using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LicenseNumber",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickupLocation = table.Column<string>(nullable: true),
                    PricePerHour = table.Column<double>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
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
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LicenseNumber", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "c4cad7b1-8235-49f0-8264-224f03fa0018", "admin@admin.com", true, "admin", "admin", "A67033", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEAOCVBbiZCVr2yTdA6REtoZTcjXtBjwDueBWxNJuCLDzIcv5sf6xH3Kmp1Pxr/EWSg==", null, false, "6d177989-8001-49b4-bb14-cb5df9b770a2", "123 Infinity Way", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "ApplicationUserId", "EndTime", "PaymentTypeId", "StartTime", "VehicleId" },
                values: new object[,]
                {
                    { 1, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2020, 1, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 1, 22, 16, 13, 37, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2020, 1, 23, 18, 13, 12, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 1, 23, 12, 16, 33, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2020, 1, 24, 20, 10, 17, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 1, 24, 13, 12, 11, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Color", "ImageURL", "Make", "Model", "PickupLocation", "PricePerHour", "Year" },
                values: new object[,]
                {
                    { 1, "White", "https://i.pinimg.com/originals/2a/54/ef/2a54ef2823c42adab1e53ed7c24c1687.jpg", "Ferrari", "F430", "3417 Main Street Garage", 220.0, "2005" },
                    { 2, "White", "https://i.ytimg.com/vi/tNLGqxOQlcs/maxresdefault.jpg", "Porsche", "911 GT3 RS", "33 St Laurent Blvd", 280.0, "2010" },
                    { 3, "Silver", "https://img.topcheapcar.com/ZHWGU6AU1ALA09291.jpg", "Lamborghini", "Gallardo", "1482 Daschund St", 280.0, "2010" },
                    { 4, "Black", "https://www.bentleygoldcoast.com/galleria_images/6116/6116_p1_l.jpg", "Mercedes", "G 63 AMG", "1616 Rodeo Dr", 260.0, "2013" },
                    { 5, "White", "https://i.ytimg.com/vi/Or1ra9aJvcs/maxresdefault.jpg", "Ford", "F150 Raptor SVT", "371 Walter's Hwy", 180.0, "2019" },
                    { 6, "Chalk Grey", "https://media.caradvice.com.au/image/private/s--OTK9ZOcV--/v1550383192/4bcfda9e61c9bb6b89451c88dd7256a5.jpg", "BMW", "M3 335i", "3480 Marcel Blvd", 150.0, "2019" },
                    { 7, "White", "https://icdn2.digitaltrends.com/image/digitaltrends/2015-lamborghini-huracan-36-382x238-c.jpg", "Lamborghini", "Huracan", "993 San Juan Blvd", 280.0, "2015" },
                    { 8, "Brown", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/2020-mclaren-720s-mmp-1-1570642764.jpg?crop=0.577xw:0.789xh;0.337xw,0.158xh&resize=640:*", "McLeran", "720S", "1478 Bender Blvd", 340.0, "2020" },
                    { 9, "Purple", "https://i.ytimg.com/vi/S34VlNk0DlU/maxresdefault.jpg", "McLeran", "600LT", "1211 Santa Pina Dr", 380.0, "2020" },
                    { 10, "White", "https://scontent-sjc3-1.cdninstagram.com/v/t51.2885-15/e35/s320x320/73372155_438818337040669_2527940268926899847_n.jpg?_nc_ht=scontent-sjc3-1.cdninstagram.com&_nc_cat=101&oh=09643be31d19f79fe7b31c64f8e89204&oe=5E661A21&ig_cache_key=MjE4OTQ2NTAzODM1OTkyOTQ4MA%3D%3D.2", "Dodge", "RAM 3500", "1872 Mall Dr", 200.0, "2019" },
                    { 11, "Charcoal Grey", "https://i.ytimg.com/vi/Xq_g6ux2kYE/maxresdefault.jpg", "Ferrari", "FF", "6742 9th Ave", 240.0, "2013" },
                    { 12, "Red", "https://upload.wikimedia.org/wikipedia/commons/c/cb/F40_Ferrari_20090509.jpg", "Ferrari", "F40", "9007 Grandview Dr", 380.0, "1990" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_PaymentTypeId",
                table: "Rentals",
                column: "PaymentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LicenseNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "AspNetUsers");
        }
    }
}
