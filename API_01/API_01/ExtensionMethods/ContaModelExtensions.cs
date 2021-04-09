using API_01.Contracts.Post;
using API_01.Models;

namespace API_01.ExtensionMethods
{
    public static class ContaModelExtensions
    {
        public static ContaModel ToContaModel(this ContaModelRequest contaPost)
        {

            var conta = new ContaModel() { NomeDoCredor = contaPost.NomeDoCredor, Email = contaPost.Email, DataDoPagamento = contaPost.DataDoPagamento, DataDoVencimento = contaPost.DataDoVencimento, ValorAPagar = contaPost.ValorAPagar };
            return conta;
        }
    }
}
