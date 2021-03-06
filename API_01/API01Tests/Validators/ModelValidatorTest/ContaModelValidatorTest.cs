using API01Tests.Tests;
using API_01.Validators.MenssageErrors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_01.Models;

namespace API_01.Validacao
{
    public class ContaModelValidatorTest : AbstractValidator<ContaModelUnitTest>
    {
        public ContaModelValidatorTest()
        {
            RuleFor(c => c.NomeDoCredor).NotEmpty().WithMessage(ContaModelErrorMenssagesTest.NameCantBeEmpty)
                 .NotNull().WithMessage(ContaModelErrorMenssagesTest.NameCantBeEmpty)
                               .MaximumLength(100).WithMessage(ContaModelErrorMenssagesTest.NameExceededMaxLength)
                               .MinimumLength(10).WithMessage(ContaModelErrorMenssagesTest.NameCantBeLessThan10);                               ;

            RuleFor(c => c.ValorAPagar).NotEmpty().WithMessage(ContaModelErrorMenssagesTest.ValueCantBeNull)
                .GreaterThan(0).WithMessage(ContaModelErrorMenssagesTest.ValueCantBeLessThan1)
                .NotNull().WithMessage(ContaModelErrorMenssagesTest.ValueCantBeNull);
        }
    }
}
