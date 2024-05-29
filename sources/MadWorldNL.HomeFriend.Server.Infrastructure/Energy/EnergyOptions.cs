using System.ComponentModel.DataAnnotations;

namespace MadWorldNL.HomeFriend.Energy;

public class EnergyOptions
{
    public const string Key = nameof(EnergyOptions); 
    
    [Required] public string DbConnectionString { get; set; } = string.Empty;
}