using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using react_api.Entities;

namespace react_api.Dtos.Skills
{
    public class CreateUpdateSkillDto
    {
        [Required]
        public string Name {get;init;}
        [Required]
        public string Description {get; init;}
        [Required]
        public int YearsExperience {get; init;}
        [Required]
        public string Image {get;init;}
        [Required]
        public Project[] Projects { get; init; }
    }

}