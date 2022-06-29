using System;
namespace react_api.Dtos.Projects
{
    public record ProjectDto
    {
      
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public DateTimeOffset CreatedDate { get; init; }
        
    }
}
