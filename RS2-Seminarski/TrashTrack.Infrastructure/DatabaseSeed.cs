using Microsoft.EntityFrameworkCore;

using TrashTrack.Core;

namespace TrashTrack.Infrastructure
{
    public partial class DatabaseContext
    {
        private readonly DateTime _dateTime = new(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Local);

        private void SeedData(ModelBuilder modelBuilder)
        {
            SeedCountries(modelBuilder);
            SeedCities(modelBuilder);
            SeedUsers(modelBuilder);
            SeedGarbage(modelBuilder);
            SeedVehicleModels(modelBuilder);
            SeedVehicles(modelBuilder);
            SeedSchedules(modelBuilder);
            SeedReports(modelBuilder);
            SeedProducts(modelBuilder);
            SeedOrders(modelBuilder);
            SeedServices(modelBuilder);
            SeedReservations(modelBuilder);
            SeedQuizzes(modelBuilder);
        }


        private void SeedCountries(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new()
                {
                    Id = 1,
                    Name = "Bosnia and Herzegovina",
                    Abbreviation = "BIH",
                    IsActive = true,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new()
                {
                    Id = 2,
                    Name = "Croatia",
                    Abbreviation = "HR",
                    IsActive = true,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new()
                {
                    Id = 3,
                    Name = "Serbia",
                    Abbreviation = "SRB",
                    IsActive = true,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new()
                {
                    Id = 4,
                    Name = "Montenegro",
                    Abbreviation = "CG",
                    IsActive = true,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new()
                {
                    Id = 5,
                    Name = "Slovenia",
                    Abbreviation = "SLO",
                    IsActive = true,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new()
                {
                    Id = 6,
                    Name = "Austria",
                    Abbreviation = "AT",
                    IsActive = true,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                });
        }

        private void SeedCities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new()
                {
                    Id = 1,
                    Name = "Mostar",
                    ZipCode = "88000",
                    CountryId = 1,
                    IsActive = true,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new()
                {
                    Id = 2,
                    Name = "Sarajevo",
                    ZipCode = "77000",
                    CountryId = 1,
                    IsActive = true,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new()
                {
                    Id = 3,
                    Name = "Zenica",
                    ZipCode = "72000",
                    CountryId = 1,
                    IsActive = true,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                });
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new()
                {
                    Id = 1,
                    FirstName = "Site",
                    LastName = "Admin",
                    Email = "site.admin@trashtrack.com",
                    Role = Role.Administrator,
                    Gender = Gender.Male,
                    PasswordHash = "b4I5yA4Mp+0Pg1C3EsKU17sS13eDExGtBjjI07Vh/JM=", //Plain text: test
                    PasswordSalt = "1wQEjdSFeZttx6dlvEDjOg==",
                    PhoneNumber = "38761123456",
                    IsVerified = true,
                    IsActive = true,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new()
                {
                    Id = 2,
                    FirstName = "Site",
                    LastName = "Driver",
                    Email = "site.driver@trashtrack.com",
                    Role = Role.Driver,
                    Gender = Gender.Male,
                    PasswordHash = "b4I5yA4Mp+0Pg1C3EsKU17sS13eDExGtBjjI07Vh/JM=", //Plain text: test
                    PasswordSalt = "1wQEjdSFeZttx6dlvEDjOg==",
                    PhoneNumber = "38761123456",
                    IsVerified = true,
                    IsActive = true,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new()
                {
                    Id = 3,
                    FirstName = "Site",
                    LastName = "User",
                    Email = "site.user@trashtrack.com",
                    Role = Role.User,
                    Gender = Gender.Male,
                    PasswordHash = "b4I5yA4Mp+0Pg1C3EsKU17sS13eDExGtBjjI07Vh/JM=", //Plain text: test
                    PasswordSalt = "1wQEjdSFeZttx6dlvEDjOg==",
                    PhoneNumber = "38761123456",
                    IsVerified = true,
                    IsActive = true,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                });
        }

        private void SeedGarbage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Garbage>().HasData(
                new Garbage
                {
                    Id = 1,
                    Address = "Location 1, Mostar, Bosnia and Herzegovina",
                    GarbageType = GarbageType.Plastic,
                    Latitude = 43.342273M, // Latitude for Location 1 in Mostar
                    Longitude = 17.808081M, // Longitude for Location 1 in Mostar
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Garbage
                {
                    Id = 2,
                    Address = "Location 2, Mostar, Bosnia and Herzegovina",
                    GarbageType = GarbageType.Organic,
                    Latitude = 43.343596M, // Latitude for Location 2 in Mostar
                    Longitude = 17.808183M, // Longitude for Location 2 in Mostar
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Garbage
                {
                    Id = 3,
                    Address = "Location 3, Mostar, Bosnia and Herzegovina",
                    GarbageType = GarbageType.Metal,
                    Latitude = 43.341981M, // Latitude for Location 3 in Mostar
                    Longitude = 17.805755M, // Longitude for Location 3 in Mostar
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Garbage
                {
                    Id = 4,
                    Address = "Location 4, Mostar, Bosnia and Herzegovina",
                    GarbageType = GarbageType.Metal,
                    Latitude = 43.340916M, // Latitude for Location 4 in Mostar
                    Longitude = 17.808719M, // Longitude for Location 4 in Mostar
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Garbage
                {
                    Id = 5,
                    Address = "Location 5, Mostar, Bosnia and Herzegovina",
                    GarbageType = GarbageType.Glass,
                    Latitude = 43.339490M, // Latitude for Location 5 in Mostar
                    Longitude = 17.809504M, // Longitude for Location 5 in Mostar
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                }
            );
        }

        private void SeedServices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id = 1,
                    Name = "Trash Collection",
                    Description = "Regular trash collection service",
                    Price = 20.00M, 
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Service
                {
                    Id = 2,
                    Name = "Recycling Pickup",
                    Description = "Service for recycling pickup",
                    Price = 15.50M, 
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Service
                {
                    Id = 3,
                    Name = "Green Waste Disposal",
                    Description = "Disposal service for green waste",
                    Price = 12.75M, 
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Service
                {
                    Id = 4,
                    Name = "Bulk Item Removal",
                    Description = "Removal service for bulky items",
                    Price = 30.00M, 
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Service
                {
                    Id = 5,
                    Name = "Hazardous Waste Pickup",
                    Description = "Specialized service for hazardous waste",
                    Price = 25.50M, 
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                }
            );
        }

        private void SeedReservations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    Id = 1,
                    UserId = 1, 
                    ServiceId = 1, 
                    Status = ReservationStatus.InProgress,
                    Latitude = 43.342273M, 
                    Longitude = 17.808081M, 
                    Price = 20.00M, 
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Reservation
                {
                    Id = 2,
                    UserId = 2,
                    ServiceId = 2, 
                    Status = ReservationStatus.Done,
                    Latitude = 43.343596M,
                    Longitude = 17.808183M,
                    Price = 15.50M,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Reservation
                {
                    Id = 3,
                    UserId = 3, 
                    ServiceId = 3, 
                    Status = ReservationStatus.InProgress,
                    Latitude = 43.341981M,
                    Longitude = 17.805755M,
                    Price = 12.75M,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Reservation
                {
                    Id = 4,
                    UserId = 3, 
                    ServiceId = 4, 
                    Status = ReservationStatus.Done,
                    Latitude = 43.340916M,
                    Longitude = 17.808719M,
                    Price = 30.00M,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Reservation
                {
                    Id = 5,
                    UserId = 2, 
                    ServiceId = 5, 
                    Status = ReservationStatus.InProgress,
                    Latitude = 43.339490M,
                    Longitude = 17.809504M,
                    Price = 25.50M,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                }
            );
        }


        private void SeedVehicleModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleModel>().HasData(
                new VehicleModel()
                {
                    Id = 1,
                    Name = "Truck 1",
                    VehicleType = VehicleType.Truck,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new VehicleModel()
                {
                    Id = 2,
                    Name = "Truck 2",
                    VehicleType = VehicleType.Truck,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new VehicleModel()
                {
                    Id = 3,
                    Name = "Truck 3",
                    VehicleType = VehicleType.Truck,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new VehicleModel()
                {
                    Id = 4,
                    Name = "Garbage Truck 1",
                    VehicleType = VehicleType.GarbageTruck,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new VehicleModel()
                {
                    Id = 5,
                    Name = "Garbage Truck 2",
                    VehicleType = VehicleType.GarbageTruck,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new VehicleModel()
                {
                    Id = 6,
                    Name = "Garbage Truck 3",
                    VehicleType = VehicleType.GarbageTruck,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                }
            );
        }

        private void SeedVehicles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle()
                {
                    Id = 1,
                    Color = "Red",
                    Notes = "First vehicle",
                    LicensePlateNumber = "ABC123",
                    ManufactureYear = 2020,
                    Capacity = 5000,
                    VehicleModelId = 1, 
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Vehicle()
                {
                    Id = 2,
                    Color = "Blue",
                    Notes = "Second vehicle",
                    LicensePlateNumber = "XYZ789",
                    ManufactureYear = 2018,
                    Capacity = 6000,
                    VehicleModelId = 2, 
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Vehicle()
                {
                    Id = 3,
                    Color = "Green",
                    Notes = "Third vehicle",
                    LicensePlateNumber = "DEF456",
                    ManufactureYear = 2022,
                    Capacity = 7000,
                    VehicleModelId = 4, 
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Vehicle()
                {
                    Id = 4,
                    Color = "Yellow",
                    Notes = "Fourth vehicle",
                    LicensePlateNumber = "GHI789",
                    ManufactureYear = 2019,
                    Capacity = 5500,
                    VehicleModelId = 1,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Vehicle()
                {
                    Id = 5,
                    Color = "Black",
                    Notes = "Fifth vehicle",
                    LicensePlateNumber = "JKL012",
                    ManufactureYear = 2021,
                    Capacity = 6500,
                    VehicleModelId = 3, 
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                }
            );
        }

        private void SeedProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Large Trash Bin",
                    Description = "Spacious bin for large volumes of trash",
                    Code = "TB100",
                    Photo = "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", 
                    Price = 30.00M,
                    Type = ProductType.TrashBin,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Product
                {
                    Id = 2,
                    Name = "Eco-Friendly Trash Bag",
                    Description = "Biodegradable trash bag for eco-conscious disposal",
                    Code = "TB200",
                    Photo = "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", 
                    Price = 5.50M,
                    Type = ProductType.TrashBag,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Product
                {
                    Id = 3,
                    Name = "Safety Gloves",
                    Description = "Protective gloves for waste handling",
                    Code = "PG100",
                    Photo = "/9j/4QAYRXhpZgAASUkqAAgAAAAAAAAAAAAAAP/sABFEdWNreQABAAQAAAA3AAD/4QMpaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLwA8P3hwYWNrZXQgYmVnaW49Iu+7vyIgaWQ9Ilc1TTBNcENlaGlIenJlU3pOVGN6a2M5ZCI/PiA8eDp4bXBtZXRhIHhtbG5zOng9ImFkb2JlOm5zOm1ldGEvIiB4OnhtcHRrPSJBZG9iZSBYTVAgQ29yZSA1LjYtYzExMSA3OS4xNTgzMjUsIDIwMTUvMDkvMTAtMDE6MTA6MjAgICAgICAgICI+IDxyZGY6UkRGIHhtbG5zOnJkZj0iaHR0cDovL3d3dy53My5vcmcvMTk5OS8wMi8yMi1yZGYtc3ludGF4LW5zIyI+IDxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSIiIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdFJlZj0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlUmVmIyIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOjJBRkQzMThDQTYyNjExRTZBODU1QjdCM0U5NUU4RTRGIiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOjJBRkQzMThCQTYyNjExRTZBODU1QjdCM0U5NUU4RTRGIiB4bXA6Q3JlYXRvclRvb2w9IkFkb2JlIFBob3Rvc2hvcCBDUzYgV2luZG93cyI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOjhCMTE4RDdDRkE1NDExRTQ4OTY3RjExQTAwM0ZCQTQ5IiBzdFJlZjpkb2N1bWVudElEPSJ4bXAuZGlkOjhCMTE4RDdERkE1NDExRTQ4OTY3RjExQTAwM0ZCQTQ5Ii8+IDwvcmRmOkRlc2NyaXB0aW9uPiA8L3JkZjpSREY+IDwveDp4bXBtZXRhPiA8P3hwYWNrZXQgZW5kPSJyIj8+/+4ADkFkb2JlAGTAAAAAAf/bAIQABwUFBQUFBwUFBwoHBgcKDAkHBwkM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", 
                    Price = 10.00M,
                    Type = ProductType.ProtectiveGear,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                }
            );
        }

        private void SeedOrders(ModelBuilder modelBuilder)
        {
            // Seed OrderDetails first
            modelBuilder.Entity<OrderDetails>().HasData(
                new OrderDetails
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 1,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new OrderDetails
                {
                    Id = 2,
                    OrderId = 1,
                    ProductId = 2,
                    Quantity = 2,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new OrderDetails
                {
                    Id = 3,
                    OrderId = 2,
                    ProductId = 3,
                    Quantity = 1,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new OrderDetails
                {
                    Id = 4,
                    OrderId = 3,
                    ProductId = 1,
                    Quantity = 1,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new OrderDetails
                {
                    Id = 5,
                    OrderId = 3,
                    ProductId = 2,
                    Quantity = 1,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new OrderDetails
                {
                    Id = 6,
                    OrderId = 4,
                    ProductId = 3,
                    Quantity = 1,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new OrderDetails
                {
                    Id = 7,
                    OrderId = 5,
                    ProductId = 1,
                    Quantity = 2,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new OrderDetails
                {
                    Id = 8,
                    OrderId = 5,
                    ProductId = 2,
                    Quantity = 1,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                }
            );

            // Then seed Orders
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    OrderNumber = "ORD1001",
                    OrderDate = DateTime.Now,
                    Total = 65.50M,
                    isCanceled = false,
                    UserId = 1,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Order
                {
                    Id = 2,
                    OrderNumber = "ORD1002",
                    OrderDate = DateTime.Now.AddDays(-2),
                    Total = 15.00M,
                    isCanceled = false,
                    UserId = 2,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Order
                {
                    Id = 3,
                    OrderNumber = "ORD1003",
                    OrderDate = DateTime.Now.AddDays(-5),
                    Total = 40.25M,
                    isCanceled = false,
                    UserId = 3,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Order
                {
                    Id = 4,
                    OrderNumber = "ORD1004",
                    OrderDate = DateTime.Now.AddDays(-7),
                    Total = 20.50M,
                    isCanceled = false,
                    UserId = 1,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Order
                {
                    Id = 5,
                    OrderNumber = "ORD1005",
                    OrderDate = DateTime.Now.AddDays(-10),
                    Total = 35.75M,
                    isCanceled = false,
                    UserId = 2,
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                }
            );
        }


        private void SeedReports(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>().HasData(
                new Report
                {
                    Id = 1,
                    Note = "Trash overflow near park",
                    ReportState = ReportState.WaitingForReview,
                    ReportType = ReportType.TrashOverflow,
                    ReporterUserId = 1, // Replace with an existing User Id
                    Photo = "trash_overflow.jpg", // Placeholder for the photo file name
                    GarbageId = 1, // Replace with an existing Garbage Id
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Report
                {
                    Id = 2,
                    Note = "Littering on the street",
                    ReportState = ReportState.WaitingForReview,
                    ReportType = ReportType.Littering,
                    ReporterUserId = 2, // Replace with an existing User Id
                    Photo = "littering_street.jpg", // Placeholder for the photo file name
                    GarbageId = 2, // Replace with an existing Garbage Id
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Report
                {
                    Id = 3,
                    Note = "Damaged garbage bin in the neighborhood",
                    ReportState = ReportState.WaitingForReview,
                    ReportType = ReportType.GarbageBinDamage,
                    ReporterUserId = 3, // Replace with an existing User Id
                    Photo = "damaged_bin.jpg", // Placeholder for the photo file name
                    GarbageId = 3, // Replace with an existing Garbage Id
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Report
                {
                    Id = 4,
                    Note = "Graffiti vandalism on public property",
                    ReportState = ReportState.Reviewed,
                    ReportType = ReportType.GraffitiVandalism,
                    ReporterUserId = 1, // Replace with an existing User Id
                    Photo = "graffiti_vandalism.jpg", // Placeholder for the photo file name
                    GarbageId = 4, // Replace with an existing Garbage Id
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Report
                {
                    Id = 5,
                    Note = "Overflowing trash near shopping center",
                    ReportState = ReportState.WaitingForReview,
                    ReportType = ReportType.TrashOverflow,
                    ReporterUserId = 2, // Replace with an existing User Id
                    Photo = "overflow_shopping_center.jpg", // Placeholder for the photo file name
                    GarbageId = 5, // Replace with an existing Garbage Id
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                }
            );
        }

        private void SeedSchedules(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule
                {
                    Id = 4,
                    PickupDate = DateTime.Now.AddDays(4),
                    Status = PickupStatus.Pending,
                    VehicleId = 1, // Replace with an existing Vehicle Id
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new Schedule
                {
                    Id = 5,
                    PickupDate = DateTime.Now.AddDays(5),
                    Status = PickupStatus.Pending,
                    VehicleId = 2, // Replace with an existing Vehicle Id
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                }
            );

            modelBuilder.Entity<ScheduleDriver>().HasData(
                new ScheduleDriver
                {
                    Id = 6,
                    DriverId = 3, // Replace with an existing User Id
                    ScheduleId = 4, // Foreign key reference
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new ScheduleDriver
                {
                    Id = 9,
                    DriverId = 2, // Replace with an existing User Id
                    ScheduleId = 5, // Foreign key reference
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                }
            // Add more ScheduleDrivers as needed
            );

            modelBuilder.Entity<ScheduleGarbage>().HasData(
                new ScheduleGarbage
                {
                    Id = 7,
                    GarbageId = 1, // Replace with an existing Garbage Id
                    ScheduleId = 4, // Foreign key reference
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new ScheduleGarbage
                {
                    Id = 8,
                    GarbageId = 2, // Replace with an existing Garbage Id
                    ScheduleId = 4, // Foreign key reference
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new ScheduleGarbage
                {
                    Id = 10,
                    GarbageId = 3, // Replace with an existing Garbage Id
                    ScheduleId = 5, // Foreign key reference
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                },
                new ScheduleGarbage
                {
                    Id = 11,
                    GarbageId = 4, // Replace with an existing Garbage Id
                    ScheduleId = 5, // Foreign key reference
                    CreatedAt = _dateTime,
                    ModifiedAt = null
                }
            // Add more ScheduleGarbages as needed
            );
        }


        private void SeedQuizzes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz
                {
                    Id = 1,
                    Title = "Recycling Basics",
                    Description = "Test your knowledge about recycling",
                    CreatedAt = _dateTime,
                    ModifiedAt = null,
                });

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    Content = "What is the first step in the recycling process?",
                    Points = 10,
                    QuizId = 1, // Foreign key referencing Quiz with Id 1
                    CreatedAt = _dateTime,
                    ModifiedAt = null,
                });

            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    Id = 1,
                    Content = "Collection",
                    IsTrue = true,
                    QuestionId = 1, // Foreign key referencing Question with Id 1
                    CreatedAt = _dateTime,
                    ModifiedAt = null,
                },
                new Answer
                {
                    Id = 2,
                    Content = "Sorting",
                    IsTrue = false,
                    QuestionId = 1, // Foreign key referencing Question with Id 1
                    CreatedAt = _dateTime,
                    ModifiedAt = null,
                },
                new Answer
                {
                    Id = 3,
                    Content = "Processing",
                    IsTrue = false,
                    QuestionId = 1, // Foreign key referencing Question with Id 1
                    CreatedAt = _dateTime,
                    ModifiedAt = null,
                });

            // Repeat the same pattern for other quizzes, questions, and answers

            // Example for the second quiz
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz
                {
                    Id = 2,
                    Title = "Reducing Waste",
                    Description = "Learn about ways to reduce waste in your daily life",
                    CreatedAt = _dateTime,
                    ModifiedAt = null,
                });

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 2,
                    Content = "What is a common practice to reduce plastic waste?",
                    Points = 10,
                    QuizId = 2, // Foreign key referencing Quiz with Id 2
                    CreatedAt = _dateTime,
                    ModifiedAt = null,
                });

            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    Id = 4,
                    Content = "Single-use plastic bags",
                    IsTrue = false,
                    QuestionId = 2, // Foreign key referencing Question with Id 2
                    CreatedAt = _dateTime,
                    ModifiedAt = null,
                },
                new Answer
                {
                    Id = 5,
                    Content = "Plastic straws",
                    IsTrue = false,
                    QuestionId = 2, // Foreign key referencing Question with Id 2
                    CreatedAt = _dateTime,
                    ModifiedAt = null,
                },
                new Answer
                {
                    Id = 6,
                    Content = "Using reusable bags",
                    IsTrue = true,
                    QuestionId = 2, // Foreign key referencing Question with Id 2
                    CreatedAt = _dateTime,
                    ModifiedAt = null,
                });

            // Repeat this pattern for other quizzes, questions, and answers

            // Example for the fifth quiz
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz
                {
                    Id = 5,
                    Title = "Energy Conservation",
                    Description = "Test your knowledge about energy conservation",
                    CreatedAt = _dateTime,
                    ModifiedAt = null,
                });

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 6,
                    Content = "Which of the following is a renewable energy source?",
                    Points = 12,
                    QuizId = 5, // Foreign key referencing Quiz with Id 5
                    CreatedAt = _dateTime,
                    ModifiedAt = null,
                });

            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    Id = 16,
                    Content = "Coal",
                    IsTrue = false,
                    QuestionId = 6, // Foreign key referencing Question with Id 6
                    CreatedAt = _dateTime,
                    ModifiedAt = null,
                },
                new Answer
                {
                    Id = 17,
                    Content = "Solar",
                    IsTrue = true,
                    QuestionId = 6, // Foreign key referencing Question with Id 6
                    CreatedAt = _dateTime,
                    ModifiedAt = null,
                },
                new Answer
                {
                    Id = 18,
                    Content = "Natural Gas",
                    IsTrue = false,
                    QuestionId = 6, // Foreign key referencing Question with Id 6
                    CreatedAt = _dateTime,
                    ModifiedAt = null,
                });

            // Repeat this pattern for other quizzes, questions, and answers
        }

    }
}
