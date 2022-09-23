using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Domain
{
    public class Parcela
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValoParcela { get; set; }

        public int NumeroParcela { get; set; }

        public bool Pago { get; set; }

        public int ParceladoId { get; set; }

        public Parcelado Parcelado { get; set; }
    }
}