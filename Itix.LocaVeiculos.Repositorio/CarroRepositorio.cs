using Dapper;
using Dapper.Contrib.Extensions;
using Itix.LocaVeiculos.Dominio.Contratos;
using Itix.LocaVeiculos.Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Itix.LocaVeiculos.Repositorio
{
    public class CarroRepositorio : BaseRepositorio<Carro>, ICarroRepositorio
    {
        private readonly string _connectionString;
        public CarroRepositorio(IConfiguration configuration) : base(configuration)
        {
            _connectionString = base.ConnectionString;
        }

        public IEnumerable<Carro> InnerJoinCategoriaCarro()
        {
            return new List<Carro>();
        }

        public int InsertCarro(Carro entity)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                var carro_id = con.Execute("insert into carro (ativo, marca, modelo, ano, cor, chassi, dtcadastro, possuiarcondicionado, possuidirecaohidraulica, categoria_id) " +
                    "values (@ativo, @marca, @modelo, @ano, @cor, @chassi, @dtcadastro, @possuiarcondicionado, @possuidirecaohidraulica, @categoria_id)", entity);
                return carro_id;
            }
        }
    }
}
