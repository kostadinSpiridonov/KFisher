using AutoMapper;
using KFisher.Library.DTOs;
using KFisher.WebApi.Models.InputModels;

namespace KFisher.Library.Mappings
{
    public class PaginationProfile : Profile
    {
        public PaginationProfile()
        {
            CreateMap<PaginationRequestModel, PaginationRequestDto>();
        }
    }
}
