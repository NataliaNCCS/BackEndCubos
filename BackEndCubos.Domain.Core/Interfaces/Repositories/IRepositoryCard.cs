using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryCard
    { 
        Card CreateCard(Guid accountId, Card card);
        IEnumerable<Card> GetCardsByPerson(Guid peopleId);
        IEnumerable<Card> GetCardsByAccount(Guid accountId);
    }
}
