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
            /*if (!resultado.Any())
            {
                Produto p = new Produto();
                p.descricao = "TV";
                prods.InsertOne(p);

                p = new Produto();
                p.descricao = "SmarthPhone";
                prods.InsertOne(p);

                p = new Produto();
                p.descricao = "Monitor";
                prods.InsertOne(p);

                p = new Produto();
                p.descricao = "Cabo";
                prods.InsertOne(p);

                p = new Produto();
                p.descricao = "Impressora";
                prods.InsertOne(p);
            }*/
            return resultado.ToList();
        }
    }
}
