using BackEndCubos.Application.DTOs;
using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Application.Interfaces
{
    public interface IPersonServiceApplication
    {
        PersonDTO Create(Person obj);
        PersonAccountDTO CreateAccount(Guid peopleId, PersonAccount account);
        IEnumerable<PersonAccountDTO> GetAccounts(Guid peopleId);
        IEnumerable<PersonAccountDTO> GetCards(Guid peopleId);
    }
}
