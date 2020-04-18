using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    public class Cliente : BaseEntity
    {
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public int PessoaFisicaId { get; set; }
        public PessoaFisica PessoaFisica { get; set; }

        public int PessoaJuridicaId { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }
    }
}
