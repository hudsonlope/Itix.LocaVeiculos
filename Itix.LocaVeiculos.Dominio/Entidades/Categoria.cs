using System.ComponentModel.DataAnnotations;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    public class Categoria : BaseEntity
    {
        [Required]
        [Display(Name ="Nome da Categoria")]
        public string NomeCategoria { get; set; }
        public decimal PrecoBaseDiaria { get; set; }
    }
}
