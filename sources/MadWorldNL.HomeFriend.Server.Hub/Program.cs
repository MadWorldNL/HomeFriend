using Hangfire;
using MadWorldNL.GreenChoice.Extensions;
using MadWorldNL.HomeFriend.Database;
using MadWorldNL.HomeFriend.Energy;
using MadWorldNL.HomeFriend.Status;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var energyOptions = builder.Configuration.GetSection(EnergyOptions.Key).Get<EnergyOptions>()!;
builder.Services.AddEnergyInfrastructure(energyOptions);

builder.Services.AddGreenChoiceApi(options =>
{
    options.Username = builder.Configuration.GetValue<string>("GreenChoice:Username")!;
    options.Password = builder.Configuration.GetValue<string>("GreenChoice:Password")!;
});

builder.Services.AddHangfire(x => x.UseInMemoryStorage());
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddStatusEndpoints();

app.UseHttpsRedirection();

app.UseHangfireDashboard();
app.Services.AddEnergyJobs();

app.Services.MigrateDatabase<EnergyDbContext>();

app.Run();