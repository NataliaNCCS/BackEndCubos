using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Domain.Core.Interfaces.Services
{
    public interface IServicePersonAccount : IServiceBase<PersonAccount>
    {
        Card PostCard(Guid accountId, Card card);
        IEnumerable<Card> GetCards(Guid accountId);
        Transaction PostTransaction(Guid accountId, Transaction transaction);
        IEnumerable<Transaction> GetTransactions(Guid accountId);
        object GetBalance(Guid accountId);
    }
}
