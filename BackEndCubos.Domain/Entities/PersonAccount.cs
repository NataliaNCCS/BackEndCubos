using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BackEndCubos.Domain.Entities
{
    public class PersonAccount
    {
        public Guid Id { get; set; }
        public string Branch { get; set; } = null!;
        public string Account { get; set; } = null!;
        public decimal Balance { get; set; }
        public IEnumerable<Card> Cards { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid PersonId { get; set; }
        public virtual Person? Person { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; } = null!;
    }
}
