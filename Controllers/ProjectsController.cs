using System;
using Microsoft.AspNetCore.Mvc;
using react_api.RepositoryInterfaces;
using react_api.Dtos.Projects;
using react_api.Utilities;
using react_api.Entities;
using System.Linq;
using System.Collections.Generic;

namespace react_api.Controllers
{
    [ApiController]
    [Route("/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsRepository repository;

        public ProjectsController(IProjectsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ProjectDto> GetProjects()
        {
            return repository.GetProjects().Select(project => project.AsProjectDto());
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectDto> GetProject(Guid id)
        {
            ProjectDto project = repository.GetProject(id).AsProjectDto();
            if (project is null)
            {
                return NotFound();
            }
            return project;
        }

        [HttpPost]
        public ActionResult<ProjectDto> CreateProject(CreateUpdateProjectDto projectDto)
        {
            Project project = new Project
            {
                Id = Guid.NewGuid(),
                Name = projectDto.Name,
                Description = projectDto.Description,
                Url = projectDto.Url,
                ImageUrl = projectDto.ImageUrl,
                CreatedDate = DateTimeOffset.UtcNow,
            };
            repository.CreateProject(project);
            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project.AsProjectDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProject(Guid id, CreateUpdateProjectDto projectDto)
        {
            var exitingProject = repository.GetProject(id);
            if(exitingProject is null)
            {
                return NotFound();
            }
            var project = exitingProject with { Name = projectDto.Name, Description = projectDto.Description, ImageUrl = projectDto.ImageUrl, Url = projectDto.Url };
            repository.UpdateProject(project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProject(Guid id)
        {
            var existingProject = repository.GetProject(id);
            if(existingProject is null)
            {
                return NotFound();
            }
            repository.DeleteProject(id);
            return NoContent();
        }
        

    }
}
