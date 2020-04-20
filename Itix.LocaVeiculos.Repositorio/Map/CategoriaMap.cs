using Dapper.FluentMap.Dommel.Mapping;
using Itix.LocaVeiculos.Dominio.Entidades;

namespace Itix.LocaVeiculos.Repositorio.Map
{
    class CategoriaMap : DommelEntityMap<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria");

            Map(m => m.Categoria_Id)
                .ToColumn("Id")
                .IsKey()
                .IsIdentity();

            Map(m => m.NomeCategoria)
                .ToColumn("NomeCategoria");

            Map(m => m.PrecoBaseDiaria)
                .ToColumn("PrecoBaseDiaria");

            //Map(m => m.Carros).Ignore();
        }

    }
}
