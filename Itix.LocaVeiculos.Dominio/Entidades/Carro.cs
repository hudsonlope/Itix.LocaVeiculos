using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    [Table("Carro")]
    public class Carro
    {
        [Key]
        public int Carro_Id { get; set; }
        public bool Ativo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Cor { get; set; }
        public string Chassi { get; set; }
        public DateTime DtCadastro { get; set; }

        public virtual Categoria Categoria { get; set; }
        public int Categoria_Id { get; set; }
    }
}
