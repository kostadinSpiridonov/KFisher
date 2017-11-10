using AutoMapper;
using KFisher.Entities;
using KFisher.Library.DTOs;
using KFisher.WebApi.Models.InputModels;
using KFisher.WebApi.Models.OutputModels;

namespace KFisher.Library.Mappings
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationDto>();
            CreateMap<LocationDto, Location>();
            CreateMap<AddLocationModel, LocationDto>();
            CreateMap<LocationDto, LocationModel>();
        }
    }
}
