using Dapper.Contrib.Extensions;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    [Table("Usuario")]
    public class Usuario : BaseEntity
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
