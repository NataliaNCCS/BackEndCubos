using BackEndCubos.Domain.Core.DTOs;

namespace BackEndCubos.Domain.Core.DTOS.ResponseDTOs
{
    public class TransactionDTO
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public class TransactionWithPaginationDTO
        {
            public IEnumerable<TransactionDTO>? Transactions { get; set; }
            public Pagination? Pagination { get; set; }
        }
    }
}
