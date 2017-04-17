using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Sani.Api.Controllers;
using Sani.Api.Models;
using System.Collections.Generic;

namespace Sani.Api
{
    public class MongoDbContext : DbContext
    {
        //private IMongoDatabase _mongoDatabase;
        public MongoDbContext(MongoClient mongoClient)
        {
            IMongoDatabase _mongoDatabase = ControllersUtils.GetDatabase(mongoClient);

            var Apoiado = _mongoDatabase.GetCollection<Apoiado>("Apoiado");
        }

        public IApoiadoRepository GetApoiadoRepository()
        {
            return new ApoiadoRepository(this);
        }
        
        public IMongoCollection<Apoiado> Apoiados { get; set; }
        public IMongoCollection<Voluntario> Voluntarios { get; set; }
        
    }
}
