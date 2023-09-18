using BackEndCubos.Domain.Core.Interfaces.Repositories;
using BackEndCubos.Domain.Core.Interfaces.Services;
using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Domain.Services
{
    public class ServicePerson : ServiceBase<Person>, IServicePerson
    {
        private readonly IRepositoryPerson repository;

        public ServicePerson(IRepositoryPerson repository) : base(repository)
        {
            this.repository = repository;
        }

        public IEnumerable<PersonAccount> GetAccounts(Guid peopleId)
        {
            return repository.GetAccounts(peopleId);
        }

        public IEnumerable<Card> GetCards(Guid peopleId)
        {
            return repository.GetCards(peopleId);
        }

        public PersonAccount PostAccount(Guid peopleId, PersonAccount account)
        {
            return repository.PostAccount(peopleId, account);
        }
    }
}
