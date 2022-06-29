using System;
using react_api.Entities;
using react_api.RepositoryInterfaces;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

namespace react_api.Repositories
{
    public class MongoReferencesRepository : IRefrencesRepository
    {
        private readonly IMongoCollection<Reference> referenceCollection;
        private readonly FilterDefinitionBuilder<Reference> referenceFilter = Builders<Reference>.Filter;

        public MongoReferencesRepository(IMongoDatabase client)
        {
            referenceCollection = client.GetCollection<Reference>("references");
        }

        public void CreateReference(Reference reference)
        {
           referenceCollection.InsertOne(reference);
        }

        public void DeleteReference(Guid id)
        {
            referenceCollection.DeleteOne(referenceFilter.Eq(existingReference => existingReference.Id, id));
        }

        public Reference GetReference(Guid id)
        {
            return referenceCollection.Find(referenceFilter.Eq(existingReference => existingReference.Id, id)).FirstOrDefault();
        }

        public IEnumerable<Reference> GetRefrences()
        {
            return referenceCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateReference(Reference reference)
        {
            referenceCollection.ReplaceOne(referenceFilter.Eq(existingReference => existingReference.Id, reference.Id), reference);
        }
    }
}
