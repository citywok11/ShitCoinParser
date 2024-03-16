using ShitCoinParser.Models;

namespace ShitCoinParser.Services
{
    public interface IShitCoinHistoricalDataService
    {
        List<ShitCoinMetaData> GetAllShitCoinHistoricalData();
    }
}
