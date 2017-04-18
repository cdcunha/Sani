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
        private readonly IVoluntarioRepository _voluntarioRepository;
        //private IMongoCollection<Voluntario> voluntarios;

        public VoluntarioController(MongoDbContext context)
        {
            //voluntarios = ControllersUtils.GetDatabase(client).GetCollection<Voluntario>(nameof(voluntarios));
            _voluntarioRepository = context.GetVoluntarioRepository();
        }

        [HttpGet("api/[controller]")]
        //[Route("api/[controller]")]
        public IEnumerable<Voluntario> Get()
        {
            /*var resultado = voluntarios.Find(FilterDefinition<Voluntario>.Empty).SortBy(it => it.Nome);//.Skip(0).Limit(50);
            return resultado.ToList();
            */
            return _voluntarioRepository.GetAll();
        }

        [HttpGet("api/[controller]/{id}", Name = "GetVoluntario")]
        //[Route("api/[controller]/{id}")]
        public IActionResult GetDetail(System.Guid id)
        {
            /*var resultado = voluntarios.Find(Builders<Voluntario>.Filter.Eq("Id", ObjectId.Parse(id))).FirstOrDefault();
            return resultado;
            */
            var item = _voluntarioRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        /*[HttpGet]
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
        */
        
        [HttpPost("api/[controller]")]
        //[ValidateAntiForgeryToken]
        //[Route("api/[controller]")]
        public IActionResult Create([FromBody] Voluntario voluntario)//[FromBody]dynamic body)
        {
            /*Voluntario voluntario = new Voluntario((string)body.nome);
            voluntarios.InsertOne(voluntario);
            return voluntario;
            */
            if (voluntario == null)
            {
                return BadRequest();
            }
            _voluntarioRepository.Add(voluntario);
            return CreatedAtRoute("GetVoluntario", new { id = voluntario.Id }, voluntario);
        }

        [HttpPut("api/[controller]/{id}")]
        //[Route("api/[controller]/{id}")]
        public IActionResult Update(System.Guid id, [FromBody]Voluntario item)
        {
            /*Voluntario voluntario = new Voluntario((string)body.nome);
            voluntario.Id = ObjectId.Parse(id);
            
            //voluntarios.UpdateOne(Builders<Voluntario>.Filter.Eq(p => p.Id, voluntario.Id), voluntario);
            voluntarios.ReplaceOne(Builders<Voluntario>.Filter.Eq(p => p.Id, voluntario.Id), voluntario);

            return voluntario;
            */
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var apoiado = _voluntarioRepository.Find(id);
            if (apoiado == null)
            {
                return NotFound();
            }

            apoiado.Nome = item.Nome;

            _voluntarioRepository.Update(apoiado);
            return new NoContentResult();
        }

        [HttpDelete("api/[controller]/{id}")]
        //[Route("api/[controller]/{id}")]
        public IActionResult Delete(System.Guid id)
        {
            /*Voluntario voluntario = GetDetail(id);
            voluntarios.DeleteOne(Builders<Voluntario>.Filter.Eq(p => p.Id, ObjectId.Parse(id)));
            return voluntario;
            */
            var apoiado = _voluntarioRepository.Find(id);
            if (apoiado == null)
            {
                return NotFound();
            }

            _voluntarioRepository.Remove(id);
            return new NoContentResult();
        }
    }
}
