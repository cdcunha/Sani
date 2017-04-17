using MongoDB.Driver;

namespace Sani.Api.Controllers
{
    public static class ControllersUtils
    {
        public static IMongoDatabase GetDatabase(MongoClient client)
        {
            //string connectionString = "mongodb://localhost:27017";
            //MongoClient client = new MongoClient(connectionString);
            return client.GetDatabase("Sani");
        }

        public static MongoClient GetMongoClient(string connectionString)
        {
            return new MongoClient(connectionString);
        }
    }
}
