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
    public class CarroLocadoRepositorio : BaseRepositorio<CarroLocado>, ICarroLocadoRepositorio
    {
        private readonly string _connectionString;
        public CarroLocadoRepositorio(IConfiguration configuration) : base(configuration)
        {
            _connectionString = base.ConnectionString;
        }

        public int InsertCarroLocado(CarroLocado entity)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                var carroLocado_id = con.Execute("insert into carrolocado (Carro_Id, DtPrimeiroDia, DtUltimoDia, DtReserva, QtdDiasLocado, Usuario_Id) " +
                    "values (@Carro_Id, @DtPrimeiroDia, @DtUltimoDia, @DtReserva, @QtdDiasLocado, @Usuario_Id); " +
                    "SELECT CAST(SCOPE_IDENTITY() as INT);", entity);

                return carroLocado_id;
            }
        }
    }
}
