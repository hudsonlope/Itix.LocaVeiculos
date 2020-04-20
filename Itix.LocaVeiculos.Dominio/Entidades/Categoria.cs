using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    [Table("Categoria")]
    public class Categoria
    {
        public Categoria()
        {
            //Carros = new List<Carro>();
        }

        [Key]
        public int Categoria_Id { get; set; }
        public string NomeCategoria { get; set; }
        public decimal PrecoBaseDiaria { get; set; }

        //public virtual ICollection<Carro> Carros { get; set; }
    }
}
