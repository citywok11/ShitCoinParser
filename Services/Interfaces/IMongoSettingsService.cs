using ShitCoinParser.Configuration;

namespace ShitCoinParser.Services.Interfaces
{
    public interface IMongoSettingsService
    {
        MongoSettings GetValidatedSettings();
    }
}