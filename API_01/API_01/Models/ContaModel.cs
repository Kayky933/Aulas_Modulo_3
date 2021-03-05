using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_01.Models
{
    public class ContaModel
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(100, ErrorMessage = "O campo deve ter no máximo {1} caracteres")]
        public string NomeDoCredor { get; set; }

        public DateTime DataDoVencimento{ get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorAPagar { get; set; }

        public DateTime? DataDoPagamento { get; set; }

        public string Email { get; set; }
    }
}
