using BackEndCubos.Domain.Core.Interfaces.Repositories;
using BackEndCubos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEndCubos.Infra.Data.Repositories
{
    public class RepositoryPersonAccount : IRepositoryPersonAccount
    {
        private readonly PostgreSQLContext postgreSQLContext;
        public RepositoryPersonAccount(PostgreSQLContext postgreSQLContext)
        {
            this.postgreSQLContext = postgreSQLContext;
        }

        public PersonAccount CreateAccount(Guid peopleId, PersonAccount account)
        {
            account.PersonId = peopleId;
            postgreSQLContext.Set<PersonAccount>().Add(account);

            postgreSQLContext.SaveChanges();

            return account;
        }

        public IEnumerable<PersonAccount> GetAccounts(Guid peopleId)
        {
            return postgreSQLContext.Set<PersonAccount>().Where(x => x.PersonId == peopleId).ToList();
        }

        public PersonAccount GetBalance(Guid accountId)
        {
            return postgreSQLContext.Set<PersonAccount>().Where(x => x.Id == accountId).First();
        }

        public PersonAccount GetCards(Guid accountId)
        {
            var personAccountWithCards = postgreSQLContext.Set<PersonAccount>()
                                                        .Include(x => x.Cards)
                                                        .FirstOrDefault(x => x.Id == accountId);

            if (personAccountWithCards == null || !personAccountWithCards.Cards!.Any())
                return personAccountWithCards!;

            return personAccountWithCards;
        }

        public bool CheckBalance(Guid accountId, decimal value)
        {
            var account = postgreSQLContext.Set<PersonAccount>().Find(accountId);

            var balance = account!.Balance;

            if ((balance += value) < 0)
                return false;

            return true;
        }

        public void UpdateBalance(Guid accountId, decimal value)
        {
            var account = postgreSQLContext.Set<PersonAccount>().Find(accountId);
            account!.Balance += value;
            postgreSQLContext.Update(account);
        }
    }
}
