using MongoDB.Driver;
using WebWeather.DataService.Data;
using WebWeather.DataService.Models;
using WebWeather.DataService.Repositories.Interfaces;

namespace WebWeather.DataService.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public GenericRepository(AppDbContext dbContext)
        {
            _collection = dbContext.GetCollection<T>(GetCollectionName(typeof(T)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName ?? documentType.Name;
        }
        public virtual void Add(T entity)
        {
            _collection.InsertOne(entity);
        }

        public virtual Task<T?> GetByParameter(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }
    }
}
