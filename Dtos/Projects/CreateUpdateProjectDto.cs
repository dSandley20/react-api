using System;
using System.ComponentModel.DataAnnotations;

namespace react_api.Dtos.Projects
{
    public class CreateUpdateProjectDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public DateTimeOffset CreatedDate { get; init; }
    }
}
