using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_01.Models
{
    public class ContaModelUnitTest
    {
        public int Id { get; set; }
               
        public string NomeDoCredor { get; set; }

        public DateTime DataDoVencimento{ get; set; }

        public decimal ValorAPagar { get; set; }

        public DateTime? DataDoPagamento { get; set; }

        public string Email { get; set; }
    }
}
