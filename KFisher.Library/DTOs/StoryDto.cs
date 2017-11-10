using System;
using System.Collections.Generic;

namespace KFisher.Library.DTOs
{
    public class StoryDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public UserDto User { get; set; }

        public Guid LocationId { get; set; }

        public LocationDto Location { get; set; }

        public string Description { get; set; }

        public IEnumerable<CommentDto> Comments { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
