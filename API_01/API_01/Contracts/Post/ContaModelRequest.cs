using System;

namespace API_01.Contracts.Post
{
    public class ContaModelRequest
    {
        public string NomeDoCredor { get; set; }

        public DateTime DataDoVencimento { get; set; }

        public decimal ValorAPagar { get; set; }

        public DateTime DataDoPagamento { get; set; }

        public string Email { get; set; }
    }
}
