using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using react_api.Repositories;
using react_api.RepositoryInterfaces;
using react_api.Dtos.Skills;
using react_api.Utilities;
using react_api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace react_api.Controllers
{
    [ApiController]
    [Route("/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsRepository repository;

        public SkillsController(ISkillsRepository repository){
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<SkillDto> GetSkills(){
            return repository.GetSkills().Select(skill => skill.AsSkillDto());
        }

        [HttpGet("{id}")]
        public ActionResult<SkillDto> GetSkill(Guid id){
            var skill = repository.GetSkill(id);
            if(skill is null){
                return NotFound();
            }
            return skill.AsSkillDto();
        }

        [HttpPost]
        public ActionResult<SkillDto> CreateSkill(CreateUpdateSkillDto skillDto){
            Skill skill = new Skill(){
                Id = Guid.NewGuid(),
                Name = skillDto.Name,
                Description = skillDto.Description,
                YearsExperience = skillDto.YearsExperience,
                Image = skillDto.Image,
                Projects = skillDto.Projects
            };

            repository.CreateSkill(skill);
            return CreatedAtAction(nameof(GetSkill), new {id = skill.Id} , skill.AsSkillDto());
        }

        [HttpPut("{id}")]
        public ActionResult<SkillDto> UpdateSkill(Guid id, CreateUpdateSkillDto skillDto){
            var existingSkill = repository.GetSkill(id);
            if(existingSkill is null){
                return NotFound();
            }
            var skill = existingSkill with {
                Name = skillDto.Name,
                Description = skillDto.Description,
                YearsExperience = skillDto.YearsExperience,
                Image = skillDto.Image,
                Projects = skillDto.Projects
            };
            repository.UpdateSkill(skill);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<SkillDto> DeleteSkill(Guid id){
            var existingSkill = repository.GetSkill(id);
            if(existingSkill is null){
                return NotFound();
            }
            repository.DeleteSkill(existingSkill);
            return NoContent();
        }
    }
}