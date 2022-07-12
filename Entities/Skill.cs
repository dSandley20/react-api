using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes
using react_api.Entities;

namespace react_api.Entities
{
    public record Skill{
        [BsonId]
        public Guid Id {get; init;}
        public string Name {get;init;}
        public string Description {get; init;}
        public int YearsExperience {get; init;}
        public string Image {get;init;}
        public Project[] {get; init;}
    }
}