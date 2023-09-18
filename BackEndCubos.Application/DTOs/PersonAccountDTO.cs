using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Application.DTOs
{
    public class PersonAccountDTO
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string Branch { get; set; } = null!;
        public string Account { get; set; } = null!;
        public decimal Balance { get; set; }
        public IEnumerable<Card>? Cards { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Person Person { get; set; } = null!;
        public virtual IEnumerable<Transaction>? Transactions { get; set; }
    }
}
