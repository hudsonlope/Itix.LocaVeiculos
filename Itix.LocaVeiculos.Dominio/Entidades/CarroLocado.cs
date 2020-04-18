using System;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
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
