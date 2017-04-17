using Microsoft.EntityFrameworkCore;
using Sani.Api.Models;

namespace Sani.Api
{
    public class MongoDbContext : DbContext
    {
        public MongoDbContext() { }

        public DbSet<Apoiado> Apoiados { get; set; }
        public DbSet<Voluntario> Voluntarios { get; set; }

        
    }
}
