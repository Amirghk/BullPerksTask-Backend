using System.Numerics;

namespace BullPerksTask.Application.Interfaces.Adapters;

public interface IWeb3RPCAdapter
{
    /// <summary>
    /// returns the total supply of specified Token
    /// </summary>
    /// <param name="contractABI">Token's contract ABI</param>
    /// <param name="contractAddress">Token's contract Address</param>
    /// <returns></returns>
    Task<BigInteger> GetTotalSupplyOfToken(string contractABI, string contractAddress);

    /// <summary>
    /// returns the balance of the specified token in address
    /// </summary>
    /// <param name="address">The address to query</param>
    /// <param name="tokenContractABI">Token's contract ABI</param>
    /// <param name="tokenContractAddress">Token's contract Address</param>
    /// <returns></returns>
    Task<BigInteger> GetBalanceOfAddress(string address, string tokenContractABI, string tokenContractAddress);
}
