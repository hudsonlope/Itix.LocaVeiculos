using Itix.LocaVeiculos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.LocaVeiculos.Dominio.Contratos
{
    public interface ICategoriaRepositorio
    {
        int Insert(Categoria categoria);
        List<Categoria> GetList();
        Categoria Get(int id);
        int Update(Categoria categoria);
        int Delete(int id);
    }
}
