using System;
using System.Collections.Generic;
using System.Text;

namespace API_01.Tests.ModelsTest
{
    public class ContaModelTest
    {
        public int Id { get; set; }

        public string NomeDoCredor { get; set; }

        public DateTime DataDoVencimento { get; set; }

        public decimal ValorAPagar { get; set; }

        public DateTime? DataDoPagamento { get; set; }

        public string Email { get; set; }
    }
}
