using System;
using System.Collections.Generic;
using react_api.RepositoryInterfaces;
using System.Linq;
using System.Threading.Tasks;
using react_api.Entities;
using MongoDB.Driver;
using MongoDB.Bson;

namespace react_api.Repositories
{
    public class MongoSkillsRepository : ISkillsRepository
    {
        private readonly IMongoCollection<Skill> skillsCollection;
        private readonly FilterDefinitionBuilder<Skill> skillsFilter = Builders<Skill>.Filter;

        public MongoSkillsRepository(IMongoDatabase client)
        {
            skillsCollection = client.GetCollection<Skill>("skills");
        }

        public void CreateSkill(Skill skill)
        {
            skillsCollection.InsertOne(skill);
        }

        public void DeleteSkill(Guid id)
        {
            skillsCollection.DeleteOne(skillsFilter.Eq((existingSkill) => existingSkill.Id, id));
        }

        public IEnumerable<Skill> GetSkills()
        {
            return skillsCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateSkill(Skill skill)
        {
            skillsCollection.ReplaceOne(skillsFilter.Eq(existingSkill => existingSkill.Id, skill.Id), skill);
        }

        public Skill GetSkill(Guid id)
        {
            return skillsCollection.Find(skillsFilter.Eq(existingSkill => existingSkill.Id, id)).FirstOrDefault();

        }

        public void DeleteSkill(Skill skill)
        {
            skillsCollection.DeleteOne(skillsFilter.Eq(existingSkill => existingSkill.Id, skill.Id));
        }
    }
}