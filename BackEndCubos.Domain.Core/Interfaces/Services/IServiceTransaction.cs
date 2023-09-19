using BackEndCubos.Domain.Core.DTOs;
using BackEndCubos.Domain.Core.DTOS.ResponseDTOs;
using BackEndCubos.Domain.Entities;
using static BackEndCubos.Domain.Core.DTOS.ResponseDTOs.TransactionDTO;

namespace BackEndCubos.Domain.Core.Interfaces.Services
{
    public interface IServiceTransaction
    {
        TransactionDTO CreateTransaction(Guid accountId, Transaction transaction);
        TransactionWithPaginationDTO GetTransactions(Guid accountId, Pagination pagination);

        TransactionDTO RevertTransaction(Guid accountId, Guid transactionId);

    }
}
