using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_01.Models
{
    public class ContaModel
    {
        [Key]
        public int Id { get; set; }
        
        public string NomeDoCredor { get; set; }

        public DateTime DataDoVencimento{ get; set; }

        public decimal ValorAPagar { get; set; }

        public DateTime? DataDoPagamento { get; set; }
    }
}
