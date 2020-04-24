using Itix.LocaVeiculos.Dominio.Contratos;
using Itix.LocaVeiculos.Dominio.Entidades;
using Itix.LocaVeiculos.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itix.LocaVeiculos.Web.Controllers
{
    [Route("api/[controller]")]
    public class CarroController : Controller
    {
        private readonly ICarroRepositorio _db;
        //private readonly ICategoriaRepositorio _dbCategoria;
        public CarroController(ICarroRepositorio carroRepositorio)
        {
            _db = carroRepositorio;
            //_dbCategoria = categoriaRepositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_db.GetList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Carro carro)
        {
            try
            {
                var erros = Validacao.getValidationErros(carro);
                if (erros.Count() != 0)
                    return BadRequest(string.Join(". ", erros));

                carro.DtCadastro = DateTime.Now;
                carro.Carro_Id = _db.InsertCarro(carro);
                return Created("api/carro", carro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //public IActionResult ObterCategorias()
        //{
        //    try
        //    {
        //        return Ok(_dbCategoria.GetList());
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.ToString());
        //    }
        //}

    }
}
