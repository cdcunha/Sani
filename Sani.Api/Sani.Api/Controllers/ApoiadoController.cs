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
        private readonly IApoiadoRepository _apoiadoRepository;
        //private IMongoCollection<Apoiado> apoiados;
        
        //public ApoiadoController(MongoClient client)
        //public ApoiadoController(IApoiadoRepository apoiadoRepository)
        public ApoiadoController(MongoDbContext context)
        {
            //_apoiadoRepository = new ApoiadoRepository();
            //apoiados = ControllersUtils.GetDatabase(client).GetCollection<Apoiado>(nameof(apoiados));
            _apoiadoRepository = context.GetApoiadoRepository();
            //_context = context;
            //_apoiadoRepository = apoiadoRepository;
        }

        [HttpGet]
        //[Route("api/[controller]")]
        public IEnumerable<Apoiado> GetAll()
        {
            //var resultado = apoiados.Find(FilterDefinition<Apoiado>.Empty).SortBy(it => it.Nome);//.Skip(0).Limit(50);
            //return resultado.ToList();
            return _apoiadoRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetApoio")]
        //[HttpGet]
        //[Route("api/[controller]/{id}")]
        public IActionResult GetById(ObjectId id)
        {
            //var resultado = apoiados.Find(Builders<Apoiado>.Filter.Eq("_id", ObjectId.Parse(id))).FirstOrDefault();
            //return resultado;
            var item = _apoiadoRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        /*[HttpGet]
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
        }*/

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[Route("api/[controller]")]
        public IActionResult Create([FromBody] Apoiado apoiado)//[FromBody]dynamic body)
        {
            //Apoiado apoiado = new Apoiado((string)body.nome);
            //apoiados.InsertOne(apoiado);
            //return apoiado;
            if (apoiado == null)
            {
                return BadRequest();
            }
            _apoiadoRepository.Add(apoiado);
            return CreatedAtRoute("GetApoio", new { id = apoiado.Id }, apoiado);
        }

        [HttpPut("{id}")]
        //[HttpPut]
        //[Route("api/[controller]/{id}")]
        public IActionResult Update(ObjectId id, [FromBody]Apoiado item)
        {
            /*Apoiado apoiado = new Apoiado((string)body.nome);
            apoiado.Id = ObjectId.Parse(id);

            //voluntarios.UpdateOne(Builders<Voluntario>.Filter.Eq(p => p.Id, voluntario.Id), voluntario);
            apoiados.ReplaceOne(Builders<Apoiado>.Filter.Eq(p => p.Id, apoiado.Id), apoiado);

            return apoiado;
            */
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var apoiado = _apoiadoRepository.Find(id);
            if (apoiado == null)
            {
                return NotFound();
            }

            apoiado.Nome = item.Nome;

            _apoiadoRepository.Update(apoiado);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        //[HttpDelete]
        //[Route("api/[controller]/{id}")]
        public IActionResult Delete(ObjectId id)
        {
            /*Apoiado apoiado = GetDetail(id);
            DeleteResult result = apoiados.DeleteOne(Builders<Apoiado>.Filter.Eq(p => p.Id, ObjectId.Parse(id)));
            if (result.DeletedCount < 1)
            {
                if (apoiado == null)
                    apoiado = new Apoiado("Erro detelando");
                apoiado.Notifications.Handle("500", "O Registro não foi encontrado");
            }
            return apoiado;
            */
            var apoiado = _apoiadoRepository.Find(id);
            if (apoiado == null)
            {
                return NotFound();
            }

            _apoiadoRepository.Remove(id);
            return new NoContentResult();
        }
    }
}
