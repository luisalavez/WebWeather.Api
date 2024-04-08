using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWeather.Entities.DBSet;

namespace WebWeather.DataService.Repositories.Interfaces
{
    public interface IWeatherRepository : IGenericRepository<Weather>
    {
    }
}
