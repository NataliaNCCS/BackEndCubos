using BackEndCubos.Application.DTOs;
using BackEndCubos.Application.Interfaces;
using BackEndCubos.Domain.Core.Interfaces.Services;
using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Application
{
    public class PersonServiceApplication : IPersonServiceApplication
    {
        private readonly IServicePerson servicePerson;

        public PersonServiceApplication(IServicePerson servicePerson)
	    {
		this.servicePerson = servicePerson;
	    }
        public PersonDTO Create(PersonDTO obj)
        {
            servicePerson.Create(obj);

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

        public PersonAccount CreateAccount(Guid peopleId, PersonAccount account)
        {
            return servicePerson.CreateAccount(peopleId, account);
        }
    }
}
