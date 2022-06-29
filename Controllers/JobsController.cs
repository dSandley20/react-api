using System;
using Microsoft.AspNetCore.Mvc;
using react_api.Repositories;
using react_api.RepositoryInterfaces;
using react_api.Dtos.Jobs;
using System.Linq;
using react_api.Utilities;
using System.Collections.Generic;
using react_api.Entities;

namespace react_api.Controllers
{
    [ApiController]
    [Route("/jobs")]
    public class JobsController : ControllerBase
    {
        private readonly IJobsRepository repository;

        public JobsController(IJobsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<JobDto> GetJobs()
        {
            return repository.GetJobs().Select(job => job.AsJobDto());
        }

        [HttpGet("{id}")]
        public ActionResult<JobDto> GetJob(Guid id)
        {
            var job = repository.GetJob(id);
            if(job is null)
            {
                return NotFound();
            }
            return job.AsJobDto();
        }

        [HttpPost]
        public ActionResult<JobDto> CreateJob(CreateUpdateJobDto jobDto)
        {
            Job job = new Job()
            {
                Id = Guid.NewGuid(),
                CompanyName = jobDto.CompanyName,
                Description = jobDto.Description,
                Position = jobDto.Position,
                startDate = jobDto.startDate,
                endDate = jobDto.endDate,
                CreatedDate = DateTimeOffset.UtcNow,
                UpdatedDate = DateTimeOffset.UtcNow

            };

            repository.CreateJob(job);
            return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job.AsJobDto());
        }

        [HttpPut("{id}")]
        public ActionResult<JobDto> UpdateJob(Guid id, CreateUpdateJobDto jobDto)
        {
            var existingJob = repository.GetJob(id);
            if(existingJob is null)
            {
                return NotFound();
            }
            var job = existingJob with { CompanyName = jobDto.CompanyName, Description = jobDto.Description, Position = jobDto.Position, startDate = jobDto.startDate, endDate = jobDto.endDate, UpdatedDate = DateTimeOffset.UtcNow };
            repository.UpdateJob(job);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<JobDto> DeleteJob(Guid id)
        {
            var existingJob = repository.GetJob(id);
            if(existingJob is null)
            {
                return NotFound();
            }
            repository.DeleteJob(id);
            return NoContent();
        }
    }
}
