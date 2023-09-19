using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryPerson
    {
        Person CreatePerson(Person person);
        public IEnumerable<Card> GetCards(Guid peopleId);

    }
}
