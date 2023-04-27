using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Domain
{
    public class Gasto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Local { get; set; }       

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataCompra { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categorias { get; set; }

        public int EstabelecimentoId { get; set; }

        public Estabelecimento Estabelecimentos { get; set; }

        public int FormaPagamentoId { get; set; }

        public FormaPagamento FormaPagamentos { get; set; }

        #nullable enable
        [MaxLength(50)]
        public string? Outro { get; set; }       
        #nullable disable
    }
}