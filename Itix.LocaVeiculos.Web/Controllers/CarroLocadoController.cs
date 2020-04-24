using Itix.LocaVeiculos.Dominio.Contratos;
using Itix.LocaVeiculos.Dominio.Entidades;
using Itix.LocaVeiculos.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itix.LocaVeiculos.Web.Controllers
{
    [Route("api/[controller]")]
    public class CarroLocadoController : Controller
    {
        private readonly ICarroLocadoRepositorio _db;
        private readonly ICarroRepositorio _dbCarro;
        private readonly ICategoriaRepositorio _dbCategoria;
        public CarroLocadoController(ICarroLocadoRepositorio carroLocadoRepositorio, ICarroRepositorio carroRepositorio, ICategoriaRepositorio categoriaRepositorio)
        {
            _db = carroLocadoRepositorio;
            _dbCarro = carroRepositorio;
            _dbCategoria = categoriaRepositorio;
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
        public IActionResult Post([FromBody] CarroLocado carroLocado)
        {
            try
            {
                var sessionData = HttpContext.Session.GetString("usuario-autenticado");

                var erros = Validacao.getValidationErros(carroLocado);
                if (erros.Count() != 0)
                    return BadRequest(string.Join(". ", erros));

                carroLocado.DtReserva = DateTime.Now;

                var qtdTotalDias = carroLocado.DtUltimoDia - carroLocado.DtPrimeiroDia;
                carroLocado.QtdDiasLocado = qtdTotalDias.Days;

                double valorBase = ObterValorBase(carroLocado.Carro_Id);
                double valorFinalAlguel = CalcularValorAluguel(valorBase, carroLocado.QtdDiasLocado);

                carroLocado.CarroLocado_Id = _db.InsertCarroLocado(carroLocado);

                return Created("api/carroLocado", carroLocado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private double CalcularValorAluguel(double valorBase, int qtdTotalDias)
        {
            double descontoPorDia = (valorBase * 0.05);
            double descontoTotal;
            double valorAluguel;

            if (qtdTotalDias <= 2)
            {
                valorAluguel = valorBase * qtdTotalDias;
                return valorAluguel;
            }
            else if (qtdTotalDias >= 30)
            {
                double desconto = (valorBase * 0.20d);
                valorAluguel = valorBase - desconto;
                return valorAluguel;
            }
            else if (qtdTotalDias % 3 == 0)
            {
                descontoTotal = descontoPorDia * qtdTotalDias;
                valorAluguel = valorBase - descontoTotal;
                return valorAluguel;
            }

            //Calcula valor aplicando desconto de 5% a cada 3 diárias:
            int diasParaDiminuir = qtdTotalDias;
            while (diasParaDiminuir > 3)
            {
                diasParaDiminuir -= 3;
            }
            descontoTotal = descontoPorDia * (qtdTotalDias - diasParaDiminuir);
            valorAluguel = valorBase - descontoTotal;

            return valorAluguel;
        }

        private double ObterValorBase(int carro_Id)
        {
            var carro = _dbCarro.Get(carro_Id);
            var categoria = _dbCategoria.Get(carro.Categoria_Id);
            return (double)categoria.PrecoBaseDiaria;
        }

        [HttpGet]
        public IActionResult ObterCarros()
        {
            try
            {
                return Ok(_dbCarro.GetList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
