using Microsoft.AspNetCore.Mvc;
using react_api.Repositories;
using System;
using System.Collections.Generic;
using react_api.Entities;
using react_api.RepositoryInterfaces;
using System.Linq;
using react_api.Dtos.Blogs;
using react_api.Utilities;

namespace react_api.Controllers

{
    [ApiController]
    // Get /blogs
    [Route("blogs")]
    public class BlogsController : ControllerBase
    {
        // not ideal to store everything in memory, should actually query the DB 
        private readonly IBlogsRepository repository;

        public BlogsController(IBlogsRepository repository){
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
            BlogDto item = repository.GetBlog(id).AsBlogDto();
            if(item is null)
            {
                return NotFound();
            } 
            return item;
        }

        // Post /items
        [HttpPost]
        public ActionResult<BlogDto> CreateBlog(CreateUpdateBlogDto blogDto)
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
        public ActionResult UpdateBlog(Guid id, CreateUpdateBlogDto blogDto)
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

        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteBlog(Guid id)
        {
            var existingBlog = repository.GetBlog(id);
            if(existingBlog is null)
            {
                return NotFound();
            }
            repository.DeleteBlog(id);
            return NoContent();
        }
    }
}