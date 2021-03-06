using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using react_api.Entities;

namespace react_api.RepositoryInterfaces
{
   public  interface IBlogsRepository
    {
        public IEnumerable<Blog> GetBlogs();
        public Blog GetBlog(Guid id);
        public void CreateBlog(Blog blog);
        void UpdateBlog(Blog blog);
        void DeleteBlog(Guid id);
    }
}
