using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Domain.Core.Interfaces.Services
{
    public interface IServicePerson : IServiceBase<Person>
    {
        PersonAccount PostAccount(Guid peopleId, PersonAccount account);
        IEnumerable<PersonAccount> GetAccounts(Guid peopleId);
        IEnumerable<Card> GetCards(Guid peopleId);
    }
}
