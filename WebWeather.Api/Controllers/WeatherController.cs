using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebWeather.DataService.Repositories;
using WebWeather.DataService.Repositories.Interfaces;
using WebWeather.DataService.Services.IService;
using WebWeather.Entities.DBSet;
using WebWeather.Entities.Dtos.Responses;

namespace WebWeather.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : BaseController
    {
        public WeatherController(
            IWeatherRepository weatherRepository, 
            IWeatherApiService weatherApiService,
            IMapper mapper) 
            : base(weatherRepository, weatherApiService, mapper)
        {
        }

        [HttpGet]
        [Route("{latitude}/{longitude}")]
        public async Task<IActionResult> GetWeather(
            [FromRoute][Range(-90, 90)] double latitude,
            [FromRoute][Range(-180, 180)] double longitude)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            WeatherApiResponse response;
            var result = await _weatherRepository.GetByParameter(latitude, longitude);
            if (result != null)
            {
                response = _mapper.Map<WeatherApiResponse>(result);
            }
            else
            {
                response = await _weatherApiService.GetWeatherForecast(latitude, longitude);

                var weather = _mapper.Map<Weather>(response);
                _weatherRepository.Add(weather);
            }

            return Ok(response);
        }
    }
}
