using BullPerksTask.Application.Interfaces.Adapters;
using BullPerksTask.Application.Interfaces.Persistance;
using BullPerksTask.Domain.Services;
using Microsoft.Extensions.Options;
using System.Numerics;

namespace BullPerksTask.Application.Commands;

public class CalculateTokenSupplyAndPersistToDatabaseAppService
{
    private readonly ITokenRepository _tokenRepository;
    private readonly IWeb3RPCAdapter _web3RPCAdapter;
    private readonly BLPSettings _settings;
    private readonly GetTokenEntityDomainService _getTokenEntityDomainService;  // injecting the domain service to have explicit dependencies (as opposed to having it as a static class)
    public CalculateTokenSupplyAndPersistToDatabaseAppService(
        ITokenRepository tokenRepository,
        IOptions<BLPSettings> blpSettings,
        GetTokenEntityDomainService getTokenEntityDomainService,
        IWeb3RPCAdapter web3RPCAdapter)
    {
        _tokenRepository = tokenRepository;
        _settings = blpSettings.Value;
        _getTokenEntityDomainService = getTokenEntityDomainService;
        _web3RPCAdapter = web3RPCAdapter;
    }

    public async Task Execute()
    {
        var totalSupply = await _web3RPCAdapter.GetTotalSupplyOfToken(_settings.BLPContractABI, _settings.BLPAddress);

        List<BigInteger> listOfNonCirculatingTokenAmounts = new();
        foreach (var address in _settings.EscrowAddresses)
        {
            var balance = await _web3RPCAdapter.GetBalanceOfAddress(address, _settings.BLPContractABI, _settings.BLPAddress);
            listOfNonCirculatingTokenAmounts.Add(balance);
        }
       
        var token = _getTokenEntityDomainService.Execute("BLP", totalSupply, listOfNonCirculatingTokenAmounts, DateTimeOffset.Now);

        await _tokenRepository.AddNewTokenInfo(token);
    }
}
