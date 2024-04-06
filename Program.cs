using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using ShitCoinParser.Models;
using ShitCoinParser.Configuration;
using System.Configuration;
using Microsoft.Extensions.Options;
using ShitCoinParser.RepositoryModelFacade.Repositories;
using ShitCoinParser.Repositories.Interfaces;
using ShitCoinParser.Services.Interfaces;
using ShitCoinParser.Services;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<IMongoSettings>(sp => sp.GetRequiredService<IOptions<MongoSettings>>().Value);

builder.Services.AddSingleton<IMongoClientFactory, MongoClientFactory>(serviceProvider =>
{
    var mongoSettings = serviceProvider.GetRequiredService<IOptions<MongoSettings>>().Value;
    var logger = serviceProvider.GetRequiredService<ILogger<MongoClientFactory>>();
    return new MongoClientFactory(Options.Create(mongoSettings), logger);
});


builder.Services.AddSingleton<IValidator<MongoSettings>, MongoSettingsValidator>();
//builder.Services.AddSingleton<IConfiguration>();


builder.Services.AddScoped<IShitCoinMetaDataRepository, ShitCoinMetaDataRepository>();
builder.Services.AddScoped<IShitCoinHistoricalDataRepository, ShitCoinHistoricalDataRespository>();
builder.Services.AddScoped<IShitCoinHistoricalDataService, ShitCoinHistoricalDataService>();
builder.Services.AddScoped<IShitCoinMetaDataService, ShitCoinMetaDataService>();

// Attempt to bind the configuration section to MongoSettings
var mongoSettingsSection = builder.Configuration.GetSection("MongoDB");
var mongoSettings = mongoSettingsSection.Get<MongoSettings>();

builder.Services.AddOptions<MongoSettings>()
    .Bind(builder.Configuration.GetSection("MongoDB"))
    .ValidateDataAnnotations();
builder.Services.AddSingleton<IMongoSettings>(sp =>
sp.GetRequiredService<IOptions<MongoSettings>>().Value);



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
