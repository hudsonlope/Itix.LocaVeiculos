using Itix.LocaVeiculos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.LocaVeiculos.Dominio.Contratos
{
    public interface IBaseRepositorio<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetList();
        long Insert(TEntity entity);
        bool InsertList(List<TEntity> listEntity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        IEnumerable<TEntity> Query(string query);
    }
}
