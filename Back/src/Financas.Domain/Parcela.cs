using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Domain
{
    public class Parcela
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValoParcela { get; set; }

        [Required]
        public int NumeroParcela { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        public DateTime? DataPagamento { get; set; }

        public bool? Pago { get; set; }

        public int ParceladoId { get; set; }

        public Parcelado Parcelado { get; set; }
        
    }
}