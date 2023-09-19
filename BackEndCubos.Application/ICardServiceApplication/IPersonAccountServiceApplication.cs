using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Application.Interfaces
{
    public interface IPersonAccountServiceApplication
    {
        PersonAccount Create(PersonAccount obj);
        Card CreateCard(Guid accountId, Card card);
        IEnumerable<Card> GetCards(Guid accountId);
        Transaction CreateTransaction(Guid accountId, Transaction transaction);
        IEnumerable<Transaction> GetTransactions(Guid accountId);
        object GetBalance(Guid accountId);
    }
}
