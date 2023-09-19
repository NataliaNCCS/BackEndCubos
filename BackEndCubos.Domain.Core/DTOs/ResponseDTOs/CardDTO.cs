using BackEndCubos.Domain.Core.DTOs;
using BackEndCubos.Domain.Utils.Enums;

namespace BackEndCubos.Domain.Core.DTOS.ResponseDTOs
{
    public class CardDTO
    {
        public Guid Id { get; set; }
        public CardType Type { get; set; }
        public string Number { get; set; } = null!;
        public string CVV { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CardWithPaginationDTO
    {
        public IEnumerable<CardDTO>? Cards { get; set; }
        public Pagination? Pagination { get; set; }
    }
}
