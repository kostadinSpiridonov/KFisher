using KFisher.Data;
using KFisher.Entities;

namespace KFisher.Services
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService(IApplicationDbContext context)
            : base(context)
        {

        }
    }
}
