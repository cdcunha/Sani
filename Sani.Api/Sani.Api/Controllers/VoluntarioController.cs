using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Sani.Api.Models;
using Sani_api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sani.Api.Controllers
{
    [Route("api/[controller]")]
    public class VoluntarioController : Controller
    {
        [HttpGet("Get")]
        public List<Voluntario> Get(string nome = "")
        {
            var apoiados = ControllersUtils.GetDatabase().GetCollection<Voluntario>("Voluntario");
            var resultado = apoiados.Find(it => it.Nome.Contains(nome))
                .SortBy(it => it.Nome).Skip(0).Limit(50);
            if (!resultado.Any())
            {
                Apoiador n = new Apoiador("dr. José Maria");
                apoiados.InsertOne(n);

                n = new Apoiador("dr. José Pedro");
                apoiados.InsertOne(n);

                n = new Apoiador("dr. Carlos José");
                n.Nome = "Monitor";
                apoiados.InsertOne(n);

                n = new Apoiador("dra. Marilda Abravanel");
                apoiados.InsertOne(n);

                n = new Apoiador("dr. Nivaldo Damasceno");
                apoiados.InsertOne(n);
            }
            return resultado.ToList();
        }
    }
}
