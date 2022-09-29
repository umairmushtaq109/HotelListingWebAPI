using AutoMapper;
using HotelListing.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Models.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Hotel, HotelDTO>();
            CreateMap<Hotel, CreateHotelDTO>();
            CreateMap<Country, CountryDTO>();
            CreateMap<Country, CreateCountryDTO>();
        }
    }
}
