using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int Cliente_Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public DateTime DtNascimento { get; set; }

        public CarroLocado CarroLocado { get; set; }
    }
}
