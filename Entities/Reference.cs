using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace react_api.Entities
{
    public class Reference
    {
        public Guid Id {get; init;}
        public string FirstName {get; init;}
        public string LastName {get; init;}
        public string CompanyName {get; init;}
        public string Position {get; init;}
        //todo make this an object
        public string ContactPhone {get; init;}
        public string ContactEmail {get; init;}
        //end todo
    }
}