using Microsoft.AspNetCore.Mvc;
using react_api.Repositories;
using System;
using System.Collections.Generic;
using react_api.Entities;
using react_api.RepositoryInterfaces;

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
        public IEnumerable<Blog> GetBlogs() {
            var blogs = repository.GetBlogs();
            return blogs;
        }
        
        //Get /items/{id} 
        [HttpGet("{id}")]
        public ActionResult<Blog> GetBlog(Guid id)
        {
            var item = repository.GetBlog(id);
            if(item is null)
            {
                return NotFound();
            } 
            return item;
        }
    }
}