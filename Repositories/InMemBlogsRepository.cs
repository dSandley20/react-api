using System.Collections.Generic;
using react_api.Entities;
using System;
using System.Linq;

namespace react_api.Repositories{
    public class InMemBlogsRepository{
        private readonly List<Blog> blogs = new(){
            new Blog{Id =  Guid.NewGuid(), Name = "First Blog" , Description = "This is my first blog", CreatedDate = DateTimeOffset.UtcNow },
            new Blog{Id =  Guid.NewGuid(), Name = "Second Blog" , Description = "This is my second blog", CreatedDate = DateTimeOffset.UtcNow },
            new Blog{Id =  Guid.NewGuid(), Name = "Third Blog" , Description = "This is my third blog", CreatedDate = DateTimeOffset.UtcNow },
        };

        public IEnumerable<Blog> GetBlogs(){
            return blogs;
        }

        public Blog GetBlog(Guid id){
            return blogs.Where(blog => blog.Id == id).SingleOrDefault();
        }
    }
}