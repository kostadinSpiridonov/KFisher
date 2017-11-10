using AutoMapper;
using KFisher.Entities;
using KFisher.Library.DTOs;

namespace KFisher.Library.Mappings
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>();
        }
    }
}
