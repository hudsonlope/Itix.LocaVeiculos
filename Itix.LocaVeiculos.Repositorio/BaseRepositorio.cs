using Dapper;
using Dapper.Contrib.Extensions;
using Itix.LocaVeiculos.Dominio.Contratos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Itix.LocaVeiculos.Repositorio
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        //private readonly IConfiguration _configuration;
        protected readonly string ConnectionString;

        public BaseRepositorio(IConfiguration configuration)
        {
            IConfiguration _configuration = configuration;
            ConnectionString = _configuration.GetSection("ConnectionStrings").GetSection("LocaVeiculos").Value;
        }

        public TEntity Get(int id)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Get<TEntity>(id);
            }
        }

        public IEnumerable<TEntity> GetList()
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.GetAll<TEntity>();
            }
        }

        public long Insert(TEntity entity)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Insert<TEntity>(entity);
            }
        }

        public bool InsertList(List<TEntity> listEntity)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.BeginTransaction();
                try
                {
                    foreach (var entity in listEntity)
                    {
                        con.Insert<TEntity>(entity);
                    }
                    con.BeginTransaction().Commit();
                    return true;
                }
                catch (Exception)
                {
                    con.BeginTransaction().Rollback();
                    return false;
                }
            }
        }

        public bool Update(TEntity entity)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Update<TEntity>(entity);
            }
        }

        public bool Delete(TEntity entity)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Delete<TEntity>(entity);
            }
        }

        public IEnumerable<TEntity> Query(string query)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<TEntity>(query);
            }
        }
    }
}
