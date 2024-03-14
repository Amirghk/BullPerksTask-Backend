using BullPerksTask.Domain.Entities;

namespace BullPerksTask.Application.Interfaces.Persistance;

public interface ITokenRepository
{
    Task AddNewTokenInfo(Token token);
    Task<Token?> GetLastTokenInfo(CancellationToken cancellationToken);
}
