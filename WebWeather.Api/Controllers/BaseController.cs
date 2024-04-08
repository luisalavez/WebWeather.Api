using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebWeather.DataService.Repositories.Interfaces;
using WebWeather.DataService.Services.IService;

namespace WebWeather.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        protected readonly IWeatherRepository _weatherRepository;
        protected readonly IWeatherApiService _weatherApiService;
        protected readonly IMapper _mapper;
        public BaseController(
            IWeatherRepository weatherRepository, 
            IWeatherApiService weatherApiService,
            IMapper mapper)
        {
            _weatherRepository = weatherRepository;
            _weatherApiService = weatherApiService;
            _mapper = mapper;
        }
    }
}
