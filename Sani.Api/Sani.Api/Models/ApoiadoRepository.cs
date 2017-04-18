using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sani.Api.Models
{
    public class ApoiadoRepository : IApoiadoRepository
    {
        private readonly MongoDbContext _context;

        public ApoiadoRepository(MongoDbContext context)
        {
            _context = context;
            var resultado = _context.Apoiados.Find(FilterDefinition<Sani.Api.Models.Apoiado>.Empty).Skip(1);
            if (!resultado.Any())
                Add(new Apoiado("Apoiado Teste"));
        }

        public void Add(Apoiado apoiado)
        {
            _context.Apoiados.InsertOne(apoiado);

            //_context.Apoiados.Add(apoiado);
            //_context.SaveChanges();
        }

        public Apoiado Find(Guid id)
        {
            var resultado = _context.Apoiados.Find(Builders<Apoiado>.Filter.Eq("_id", id)).FirstOrDefault();
            return resultado;
        }

        public IEnumerable<Apoiado> GetAll()
        {
            var resultado = _context.Apoiados.Find(FilterDefinition<Apoiado>.Empty).SortBy(it => it.Nome);//.Skip(0).Limit(50)
            return resultado.ToList();
        }

        public void Remove(Guid id)
        {
            _context.Apoiados.DeleteOne(Builders<Apoiado>.Filter.Eq(p => p.Id, id));

            //var apoiado = _context.Apoiados.First(t => t.Id == id);
            //_context.Apoiados.Remove(apoiado);
            _context.SaveChanges();
        }

        public void Update(Apoiado apoiado)
        {
            _context.Apoiados.ReplaceOne(Builders<Apoiado>.Filter.Eq(p => p.Id, apoiado.Id), apoiado);
            //_context.Apoiados.Update(apoiado);
            //_context.SaveChanges();
        }
    }
}
