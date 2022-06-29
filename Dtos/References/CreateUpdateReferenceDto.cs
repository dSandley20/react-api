using System;
using System.ComponentModel.DataAnnotations;

namespace react_api.Dtos.References
{
    public class CreateUpdateReferenceDto
    {
        [Required]
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }
        [Required]
        public string CompanyName { get; init; }
        [Required]
        public string Position { get; init; }
        [Required]
        public string ContactPhone { get; init; }
        [Required]
        public string ContactEmail { get; init; }
    }
}
