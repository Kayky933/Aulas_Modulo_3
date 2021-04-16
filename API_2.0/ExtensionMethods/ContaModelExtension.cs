using API_2._0.Models;
using API_2._0.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2._0.ExtensionMethods
{
    public static class ContaModelExtension
    {
        public static ContaModel ToContaModel(this ContaModelRequest contapost)
        {
            var conta = new ContaModel() { NomeDoCredor = contapost.NomeDoCredor, DataDoVencimento = contapost.DataDoVencimento, ValorAPagar = contapost.ValorAPagar, DataDoPagamento = contapost.DataDoPagamento, Email = contapost.Email };
            return conta;
        }
    }
}
