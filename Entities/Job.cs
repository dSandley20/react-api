using System;
using MongoDB.Bson.Serialization.Attributes;

namespace react_api.Entities
{
    public record Job{
        [BsonId]
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