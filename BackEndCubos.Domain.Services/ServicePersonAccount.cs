using BackEndCubos.Domain.Core.DTOS.ResponseDTOs;
using BackEndCubos.Domain.Core.Interfaces.Repositories;
using BackEndCubos.Domain.Core.Interfaces.Services;
using BackEndCubos.Domain.Entities;
using static BackEndCubos.Domain.Core.DTOS.ResponseDTOs.PersonAccountDTO;

namespace BackEndCubos.Domain.Services
{
    public class ServicePersonAccount : IServicePersonAccount
    {
        private readonly IRepositoryPersonAccount repository;
        public ServicePersonAccount(IRepositoryPersonAccount repository)
        {
            this.repository = repository;
        }

        public PersonAccountDTO CreateAccount(Guid peopleId, PersonAccount account)
        {
            account.CreatedAt = DateTime.UtcNow;
            account.UpdatedAt = DateTime.UtcNow;

            var createdAccount = repository.CreateAccount(peopleId, account);

            return new PersonAccountDTO
            {
                Id = createdAccount.Id,
                Branch = createdAccount.Branch,
                Account = createdAccount.Account,
                CreatedAt = createdAccount.CreatedAt,
                UpdatedAt = createdAccount.UpdatedAt
            };
        }

        public IEnumerable<PersonAccountDTO> GetAccounts(Guid peopleId)
        {
            return repository.GetAccounts(peopleId)
            .Select(account => new PersonAccountDTO
            {
                Id = account.Id,
                Branch = account.Branch,
                Account = account.Account,
                CreatedAt = account.CreatedAt,
                UpdatedAt = account.UpdatedAt
            }).ToList();
        }

        public PersonAccountWithBalanceDTO GetBalance(Guid accountId)
        {
            var account = repository.GetBalance(accountId);

            return new PersonAccountWithBalanceDTO
            {
                Balance = account.Balance,
            };
        }

        public PersonAccountWithCardsDTO GetCards(Guid accountId)
        {
            var account = repository.GetCards(accountId);

            var cards = account.Cards!
            .Select(card => new CardDTO
            {
                Id = card.Id,
                Type = card.Type,
                Number = card.Number.Substring(card.Number.Length - 4),
                CVV = card.CVV,
                CreatedAt = card.CreatedAt,
                UpdatedAt = card.UpdatedAt,
            }).ToList();

            return new PersonAccountWithCardsDTO
            {
                Id = account.Id,
                Branch = account.Branch,
                Account = account.Account,
                Cards = cards,
                CreatedAt = account.CreatedAt,
                UpdatedAt = account.UpdatedAt
            };
        }
    }
}
