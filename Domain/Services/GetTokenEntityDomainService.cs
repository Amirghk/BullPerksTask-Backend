using BullPerksTask.Domain.Entities;
using System.Numerics;

namespace BullPerksTask.Domain.Services;

public class GetTokenEntityDomainService
{
    public Token Execute(string name, BigInteger totalSupply, IEnumerable<BigInteger> listOfNonCirculatingTokenAmounts, DateTimeOffset currentDateTime)
    {
        BigInteger nonCirculatingTokens = 0;
        foreach (var amount in listOfNonCirculatingTokenAmounts)
        {
            nonCirculatingTokens += amount;
        }

        var circulatingSupply = totalSupply - nonCirculatingTokens;

        var token = new Token
        {
            Name = name,
            CirculatingSupply = circulatingSupply.ToString(),
            TotalSupply = totalSupply.ToString(),
            DataFetchedAt = currentDateTime
        };

        return token;
    }
}
