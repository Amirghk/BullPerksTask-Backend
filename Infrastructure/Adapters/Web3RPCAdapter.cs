using BullPerksTask.Application.Interfaces.Adapters;
using Microsoft.Extensions.Options;
using Nethereum.Web3;
using System.Numerics;

namespace BullPerksTask.Infrastructure.Adapters;

public class Web3RPCAdapter : IWeb3RPCAdapter
{
    private readonly Web3RPCSettings _settings;
    private readonly Web3 web3;
    public Web3RPCAdapter(IOptions<Web3RPCSettings> settings)
    {
        _settings = settings.Value;
        web3 = new Web3(_settings.Address);
    }

    public async Task<BigInteger> GetBalanceOfAddress(string address, string tokenContractABI, string tokenContractAddress)
    {

        var contract = web3.Eth.GetContract(tokenContractABI, tokenContractAddress);

        var balance = await contract.GetFunction("balanceOf").CallAsync<BigInteger>(address);
        
        return balance;
    }

    public async Task<BigInteger> GetTotalSupplyOfToken(string contractABI, string contractAddress)
    {
        var contract = web3.Eth.GetContract(contractABI, contractAddress);

        var totalSupply = await contract.GetFunction("totalSupply").CallAsync<BigInteger>();

        return totalSupply;
    }
}
