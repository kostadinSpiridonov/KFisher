using KFisher.Data;
using KFisher.Entities;

namespace KFisher.Services
{
    public class StoryService : BaseService<Story>, IStoryService
    {
        public StoryService(IApplicationDbContext context)
            : base(context)
        {

        }
    }
}
