using BackEndCubos.Domain.Core.DTOs;
using BackEndCubos.Domain.Core.DTOS.ResponseDTOs;
using BackEndCubos.Domain.Entities;
using BackEndCubos.Domain.Utils.Enums;

namespace BackEndCubos.Domain.Core.Interfaces.Services
{
    public interface IServiceCard
    {
        CardDTO CreateCard(Guid accountId, Card card);
        CardWithPaginationDTO GetCardsByPerson(Guid peopleId, Pagination pagination);
        IEnumerable<CardDTO> GetCardsByAccount(Guid accountId);
        bool AlreadyHasPhysicalCard(Guid accountId);

    }
}
