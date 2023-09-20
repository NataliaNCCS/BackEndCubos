using BackEndCubos.Domain.Core.Interfaces.Repositories;
using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Infra.Data.Repositories
{
    public class RepositoryTransaction : IRepositoryTransaction
    {
        private readonly PostgreSQLContext postgreSQLContext;
        private readonly IRepositoryPersonAccount repositoryPersonAccount;

        public RepositoryTransaction(PostgreSQLContext postgreSQLContext, IRepositoryPersonAccount repositoryPersonAccount)
        {
            this.postgreSQLContext = postgreSQLContext;
            this.repositoryPersonAccount = repositoryPersonAccount;
        }

        public Transaction CreateTransaction(Guid accountId, Transaction transaction)
        {
            transaction.AccountId = accountId;

            postgreSQLContext.Set<Transaction>().Add(transaction);
            postgreSQLContext.SaveChanges();
            return transaction;
        }

        public IEnumerable<Transaction> GetTransactions(Guid accountId, DateTime startDateTimeUtc, DateTime endDateTimeUtc)
        {
            return postgreSQLContext.Set<Transaction>()
                .Where(x => x.AccountId == accountId)
                .Where(x => x.CreatedAt >= startDateTimeUtc && x.CreatedAt <= endDateTimeUtc)
                .ToList();
        }

        public Transaction RevertTransaction(Guid accountId, Guid transactionId)
        {
            var transaction = postgreSQLContext.Set<Transaction>().Find(transactionId);

            Transaction revertedTransaction = new Transaction();
            decimal value = transaction!.Value;

            if (value > 0)
            {
                revertedTransaction.Description = "Estorno crédito indevido: " + transaction.Description;

                revertedTransaction!.Value = -value;
            }

            if (value < 0)
            {
                revertedTransaction.Description = "Estorno cobrança indevida: " + transaction.Description;

                revertedTransaction!.Value = Math.Abs(value);
            }

            repositoryPersonAccount.UpdateBalance(accountId, revertedTransaction.Value);

            CreateTransaction(accountId, revertedTransaction!);

            return revertedTransaction;
        }
    }
}
