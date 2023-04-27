using System;
using System.ComponentModel.DataAnnotations;

namespace Financas.Application.Dtos
{
    public class ParcelaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório."),
        Range(0.01, 1000000, ErrorMessage = "{0} não pode ser zero ou acima de 1.000.000,00.")]
        public decimal ValoParcela { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório."),
        Range(1, 1000, ErrorMessage = "{0} não pode ser zero ou maior que 1000.")]
        public int NumeroParcela { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public DateTime DataVencimento { get; set; }

        public DateTime? DataPagamento { get; set; }
        
        public bool? Pago { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public int ParceladoId { get; set; }

        public ParceladoDto Parcelado { get; set; }

    }
}