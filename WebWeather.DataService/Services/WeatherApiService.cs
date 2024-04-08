using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebWeather.DataService.Services.IService;
using WebWeather.Entities.Dtos.Responses;

namespace WebWeather.DataService.Services
{
    public class WeatherApiService :  IWeatherApiService
    {
        private readonly HttpClient _httpClient;

        public WeatherApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherApiResponse> GetWeatherForecast(double latitude, double longitude)
        {
            var response = await _httpClient.GetAsync($"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,wind_speed_10m,wind_direction_10m&&daily=sunrise&forecast_days=1");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to retrieve weather forecast. Status code: {response.StatusCode}");
            }

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<WeatherApiResponse>(responseStream);
            result.Latitude = latitude;
            result.Longitude = longitude;
            return result;
        }
    }
}
