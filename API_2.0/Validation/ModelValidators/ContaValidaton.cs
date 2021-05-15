using API_2._0.Models;
using API_2._0.Validation.ErrorMenssages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2._0.Validation.ModelValidators
{
    public class ContaValidaton : AbstractValidator<ContaModel>
    {
        public ContaValidaton()
        {
            RuleFor(x => x.NomeDoCredor).NotEmpty().WithMessage(ErrorMenssagesConta.NameEmpty)
                .MaximumLength(80).WithMessage(ErrorMenssagesConta.NameMaxLength)
                .MinimumLength(3).WithMessage(ErrorMenssagesConta.NameMinmLength);

            RuleFor(x => x.DataDoPagamento).NotEmpty().WithMessage(ErrorMenssagesConta.DateNull)
                .Must(DataValida).WithMessage(ErrorMenssagesConta.DateMinm);

            RuleFor(x => x.DataDoVencimento).NotEmpty().WithMessage(ErrorMenssagesConta.DateNull)
                .Must(DataValida).WithMessage(ErrorMenssagesConta.DateMax);

            RuleFor(x => x.Email).EmailAddress().WithMessage(ErrorMenssagesConta.EmailNull);

            RuleFor(x => x.ValorAPagar).NotEmpty().WithMessage(ErrorMenssagesConta.ValueNull)
                .GreaterThan(0).WithMessage(ErrorMenssagesConta.ValueMinm);
        }
        private static bool DataValida(DateTime data)
        {
            return data <= DateTime.Now;
        }

    }
}
