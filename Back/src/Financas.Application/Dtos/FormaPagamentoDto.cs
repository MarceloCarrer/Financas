using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financas.Application.Dtos
{
    public class FormaPagamentoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório."),
         MinLength(3, ErrorMessage = "Mínimo de 3 caracteres."),
         MaxLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public string Nome { get; set; }        
        
        [Required(ErrorMessage = "{0} é obrigatório.")]
        public DateTime DataCadastro { get; set; }

        public IEnumerable<GastoDto> Gastos { get; set; }

        public IEnumerable<ParceladoDto> Parcelados { get; set; }
    }
}