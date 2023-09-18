using BackEndCubos.Domain.Core.Interfaces.Repositories;
using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Infra.Data.Repositories
{
    public class RepositoryPerson : RepositoryBase<Person>, IRepositoryPerson
    {
        private readonly PostgreSQLContext postgreSQLContext;
        public RepositoryPerson(PostgreSQLContext postgreSQLContext) : base(postgreSQLContext)
        {
            this.postgreSQLContext = postgreSQLContext;
        }

        public IEnumerable<PersonAccount> GetAccounts(Guid peopleId)
        {
            return postgreSQLContext.Set<PersonAccount>().Where(x => x.PersonId == peopleId).ToList();
        }

        public IEnumerable<Card> GetCards(Guid peopleId)
        {
            return postgreSQLContext.Set<Card>().Where(x => x.Account!.PersonId == peopleId).ToList();
        }

        public PersonAccount PostAccount(Guid peopleId, PersonAccount account)
        {
            account.PersonId = peopleId;
            postgreSQLContext.Set<PersonAccount>().Add(account);

            var person = postgreSQLContext.Set<Person>().Where(x => x.Id == peopleId).FirstOrDefault();
            
            if (person is not null)
                person.Accounts.Append(account);

            postgreSQLContext.SaveChanges();

            return account;
        }
    }
}
