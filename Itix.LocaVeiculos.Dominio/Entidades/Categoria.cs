using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    [Table("Categoria")]
    public class Categoria
    {
        public Categoria()
        {
            //Carros = new List<Carro>();
        }

        [Dapper.Contrib.Extensions.Key]
        public int Categoria_Id { get; set; }

        [Required(ErrorMessage = "Nome da Categoria deve ser preenchido", AllowEmptyStrings = false)]
        [StringLength(60, MinimumLength = 4)]
        public string NomeCategoria { get; set; }

        [Range(1, 99999, ErrorMessage = "Preço Base deve ser preenchido")]
        public decimal PrecoBaseDiaria { get; set; }

        //public virtual ICollection<Carro> Carros { get; set; }
    }
}
