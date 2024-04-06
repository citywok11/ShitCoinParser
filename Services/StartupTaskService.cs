using ShitCoinParser.Services;
using ShitCoinParser.Services.Interfaces;

public class StartupTaskService : IHostedService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<StartupTaskService> _logger;

    public StartupTaskService(IServiceScopeFactory scopeFactory, ILogger<StartupTaskService> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var metaDataService = scope.ServiceProvider.GetRequiredService<IShitCoinMetaDataService>();
            try
            {
                var test = await metaDataService.GetAllShitCoinMetaDataIds();
                var test1 = "";
                // Do something with test
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing StartupTaskService.");
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        // Implement any cleanup, if necessary
        return Task.CompletedTask;
    }
}
