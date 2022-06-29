using System;
namespace react_api.Dtos.References
{
    public record ReferenceDto
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string CompanyName { get; init; }
        public string Position { get; init; }
        public string ContactPhone { get; init; }
        public string ContactEmail { get; init; }
    }
}
