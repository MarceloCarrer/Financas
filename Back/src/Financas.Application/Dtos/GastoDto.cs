using System;
using System.ComponentModel.DataAnnotations;

namespace Financas.Application.Dtos
{
    public class GastoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório."),
         MinLength(3, ErrorMessage = "Mínimo de 3 caracteres."),
         MaxLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public string Local { get; set; }    

        [Required(ErrorMessage = "{0} é obrigatório."),
         Range(0.01, 1000000, ErrorMessage = "{0} não pode ser zero ou acima de 1.000.000,00.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public DateTime DataCompra { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public int CategoriaId { get; set; }

        public CategoriaDto Categorias { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public int FormaPagamentoId { get; set; }

        public FormaPagamentoDto FormaPagamentos { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public int EstabelecimentoId { get; set; }

        public EstabelecimentoDto Estabelecimentos { get; set; }
        
        #nullable enable
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public string? Outro { get; set; }
        #nullable disable
    }
}