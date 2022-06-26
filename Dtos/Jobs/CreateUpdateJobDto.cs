using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace react_api.Dtos.Jobs
{
    public class CreateUpdateJobDto
    {
        [Required]
        public string CompanyName
        [Required]
        public string Position {get; init;}
        [Required]
        public string Description {get; init;}
        [Required]
        public DateTimeOffset startDate {get; init;}
        [Required]
        public DateTimeOffset endDate {get; init;}
    }
}