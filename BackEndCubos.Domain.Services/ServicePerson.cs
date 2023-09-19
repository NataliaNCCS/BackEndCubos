using BackEndCubos.Domain.Core.DTOS.ResponseDTOs;
using BackEndCubos.Domain.Core.Interfaces.Repositories;
using BackEndCubos.Domain.Core.Interfaces.Services;
using BackEndCubos.Domain.Entities;
using static BackEndCubos.Domain.Core.DTOS.ResponseDTOs.PersonDTO;

namespace BackEndCubos.Domain.Services
{
    public class ServicePerson : IServicePerson
    {
        private readonly IRepositoryPerson repository;

        public ServicePerson(IRepositoryPerson repository) 
        {
            this.repository = repository;
        }

        public PersonDTO CreatePerson(Person person)
        {
            person.CreatedAt = DateTime.UtcNow;
            person.UpdatedAt = DateTime.UtcNow;

            var createdPerson = repository.CreatePerson(person);

            var personDTO = new PersonDTO()
            {
                Id = createdPerson.Id,
                Name = createdPerson.Name,
                Document = createdPerson.Document,
                CreatedAt = createdPerson.CreatedAt,
                UpdatedAt = createdPerson.UpdatedAt,
            };

            return personDTO;
        }

        public PersonWithCardsDTO GetCards(Guid personId)
        {
            var cards = repository.GetCards(personId)
            .Select(card => new CardDTO
            {
                Id = card.Id,
                Type = card.Type,
                Number = card.Number.Substring(card.Number.Length - 4),
                CVV = card.CVV,
                CreatedAt = card.CreatedAt,
                UpdatedAt = card.UpdatedAt,
            });

            return new PersonWithCardsDTO()
            {
                Cards = cards,
            };
        }
    }
}
