using BackEndCubos.Domain.Entities;
using BackEndCubos.Infra.Utils.Enums;

namespace BackEndCubos.Application.DTOs
{
    public class CardDTO
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public CardType Type { get; set; }
        public string Number { get; set; } = null!;
        public string CVV { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual PersonAccount Account { get; set; } = null!;
        public virtual IEnumerable<Transaction>? Transactions { get; set; }
    }
}
