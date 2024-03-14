namespace BullPerksTask.Application.Models;

public record TokenDataOutputModel
{
    public required string Name { get; init; }
    public required string TotalSupply { get; init; }
    public required string CirculatingSupply { get; init; }
    public required DateTimeOffset UpdatedAt { get; init; }

}
