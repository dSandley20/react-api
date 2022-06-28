using System;
using System.Collections.Generic;
using react_api.Entities;
namespace react_api.RepositoryInterfaces
{
    public interface IJobsRepository
    {
        public IEnumerable<Job> GetJobs();
        public Job GetJob(Guid id);
        public void CreateJob(Job job);
        void UpdateJob(Job job);
        void DeleteJob(Guid id);
    }
}
