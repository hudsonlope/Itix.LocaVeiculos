using Dapper;
using Itix.LocaVeiculos.Dominio.Contratos;
using Itix.LocaVeiculos.Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Dapper.Contrib.Extensions;
using Slapper;

namespace Itix.LocaVeiculos.Repositorio
{
    public class RepositorioDapper : IBaseRepositorio
    {
        //private readonly IConfiguration _configuration;
        protected readonly string ConnectionString;

        public RepositorioDapper(IConfiguration configuration)
        {
            IConfiguration _configuration = configuration;
            ConnectionString = _configuration.GetSection("ConnectionStrings").GetSection("LocaVeiculos").Value;
        }

        //public void GetConnection()
        //{
        //    connectionString = _configuration.GetSection("ConnectionStrings").GetSection("LocaVeiculos").Value;
        //    //return connection;
        //}

        public TEntity Get<TEntity>(int id) where TEntity : class
        {
            //var connectionString = this.GetConnection();
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Get<TEntity>(id);
            }
        }

        public IEnumerable<TEntity> GetList<TEntity>() where TEntity : class
        {
            //var connectionString = this.GetConnection();
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.GetAll<TEntity>();
            }
        }

        public long Insert<TEntity>(TEntity entity) where TEntity : class
        {
            //var connectionString = this.GetConnection();
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Insert<TEntity>(entity);
            }
        }

        public bool InsertList<TEntity>(List<TEntity> listEntity) where TEntity : class
        {
            //var connectionString = this.GetConnection();
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

        public bool Update<TEntity>(TEntity entity) where TEntity : class
        {
            //var connectionString = this.GetConnection();
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Update<TEntity>(entity);
            }
        }

        public bool Delete<TEntity>(TEntity entity) where TEntity : class
        {
            //var connectionString = this.GetConnection();
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Delete<TEntity>(entity);
            }
        }

        public IEnumerable<TEntity> Query<TEntity>(string query) where TEntity : class
        {
            //var connectionString = this.GetConnection();
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<TEntity>(query);
            }
        }

        public IEnumerable<Carro> InnerJoinCategoriaCarro()
        {
            //List<Categoria> ret;
            //var connectionString = this.GetConnection();
            using (var con = new SqlConnection(ConnectionString))
            {
                //var sql = @"select 
                //            CAR.Id, 
                //            CAR.Ativo, 
                //            CAR.Marca, 
                //            CAR.Modelo, 
                //            CAR.Ano, 
                //            CAR.Cor, 
                //            CAR.Chassi, 
                //            CAR.DtCadastro,
                //            CAT.Id, 
                //            CAT.NomeCategoria, 
                //            CAT.PrecoBaseDiaria
                //            from Carro CAR
                //            inner join [Categoria] CAT on CAR.Categoria_Id = CAT.Id";           

                var sql = @"select 
                            CAT.Categoria_Id, 
                            CAT.NomeCategoria, 
                            CAT.PrecoBaseDiaria, 
                            CAR.Carro_Id AS Carro_CarroId, 
                            CAR.Ativo AS Carro_Ativo, 
                            CAR.Marca AS Carro_Marca, 
                            CAR.Modelo AS Carro_Modelo, 
                            CAR.Ano AS Carro_Ano, 
                            CAR.Cor AS Carro_Cor, 
                            CAR.Chassi AS Carro_Chassi, 
                            CAR.DtCadastro AS Carro_DtCadastro
                            from Categoria CAT
                            inner join [Carro] CAR on CAT.Categoria_Id = CAR.Carro_Id
                            ORDER BY CAR.Marca, CAT.NomeCategoria";

                //        ret = con.Query<Categoria>(sql,
                //new[]
                //{
                //        typeof(Categoria),
                //        typeof(List<Carro>)
                //},
                //objects =>
                //{
                //    var categoria = objects[0] as Categoria;
                //    var carro = objects[1] as List<Carro>;

                //    categoria.Carros = carro;

                //    return categoria;
                //}, splitOn: "Id, Id").AsList();

                var listCategoria = con.Query<dynamic>(sql).ToList();

                AutoMapper.Configuration.AddIdentifier(
                   typeof(Categoria), "Categoria_Id");
                AutoMapper.Configuration.AddIdentifier(
                    typeof(Carro), "Carro_Id");

                List<Categoria> categoria2 = (AutoMapper.MapDynamic<Categoria>(listCategoria)
                    as IEnumerable<Categoria>).ToList();



                return con.Query<Carro, Categoria, Carro>(sql, (carro, categoria) =>
                 {
                     carro.Categoria = categoria;
                     return carro;
                 },
                 splitOn: "Id");



                //var result = listCategoria.GroupBy(p => p.Id).Select(g =>
                //{
                //    var groupedCategoria = g.First();
                //    groupedCategoria.Carros = g.Select(p => p.Carros.Single()).ToList();
                //    return groupedCategoria;
                //});
            }
        }





        //public Categoria Get(int id)
        //{
        //    var connectionString = this.GetConnection();
        //    Categoria categoria = new Categoria();

        //    using (var con = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            con.Open();
        //            var query = "SELECT * FROM Categoria WHERE Id =" + id;
        //            categoria = con.Query<Categoria>(query).FirstOrDefault();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }

        //        return categoria;
        //    }
        //}

        //public List<Categoria> GetList()
        //{
        //    var connectionString = this.GetConnection();
        //    List<Categoria> categoria = new List<Categoria>();

        //    using (var con = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            con.Open();
        //            var query = "SELECT * FROM Categoria";
        //            categoria = con.Query<Categoria>(query).ToList();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }

        //        return categoria;
        //    }
        //}

        //public int Insert(Categoria categoria)
        //{
        //    var connectionString = this.GetConnection();
        //    int count = 0;
        //    using (var con = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            con.Open();
        //            var query = "INSERT INTO Categoria(NomeCategoria, PrecoBaseDiaria) VALUES(@NomeCategoria, @PrecoBaseDiaria); SELECT CAST(SCOPE_IDENTITY() as INT); ";
        //            count = con.Execute(query, categoria);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }

        //        return count;
        //    }
        //}

        //public int Delete(int id)
        //{
        //    var connectionString = this.GetConnection();
        //    var count = 0;

        //    using (var con = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            con.Open();
        //            var query = "DELETE FROM Categoria WHERE Id =" + id;
        //            count = con.Execute(query);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }
        //        return count;
        //    }
        //}

        //public int Update(Categoria categoria)
        //{
        //    var connectionString = this.GetConnection();
        //    var count = 0;

        //    using (var con = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            con.Open();
        //            var query = "UPDATE Produtos SET NomeCategoria = @NomeCategoria, PrecoBaseDiaria = @PrecoBaseDiaria WHERE ProdutoId = " + categoria.Id;
        //            count = con.Execute(query, categoria);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }

        //        return count;
        //    }
        //}
    }
}
