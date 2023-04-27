using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financas.Domain
{
    public class Estabelecimento
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Endereco { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        [MaxLength(50)]
        public string Bairro { get; set; }

        [Required]
        public int CEP { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(2)]
        public string UF { get; set; }

        [Required]
        public string Foto { get; set; }
        
        [Required]
        public DateTime DataCadastro { get; set; }

        public IEnumerable<Gasto> Gastos { get; set; }

        public IEnumerable<Parcelado> Parcelados { get; set; }

        #nullable enable
        public string? Observacao { get; set; }
        #nullable disable
    }
}