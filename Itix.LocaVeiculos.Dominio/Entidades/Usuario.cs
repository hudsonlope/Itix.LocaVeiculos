using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    [Table("Usuario")]
    public class Usuario
    {
        [Dapper.Contrib.Extensions.Key]
        public int Usuario_Id { get; set; }

        [Required(ErrorMessage = "Email deve ser preenchido", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha deve ser preenchido", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Nome deve ser preenchido", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome deve ser preenchido", AllowEmptyStrings = false)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Endereço deve ser preenchido", AllowEmptyStrings = false)]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "CPF deve ser preenchido", AllowEmptyStrings = false)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Telefone deve ser preenchido", AllowEmptyStrings = false)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Data de Nascimento deve ser preenchido", AllowEmptyStrings = false)]
        public DateTime DtNascimento { get; set; }
    }
}
