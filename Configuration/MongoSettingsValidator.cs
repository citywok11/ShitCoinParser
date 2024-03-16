using FluentValidation;

namespace ShitCoinParser.Configuration
{
    public class MongoSettingsValidator : AbstractValidator<MongoSettings>
    {
        public MongoSettingsValidator()
        {
            RuleFor(settings => settings.ConnectionString)
                .NotEmpty().WithMessage("MongoDB connection string must not be empty.");

            RuleFor(settings => settings.ShitDatabaseName)
                .NotEmpty().WithMessage("MongoDB database name must not be empty.");

        }
    }
}