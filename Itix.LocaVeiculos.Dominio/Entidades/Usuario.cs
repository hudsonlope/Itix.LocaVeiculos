using Dapper.Contrib.Extensions;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Usuario_Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
