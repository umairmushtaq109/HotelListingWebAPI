﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Models.Configurations.Entities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
        }
    }
}
