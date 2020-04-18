using System;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    public class PessoaFisica: BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
