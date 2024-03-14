namespace BullPerksTask.Application;

public class BLPSettings
{
    public const string SectionName = "BLPSettings";
    public string BLPAddress { get; set; } = null!;
    public string BLPContractABI { get; set; } = null!;
    public string[] EscrowAddresses { get; set; } = null!;

}
