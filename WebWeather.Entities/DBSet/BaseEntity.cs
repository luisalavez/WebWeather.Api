using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWeather.Entities.DBSet.Interface;

namespace WebWeather.Entities.DBSet
{
    public abstract class BaseEntity : IDocument
    {
        public ObjectId Id { get; set; }
    }
}
