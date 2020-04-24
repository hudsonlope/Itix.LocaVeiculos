using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    [Table("Carro")]
    public class Carro
    {
        [Dapper.Contrib.Extensions.Key]
        public int Carro_Id { get; set; }
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Marca deve ser preenchido", AllowEmptyStrings = false)]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Modelo deve ser preenchido", AllowEmptyStrings = false)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Ano deve ser preenchido", AllowEmptyStrings = false)]
        public string Ano { get; set; }

        [Required(ErrorMessage = "Cor deve ser preenchido", AllowEmptyStrings = false)]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Chassi deve ser preenchido", AllowEmptyStrings = false)]
        public string Chassi { get; set; }
        public bool PossuiArCondicionado { get; set; }
        public bool PossuiDirecaoHidraulica { get; set; }
        public DateTime DtCadastro { get; set; }

        public virtual Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Escolha uma categoria", AllowEmptyStrings = false)]
        [Range(1, 99999, ErrorMessage = "Escolha uma categoria")]
        public int Categoria_Id { get; set; }

    }
}
