using BackEndCubos.Domain.Entities;
using BackEndCubos.Domain.Utils.Enums;

namespace BackEndCubos.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryCard
    { 
        Card CreateCard(Guid accountId, Card card);
        IEnumerable<Card> GetCardsByPerson(Guid peopleId);
        IEnumerable<Card> GetCardsByAccount(Guid accountId);
    }
}
