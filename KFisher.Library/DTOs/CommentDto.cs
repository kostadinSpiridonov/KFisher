using System;

namespace KFisher.Library.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public Guid UserId { get; set; }

        public UserDto User { get; set; }
    }
}
