using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Sani.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sani.Api.Controllers
{
    [Controller]
    public class VoluntarioController : Controller
    {
        private IMongoCollection<Voluntario> voluntarios;

        public VoluntarioController(MongoClient client)
        {
            voluntarios = ControllersUtils.GetDatabase(client).GetCollection<Voluntario>(nameof(voluntarios));
        }

        [HttpGet]
        [Route("api/[controller]")]
        public List<Voluntario> Get()
        {
            var resultado = voluntarios.Find(FilterDefinition<Voluntario>.Empty).SortBy(it => it.Nome);//.Skip(0).Limit(50);
            return resultado.ToList();
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Voluntario GetDetail(string id)
        {
            var resultado = voluntarios.Find(Builders<Voluntario>.Filter.Eq("Id", ObjectId.Parse(id))).FirstOrDefault();
            return resultado;
        }

        [HttpGet]
        [Route("api/[controller]/{nome}")]
        public List<Voluntario> Get(string nome)
        {
            var resultado = voluntarios.Find(it => it.Nome.Contains(nome)).SortBy(it => it.Nome).Skip(0).Limit(50);
            //var resultado = voluntarios.Find(Builders<Voluntario>.Filter.Eq("Id", ObjectId.Parse(id)));
            #region
            if (!resultado.Any())
            {
                Voluntario n = new Voluntario("dr. José Maria");
                voluntarios.InsertOne(n);

                n = new Voluntario("dr. José Pedro");
                voluntarios.InsertOne(n);

                n = new Voluntario("dr. Carlos José");
                n.Nome = "Monitor";
                voluntarios.InsertOne(n);

                n = new Voluntario("dra. Marilda Abravanel");
                voluntarios.InsertOne(n);

                n = new Voluntario("dr. Nivaldo Damasceno");
                voluntarios.InsertOne(n);
            }
            #endregion
            return resultado.ToList();
        }
        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("api/[controller]")]
        public Voluntario Post([FromBody]dynamic body)
        {
            Voluntario voluntario = new Voluntario((string)body.nome);
            voluntarios.InsertOne(voluntario);
            return voluntario;
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public Voluntario Put(string id, [FromBody]dynamic body)
        {
            Voluntario voluntario = new Voluntario((string)body.nome);
            voluntario.Id = ObjectId.Parse(id);
            
            //voluntarios.UpdateOne(Builders<Voluntario>.Filter.Eq(p => p.Id, voluntario.Id), voluntario);
            voluntarios.ReplaceOne(Builders<Voluntario>.Filter.Eq(p => p.Id, voluntario.Id), voluntario);

            return voluntario;
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public Voluntario Delete(string id)
        {
            Voluntario voluntario = GetDetail(id);
            voluntarios.DeleteOne(Builders<Voluntario>.Filter.Eq(p => p.Id, ObjectId.Parse(id)));
            return voluntario;
        }
    }
}
