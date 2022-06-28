using System;
using System.Collections.Generic;
using System.Linq;
using react_api.RepositoryInterfaces;
using MongoDB.Driver;
using react_api.Entities;
using MongoDB.Bson;

namespace react_api.Repositories
{
    public class MongoBlogsRepository : IBlogsRepository
    {
        private readonly IMongoCollection<Blog> blogsCollection;
        private readonly FilterDefinitionBuilder<Blog> blogsFilter = Builders<Blog>.Filter;

        public MongoBlogsRepository(IMongoDatabase client){
            blogsCollection = client.GetCollection<Blog>("blogs");
        }

        public void CreateBlog(Blog blog)
        {
            blogsCollection.InsertOne(blog);
        }

        public Blog GetBlog(Guid id)
        {
            return blogsCollection.Find(blogsFilter.Eq(blog => blog.Id, id)).FirstOrDefault<Blog>();
        }

        public IEnumerable<Blog> GetBlogs()
        {
            return blogsCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateBlog(Blog blog)
        {
            blogsCollection.ReplaceOne(blogsFilter.Eq(existingBlog => existingBlog.Id, blog.Id), blog);
        }

        public void DeleteBlog(Guid id)
        {
            blogsCollection.DeleteOne(blogsFilter.Eq(blog => blog.Id, id));
        }
    }
}