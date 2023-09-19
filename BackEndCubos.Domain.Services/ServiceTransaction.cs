using BackEndCubos.Domain.Core.DTOs;
using BackEndCubos.Domain.Core.DTOS.ResponseDTOs;
using BackEndCubos.Domain.Core.Interfaces.Repositories;
using BackEndCubos.Domain.Core.Interfaces.Services;
using BackEndCubos.Domain.Entities;
using static BackEndCubos.Domain.Core.DTOS.ResponseDTOs.TransactionDTO;

namespace BackEndCubos.Domain.Services
{
    public class ServiceTransaction : IServiceTransaction
    {
        private readonly IRepositoryTransaction repository;
        private readonly IRepositoryPersonAccount repositoryPersonAccount;

        public ServiceTransaction(IRepositoryTransaction repository, IRepositoryPersonAccount repositoryPersonAccount)
        {
            this.repository = repository;
            this.repositoryPersonAccount = repositoryPersonAccount;
        }

        public TransactionDTO CreateTransaction(Guid accountId, Transaction transaction)
        {
            transaction.CreatedAt = DateTime.UtcNow;
            transaction.UpdatedAt = DateTime.UtcNow;

            if (repositoryPersonAccount.CheckBalance(accountId, transaction.Value))
            {
                repositoryPersonAccount.UpdateBalance(accountId, transaction.Value);

                var createdTransaction = repository.CreateTransaction(accountId, transaction);

                return new TransactionDTO
                {
                    Id = createdTransaction.Id,
                    Value = createdTransaction.Value,
                    Description = createdTransaction.Description,
                    CreatedAt = createdTransaction.CreatedAt,
                    UpdatedAt = createdTransaction.UpdatedAt,
                };
            }

            return new TransactionDTO
            {
                Description = "Falha",
            };
        }
        public TransactionWithPaginationDTO GetTransactions(Guid accountId, Pagination pagination)
        {
            return new TransactionWithPaginationDTO()
            {
                Transactions = repository.GetTransactions(accountId)
                .Select(transaction => new TransactionDTO
                {
                    Id = transaction.Id,
                    Value = transaction.Value,
                    Description = transaction.Description,
                    CreatedAt = transaction.CreatedAt,
                    UpdatedAt = transaction.UpdatedAt,
                })
                .Skip(pagination.Skip)
                .Take(pagination.ItemsPerPage)
                .ToList(),
                Pagination = new Pagination()
                {
                    ItemsPerPage = pagination.ItemsPerPage,
                    CurrentPage = pagination.CurrentPage
                }
            };
        }

        public TransactionDTO RevertTransaction(Guid accountId, Guid transactionId)
        {
            var revertedTransaction = repository.RevertTransaction(accountId, transactionId);

            return new TransactionDTO
            {
                Id = revertedTransaction.Id,
                Value = revertedTransaction.Value,
                Description = revertedTransaction.Description,
                CreatedAt = revertedTransaction.CreatedAt,
                UpdatedAt = DateTime.UtcNow,
            };
        }
    }
}
