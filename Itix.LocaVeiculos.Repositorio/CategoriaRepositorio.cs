using Dapper;
using Itix.LocaVeiculos.Dominio.Contratos;
using Itix.LocaVeiculos.Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace Itix.LocaVeiculos.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        IConfiguration _configuration;
        public CategoriaRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("CategoriaConnection").Value;
            return connection;
        }
        public Categoria Get(int id)
        {
            var connectionString = this.GetConnection();
            Categoria categoria = new Categoria();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Categoria WHERE Id =" + id;
                    categoria = con.Query<Categoria>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return categoria;
            }
        }
        public List<Categoria> GetList()
        {
            var connectionString = this.GetConnection();
            List<Categoria> categoria = new List<Categoria>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Categoria";
                    categoria = con.Query<Categoria>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return categoria;
            }
        }
        public int Insert(Categoria categoria)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Categoria(NomeCategoria, PrecoBaseDiaria) VALUES(@NomeCategoria, @PrecoBaseDiaria); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = con.Execute(query, categoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }
        }
        public int Delete(int id)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Categoria WHERE Id =" + id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
        public int Update(Categoria categoria)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Produtos SET NomeCategoria = @NomeCategoria, PrecoBaseDiaria = @PrecoBaseDiaria WHERE ProdutoId = " + categoria.Id;
                    count = con.Execute(query, categoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }
        }
    }
}
