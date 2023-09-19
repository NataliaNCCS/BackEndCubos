using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryPersonAccount
    {
        PersonAccount CreateAccount(Guid peopleId, PersonAccount account);
        IEnumerable<PersonAccount> GetAccounts(Guid peopleId);
        PersonAccount GetBalance(Guid accountId);

        PersonAccount GetCards(Guid accountId);

        bool CheckBalance(Guid accountId, decimal value);
        void UpdateBalance(Guid accountId, decimal value);
    }
}
