using AutoMapper;
using HiddenVilla.Domain;
using HiddenVilla.Persistence.Models;

namespace HiddenVilla.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HotelRoomDto, HotelRoom>();
            CreateMap<HotelRoom, HotelRoomDto>();
        }
    }
}