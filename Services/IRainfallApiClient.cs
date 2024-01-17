using RainfallApi.Models;

namespace RainfallApi.Services
{
    public interface IRainfallApiClient
    {
        Task<RainfallReadingResponseModel> GetRainfallReadingsAsync(string stationId, int count);
    }
}
