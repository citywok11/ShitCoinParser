using ShitCoinParser.Models;

namespace ShitCoinParser.Repositories.Interfaces
{
    public interface IShitCoinMetaDataRepository
    {
        Task<List<ShitCoinMetaData>> GetAllAsync();
        Task<IEnumerable<string>> GetAllIdsAsync();
    }
}