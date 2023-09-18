using BackEndCubos.Application.Interfaces;
using BackEndCubos.Domain.Core.Interfaces.Services;
using BackEndCubos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndCubos.Application
{
    public class ApplicationServicePersonAccount : IApplicationServicePersonAccount
    {
        private readonly IServicePersonAccount servicePersonAccount;

        public ApplicationServicePersonAccount(IServicePersonAccount servicePersonAccount)
        {
            this.servicePersonAccount = servicePersonAccount;
        }

        public PersonAccount Add(PersonAccount obj)
        {
            servicePersonAccount.Add(obj);

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

        public Card PostCard(Guid accountId, Card card)
        {
            return servicePersonAccount.PostCard(accountId, card);
        }

        public Transaction PostTransaction(Guid accountId, Transaction transaction)
        {
            return servicePersonAccount.PostTransaction(accountId, transaction);
        }
    }
}
