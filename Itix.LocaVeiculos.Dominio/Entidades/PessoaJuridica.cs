using System;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    public class PessoaJuridica : BaseEntity
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
