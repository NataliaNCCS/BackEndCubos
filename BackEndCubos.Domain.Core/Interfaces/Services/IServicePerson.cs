using BackEndCubos.Domain.Core.DTOS.ResponseDTOs;
using BackEndCubos.Domain.Entities;
using static BackEndCubos.Domain.Core.DTOS.ResponseDTOs.PersonDTO;

namespace BackEndCubos.Domain.Core.Interfaces.Services
{
    public interface IServicePerson 
    {
        PersonDTO CreatePerson(Person person);
        public PersonWithCardsDTO GetCards(Guid personId);

    }
}
