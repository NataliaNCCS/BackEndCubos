using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Domain.Core.DTOS.ResponseDTOs
{
    public class PersonAccountDTO
    {
        public Guid Id { get; set; }
        public string Branch { get; set; } = null!;
        public string Account { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public class PersonAccountWithCardsDTO : PersonAccountDTO
        {
            public IEnumerable<CardDTO>? Cards { get; set; }
        }

        public class PersonAccountWithBalanceDTO
        {
            public decimal Balance { get; set; }
        }

        public class PersonAccountWithTransactionsDTO : PersonAccountDTO
        {
            public virtual IEnumerable<Transaction>? Transactions { get; set; }
        }
    }
}
