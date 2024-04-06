using ShitCoinParser.Models;
using ShitCoinParser.Repositories.Interfaces;
using ShitCoinParser.Services.Interfaces;

namespace ShitCoinParser.Services
{
    public class ShitCoinMetaDataService : IShitCoinMetaDataService
    {
        private readonly IShitCoinMetaDataRepository _repository;
        private readonly ILogger<ShitCoinMetaDataService> _logger;

        public ShitCoinMetaDataService(IShitCoinMetaDataRepository repository, ILogger<ShitCoinMetaDataService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        public async Task<List<ShitCoinMetaData>> GetAllShitCoinMetaData()
        {
            try
            {
                return await _repository.GetAllAsync();

            }
            catch (Exception)
            {
                _logger.LogError("Unable to get shitcoin data");
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetAllShitCoinMetaDataIds()
        {
            try
            {
                return await _repository.GetAllIdsAsync();

            }
            catch (Exception)
            {
                _logger.LogError("Unable to get shitcoin data");
                throw;
            }
        }

    }
}