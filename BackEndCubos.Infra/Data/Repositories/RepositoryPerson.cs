using BackEndCubos.Domain.Core.Interfaces.Repositories;
using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Infra.Data.Repositories
{
    public class RepositoryPerson : IRepositoryPerson
    {
        private readonly PostgreSQLContext postgreSQLContext;
        private readonly IRepositoryPersonAccount repositoryPersonAccount;
        public RepositoryPerson(PostgreSQLContext postgreSQLContext, IRepositoryPersonAccount repositoryPersonAccount)
        {
            this.postgreSQLContext = postgreSQLContext;
            this.repositoryPersonAccount = repositoryPersonAccount;
        }

        public Person CreatePerson(Person person)
        {
            postgreSQLContext.Set<Person>()
                .Add(person);
            
            postgreSQLContext.SaveChanges();
            
            return person;
        }

        public IEnumerable<Card> GetCards(Guid peopleId)
        {
            var accounts = repositoryPersonAccount.GetAccounts(peopleId);

            List<Card> cards = new List<Card>();

            foreach (var account in accounts)
            {
                var accountCards = repositoryPersonAccount.GetCards(account.Id)?.Cards;

                if (accountCards != null)
                    cards.AddRange(accountCards);
            }

            return cards;
        }
    }
}
