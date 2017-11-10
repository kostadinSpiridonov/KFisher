using System;

namespace KFisher.WebApi.Models.OutputModels
{
    public class BaseStoryModel
    {
        public Guid Id { get; set; }

        public BaseUserModel User { get; set; }

        public Guid LocationId { get; set; }

        public LocationModel Location { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
