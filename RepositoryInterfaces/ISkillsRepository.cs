using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using react_api.Entities;

namespace react_api.RepositoryInterfaces
{
    public interface ISkillsRepository
    {
        public IEnumerable<Skill> GetSkills();
        public Skill GetSkill(Guid id);
        public void CreateSkill(Skill skill);
        void UpdateSkill(Skill skill);
        void DeleteSkill(Skill skill);
    }
}