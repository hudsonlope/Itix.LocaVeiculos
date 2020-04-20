using Dapper.FluentMap.Dommel.Mapping;
using Itix.LocaVeiculos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.LocaVeiculos.Repositorio.Map
{
    class CarroMap : DommelEntityMap<Carro>
    {
        public CarroMap()
        {
            ToTable("Carro");

            Map(m => m.Carro_Id)
                .ToColumn("Id")
                .IsKey()
                .IsIdentity();

            Map(m => m.Ano)
                .ToColumn("Ano");

            Map(m => m.Ativo)
                .ToColumn("Ativo");

            Map(m => m.Ativo)
                .ToColumn("Ativo");

            Map(m => m.Chassi)
                .ToColumn("Chassi");

            Map(m => m.Cor)
                .ToColumn("Cor");

            Map(m => m.DtCadastro)
                .ToColumn("DtCadastro");

            Map(m => m.Marca)
                .ToColumn("Marca");

            Map(m => m.Modelo)
                .ToColumn("Modelo");

            Map(x => x.Categoria)
                .Ignore();
        }
    }
}
