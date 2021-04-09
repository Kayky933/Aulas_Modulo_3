using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_01.Models
{
    public class ContaModel
    {
        [Key]
        public int Id_Conta { get; set; }
        
        [MaxLength(100)]
        public string NomeDoCredor { get; set; }

        public DateTime DataDoVencimento{ get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorAPagar { get; set; }

        public DateTime DataDoPagamento { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
    }
}
