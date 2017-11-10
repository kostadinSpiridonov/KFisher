using AutoMapper;
using KFisher.Entities;
using KFisher.Library.DTOs;
using KFisher.WebApi.Models.InputModels;
using KFisher.WebApi.Models.OutputModels;

namespace KFisher.Library.Mappings
{
    public class StoryProfile : Profile
    {
        public StoryProfile()
        {
            CreateMap<Story, StoryDto>();
            CreateMap<AddStoryModel, StoryDto>();
            CreateMap<StoryDto, Story>();
            CreateMap<StoryDto, BaseStoryModel>();
        }
    }
}
