using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWeather.DataService.Models;
using WebWeather.Entities.DBSet;

namespace WebWeather.DataService.Data
{
    public class AppDbContext 
    {
        private readonly IMongoDatabase _database;

        public AppDbContext(IMongoDatabase database)
        {
            _database = database;

        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }

    }
}
