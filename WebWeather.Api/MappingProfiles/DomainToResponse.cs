using AutoMapper;
using WebWeather.Entities.DBSet;
using WebWeather.Entities.Dtos.Responses;

namespace WebWeather.Api.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse() 
        {
            CreateMap<Weather, WeatherApiResponse>()
            .ForMember(dest => dest.Current, opt => opt.MapFrom(src => new Entities.Dtos.Responses.CurrentWeather
            {
                Temperature = src.Current.Temperature,
                Wind_Speed = src.Current.Wind_Speed,
                Wind_Direction = src.Current.Wind_Direction,
            }))
            .ForMember(dest => dest.Daily, opt => opt.MapFrom(src => new Entities.Dtos.Responses.DailyWeather
            {
                Sunrise = src.Daily.Sunrise,
                Time = src.Daily.Time,
            }));

        }

    }
}
