using System;
using System.Collections.Generic;
using react_api.Entities;
using react_api.RepositoryInterfaces;
using MongoDB.Driver;
using MongoDB.Bson;

namespace react_api.Repositories
{
    public class MongoProjectsRepository : IProjectsRepository
    {
        private readonly IMongoCollection<Project> projectCollection;
        private readonly FilterDefinitionBuilder<Project> projectFilter = Builders<Project>.Filter;

        public MongoProjectsRepository(IMongoDatabase client)
        {
            projectCollection = client.GetCollection<Project>("projects");
        }

        public void CreateProject(Project project)
        {
            projectCollection.InsertOne(project);
        }

        public void DeleteProject(Guid id)
        {
            projectCollection.DeleteOne(projectFilter.Eq(existingProject => existingProject.Id, id));
        }

        public Project GetProject(Guid id)
        {
            return projectCollection.Find(projectFilter.Eq(existingProject => existingProject.Id, id)).FirstOrDefault();
        }

        public IEnumerable<Project> GetProjects()
        {
            return projectCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateProject(Project project)
        {
            projectCollection.ReplaceOne(projectFilter.Eq(existingProject => existingProject.Id, project.Id), project);
        }
    }
}
