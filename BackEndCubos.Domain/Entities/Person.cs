using System.Text.Json.Serialization;

namespace BackEndCubos.Domain.Entities
{
    public class Person
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string Password { get; set; } = null!;
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public IEnumerable<PersonAccount>? Accounts { get; set; }
    }
}
