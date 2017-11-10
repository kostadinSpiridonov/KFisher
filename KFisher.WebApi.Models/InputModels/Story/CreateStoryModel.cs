using System.ComponentModel.DataAnnotations;

namespace KFisher.WebApi.Models.InputModels
{
    public class AddStoryModel
    {
        public AddLocationModel Location { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
