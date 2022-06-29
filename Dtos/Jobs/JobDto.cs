using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace react_api.Dtos.Jobs
{
    public record JobDto
    {
        public Guid Id {get; init;}
        public string CompanyName {get; init;}
        public string Position {get; init;}
        public string Description {get; init;}
        public DateTimeOffset startDate {get; init;}
        public DateTimeOffset endDate {get; init;}
        public DateTimeOffset CreatedDate {get; init;}
        public DateTimeOffset? UpdatedDate {get; init;}
    }
}