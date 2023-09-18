using BackEndCubos.Application.Interfaces;
using BackEndCubos.Domain.Core.Interfaces.Services;
using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Application
{
    public class ApplicationServicePerson : IApplicationServicePerson
    {
        private readonly IServicePerson servicePerson;

        public ApplicationServicePerson(IServicePerson servicePerson)
	    {
		this.servicePerson = servicePerson;
	    }
        public Person Add(Person obj)
        {
            servicePerson.Add(obj);

            return obj;
        }

        public IEnumerable<PersonAccount> GetAccounts(Guid peopleId)
        {
            return servicePerson.GetAccounts(peopleId).ToList();
        }

        public IEnumerable<Card> GetCards(Guid peopleId)
        {
            return servicePerson.GetCards(peopleId).ToList();
        }

        public PersonAccount PostAccount(Guid peopleId, PersonAccount account)
        {
            return servicePerson.PostAccount(peopleId, account);
        }
    }
}
