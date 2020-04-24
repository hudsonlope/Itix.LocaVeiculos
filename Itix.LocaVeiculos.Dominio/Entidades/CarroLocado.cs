using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    [Table("CarroLocado")]
    public class CarroLocado : BaseEntity
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int CarroLocado_Id { get; set; }

        public int QtdDiasLocado { get; set; }

        [Required(ErrorMessage = "Preenchida a data do primeiro dia", AllowEmptyStrings = false)]
        public DateTime DtPrimeiroDia { get; set; }

        [Required(ErrorMessage = "Preenchida a data do último dia", AllowEmptyStrings = false)]
        public DateTime DtUltimoDia { get; set; }

        [Required(ErrorMessage = "Marca deve ser preenchido", AllowEmptyStrings = false)]
        public DateTime DtReserva { get; set; }

        public int Usuario_Id { get; set; }

        [Range(1, 99999, ErrorMessage = "Escolha um veículo")]
        public int Carro_Id { get; set; }
    }
}
