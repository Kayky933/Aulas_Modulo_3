using API_2._0.Models;
using API_2._0.Models.ModelsPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2._0.ExtensionMethods
{
    public static class ContaModelExtension
    {
        public static ContaModel ToContaModel(this ContaModelRequest contaPost)
        {

            var conta = new ContaModel() { NomeDoCredor = contaPost.NomeDoCredor, Email = contaPost.Email, DataDoPagamento = contaPost.DataDoPagamento, DataDoVencimento = contaPost.DataDoVencimento, ValorAPagar = contaPost.ValorAPagar };
            return conta;
        }
    }
}
