using Itix.LocaVeiculos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Itix.LocaVeiculos.Web.Helpers
{
    public static class Validacao
    {
        public static IEnumerable<ValidationResult> getValidationErros(object obj)
        {
            var resultadoValidacao = new List<ValidationResult>();
            var contexto = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, contexto, resultadoValidacao, true);
            return resultadoValidacao;
        }

        public static IEnumerable<ValidationResult> getValidationErros(Usuario usuario, bool validarLogin)
        {
            var resultadoValidacao = new List<ValidationResult>();
            var contexto = new ValidationContext(usuario);
            Validator.TryValidateObject(usuario, contexto, resultadoValidacao, false);

            return resultadoValidacao.Where(x=>x.ErrorMessage.Contains("Email") || x.ErrorMessage.Contains("Senha")).ToList();
        }
    }
}
