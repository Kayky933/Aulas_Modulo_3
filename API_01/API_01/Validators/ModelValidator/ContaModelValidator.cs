using API_01.Models;
using API_01.Validators.MenssageErrors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_01.Validacao
{
    public class ContaModelValidator : AbstractValidator<ContaModel>
    {
        public ContaModelValidator()
        {
            RuleFor(c => c.NomeDoCredor).NotEmpty().WithMessage(ContaModelErrorMenssages.NameCantBeEmpty)
                 .NotNull().WithMessage(ContaModelErrorMenssages.NameCantBeEmpty)
                               .MaximumLength(100).WithMessage(ContaModelErrorMenssages.NameExceededMaxLength)
                               .MinimumLength(10).WithMessage(ContaModelErrorMenssages.NameCantBeLessThan10);                               ;

            RuleFor(c => c.ValorAPagar).NotEmpty().WithMessage(ContaModelErrorMenssages.ValueCantBeNull)
                .GreaterThan(0).WithMessage(ContaModelErrorMenssages.ValueCantBeLessThan1)
                .NotNull().WithMessage(ContaModelErrorMenssages.ValueCantBeNull);
        }
    }
}
