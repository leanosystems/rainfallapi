using Newtonsoft.Json;
using RainfallApi.Models;

namespace RainfallApi.Services
{
    public class RainfallApiClient : IRainfallApiClient
    {
        private readonly HttpClient _httpClient;

        public RainfallApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RainfallReadingResponseModel> GetRainfallReadingsAsync(string stationId, int count)
        {
            var response = await _httpClient.GetAsync($"/rainfall/id/{stationId}/readings?count={count}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RainfallReadingResponseModel>(content);

            return result;
        }
    }
}
