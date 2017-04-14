using MongoDB.Driver;
using System;

namespace Sani_api.Controllers
{
    public static class ControllersUtils
    {
        public static IMongoDatabase GetDatabase()
        {
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            return client.GetDatabase("Sani");
        }
    }
}
