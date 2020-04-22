using Dapper;
using Itix.LocaVeiculos.Dominio.Contratos;
using Itix.LocaVeiculos.Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Itix.LocaVeiculos.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(IConfiguration configuration) : base(configuration)
        {
        }

        public Usuario Get(string email, string senha)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                string query = String.Format("select * from usuario where email='{0}' and senha='{1}'", email, senha);
                var usuario = con.Query<Usuario>(query);
                return usuario.FirstOrDefault();
            }
        }

        public Usuario Get(string email)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                string query = String.Format("select * from usuario where email='{0}'", email);
                var usuario = con.Query<Usuario>(query);
                return usuario.FirstOrDefault();
            }
        }


    }
}
