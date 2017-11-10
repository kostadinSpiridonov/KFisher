using System.Threading.Tasks;
using KFisher.Library.DTOs;
using KFisher.Services;
using KFisher.Entities;
using System;
using AutoMapper;
using System.Collections.Generic;

namespace KFishers.Managers
{
    public class StoryManager : IStoryManager
    {
        private readonly IStoryService storyService;

        public StoryManager(IStoryService storyService)
        {
            this.storyService = storyService;
        }

        public Task<StoryDto> Add(StoryDto model)
        {
            var story = new Story
            {
                CreateDate = DateTime.UtcNow,
                Description = model?.Description,
                Location = Mapper.Map<Location>(model?.Location)
            };

            return this.storyService
                .Add(story)
                .ContinueWith(x => Mapper.Map<StoryDto>(x.Result));
        }

        public Task<IEnumerable<StoryDto>> GetAll(PaginationRequestDto request)
        {
            if (request == null)
            {
                return null;
            }

            return this.storyService
                .GetAll(request.Page, request.PageSize)
                .ContinueWith(x => Mapper.Map<IEnumerable<StoryDto>>(x.Result));
        }
    }
}
