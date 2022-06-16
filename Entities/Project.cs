using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace react_api.Entities
{
    public record Project
    {
        public Guid Id {get; init;}
        public string Name {get; init;}
        public string Description {get; set;}
        public string ImageUrl {get; set;}
        public string Url {get; set;}
        public DateTimeOffset CreatedDate {get; init;}

    }
}