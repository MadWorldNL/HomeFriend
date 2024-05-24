namespace MadWorldNL.GreenChoice.Statistics;

public class CostSummary
{
    public float ConsumptionHigh { get; set; }
    public float ConsumptionLow { get; set; }
    public float ConsumptionTotal { get; set; }
    
    public float CostsHigh { get; set; }
    public List<CostsComponent> CostsHighComponents { get; set; } = [];
    
    public float CostsLow { get; set; }
    public List<CostsComponent> CostsLowComponents { get; set; } = [];
    
    public float CostsFixed { get; set; }
    public List<CostsComponent> CostsFixedComponents { get; set; } = [];
    
    public float CostsTotal { get; set; }

    public string Status { get; set; } = string.Empty;
}