using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace react_api.Dtos.Skills
{
    public record SkillDto
    {
        public Guid Id {get; init;}
        public string Name {get;init;}
        public string Description {get; init;}
        public int YearsExperience {get; init;}
        public string Image {get;init;}
        public Project[] {get; init;}
    }
}