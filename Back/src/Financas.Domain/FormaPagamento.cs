using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financas.Domain
{
    public class FormaPagamento
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        
        [Required]
        public DateTime DataCadastro { get; set; }

        public IEnumerable<Gasto> Gastos { get; set; }

        public IEnumerable<Parcelado> Parcelados { get; set; }
    }
}