using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rental.Models;
using System;

namespace Rental.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        //setting types of data to populate the database

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Models.VehicleRental> VehicleRentals { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        //model creating method to build tables in the database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create a new user for Identity Framework
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                StreetAddress = "123 Infinity Way",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                LicenseNumber = "A67033",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            //creating a new rental seed for the database
            modelBuilder.Entity<Models.VehicleRental>().HasData(
                new Models.VehicleRental()
                {
                    Id = 1,
                    StartTime = new DateTime(2020, 01, 22, 16, 13, 37),
                    EndTime = new DateTime(2020, 01, 22, 19, 00, 00),
                    PaymentTypeId = null,
                    ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    VehicleId = 1,
                },
                new Models.VehicleRental()
                {
                    Id = 2,
                    StartTime = new DateTime(2020, 01, 23, 12, 16, 33),
                    EndTime = new DateTime(2020, 01, 23, 18, 13, 12),
                    PaymentTypeId = null,
                    ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    VehicleId = 2,
                },
                new Models.VehicleRental()
                {
                    Id = 3,
                    StartTime = new DateTime(2020, 01, 24, 13, 12, 11),
                    EndTime = new DateTime(2020, 01, 24, 20, 10, 17),
                    PaymentTypeId = null,
                    ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    VehicleId = 3,
                }
                );
            // creating the vehicles in the database to be seeded
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle()
                {
                    Id = 1,
                    PickupLocation = "3417 Main Street Garage",
                    PricePerHour = 220.00,
                    Make = "Ferrari",
                    Model = "F430",
                    Year = "2005",
                    Color = "White",
                    ImageURL = "https://i.pinimg.com/originals/2a/54/ef/2a54ef2823c42adab1e53ed7c24c1687.jpg"

                },
                new Vehicle()
                {
                    Id = 2,
                    PickupLocation = "33 St Laurent Blvd",
                    PricePerHour = 280.00,
                    Make = "Porsche",
                    Model = "911 GT3 RS",
                    Year = "2010",
                    Color = "White",
                    ImageURL = "https://i.ytimg.com/vi/tNLGqxOQlcs/maxresdefault.jpg"
                },
                new Vehicle()
                {
                    Id = 3,
                    PickupLocation = "1482 Daschund St",
                    PricePerHour = 280.00,
                    Make = "Lamborghini",
                    Model = "Gallardo",
                    Year = "2010",
                    Color = "Silver",
                    ImageURL = "https://img.topcheapcar.com/ZHWGU6AU1ALA09291.jpg"
                },
                new Vehicle()
                {
                    Id = 4,
                    PickupLocation = "1616 Rodeo Dr",
                    PricePerHour = 260.00,
                    Make = "Mercedes",
                    Model = "G 63 AMG",
                    Year = "2013",
                    Color = "Black",
                    ImageURL = "https://www.bentleygoldcoast.com/galleria_images/6116/6116_p1_l.jpg"
                },
                new Vehicle()
                {
                    Id = 5,
                    PickupLocation = "371 Walter's Hwy",
                    PricePerHour = 180.00,
                    Make = "Ford",
                    Model = "F150 Raptor SVT",
                    Year = "2019",
                    Color = "White",
                    ImageURL = "https://i.ytimg.com/vi/Or1ra9aJvcs/maxresdefault.jpg"
                },
                new Vehicle()
                {
                    Id = 6,
                    PickupLocation = "3480 Marcel Blvd",
                    PricePerHour = 150.00,
                    Make = "BMW",
                    Model = "M3 335i",
                    Year = "2019",
                    Color = "Chalk Grey",
                    ImageURL = "https://media.caradvice.com.au/image/private/s--OTK9ZOcV--/v1550383192/4bcfda9e61c9bb6b89451c88dd7256a5.jpg"
                },
                new Vehicle()
                {
                    Id = 7,
                    PickupLocation = "993 San Juan Blvd",
                    PricePerHour = 280.00,
                    Make = "Lamborghini",
                    Model = "Huracan",
                    Year = "2015",
                    Color = "White",
                    ImageURL = "https://icdn2.digitaltrends.com/image/digitaltrends/2015-lamborghini-huracan-36-382x238-c.jpg"
                },
                new Vehicle()
                {
                    Id = 8,
                    PickupLocation = "1478 Bender Blvd",
                    PricePerHour = 340.00,
                    Make = "McLeran",
                    Model = "720S",
                    Year = "2020",
                    Color = "Brown",
                    ImageURL = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/2020-mclaren-720s-mmp-1-1570642764.jpg?crop=0.577xw:0.789xh;0.337xw,0.158xh&resize=640:*"
                },
                new Vehicle()
                {
                    Id = 9,
                    PickupLocation = "1211 Santa Pina Dr",
                    PricePerHour = 380.00,
                    Make = "McLeran",
                    Model = "600LT",
                    Year = "2020",
                    Color = "Purple",
                    ImageURL = "https://i.ytimg.com/vi/S34VlNk0DlU/maxresdefault.jpg"
                },
                new Vehicle()
                {
                    Id = 10,
                    PickupLocation = "1872 Mall Dr",
                    PricePerHour = 200.00,
                    Make = "Dodge",
                    Model = "RAM 3500",
                    Year = "2019",
                    Color = "White",
                    ImageURL = "https://scontent-sjc3-1.cdninstagram.com/v/t51.2885-15/e35/s320x320/73372155_438818337040669_2527940268926899847_n.jpg?_nc_ht=scontent-sjc3-1.cdninstagram.com&_nc_cat=101&oh=09643be31d19f79fe7b31c64f8e89204&oe=5E661A21&ig_cache_key=MjE4OTQ2NTAzODM1OTkyOTQ4MA%3D%3D.2"
                },
                new Vehicle()
                {
                    Id = 11,
                    PickupLocation = "6742 9th Ave",
                    PricePerHour = 240.00,
                    Make = "Ferrari",
                    Model = "FF",
                    Year = "2013",
                    Color = "Charcoal Grey",
                    ImageURL = "https://i.ytimg.com/vi/Xq_g6ux2kYE/maxresdefault.jpg"
                },
                new Vehicle()
                {
                    Id = 12,
                    PickupLocation = "9007 Grandview Dr",
                    PricePerHour = 380.00,
                    Make = "Ferrari",
                    Model = "F40",
                    Year = "1990",
                    Color = "Red",
                    ImageURL = "https://upload.wikimedia.org/wikipedia/commons/c/cb/F40_Ferrari_20090509.jpg"
                }
                );
            base.OnModelCreating(modelBuilder);
        }
        //model creating method to build tables in the database

        public DbSet<Rental.Models.PaymentType> PaymentType { get; set; }
        }
}
