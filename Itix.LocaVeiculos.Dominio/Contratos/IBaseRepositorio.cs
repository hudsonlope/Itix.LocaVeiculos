using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.LocaVeiculos.Dominio.Contratos
{
    public interface IBaseRepositorio<TEntity> : IDisposable
        where TEntity : class
    {
        void Inserir(TEntity entity);
        void Deletar(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetList();
    }
}
