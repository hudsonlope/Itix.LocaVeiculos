using System;
using System.Collections.Generic;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    public class Carro : BaseEntity
    {
        public bool Ativo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Chassi { get; set; }
        public DateTime DtCadastro { get; set; }

        public ICollection<int> CategoriaId { get; set; }
        public ICollection<Categoria> Categoria { get; set; }
    }
}
