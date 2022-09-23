using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Domain
{
    public class Parcelado
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }        

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        public int QtdParcela { get; set; }

        public DateTime DataCompra { get; set; }

        public bool Ativo { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categorias { get; set; }

        public IEnumerable<Parcela> Parcelas { get; set; }

        #nullable enable
        [MaxLength(50)]
        public string? Outro { get; set; }       
        #nullable disable 
    }
}