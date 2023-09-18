using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Application.Interfaces
{
    public interface IApplicationServicePerson
    {
        Person Add(Person obj);
        PersonAccount PostAccount(Guid peopleId, PersonAccount account);
        IEnumerable<PersonAccount> GetAccounts(Guid peopleId);
        IEnumerable<Card> GetCards(Guid peopleId);
    }
}
