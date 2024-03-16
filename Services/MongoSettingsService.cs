using FluentValidation;
using Microsoft.Extensions.Options;
using ShitCoinParser.Configuration;
using ShitCoinParser.Repositories.Interfaces;
using ShitCoinParser.Services.Interfaces;

namespace ShitCoinParser.Services
{
    public class MongoSettingsService: IMongoSettingsService
    {
        private readonly MongoSettings _mongoSettings;
        private readonly ILogger<MongoSettingsService> _logger;

        public MongoSettingsService(IOptions<MongoSettings> mongoSettingsOptions, IValidator<MongoSettings> validator, ILogger<MongoSettingsService> logger)
        {
            _logger = logger;

            if (mongoSettingsOptions == null || mongoSettingsOptions.Value == null)
            {
                var msg = "MongoDB settings options are not provided.";
                logger.LogError(msg);
                throw new ArgumentNullException(nameof(mongoSettingsOptions), msg);
            }

            var validationResult = validator.Validate(mongoSettingsOptions.Value);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                logger.LogError($"Invalid MongoDB settings: {errors}");
                throw new ArgumentException($"Invalid MongoDB settings: {errors}");
            }

            _mongoSettings = mongoSettingsOptions.Value;
        }

        public MongoSettings GetValidatedSettings()
        {
            return _mongoSettings;
        }
    }
}
