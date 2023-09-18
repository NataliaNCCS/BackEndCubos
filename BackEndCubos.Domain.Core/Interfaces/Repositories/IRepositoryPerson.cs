using BackEndCubos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndCubos.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryPerson : IRepositoryBase<Person>
    {
        PersonAccount PostAccount(Guid peopleId, PersonAccount account);
        IEnumerable<PersonAccount> GetAccounts(Guid peopleId);
        IEnumerable<Card> GetCards(Guid peopleId);
    }
}
