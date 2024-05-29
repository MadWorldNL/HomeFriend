using MadWorldNL.GreenChoice.Extensions;
using MadWorldNL.HomeFriend.Energy;
using MadWorldNL.HomeFriend.Status;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEnergyInfrastructure(builder.Configuration.GetValue<EnergyOptions>(EnergyOptions.Key)!);

builder.Services.AddGreenChoiceApi(options =>
{
    options.Username = builder.Configuration.GetValue<string>("GreenChoice:Username")!;
    options.Password = builder.Configuration.GetValue<string>("GreenChoice:Password")!;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddStatusEndpoints();

app.UseHttpsRedirection();

app.Run();