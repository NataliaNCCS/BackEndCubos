using BackEndCubos.Domain.Core.Interfaces.Repositories;
using BackEndCubos.Domain.Core.Interfaces.Services;
using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Domain.Services
{
    public class ServicePersonAccount : ServiceBase<PersonAccount>, IServicePersonAccount
    {
        private readonly IRepositoryPersonAccount repository;
        public ServicePersonAccount(IRepositoryPersonAccount repository) : base(repository)
        {
            this.repository = repository;
        }

        public object GetBalance(Guid accountId)
        {
            return repository.GetBalance(accountId);
        }

        public IEnumerable<Card> GetCards(Guid accountId)
        {
            return repository.GetCards(accountId);
        }

        public IEnumerable<Transaction> GetTransactions(Guid accountId)
        {
            return repository.GetTransactions(accountId);
        }

        public Card PostCard(Guid accountId, Card card)
        {
            return repository.PostCard(accountId, card);
        }

        public Transaction PostTransaction(Guid accountId, Transaction transaction)
        {
            return repository.PostTransaction(accountId, transaction);
        }
    }
}
