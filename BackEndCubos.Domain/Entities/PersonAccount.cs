using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Transactions;

namespace BackEndCubos.Domain.Entities
{
    public class PersonAccount
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Branch { get; set; } = null!;
        public string Account { get; set; } = null!;
        [JsonIgnore]
        public decimal Balance { get; set; }
        [JsonIgnore]
        public IEnumerable<Card>? Cards { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public Guid PersonId { get; set; }
        [JsonIgnore]
        public virtual Person? Person { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Transaction>? Transactions { get; set; }
    }
}
