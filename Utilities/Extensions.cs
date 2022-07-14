using react_api.Dtos.Blogs;
using react_api.Dtos.Projects;
using react_api.Dtos.References;
using react_api.Dtos.Jobs;
using react_api.Dtos.Skills;
using react_api.Entities;

namespace react_api.Utilities
{
    public static class Extensions
    {
        public static BlogDto AsBlogDto(this Blog blog)
        {
            return new BlogDto { 
                Id = blog.Id,
                Name = blog.Name,
                Description = blog.Description,
                CreatedDate = blog.CreatedDate
            };
        }

        public static ProjectDto AsProjectDto(this Project project)
        {
            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Url = project.Url,
                CreatedDate = project.CreatedDate,
                ImageUrl = project.ImageUrl
            };
        }

        public static ReferenceDto AsReferenceDto(this Reference reference)
        {
            return new ReferenceDto
            {
                Id = reference.Id,
                CompanyName = reference.CompanyName,
                ContactEmail = reference.ContactEmail,
                ContactPhone = reference.ContactPhone,
                FirstName = reference.FirstName,
                LastName = reference.LastName,
                Position = reference.Position
            };
        }

        public static JobDto AsJobDto(this Job job)
        {
            return new JobDto
            {
                Id = job.Id,
                CompanyName = job.CompanyName,
                Description = job.Description,
                CreatedDate = job.CreatedDate,
                endDate = job.endDate,
                Position = job.Position,
                startDate = job.startDate,
                UpdatedDate = job.UpdatedDate
            };
        }

        public static SkillDto AsSkillDto(this Skill skill){
            return new SkillDto
            {
                Id = skill.Id,
                Name = skill.Name,
                Description = skill.Description,
                YearsExperience = skill.YearsExperience,
                Image = skill.Image,
                Projects = skill.Projects
            };
        }
    }
}
