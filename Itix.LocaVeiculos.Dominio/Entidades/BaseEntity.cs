using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Itix.LocaVeiculos.Dominio.Entidades
{
    public abstract class BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        //public List<string> _mensagemValidacao { get; set; }
        //public List<string> MensagemValidacao
        //{
        //    get { return _mensagemValidacao ?? (_mensagemValidacao = new List<string>()); }
        //}

        //public abstract void Validate();
        //protected bool EhValido
        //{
        //    get { return !MensagemValidacao.Any(); }
        //}
    }
}
