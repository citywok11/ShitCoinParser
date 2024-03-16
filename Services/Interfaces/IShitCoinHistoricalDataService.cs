using ShitCoinParser.Models;

namespace ShitCoinParser.Services.Interfaces
{
    public interface IShitCoinHistoricalDataService
    {
        List<ShitCoinMetaData> GetAllShitCoinHistoricalData();
    }
}
