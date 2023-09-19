using System.Text.Json.Serialization;

namespace BackEndCubos.Domain.Entities
{
    public class Transaction
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        
        [JsonIgnore]
        public Guid AccountId { get; set; }
        public decimal Value { get; set; }
        public string? Description { get; set; }
        
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual PersonAccount? Account { get; set; }
    }
}
