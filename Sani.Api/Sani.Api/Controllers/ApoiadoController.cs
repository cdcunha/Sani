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
    public class ApoiadoController : Controller
    {
        [HttpGet("Get")]
        public List<Apoiado> Get(string nome = "")
        {
            var apoiados = ControllersUtils.GetDatabase().GetCollection<Apoiado>("Apoiado");
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
            return resultado.ToList();
        }
    }
}
