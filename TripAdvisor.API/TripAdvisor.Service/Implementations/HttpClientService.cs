using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripAdvisor.Dto.Config;
using TripAdvisor.Service.Interfaces;

namespace TripAdvisor.Service.Implementations
{
    public class HttpClientService : IHttpClientService
    {
        private readonly string baseUrl;
        public HttpClientService(IOptions<WeatherForecastApiSettings> apiSettingsOption)
        {
            baseUrl = apiSettingsOption.Value.WeatherFordCastApiBaseUrl;
        }

        public async Task<T> SendGetRequest<T>(string queryParams)
        {
            using HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}{queryParams}");
            
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}
