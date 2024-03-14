using BullPerksTask.Application.Interfaces.Persistance;
using BullPerksTask.Application.Models;
using BullPerksTask.Domain.Entities;

namespace BullPerksTask.Application.Queries;

public class GetTokenInfoAppService
{
    private readonly ITokenRepository _tokenRepository;

    public GetTokenInfoAppService(ITokenRepository tokenRepository)
    {
        _tokenRepository = tokenRepository;
    }

    public async Task<TokenDataOutputModel?> Execute(CancellationToken cancellationToken)
    {
        var dbResult = await _tokenRepository.GetLastTokenInfo(cancellationToken);

        return MapToOutputDto(dbResult);
    }

    private static TokenDataOutputModel? MapToOutputDto(Token? dbResult)
    {

        if (dbResult is null)
        {
            return null;
        }

        var result = new TokenDataOutputModel
        {
            Name = dbResult.Name,
            TotalSupply = dbResult.TotalSupply,
            CirculatingSupply = dbResult.CirculatingSupply,
            UpdatedAt = dbResult.DataFetchedAt
        };

        return result;
    }
}
