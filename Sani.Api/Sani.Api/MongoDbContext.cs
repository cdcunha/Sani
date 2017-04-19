using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Sani.Api.Controllers;
using Sani.Api.Models;
using Sani.Api.Repository;

namespace Sani.Api
{
    public class MongoDbContext : DbContext
    {
        //private IMongoDatabase _mongoDatabase;
        public MongoDbContext(MongoClient mongoClient)
        {
            IMongoDatabase _mongoDatabase = ControllersUtils.GetDatabase(mongoClient);

            Apoiados = _mongoDatabase.GetCollection<Apoiado>("Apoiado");
            Voluntarios = _mongoDatabase.GetCollection<Voluntario>("Voluntario");
        }

        public IApoiadoRepository GetApoiadoRepository()
        {
            return new ApoiadoRepository(this);
        }

        public IVoluntarioRepository GetVoluntarioRepository()
        {
            return new VoluntarioRepository(this);
        }

        public IMongoCollection<Apoiado> Apoiados { get; set; }
        public IMongoCollection<Voluntario> Voluntarios { get; set; }
        
    }
}
