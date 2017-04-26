using Microsoft.AspNetCore.Mvc;
using Sani.Api.Models;
using Sani.Api.Repository;
using System.Collections.Generic;

namespace Sani.Api.Controllers
{
    [Controller]
    public class VoluntarioController : Controller
    {
        private readonly IVoluntarioRepository _voluntarioRepository;

        public VoluntarioController(MongoDbContext context)
        {
            _voluntarioRepository = context.GetVoluntarioRepository();
        }

        [HttpGet("api/[controller]")]
        //[Route("api/[controller]")]
        public IEnumerable<Voluntario> Get()
        {
            return _voluntarioRepository.GetAll();
        }

        [HttpGet("api/[controller]/{id}", Name = "GetVoluntario")]
        //[Route("api/[controller]/{id}")]
        public IActionResult GetDetail(System.Guid id)
        {
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
        public IActionResult Create([FromBody]dynamic body)//[FromBody] Voluntario voluntario)
        {
            /*if (voluntario == null)
            {
                return BadRequest();
            }
            _voluntarioRepository.Add(voluntario);
            return CreatedAtRoute("GetVoluntario", new { id = voluntario.Id }, voluntario);
            */
            return new NoContentResult();
        }

        [HttpPut("api/[controller]/{id}")]
        //[Route("api/[controller]/{id}")]
        public IActionResult Update(System.Guid id, [FromBody]dynamic body)//[FromBody]Voluntario item)
        {
            /*if (item == null || item.Id != id)
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
            */
            return new NoContentResult();
        }

        [HttpDelete("api/[controller]/{id}")]
        //[Route("api/[controller]/{id}")]
        public IActionResult Delete(System.Guid id)
        {
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
