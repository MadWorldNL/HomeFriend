// See https://aka.ms/new-console-template for more information

using MadWorldNL.GreenChoice.Authentication;

Console.WriteLine("Hello, World!");

var service = new AuthenticationService();
await service.LoginAsync("", "");