using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sani.Api
{
    public static class MongoDbSupport
    {
        public static void AddMongo(this IServiceCollection services, IConfigurationSection configuration)
        {
            //services.AddSingleton(Controllers.ControllersUtils.GetMongoClient(configuration.GetSection("SaniDbConnection").Value));
            services.AddSingleton(new MongoDbContext(Controllers.ControllersUtils.GetMongoClient(configuration.GetSection("SaniDbConnection").Value)));
        }
    }
}
