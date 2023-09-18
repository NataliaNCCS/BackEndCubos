using BackEndCubos.Domain.Utils.Enums;
using System.Transactions;

namespace BackEndCubos.Domain.Entities
{
    public class Card
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public CardType Type { get; set; }
        public string Number { get; set; } = null!;
        public string CVV { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual PersonAccount? Account { get; set; }
        public virtual IEnumerable<Transaction>? Transactions { get; set; }
    }
}
