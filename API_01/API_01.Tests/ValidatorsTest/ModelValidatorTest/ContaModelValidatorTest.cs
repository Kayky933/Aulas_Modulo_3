using API_01.Tests.ModelsTest;
using API_01.Validators.MenssageErrors;
using FluentValidation;
using System;

namespace API_01.Validacao
{
    public class ContaModelValidatorTest : AbstractValidator<ContaModelTest>
    {
        public ContaModelValidatorTest()
        {
            RuleFor(c => c.NomeDoCredor).NotEmpty().WithMessage(ContaModelErrorMenssagesTest.NameCantBeEmpty)
                 .NotNull().WithMessage(ContaModelErrorMenssagesTest.NameCantBeEmpty)
                               .MaximumLength(100).WithMessage(ContaModelErrorMenssagesTest.NameExceededMaxLength)
                               .MinimumLength(10).WithMessage(ContaModelErrorMenssagesTest.NameCantBeLessThan10);

            RuleFor(c => c.DataDoPagamento).NotEmpty().WithMessage(ContaModelErrorMenssagesTest.DateCantBeEmpty)
                        .NotNull().WithMessage(ContaModelErrorMenssagesTest.DateCantBeEmpty)
                        .LessThanOrEqualTo(DateTime.Now).WithMessage(ContaModelErrorMenssagesTest.DateCantBeGreaterThanNow); ;


            RuleFor(c => c.Email).NotEmpty().WithMessage(ContaModelErrorMenssagesTest.EmailCantBeEmpty)
                 .NotNull().WithMessage(ContaModelErrorMenssagesTest.EmailCantBeEmpty)
                               .MaximumLength(100).WithMessage(ContaModelErrorMenssagesTest.EmailCantBeGreaterThan100)
                               .MinimumLength(13).WithMessage(ContaModelErrorMenssagesTest.EmailCantBeLessThan13);

            RuleFor(c => c.ValorAPagar).NotEmpty().WithMessage(ContaModelErrorMenssagesTest.ValueCantBeNull)
                .NotNull().WithMessage(ContaModelErrorMenssagesTest.ValueCantBeNull)
                .GreaterThan(0).WithMessage(ContaModelErrorMenssagesTest.ValueCantBeLessThan1);
        }
    }
}
