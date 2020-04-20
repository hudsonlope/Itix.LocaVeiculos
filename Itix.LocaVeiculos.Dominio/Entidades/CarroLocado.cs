using Dapper.Contrib.Extensions;
using System;
using System.Linq;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    [Table("CarroLocado")]
    public class CarroLocado : BaseEntity
    {
        public int QtdDiasLocado { get; set; }
        public DateTime DtPrimeiroDia { get; set; }
        public DateTime DtUltimoDia { get; set; }
        public DateTime DtReserva { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int CarroId { get; set; }
        public Carro Carro { get; set; }
    }
}
