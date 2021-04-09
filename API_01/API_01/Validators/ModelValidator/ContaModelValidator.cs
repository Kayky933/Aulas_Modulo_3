using API_01.Models;
using API_01.Validators.MenssageErrors;
using FluentValidation;
using System;

namespace API_01.Validacao
{
    public class ContaModelValidator : AbstractValidator<ContaModel>
    {
        public ContaModelValidator()
        {
            RuleFor(c => c.NomeDoCredor).NotEmpty().WithMessage(ContaModelErrorMenssages.NameCantBeEmpty)
                 .NotNull().WithMessage(ContaModelErrorMenssages.NameCantBeEmpty)
                               .MaximumLength(100).WithMessage(ContaModelErrorMenssages.NameExceededMaxLength)
                               .MinimumLength(10).WithMessage(ContaModelErrorMenssages.NameCantBeLessThan10);

            RuleFor(c => c.DataDoPagamento).NotEmpty().WithMessage(ContaModelErrorMenssages.DateCantBeEmpty)
                        .NotNull().WithMessage(ContaModelErrorMenssages.DateCantBeEmpty)
                        .LessThanOrEqualTo(DateTime.Now).WithMessage(ContaModelErrorMenssages.DateCantBeGreaterThanNow); ;


            RuleFor(c => c.Email).NotEmpty().WithMessage(ContaModelErrorMenssages.EmailCantBeEmpty)
                 .NotNull().WithMessage(ContaModelErrorMenssages.EmailCantBeEmpty)
                               .MaximumLength(100).WithMessage(ContaModelErrorMenssages.EmailCantBeGreaterThan100)
                               .MinimumLength(13).WithMessage(ContaModelErrorMenssages.EmailCantBeLessThan13);

            RuleFor(c => c.ValorAPagar).NotEmpty().WithMessage(ContaModelErrorMenssages.ValueCantBeNull)
                .NotNull().WithMessage(ContaModelErrorMenssages.ValueCantBeNull)
                .GreaterThan(0).WithMessage(ContaModelErrorMenssages.ValueCantBeLessThan1);
        }
    }
}
