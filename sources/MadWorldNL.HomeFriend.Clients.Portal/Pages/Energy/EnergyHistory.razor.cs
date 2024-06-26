using System.Globalization;
using MadWorldNL.HomeFriend.Domain.Energy;
using MadWorldNL.HomeFriend.Energy;
using Microsoft.AspNetCore.Components;

namespace MadWorldNL.HomeFriend.Pages.Energy;

public partial class EnergyHistory : ComponentBase
{
    private IEnumerable<ConsumptionContract> Consumptions = [];

    private IEnumerable<string> Years { get; set; } = [];
    private string SelectedYear { get; set; } = string.Empty;
    
    private IEnumerable<MonthSelection> Months { get; set; } = [];
    private MonthSelection SelectionMonth { get; set; } = new();
    
    protected override void OnInitialized()
    {
        CreateYearsComboBox();
        CreateMonthComboBox();
        GetConsumptions();
    }

    private void GetConsumptions()
    {
        Consumptions =
        [
            new ConsumptionContract()
            {
                Type = "Electric",
                Timestamp = new DateTime(2024, 10, 10),
                Cost = 10
            },
            new ConsumptionContract()
            {
                Type = "Gas",
                Timestamp = new DateTime(2024, 10, 10),
                Cost = 11
            },
            new ConsumptionContract()
            {
                Type = "Electric",
                Timestamp = new DateTime(2024, 10, 11),
                Cost = 20
            },
            new ConsumptionContract()
            {
                Type = "Gas",
                Timestamp = new DateTime(2024, 10, 11),
                Cost = 22
            },
        ];
    }

    private void CreateYearsComboBox()
    {
        const int startYear = 2020;

        var today = DateTime.UtcNow;
        SelectedYear = today.Year.ToString();

        var currentYear = today;
        var tempYears = new List<string>();
        while (currentYear.Year != startYear)
        {
            tempYears.Add(currentYear.Year.ToString());
            currentYear = currentYear.AddYears(-1);
        }

        Years = tempYears;
    }

    private void CreateMonthComboBox()
    {
        const int totalMonths = 12;

        var today = DateTime.UtcNow;
        
        var tempMonths = new List<MonthSelection>();
        for (int monthIndex = 1; monthIndex <= totalMonths; monthIndex++)
        {
            var selection = new MonthSelection()
            {
                Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(monthIndex),
                Value = monthIndex.ToString()
            };
            
            tempMonths.Add(selection);

            if (today.Month == monthIndex)
            {
                SelectionMonth = selection;
            }
        }

        Months = tempMonths;
    }
}