using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Models.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
