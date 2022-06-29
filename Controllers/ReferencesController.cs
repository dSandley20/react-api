using System;
using Microsoft.AspNetCore.Mvc;
using react_api.Entities;
using react_api.Dtos.References;
using react_api.Utilities;
using react_api.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace react_api.Controllers
{
    [ApiController]
    [Route("/references")]
    public class ReferencesController : ControllerBase
    {
        private readonly IRefrencesRepository repository;
        public ReferencesController(IRefrencesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ReferenceDto> GetReferences()
        {
            return repository.GetRefrences().Select(reference => reference.AsReferenceDto());
        }

        [HttpGet("{id}")]
        public ActionResult<ReferenceDto> GetReference(Guid id)
        {
            Reference reference = repository.GetReference(id);
            if(reference is null)
            {
                return NotFound();
            }
            var referenceDto = reference.AsReferenceDto();
            return referenceDto;
        }

        [HttpPost]
        public ActionResult<ReferenceDto> CreateReference(CreateUpdateReferenceDto referenceDto)
        {
            Reference newReference = new Reference()
            {
                Id = Guid.NewGuid(),
                CompanyName = referenceDto.CompanyName,
                ContactEmail = referenceDto.ContactEmail,
                ContactPhone = referenceDto.ContactPhone,
                FirstName = referenceDto.FirstName,
                LastName = referenceDto.LastName,
                Position = referenceDto.Position,
            };
            repository.CreateReference(newReference);
            return CreatedAtAction(nameof(GetReference), new { id = newReference.Id }, newReference.AsReferenceDto());
        }

        [HttpPut("{id}")]
        public ActionResult<ReferenceDto> UpdateReference(Guid id, CreateUpdateReferenceDto referenceDto)
        {
            var existingReference = repository.GetReference(id);
            if(existingReference is null)
            {
                return NotFound();
            }
            var updatedReference = existingReference with { CompanyName = referenceDto.CompanyName, ContactEmail = referenceDto.ContactEmail, ContactPhone = referenceDto.ContactPhone, FirstName = referenceDto.FirstName, LastName = referenceDto.LastName, Position = referenceDto.Position };
            repository.UpdateReference(updatedReference);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<ReferenceDto> DeleteReference(Guid id)
        {
            var existingReference = repository.GetReference(id);
            if(existingReference is null)
            {
                return NotFound();
            }
            repository.DeleteReference(id);
            return NoContent();
        }
    }
}
