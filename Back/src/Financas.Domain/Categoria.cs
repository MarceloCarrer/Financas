using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Financas.Domain
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        
        public DateTime DataCadastro { get; set; }

        public IEnumerable<Gasto> Gastos { get; set; }

        public IEnumerable<Parcelado> Parcelados { get; set; }

    }
}