using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itix.LocaVeiculos.Dominio.Contratos;
using Itix.LocaVeiculos.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Itix.LocaVeiculos.Web.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        IBaseRepositorio _db;
        public SampleDataController(IBaseRepositorio categoriaRepositorio)
        {
            _db = categoriaRepositorio;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            //var atualizar = _categoriaRepositorio.Get(5);

            //_categoriaRepositorio.Update(CategoriaNova);

            //var carro = new Carro() { Marca = "Toyota", Modelo = "Corolla", Ano = "2012", Cor = "Bege", Ativo = true, Chassi = "1234578fdfdf6544", Categoria_Id = 4, DtCadastro = DateTime.Now };

            //var retorno = _db.Insert<Carro>(carro);

            //var getTeste = _db.GetList<Carro>();

            //var tabelas = new List<string>() { "Categoria", "Carro" };

            //var getTeste1 = _db.InnerJoinCategoriaCarro();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
