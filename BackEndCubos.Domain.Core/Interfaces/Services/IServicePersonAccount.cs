using BackEndCubos.Domain.Core.DTOS.ResponseDTOs;
using BackEndCubos.Domain.Entities;
using static BackEndCubos.Domain.Core.DTOS.ResponseDTOs.PersonAccountDTO;

namespace BackEndCubos.Domain.Core.Interfaces.Services
{
    public interface IServicePersonAccount
    {
        PersonAccountDTO CreateAccount(Guid peopleId, PersonAccount account);
        IEnumerable<PersonAccountDTO> GetAccounts(Guid peopleId);
        PersonAccountWithBalanceDTO GetBalance(Guid accountId);
        PersonAccountWithCardsDTO GetCards(Guid accountId);
    }
}
