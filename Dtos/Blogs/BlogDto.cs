using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace react_api.Dtos.Blogs
{
    public record BlogDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
