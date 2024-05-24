// See https://aka.ms/new-console-template for more information

using MadWorldNL.GreenChoice.Authentication;
using MadWorldNL.GreenChoice.Statistics;

Console.WriteLine("Hello, World!");

var account = new Account()
{   
    Username = "",
    Password = ""
};

var statisticService = new StatisticsService(new AuthenticationService(account));

var now = DateTime.Now;
var stats = await statisticService.Get(now.AddDays(-7), now);

Console.ReadLine();