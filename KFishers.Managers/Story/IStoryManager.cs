using KFisher.Library.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KFishers.Managers
{
    public interface IStoryManager
    {
        Task<StoryDto> Add(StoryDto model);

        Task<IEnumerable<StoryDto>> GetAll(PaginationRequestDto request);

    }
}
