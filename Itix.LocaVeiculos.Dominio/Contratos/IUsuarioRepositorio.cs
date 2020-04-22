using Itix.LocaVeiculos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.LocaVeiculos.Dominio.Contratos
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        Usuario Get(string email, string senha);
        Usuario Get(string email);
    }
}
