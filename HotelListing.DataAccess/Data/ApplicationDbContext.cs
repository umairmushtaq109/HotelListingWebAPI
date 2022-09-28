using HotelListing.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options){ }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "United States of America",
                    ShortName = "USA"
                },
                new Country
                {
                    Id = 2,
                    Name = "Pakistan",
                    ShortName = "PAK"
                },
                new Country
                {
                    Id = 3,
                    Name = "India",
                    ShortName = "IND"
                }
            );

            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Lords Hotel",
                    Address = "New York",
                    Rating = 4.5,
                    CountryId = 1
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Pearl Continental Hotel",
                    Address = "Islamabad",
                    Rating = 4.8,
                    CountryId = 2
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Taj Hotel",
                    Address = "Mumbai",
                    Rating = 4.2,
                    CountryId = 3 
                }
            );
        }

    }
}
