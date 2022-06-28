using System;
using System.Collections.Generic;
using System.Linq;
using react_api.RepositoryInterfaces;
using MongoDB.Driver;
using react_api.Entities;
using MongoDB.Bson;

namespace react_api.Repositories
{
    public class MongoJobsRepository : IJobsRepository
    {
        private readonly IMongoCollection<Job> jobsCollection;
        private readonly FilterDefinitionBuilder<Job> jobsFilter = Builders<Job>.Filter;

        public MongoJobsRepository(IMongoDatabase client)
        {
            jobsCollection = client.GetCollection<Job>("jobs");
        }

        public void CreateJob(Job job)
        {
            jobsCollection.InsertOne(job);
        }

        public void DeleteJob(Guid id)
        {
            jobsCollection.DeleteOne(jobsFilter.Eq(existingJob => existingJob.Id, id));
        }

        public Job GetJob(Guid id)
        {
            return jobsCollection.Find(jobsFilter.Eq(existingJob => existingJob.Id, id)).FirstOrDefault();
        }

        public IEnumerable<Job> GetJobs()
        {
            return jobsCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateJob(Job job)
        {
            jobsCollection.ReplaceOne(jobsFilter.Eq(existingJob => existingJob.Id, job.Id), job);
        }
    }
}
