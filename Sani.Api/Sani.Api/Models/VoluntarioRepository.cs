using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sani.Api.Models
{
    public class VoluntarioRepository : IVoluntarioRepository
    {
        private readonly MongoDbContext _context;

        public VoluntarioRepository(MongoDbContext context)
        {
            _context = context;
            var resultado = _context.Voluntarios.Find(FilterDefinition<Voluntario>.Empty).Skip(1);
            if (!resultado.Any())
                Add(new Voluntario("Voluntario Teste"));
        }

        public void Add(Voluntario voluntario)
        {
            _context.Voluntarios.InsertOne(voluntario);

            //_context.Apoiados.Add(apoiado);
            //_context.SaveChanges();
        }

        public Voluntario Find(Guid id)
        {   
            var resultado = _context.Voluntarios.Find(Builders<Voluntario>.Filter.Eq("_id", id)).FirstOrDefault();
            return resultado;
        }

        public IEnumerable<Voluntario> GetAll()
        {
            var resultado = _context.Voluntarios.Find(FilterDefinition<Voluntario>.Empty).SortBy(it => it.Nome);//.Skip(0).Limit(50)
            return resultado.ToList();
        }

        public void Remove(Guid id)
        {
            _context.Voluntarios.DeleteOne(Builders<Voluntario>.Filter.Eq(p => p.Id, id));

            //var apoiado = _context.Apoiados.First(t => t.Id == id);
            //_context.Apoiados.Remove(apoiado);
            //_context.SaveChanges();
        }

        public void Update(Voluntario voluntario)
        {
            _context.Voluntarios.ReplaceOne(Builders<Voluntario>.Filter.Eq(p => p.Id, voluntario.Id), voluntario);
            //_context.Apoiados.Update(apoiado);
            //_context.SaveChanges();
        }
    }
}
