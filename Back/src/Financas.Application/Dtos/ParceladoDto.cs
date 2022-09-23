using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Financas.Domain;

namespace Financas.Application.Dtos
{
    public class ParceladoDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório."),
         MinLength(3, ErrorMessage = "Mínimo de 3 caracteres."),
         MaxLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public string Nome { get; set; }        

        [Required(ErrorMessage = "{0} é obrigatório."),
         Range(0.01, 1000000, ErrorMessage = "{0} não pode ser zero ou acima de 1.000.000,00.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório."),
         Range(2, 1000, ErrorMessage = "{0} não pode ser zero ou maior que 1000.")]
        public int QtdParcela { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public string DataCompra { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório.")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public int CategoriaId { get; set; }

        public CategoriaDto Categorias { get; set; }

        #nullable enable
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public string? Outro { get; set; }       
        #nullable disable
    }
}