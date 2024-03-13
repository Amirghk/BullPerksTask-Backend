using BullPerksTask.Application.Interfaces.Persistance;
using BullPerksTask.Domain.Entities;
using BullPerksTask.Infrastructure.Persistence;

namespace BullPerksTask.Application.Queries;

public class GetTokenInfoAppService
{
    private readonly ITokenRepository _tokenRepository;

    public GetTokenInfoAppService(ITokenRepository tokenRepository)
    {
        _tokenRepository = tokenRepository;
    }

    public async Task<Token> Execute(CancellationToken cancellationToken)
    {
        return await _tokenRepository.GetLastTokenInfo(cancellationToken);
    }
}
