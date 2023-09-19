using BackEndCubos.Application.Interfaces;
using BackEndCubos.Domain.Core.Interfaces.Services;
using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Application
{
    public class PersonAccountServiceApplication : IPersonAccountServiceApplication
    {
        private readonly IServicePersonAccount servicePersonAccount;

        public PersonAccountServiceApplication(IServicePersonAccount servicePersonAccount)
        {
            this.servicePersonAccount = servicePersonAccount;
        }

        public PersonAccount Create(PersonAccount obj)
        {
            servicePersonAccount.Create(obj);

            return obj;
        }

        public object GetBalance(Guid accountId)
        {
            return servicePersonAccount.GetBalance(accountId);
        }

        public IEnumerable<Card> GetCards(Guid accountId)
        {
            return servicePersonAccount.GetCards(accountId).ToList();
        }

        public IEnumerable<Transaction> GetTransactions(Guid accountId)
        {
            return servicePersonAccount.GetTransactions(accountId).ToList();
        }

        public Card CreateCard(Guid accountId, Card card)
        {
            return servicePersonAccount.PostCard(accountId, card);
        }

        public Transaction CreateTransaction(Guid accountId, Transaction transaction)
        {
            return servicePersonAccount.PostTransaction(accountId, transaction);
        }
    }
}
