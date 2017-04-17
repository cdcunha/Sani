using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sani.Api
{
    public static class MongoDbSupport
    {
        public static void AddMongo(this IServiceCollection services, IConfigurationSection configuration)
        {
            services.AddSingleton(Controllers.ControllersUtils.GetMongoClient(configuration.GetSection("SaniDbConnection").Value));
        }
    }
}
