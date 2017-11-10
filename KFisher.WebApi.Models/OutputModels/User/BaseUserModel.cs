using System;

namespace KFisher.WebApi.Models.OutputModels
{
    public class BaseUserModel
    {
        public Guid Id { get; set; }

        public string   FullName{ get; set; }

        public Guid Email { get; set; }
    }
}
