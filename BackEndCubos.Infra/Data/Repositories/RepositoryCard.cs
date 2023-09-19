using BackEndCubos.Domain.Core.Interfaces.Repositories;
using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Infra.Data.Repositories
{
    public class RepositoryCard : IRepositoryCard
    {
        private readonly PostgreSQLContext postgreSQLContext;

        public RepositoryCard(PostgreSQLContext postgreSQLContext)
        {
            this.postgreSQLContext = postgreSQLContext;

        }
        public Card CreateCard(Guid accountId, Card card)
        {
            card.AccountId = accountId;
            postgreSQLContext.Set<Card>().Add(card);
            postgreSQLContext.SaveChanges();
            return card;
        }

        public IEnumerable<Card> GetCardsByAccount(Guid accountId)
        {
            return postgreSQLContext.Set<Card>().Where(x => x.AccountId == accountId).ToList();
        }

        public IEnumerable<Card> GetCardsByPerson(Guid peopleId)
        {
            return postgreSQLContext.Set<Card>()
                .Where(x => x.Account!.PersonId == peopleId)
                .ToList();
        }
    }
}
