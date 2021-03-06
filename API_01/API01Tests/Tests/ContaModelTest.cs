using API_01.Models;
using API_01.Validacao;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace API01Tests.Tests
{
   public class ContaModelTest
    {
        private ContaModelUnitTest conta;
        public ContaModelTest()
        {
            conta = new ContaModelUnitTest()
            {
                Id = 1,
                NomeDoCredor = "João",
                Email = "joao@gmail.com",
                DataDoPagamento = DateTime.Parse("18-02-2021"),
                DataDoVencimento = DateTime.Parse("20-02-2020"),
                ValorAPagar = 10
            };
        }

        [Fact]
        public void ObjetoDeveSerValido()
        {
            var validador = new ContaModelValidatorTest();
            var result = validador.Validate(conta);

            Assert.True(result.IsValid);
        }

        [Theory(DisplayName = "Teste de emails inválidos")]
        [InlineData("aaaaa")]
        [InlineData("aaaaa@")]
        [InlineData("@aaaaa")]
        [InlineData("aaaaa.com")]
        public void EmailNaoDeveSerValido(string email)
        {
            var validador = new ContaModelValidatorTest();
            conta.Email = email;
            var result = validador.Validate(conta);

            Assert.False(result.IsValid);
        }

        [Theory(DisplayName = "Teste de datas de vencimento")]
        [InlineData("01/01/2020")]
        [InlineData("01/01/2021")]
        public void DataDeveSerValida(string dataStr)
        {
            var validador = new ContaModelValidatorTest();
            conta.DataDoVencimento = DateTime.Parse(dataStr);
            var result = validador.Validate(conta);

            Assert.True(result.IsValid);
        }

        [Theory(DisplayName = "Teste de datas de nascimento")]
        [InlineData("01/01/2022")]
        [InlineData("01/01/2023")]
        [InlineData("01/01/2054")]
        public void DataDeveSerInValida(string dataStr)
        {
            var validador = new ContaModelValidatorTest();
            conta.DataDoPagamento = DateTime.Parse(dataStr);
            var result = validador.Validate(conta);

            Assert.False(result.IsValid);
        }
    }
}
