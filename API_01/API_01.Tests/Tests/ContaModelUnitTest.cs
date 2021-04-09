using API_01.Tests.ModelsTest;
using API_01.Validacao;
using System;
using Xunit;

namespace API_01.Tests.Tests
{
    public class ContaModelUnitTest
    {
        private ContaModelTest conta;
        public ContaModelUnitTest()
        {
            conta = new ContaModelTest()
            {
                Id = 1,
                NomeDoCredor = "João Pedro Augusto",
                Email = "joaopedro@gmail.com",
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
        #region
        [Theory(DisplayName = "Teste de Nomes Válidos")]
        [InlineData("João Pedro Algusto")]
        [InlineData("Marcos Antônio Meireles")]
        [InlineData("Felipe Smith Samu")]
        public void NomeDeveSerValida(string StrName)
        {
            var validador = new ContaModelValidatorTest();
            conta.NomeDoCredor = StrName;
            var result = validador.Validate(conta);

            Assert.True(result.IsValid);
        }

        [Theory(DisplayName = "Teste de Nomes Inválidos")]
        [InlineData("João")]
        [InlineData("Marcos")]
        [InlineData("Felipe")]
        public void NomeDeveSerInvalida(string StrName)
        {
            var validador = new ContaModelValidatorTest();
            conta.NomeDoCredor = StrName;
            var result = validador.Validate(conta);

            Assert.False(result.IsValid);
        }
        #endregion

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
        [InlineData("01/01/2019")]
        [InlineData("01/01/2020")]
        [InlineData("01/01/2021")]
        public void DataDeveSerValida(string dataStr)
        {
            var validador = new ContaModelValidatorTest();
            conta.DataDoVencimento = DateTime.Parse(dataStr);
            var result = validador.Validate(conta);

            Assert.True(result.IsValid);
        }

        [Theory(DisplayName = "Teste de datas de Pagamentos já efetuados")]
        [InlineData("01-01-2024")]
        [InlineData("01-01-2023")]
        [InlineData("01-01-2022")]
        public void DataDeveSerInValida(string dataStr)
        {
            var validador = new ContaModelValidatorTest();
            conta.DataDoPagamento = DateTime.Parse(dataStr);
            var result = validador.Validate(conta);

            Assert.False(result.IsValid);
        }
    }
}
