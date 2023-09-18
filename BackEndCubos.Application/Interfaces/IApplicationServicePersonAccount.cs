using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Application.Interfaces
{
    public interface IApplicationServicePersonAccount
    {
        PersonAccount Add(PersonAccount obj);
        Card PostCard(Guid accountId, Card card);
        IEnumerable<Card> GetCards(Guid accountId);
        Transaction PostTransaction(Guid accountId, Transaction transaction);
        IEnumerable<Transaction> GetTransactions(Guid accountId);
        object GetBalance(Guid accountId);
    }
}
