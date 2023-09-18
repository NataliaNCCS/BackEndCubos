using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Application.DTOs
{
    public class TransactionDTO
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public decimal Value { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual PersonAccount Account { get; set; } = null!;
    }
}
