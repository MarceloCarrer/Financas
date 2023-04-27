using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financas.Application.Dtos
{
    public class EstabelecimentoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório."),
         MinLength(3, ErrorMessage = "Mínimo de 3 caracteres."),
         MaxLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório."),
         MinLength(3, ErrorMessage = "Mínimo de 3 caracteres."),
         MaxLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório."),
         MinLength(3, ErrorMessage = "Mínimo de 3 caracteres."),
         MaxLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public int CEP { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório."),
         MinLength(3, ErrorMessage = "Mínimo de 3 caracteres."),
         MaxLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório."),
         MinLength(2, ErrorMessage = "Mínimo de 2 caracteres."),
         MaxLength(2, ErrorMessage = "Máximo de 2 caracteres.")]
        public string UF { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public string Foto { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório.")]
        public DateTime DataCadastro { get; set; }

        public IEnumerable<GastoDto> Gastos { get; set; }

        public IEnumerable<ParceladoDto> Parcelados { get; set; }

         #nullable enable
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public string? Observacao { get; set; }   
        #nullable disable
    }
}