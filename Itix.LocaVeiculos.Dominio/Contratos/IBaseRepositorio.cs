using Itix.LocaVeiculos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.LocaVeiculos.Dominio.Contratos
{
    public interface IBaseRepositorio
    {
        TEntity Get<TEntity>(int id) where TEntity : class;
        IEnumerable<TEntity> GetList<TEntity>() where TEntity : class;
        long Insert<TEntity>(TEntity entity) where TEntity : class;
        bool InsertList<TEntity>(List<TEntity> listEntity) where TEntity : class;
        bool Update<TEntity>(TEntity entity) where TEntity : class;
        bool Delete<TEntity>(TEntity entity) where TEntity : class;
        IEnumerable<TEntity> Query<TEntity>(string query) where TEntity : class;

        IEnumerable<Carro> InnerJoinCategoriaCarro();
    }
}
