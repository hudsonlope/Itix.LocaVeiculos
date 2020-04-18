namespace Itix.LocaVeiculos.Dominio.Entidades
{
    public class Categoria : BaseEntity
    {
        public string NomeCategoria { get; set; }
        public decimal PrecoBaseDiaria { get; set; }
    }
}
