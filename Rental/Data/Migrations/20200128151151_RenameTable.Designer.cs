﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rental.Data;

namespace Rental.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200128151151_RenameTable")]
    partial class RenameTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Rental.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "00000000-ffff-ffff-ffff-ffffffffffff",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a478e6e0-523c-454d-9664-bc33b59d2a00",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            FirstName = "admin",
                            LastName = "admin",
                            LicenseNumber = "A67033",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGkZVcE8rS/cgncwXHFIvObivJByo3bSKcSLUYdrEeljfq3itsWCEI10PP+utEhNaQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "68924479-ce3c-4751-80c6-ff0320f1c228",
                            StreetAddress = "123 Infinity Way",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        });
                });

            modelBuilder.Entity("Rental.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentType");
                });

            modelBuilder.Entity("Rental.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PickupLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PricePerHour")
                        .HasColumnType("float");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "White",
                            ImageURL = "https://i.pinimg.com/originals/2a/54/ef/2a54ef2823c42adab1e53ed7c24c1687.jpg",
                            Make = "Ferrari",
                            Model = "F430",
                            PickupLocation = "3417 Main Street Garage",
                            PricePerHour = 220.0,
                            Year = "2005"
                        },
                        new
                        {
                            Id = 2,
                            Color = "White",
                            ImageURL = "https://i.ytimg.com/vi/tNLGqxOQlcs/maxresdefault.jpg",
                            Make = "Porsche",
                            Model = "911 GT3 RS",
                            PickupLocation = "33 St Laurent Blvd",
                            PricePerHour = 280.0,
                            Year = "2010"
                        },
                        new
                        {
                            Id = 3,
                            Color = "Silver",
                            ImageURL = "https://img.topcheapcar.com/ZHWGU6AU1ALA09291.jpg",
                            Make = "Lamborghini",
                            Model = "Gallardo",
                            PickupLocation = "1482 Daschund St",
                            PricePerHour = 280.0,
                            Year = "2010"
                        },
                        new
                        {
                            Id = 4,
                            Color = "Black",
                            ImageURL = "https://www.bentleygoldcoast.com/galleria_images/6116/6116_p1_l.jpg",
                            Make = "Mercedes",
                            Model = "G 63 AMG",
                            PickupLocation = "1616 Rodeo Dr",
                            PricePerHour = 260.0,
                            Year = "2013"
                        },
                        new
                        {
                            Id = 5,
                            Color = "White",
                            ImageURL = "https://i.ytimg.com/vi/Or1ra9aJvcs/maxresdefault.jpg",
                            Make = "Ford",
                            Model = "F150 Raptor SVT",
                            PickupLocation = "371 Walter's Hwy",
                            PricePerHour = 180.0,
                            Year = "2019"
                        },
                        new
                        {
                            Id = 6,
                            Color = "Chalk Grey",
                            ImageURL = "https://media.caradvice.com.au/image/private/s--OTK9ZOcV--/v1550383192/4bcfda9e61c9bb6b89451c88dd7256a5.jpg",
                            Make = "BMW",
                            Model = "M3 335i",
                            PickupLocation = "3480 Marcel Blvd",
                            PricePerHour = 150.0,
                            Year = "2019"
                        },
                        new
                        {
                            Id = 7,
                            Color = "White",
                            ImageURL = "https://icdn2.digitaltrends.com/image/digitaltrends/2015-lamborghini-huracan-36-382x238-c.jpg",
                            Make = "Lamborghini",
                            Model = "Huracan",
                            PickupLocation = "993 San Juan Blvd",
                            PricePerHour = 280.0,
                            Year = "2015"
                        },
                        new
                        {
                            Id = 8,
                            Color = "Brown",
                            ImageURL = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/2020-mclaren-720s-mmp-1-1570642764.jpg?crop=0.577xw:0.789xh;0.337xw,0.158xh&resize=640:*",
                            Make = "McLeran",
                            Model = "720S",
                            PickupLocation = "1478 Bender Blvd",
                            PricePerHour = 340.0,
                            Year = "2020"
                        },
                        new
                        {
                            Id = 9,
                            Color = "Purple",
                            ImageURL = "https://i.ytimg.com/vi/S34VlNk0DlU/maxresdefault.jpg",
                            Make = "McLeran",
                            Model = "600LT",
                            PickupLocation = "1211 Santa Pina Dr",
                            PricePerHour = 380.0,
                            Year = "2020"
                        },
                        new
                        {
                            Id = 10,
                            Color = "White",
                            ImageURL = "https://scontent-sjc3-1.cdninstagram.com/v/t51.2885-15/e35/s320x320/73372155_438818337040669_2527940268926899847_n.jpg?_nc_ht=scontent-sjc3-1.cdninstagram.com&_nc_cat=101&oh=09643be31d19f79fe7b31c64f8e89204&oe=5E661A21&ig_cache_key=MjE4OTQ2NTAzODM1OTkyOTQ4MA%3D%3D.2",
                            Make = "Dodge",
                            Model = "RAM 3500",
                            PickupLocation = "1872 Mall Dr",
                            PricePerHour = 200.0,
                            Year = "2019"
                        },
                        new
                        {
                            Id = 11,
                            Color = "Charcoal Grey",
                            ImageURL = "https://i.ytimg.com/vi/Xq_g6ux2kYE/maxresdefault.jpg",
                            Make = "Ferrari",
                            Model = "FF",
                            PickupLocation = "6742 9th Ave",
                            PricePerHour = 240.0,
                            Year = "2013"
                        },
                        new
                        {
                            Id = 12,
                            Color = "Red",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/c/cb/F40_Ferrari_20090509.jpg",
                            Make = "Ferrari",
                            Model = "F40",
                            PickupLocation = "9007 Grandview Dr",
                            PricePerHour = 380.0,
                            Year = "1990"
                        });
                });

            modelBuilder.Entity("Rental.Models.VehicleRental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("VehicleRentals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            EndTime = new DateTime(2020, 1, 22, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2020, 1, 22, 16, 13, 37, 0, DateTimeKind.Unspecified),
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 2,
                            ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            EndTime = new DateTime(2020, 1, 23, 18, 13, 12, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2020, 1, 23, 12, 16, 33, 0, DateTimeKind.Unspecified),
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 3,
                            ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            EndTime = new DateTime(2020, 1, 24, 20, 10, 17, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2020, 1, 24, 13, 12, 11, 0, DateTimeKind.Unspecified),
                            VehicleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Rental.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Rental.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rental.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Rental.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Rental.Models.VehicleRental", b =>
                {
                    b.HasOne("Rental.Models.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
