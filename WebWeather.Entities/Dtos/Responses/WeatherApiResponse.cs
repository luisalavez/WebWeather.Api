using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebWeather.Entities.Dtos.Responses
{
    public class WeatherApiResponse
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [JsonPropertyName("timezone")]
        public string TimeZone { get; set; } = string.Empty;

        [JsonPropertyName("current")]
        public CurrentWeather Current { get; set; }

        [JsonPropertyName("daily")]
        public DailyWeather Daily
        {
            get; set;
        }
    }


    public class CurrentWeather
    {
        [JsonPropertyName("temperature_2m")]
        public double Temperature { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public double Wind_Speed { get; set; }
        [JsonPropertyName("wind_direction_10m")]
        public double Wind_Direction { get; set; }
    }

    public class DailyWeather
    {
        [JsonPropertyName("time")]
        public string[] Time { get; set; }
        [JsonPropertyName("sunrise")]
        public string[] Sunrise { get; set; }
    }
}
