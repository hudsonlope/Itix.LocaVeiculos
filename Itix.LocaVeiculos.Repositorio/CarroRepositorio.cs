using Itix.LocaVeiculos.Dominio.Contratos;
using Itix.LocaVeiculos.Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.LocaVeiculos.Repositorio
{
    public class CarroRepositorio : BaseRepositorio<Carro>, ICarroRepositorio
    {
        public CarroRepositorio(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<Carro> InnerJoinCategoriaCarro()
        {
            return new List<Carro>();
        }
    }
}
