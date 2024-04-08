using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWeather.DataService.Models;

namespace WebWeather.Entities.DBSet
{
    [BsonCollection("Weather")]
    public class Weather : BaseEntity
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string TimeZone { get; set; } = string.Empty;
        public CurrentWeather Current { get; set; }
        public DailyWeather Daily { get; set; }
    }

    public class CurrentWeather
    {
        public double Temperature { get; set; }
        public double Wind_Speed { get; set; }
        public double Wind_Direction { get; set; }
    }

    public class DailyWeather
    {
        public string[] Time { get; set; }
        public string[] Sunrise { get; set; }
    }

}
