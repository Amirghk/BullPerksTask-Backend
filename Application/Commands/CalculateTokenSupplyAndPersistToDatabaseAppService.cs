using BullPerksTask.Application.Interfaces.Persistance;
using BullPerksTask.Domain;
using BullPerksTask.Domain.Entities;
using BullPerksTask.Infrastructure.Persistence;
using Microsoft.Extensions.Options;
using Nethereum.Web3;
using Newtonsoft.Json;
using System.Numerics;

namespace BullPerksTask.Application.Commands;

public class CalculateTokenSupplyAndPersistToDatabaseAppService
{
    private readonly ITokenRepository _tokenRepository;
    private readonly BLPSettings _settings;
    public CalculateTokenSupplyAndPersistToDatabaseAppService(ITokenRepository tokenRepository, IOptions<BLPSettings> blpSettings)
    {
        _tokenRepository = tokenRepository;
        _settings = blpSettings.Value;
    }

    public async Task Execute()
    {
        var web3 = new Web3("https://go.getblock.io/6c1580d12bff4b2c82347901c3847537");

        var contract = web3.Eth.GetContract(_settings.BLPContractABI, _settings.BLPAddress);
        var totalSupply = await contract.GetFunction("totalSupply").CallAsync<BigInteger>();

        // calculate circulating supply
        BigInteger nonCirculatingTokens = 0;
        foreach (var address in _settings.EscrowAddresses)
        {
            //var balance = await web3.Eth.GetBalance.SendRequestAsync(address);
            var balance = await contract.GetFunction("balanceOf").CallAsync<BigInteger>(address);
            nonCirculatingTokens += balance;
        }

        var circulatingSupply = totalSupply - nonCirculatingTokens;

        var token = new Token
        {
            Name = "BLP",
            CirculatingSupply = circulatingSupply.ToString(),
            TotalSupply = totalSupply.ToString(),
            DataFetchedAt = DateTime.UtcNow,
        };


        await _tokenRepository.AddNewTokenInfo(token);
    }
}
