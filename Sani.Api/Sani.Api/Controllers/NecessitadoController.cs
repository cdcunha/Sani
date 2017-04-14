using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Sani_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sani_api.Controllers
{
    [Route("api/[controller]")]
    public class NecessitadoController : Controller
    {
        [HttpGet("Get")]
        public List<Necessitado> Get(string nome = "")
        {
            var necessitados = ControllersUtils.GetDatabase().GetCollection<Necessitado>("Necessitado");
            var resultado = necessitados.Find(it => it.Nome.Contains(nome))
                .SortBy(it => it.Nome).Skip(0).Limit(50);
            if (!resultado.Any())
            {
                Necessitado n = new Necessitado("José Maria");
                necessitados.InsertOne(n);

                n = new Necessitado("José Pedro");
                necessitados.InsertOne(n);

                n = new Necessitado("Carlos José");
                n.Nome = "Monitor";
                necessitados.InsertOne(n);

                n = new Necessitado("Marilda Abravanel");
                necessitados.InsertOne(n);

                n = new Necessitado("Nivaldo Damasceno");
                necessitados.InsertOne(n);
            }
            return resultado.ToList();
        }
    }
}
