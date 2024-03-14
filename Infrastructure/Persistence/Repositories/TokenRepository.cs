using BullPerksTask.Application.Interfaces.Persistance;
using BullPerksTask.Domain.Entities;
using BullPerksTask.Infrastructure.Persistence.Db;
using Microsoft.EntityFrameworkCore;

namespace BullPerksTask.Infrastructure.Persistence.Repositories;

public class TokenRepository : ITokenRepository
{
    private readonly AppDbContext _appDbContext;

    public TokenRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddNewTokenInfo(Token token)
    {
        _appDbContext.Tokens.Add(token);
        await _appDbContext.SaveChangesAsync();
    }


    public async Task<Token?> GetLastTokenInfo(CancellationToken cancellationToken)
    {
        var token = await _appDbContext.Tokens.OrderByDescending(x => x.DataFetchedAt).AsNoTracking().FirstOrDefaultAsync(cancellationToken);

        return token;
    }
}
