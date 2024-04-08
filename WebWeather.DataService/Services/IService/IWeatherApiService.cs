using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWeather.Entities.Dtos.Responses;

namespace WebWeather.DataService.Services.IService
{
    public interface IWeatherApiService
    {
        Task<WeatherApiResponse> GetWeatherForecast(double latitude, double longitude);
    }
}
