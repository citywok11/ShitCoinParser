using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using ShitCoinParser.Models;
using ShitCoinParser.Configuration;
using System.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Attempt to bind the configuration section to MongoSettings
var mongoSettingsSection = builder.Configuration.GetSection("MongoDB");
var mongoSettings = mongoSettingsSection.Get<MongoSettings>();

builder.Services.AddOptions<MongoSettings>()
    .Bind(builder.Configuration.GetSection("MongoDB"))
    .ValidateDataAnnotations();
    builder.Services.AddSingleton<IMongoSettings>(sp =>
    sp.GetRequiredService<IOptions<MongoSettings>>().Value);

// Register the MongoClientFactory
builder.Services.AddSingleton<MongoClientFactory>();
// Register the repository
builder.Services.AddScoped<ShitCoinParser.RepositoryModelFacade.Repositories.ShitCoinMetaDataRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
