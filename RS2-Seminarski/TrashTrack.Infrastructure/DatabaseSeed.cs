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
                new User
                {
                    Id = 1,
                    FirstName = "Site",
                    LastName = "Admin",
                    Email = "site.admin@TrashTrack.com",
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
                new User
                {
                    Id = 2,
                    FirstName = "Hamza",
                    LastName = "Taslidza",
                    Email = "hamza.admin@TrashTrack.com",
                    Role = Role.Administrator,
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

        //private void SeedGarbage(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Garbage>().HasData(
        //        new Garbage
        //        {
        //            Id = 1,
        //            Address = "dwudid",
        //            GarbageType = GarbageType.Plastic,
        //            Latitude = 10,
        //            Longitude = 10,
        //            CreatedAt = _dateTime,
        //            ModifiedAt = null
        //        });
        //}


        //private void SeedVehicleModels(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<VehicleModel>().HasData(
        //        new()
        //        {
        //            Id = 1,
        //            Name = "Golf MK 8",
        //            VehicleType = VehicleType.Hatchback,
        //            VehicleBrandId = 1,
        //            CreatedAt = _dateTime,
        //            ModifiedAt = null
        //        },
        //        new()
        //        {
        //            Id = 2,
        //            Name = "Jetta",
        //            VehicleType = VehicleType.Hatchback,
        //            VehicleBrandId = 1,
        //            CreatedAt = _dateTime,
        //            ModifiedAt = null
        //        },
        //        new()
        //        {
        //            Id = 3,
        //            Name = "Arteon",
        //            VehicleType = VehicleType.Hatchback,
        //            VehicleBrandId = 1,
        //            CreatedAt = _dateTime,
        //            ModifiedAt = null
        //        },
        //        new()
        //        {
        //            Id = 4,
        //            Name = "A3",
        //            VehicleType = VehicleType.Hatchback,
        //            VehicleBrandId = 2,
        //            CreatedAt = _dateTime,
        //            ModifiedAt = null
        //        },
        //        new()
        //        {
        //            Id = 5,
        //            Name = "A4",
        //            VehicleType = VehicleType.Hatchback,
        //            VehicleBrandId = 2,
        //            CreatedAt = _dateTime,
        //            ModifiedAt = null
        //        },
        //        new()
        //        {
        //            Id = 6,
        //            Name = "A5",
        //            VehicleType = VehicleType.Hatchback,
        //            VehicleBrandId = 2,
        //            CreatedAt = _dateTime,
        //            ModifiedAt = null
        //        },
        //        new()
        //        {
        //            Id = 7,
        //            Name = "GLA 250 SUV",
        //            VehicleType = VehicleType.SUV,
        //            VehicleBrandId = 3,
        //            CreatedAt = _dateTime,
        //            ModifiedAt = null
        //        },
        //        new()
        //        {
        //            Id = 8,
        //            Name = "CLA Coupe",
        //            VehicleType = VehicleType.Hatchback,
        //            VehicleBrandId = 3,
        //            CreatedAt = _dateTime,
        //            ModifiedAt = null
        //        });
        //}
    }
}
