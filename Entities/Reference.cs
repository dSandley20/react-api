using System;
using MongoDB.Bson.Serialization.Attributes;

namespace react_api.Entities
{
    public record Reference
    {
        [BsonId]
        public Guid Id {get; init;}
        public string FirstName {get; init;}
        public string LastName {get; init;}
        public string CompanyName {get; init;}
        public string Position {get; init;}
        public string ContactPhone {get; init;}
        public string ContactEmail {get; init;}
    }
}