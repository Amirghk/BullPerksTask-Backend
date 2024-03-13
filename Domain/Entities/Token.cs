using System.Numerics;

namespace BullPerksTask.Domain.Entities;

public class Token
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string TotalSupply { get; set; }
    public required string CirculatingSupply { get; set;}
    public required DateTime DataFetchedAt { get; set; }
}
