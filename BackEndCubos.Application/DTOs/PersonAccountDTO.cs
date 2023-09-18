using BackEndCubos.Domain.Entities;
using System.Text.Json.Serialization;

namespace BackEndCubos.Application.DTOs
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
            public IEnumerable<Card>? Cards { get; set; }
        }
    
        public class PersonAccountWithBalance : PersonAccountDTO
        {
            public decimal Balance { get; set; }
        }

        public class PersonAccountWithTransactions : PersonAccountDTO
        {
            public virtual IEnumerable<Transaction>? Transactions { get; set; }
        }
    }
}
