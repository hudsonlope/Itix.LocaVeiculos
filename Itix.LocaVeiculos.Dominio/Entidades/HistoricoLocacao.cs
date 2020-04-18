using System;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    public class HistoricoLocacao : BaseEntity
    {
        public int QtdDiasLocados { get; set; }
        public DateTime DtPrimeiroDia { get; set; }
        public DateTime DtUltimoDia { get; set; }
        public bool Cancelado { get; set; }
        public DateTime DtCancelamento { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int CarroId { get; set; }
        public Carro Carro { get; set; }
    }
}
