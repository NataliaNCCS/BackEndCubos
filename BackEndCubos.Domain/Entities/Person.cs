using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BackEndCubos.Domain.CustomValidations.Attributes;

namespace BackEndCubos.Domain.Entities
{
    public class Person
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [MinLength(2, ErrorMessage = "Nome deve conter mais de 1 caractere.")]
        public string Name { get; set; } = null!;

        [CpfOrCnpj]
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
