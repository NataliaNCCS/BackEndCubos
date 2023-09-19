using BackEndCubos.Domain.Core.DTOs;
using BackEndCubos.Domain.Core.DTOS.ResponseDTOs;
using BackEndCubos.Domain.Core.Interfaces.Repositories;
using BackEndCubos.Domain.Core.Interfaces.Services;
using BackEndCubos.Domain.Entities;
using BackEndCubos.Domain.Utils.Enums;

namespace BackEndCubos.Domain.Services
{
    public class ServiceCard : IServiceCard
    {
        private readonly IRepositoryCard repository;
        public ServiceCard(IRepositoryCard repository)
        {
            this.repository = repository;
        }
        public CardDTO CreateCard(Guid accountId, Card card)
        {
            card.CreatedAt = DateTime.UtcNow;
            card.UpdatedAt = DateTime.UtcNow;

            var createdCard = repository.CreateCard(accountId, card);

            return new CardDTO
            {
                Id = createdCard.Id,
                Type = createdCard.Type,
                Number = createdCard.Number.Substring(createdCard.Number.Length - 4),
                CVV = createdCard.CVV,
                CreatedAt = createdCard.CreatedAt,
                UpdatedAt = createdCard.UpdatedAt
            };
        }

        public IEnumerable<CardDTO> GetCardsByAccount(Guid accountId)
        {
            return repository.GetCardsByAccount(accountId)
            .Select(card => new CardDTO
            {
                Id = card.Id,
                Type = card.Type,
                Number = card.Number.Substring(card.Number.Length - 4),
                CVV = card.CVV,
                CreatedAt = card.CreatedAt,
                UpdatedAt = card.UpdatedAt,
            }).ToList();
        }

        public CardWithPaginationDTO GetCardsByPerson(Guid peopleId, Pagination pagination)
        {
            return new CardWithPaginationDTO()
            {
                Cards = repository.GetCardsByPerson(peopleId)
                .Select(card => new CardDTO
                {
                    Id = card.Id,
                    Type = card.Type,
                    Number = card.Number.Substring(card.Number.Length - 4),
                    CVV = card.CVV,
                    CreatedAt = card.CreatedAt,
                    UpdatedAt = card.UpdatedAt,
                })
                .Skip(pagination.Skip)
                .Take(pagination.ItemsPerPage)
                .ToList(),
                Pagination = new Pagination()
                {
                    ItemsPerPage = pagination.ItemsPerPage,
                    CurrentPage = pagination.CurrentPage
                }
            };
        }

        public bool AlreadyHasPhysicalCard(Guid accountId)
        {
            var cards = repository.GetCardsByAccount(accountId);

            if (cards.Any(x => x.Type == CardType.Physical))
                return true;
            
            return false;
        }
    }
}
