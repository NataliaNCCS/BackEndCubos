using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryTransaction
    {
        Transaction CreateTransaction(Guid accountId, Transaction transaction);
        IEnumerable<Transaction> GetTransactions(Guid accountId);
        Transaction RevertTransaction(Guid accountId, Guid transactionId);

    }
}
