using System;
using AutoMapper;
using System.Linq;
using System.Text;
using HotelListing.Core.DTO;
using System.Threading.Tasks;
using HotelListing.Domain.Models;
using System.Collections.Generic;

namespace HotelListing.Core.Configuration
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
        }
    }
}
