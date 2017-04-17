using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Sani.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sani.Api.Controllers
{
    [Controller]
    public class ApoiadoController : Controller
    {
        private IMongoCollection<Apoiado> apoiados;

        public ApoiadoController(MongoClient client)
        {
            apoiados = ControllersUtils.GetDatabase(client).GetCollection<Apoiado>(nameof(apoiados));
        }

        [HttpGet]
        [Route("api/[controller]")]
        public List<Apoiado> Get()
        {
            var resultado = apoiados.Find(FilterDefinition<Apoiado>.Empty).SortBy(it => it.Nome);//.Skip(0).Limit(50);
            return resultado.ToList();
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Apoiado GetDetail(string id)
        {
            var resultado = apoiados.Find(Builders<Apoiado>.Filter.Eq("_id", ObjectId.Parse(id))).FirstOrDefault();
            return resultado;
        }

        [HttpGet]
        [Route("api/[controller]/{nome}")]
        public List<Apoiado> Get(string nome)
        {
            var resultado = apoiados.Find(it => it.Nome.Contains(nome))
                .SortBy(it => it.Nome).Skip(0).Limit(50);
            if (!resultado.Any())
            {
                Apoiado n = new Apoiado("José Maria");
                apoiados.InsertOne(n);

                n = new Apoiado("José Pedro");
                apoiados.InsertOne(n);

                n = new Apoiado("Carlos José");
                n.Nome = "Monitor";
                apoiados.InsertOne(n);

                n = new Apoiado("Marilda Abravanel");
                apoiados.InsertOne(n);

                n = new Apoiado("Nivaldo Damasceno");
                apoiados.InsertOne(n);
            }

            
            //Notifications.Handle("TESTE", "Teste de erro");

            //return CreateResponse(HttpStatusCode.Created, resultado);
            return resultado.ToList();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("api/[controller]")]
        public Apoiado Post(Apoiados apoiados)//[FromBody]dynamic body)
        {
            Apoiado apoiado = new Apoiado((string)body.nome);
            apoiados.InsertOne(apoiado);
            return apoiado;
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public Apoiado Put(string id, [FromBody]dynamic body)
        {
            Apoiado apoiado = new Apoiado((string)body.nome);
            apoiado.Id = ObjectId.Parse(id);

            //voluntarios.UpdateOne(Builders<Voluntario>.Filter.Eq(p => p.Id, voluntario.Id), voluntario);
            apoiados.ReplaceOne(Builders<Apoiado>.Filter.Eq(p => p.Id, apoiado.Id), apoiado);

            return apoiado;
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public Apoiado Delete(string id)
        {
            Apoiado apoiado = GetDetail(id);
            DeleteResult result = apoiados.DeleteOne(Builders<Apoiado>.Filter.Eq(p => p.Id, ObjectId.Parse(id)));
            if (result.DeletedCount < 1)
            {
                if (apoiado == null)
                    apoiado = new Apoiado("Erro detelando");
                apoiado.Notifications.Handle("500", "O Registro não foi encontrado");
            }
            return apoiado;
        }
    }
}
