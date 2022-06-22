using react_api.Dtos.Blogs;
using react_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
