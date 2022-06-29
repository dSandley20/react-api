using System;
using System.Collections.Generic;
using react_api.Entities;
namespace react_api.RepositoryInterfaces
{
    public interface IProjectsRepository
    {
        public IEnumerable<Project> GetProjects();
        public Project GetProject(Guid id);
        public void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(Guid id);
    }
}
