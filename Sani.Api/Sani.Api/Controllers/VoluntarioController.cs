using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Sani.Api.Assertions;
using Sani.Api.Models;
using Sani.Api.Repository;
using System;
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
        public IActionResult GetById(System.Guid id)
        {
            if (id == Guid.Empty)
            {
                var error = new
                {
                    value = "O parâmetro id deve possuir um valor",
                    status = Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError
                };
                Response.StatusCode = error.status;
                return new ObjectResult(error);
            }
            else
            {
                var item = _voluntarioRepository.Find(id);
                if (item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
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
            if (string.IsNullOrEmpty(body.ToString()))
            {
                return BadRequest();
            }
            Voluntario voluntario = new Voluntario(((JValue)body.SelectToken("nome")).Value.ToString());
            voluntario.DeserializeJson(body); //Converte Json para o objeto Apoiado

            //Verifica se há inconsistência nos dados
            VoluntarioAssertion voluntarioAssertion = new VoluntarioAssertion(voluntario, true);
            if (voluntarioAssertion.Notifications.HasNotifications())
            {
                Response.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError;
                return new ObjectResult(voluntarioAssertion.Notifications.Notify());
            }

            _voluntarioRepository.Add(voluntario);
            //return CreatedAtRoute("GetApoio", new { id = apoiado.Id }, apoiado);
            Response.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status201Created;
            return new ObjectResult(voluntario);
        }

        [HttpPut("api/[controller]/{id}")]
        //[Route("api/[controller]/{id}")]
        public IActionResult Update(Guid id, [FromBody]dynamic body)//[FromBody]Voluntario item)
        {
            if (string.IsNullOrEmpty(body.ToString()))
            {
                return BadRequest();
            }

            //Verifica se o registro existe na base
            var voluntarioFounded = _voluntarioRepository.Find(id);
            if (voluntarioFounded == null)
            {
                return NotFound();
            }

            Voluntario voluntarioNew = new Voluntario();
            voluntarioNew = voluntarioFounded;
            voluntarioNew.DeserializeJson(body); //Converte Json para o objeto Apoiado
            voluntarioNew.DataAlteracao = System.DateTime.Now;

            //Verifica se há inconsistência nos dados
            VoluntarioAssertion voluntarioAssertion = new VoluntarioAssertion(voluntarioNew);
            if (voluntarioAssertion.Notifications.HasNotifications())
            {
                Response.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError;
                return new ObjectResult(voluntarioAssertion.Notifications.Notify());
            }
            _voluntarioRepository.Update(voluntarioNew);
            //return new NoContentResult();
            Response.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status200OK;
            return new ObjectResult(voluntarioNew);
        }

        [HttpDelete("api/[controller]/{id}")]
        //[Route("api/[controller]/{id}")]
        public IActionResult Delete(System.Guid id)
        {
            var voluntario = _voluntarioRepository.Find(id);
            if (voluntario == null)
            {
                return NotFound();
            }

            _voluntarioRepository.Remove(id);
            Response.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status200OK;
            return new ObjectResult(voluntario);
        }
    }
}
