using BackEndCubos.Domain.Entities;

namespace BackEndCubos.Domain.Core.DTOS.ResponseDTOs
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Document { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public class PersonWithAccountsDTO : PersonDTO
        {
            public IEnumerable<PersonAccount>? Accounts { get; set; }
        }

        public class PersonWithCardsDTO
        {
            public IEnumerable<CardDTO>? Cards { get; set; }
        }
    }
}
