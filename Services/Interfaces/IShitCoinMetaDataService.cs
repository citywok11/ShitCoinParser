using ShitCoinParser.Models;

namespace ShitCoinParser.Services.Interfaces
{
    public interface IShitCoinMetaDataService
    {
        Task<List<ShitCoinMetaData>> GetAllShitCoinMetaData();
        Task<IEnumerable<string>> GetAllShitCoinMetaDataIds();
    }
}
