using Itix.LocaVeiculos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.LocaVeiculos.Dominio.Contratos
{
    public interface ICarroRepositorio : IBaseRepositorio<Carro>
    {
        IEnumerable<Carro> InnerJoinCategoriaCarro();
    }
}
