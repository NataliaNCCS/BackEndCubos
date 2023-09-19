using BackEndCubos.Domain.Utils.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackEndCubos.Domain.Entities
{
    public class Card
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [JsonIgnore]
        public Guid AccountId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CardType Type { get; set; }

        public string Number { get; set; } = null!;

        [StringLength(3, MinimumLength = 3, ErrorMessage = "CVV deve ter 3 dígitos")]
        public string CVV { get; set; } = null!;

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual PersonAccount? Account { get; set; }
    }
}
