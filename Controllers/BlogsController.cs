using Microsoft.AspNetCore.Mvc;
using react_api.Repositories;
using System;
using System.Collections.Generic;
using react_api.Entities;
using react_api.RepositoryInterfaces;
using System.Linq;
using react_api.Dtos;
using react_api.Utilities;

namespace react_api.Controllers

{
    [ApiController]
    // Get /blogs
    [Route("blogs")]
    public class BlogsController : ControllerBase
    {
        // not ideal to store everything in memory, should actually query the DB 
        private readonly BlogsRepoInterface repository;

        public BlogsController(BlogsRepoInterface repository){
            this.repository = repository;
        }

        // Get /items
        [HttpGet]
        public IEnumerable<BlogDto> GetBlogs() {
            var blogs = repository.GetBlogs().Select(blog => blog.AsBlogDto());
            return blogs;
        }
        
        // Get /items/{id} 
        [HttpGet("{id}")]
        public ActionResult<BlogDto> GetBlog(Guid id)
        {
            var item = repository.GetBlog(id).AsBlogDto();
            if(item is null)
            {
                return NotFound();
            } 
            return item;
        }

        // Post /items
        [HttpPost]
        public ActionResult<BlogDto> CreateBlog(CreateBlogDto blogDto)
        {
            Blog blog = new()
            {
                Id = Guid.NewGuid(),
                Name = blogDto.Name,
                Description = blogDto.Description,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateBlog(blog);
            return CreatedAtAction(nameof(GetBlog), new { id = blog.Id}, blog.AsBlogDto());
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateBlog(Guid id, UpdateBlogDto blogDto)
        {
            var existingItem = repository.GetBlog(id);
            if(existingItem is null)
            {
                return NotFound();
            }
            //with copys the original value then overwrites the specified properties
            Blog updatedBlog = existingItem with { Name = blogDto.Name, Description = blogDto.Description };
            repository.UpdateBlog(updatedBlog);
            return NoContent();
        }
    }
}