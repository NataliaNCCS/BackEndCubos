using BackEndCubos.Domain.Core.Interfaces.Repositories;
using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Infra.Data.Repositories
{
    public class RepositoryPersonAccount : RepositoryBase<PersonAccount>, IRepositoryPersonAccount
    {
        private readonly PostgreSQLContext postgreSQLContext;
        public RepositoryPersonAccount(PostgreSQLContext postgreSQLContext) : base(postgreSQLContext)
        {
            this.postgreSQLContext = postgreSQLContext;
        }

        public object GetBalance(Guid accountId)
        {
            return postgreSQLContext.Set<PersonAccount>().Where(x => x.Id == accountId);
        }

        public IEnumerable<Card> GetCards(Guid accountId)
        {
            return postgreSQLContext.Set<Card>().Where(x => x.AccountId == accountId).ToList();
        }

        public IEnumerable<Transaction> GetTransactions(Guid accountId)
        {
            return postgreSQLContext.Set<Transaction>().Where(x => x.AccountId == accountId).ToList();
        }

        public Card PostCard(Guid accountId, Card card)
        {
            card.AccountId = accountId;
            postgreSQLContext.Set<Card>().Add(card);
            postgreSQLContext.Set<PersonAccount>().Where(x => x.Id == accountId).First().Cards.Append(card);

            postgreSQLContext.SaveChanges();
            return card;
        }

        public Transaction PostTransaction(Guid accountId, Transaction transaction)
        {
            transaction.AccountId = accountId;
            postgreSQLContext.Set<Transaction>().Add(transaction);
            postgreSQLContext.Set<PersonAccount>().Where(x => x.Id == accountId).First().Transactions.Append(transaction);

            postgreSQLContext.SaveChanges();
            return transaction;
        }
    }
}
