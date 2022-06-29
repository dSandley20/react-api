using System;
using System.Collections.Generic;
using react_api.Entities;

namespace react_api.RepositoryInterfaces
{
    public interface IRefrencesRepository
    {
        public IEnumerable<Reference> GetRefrences();
        public Reference GetReference(Guid id);
        public void CreateReference(Reference reference);
        void UpdateReference(Reference reference);
        void DeleteReference(Guid id);
    }
}
