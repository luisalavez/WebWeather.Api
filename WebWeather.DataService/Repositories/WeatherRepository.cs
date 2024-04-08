using MongoDB.Driver;
using WebWeather.DataService.Data;
using WebWeather.DataService.Repositories.Interfaces;
using WebWeather.Entities.DBSet;

namespace WebWeather.DataService.Repositories
{
    public class WeatherRepository : GenericRepository<Weather>, IWeatherRepository
    {
        private readonly IMongoCollection<Weather> _weatherCollection;
        public WeatherRepository(AppDbContext dbContext) : base(dbContext)
        {
            _weatherCollection = dbContext.GetCollection<Weather>(typeof(Weather).Name);
        }

        public override async Task<Weather?> GetByParameter(double latitude, double longitude)
        {
            var filter = Builders<Weather>.Filter.Eq(w => w.Latitude, latitude) &
                     Builders<Weather>.Filter.Eq(w => w.Longitude, longitude);

            var result = await _weatherCollection.Find(filter).FirstOrDefaultAsync();

            return result;
        }
    }
}
