using Microsoft.AspNetCore.Mvc;
using Sani.Api.Assertions;
using Sani.Api.Models;
using Sani.Api.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sani.Api.Controllers
{
    [Controller]
    public class ApoiadoController : Controller
    {
        private readonly IApoiadoRepository _apoiadoRepository;

        public ApoiadoController(MongoDbContext context)
        {
            _apoiadoRepository = context.GetApoiadoRepository();
        }

        [HttpGet("api/[controller]")]
        //[Route("api/[controller]")]
        public IEnumerable<Apoiado> GetAll()
        {
                return _apoiadoRepository.GetAll();
        }

        [HttpGet("api/[controller]/{id}", Name = "GetApoio")]
        //[HttpGet]
        //[Route("api/[controller]/{id}")]
        public IActionResult GetById(Guid id)
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
                var item = _apoiadoRepository.Find(id);
                if (item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
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

        [HttpPost("api/[controller]")]
        //[ValidateAntiForgeryToken]
        //[Route("api/[controller]")]
        public IActionResult Create([FromBody] Apoiado apoiado)//[FromBody]dynamic body)
        {
            
            if (apoiado == null)
            {
                return BadRequest();
            }
            _apoiadoRepository.Add(apoiado);
            return CreatedAtRoute("GetApoio", new { id = apoiado.Id }, apoiado);
        }

        [HttpPut("api/[controller]/{id}")]
        //[HttpPut]
        //[Route("api/[controller]/{id}")]
        public IActionResult Update(Guid id, [FromBody]Apoiado apoiadoNew)
        {   
            if (apoiadoNew == null || apoiadoNew.Id != id)
            {
                return BadRequest();
            }

            var apoiadoFounded = _apoiadoRepository.Find(id);
            if (apoiadoFounded == null)
            {
                return NotFound();
            }

            ApoiadoAssertion apoiadoAssertion = new ApoiadoAssertion(apoiadoNew);
            if (apoiadoAssertion.Notifications.HasNotifications())
            {
                Response.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError;
                return new ObjectResult(apoiadoAssertion.Notifications.Notify());
            }
            else
            {
                //apoiado.Nome = apoiadoNew.Nome;
                _apoiadoRepository.Update(apoiadoNew);
                return new NoContentResult();
            }
        }

        [HttpDelete("api/[controller]/{id}")]
        //[HttpDelete]
        //[Route("api/[controller]/{id}")]
        public IActionResult Delete(Guid id)
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
