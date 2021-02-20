using API_01.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_01.Validacao
{
    public class ValidaConta2 : AbstractValidator<ContaModel>
    {
        public ValidaConta2()
        {
            RuleFor(c => c.NomeDoCredor).NotEmpty().WithMessage("O campo Nome não pode ser vazio !")
                 .NotNull().WithMessage("O campo não pode ser nulo!")
                               .MaximumLength(100).WithMessage("O campo nome não pode ultrapassar 100 caracteres");

            RuleFor(c => c.ValorAPagar).NotEmpty().WithMessage("O campo não pode ser nulo!")
                .GreaterThan(0).WithMessage("O campo temque ser maior que 0!")
                .NotNull().WithMessage("O campo não pode ser nulo!");

            RuleFor(c => c.DataDoVencimento).NotNull().WithMessage("O campo não pode ser nulo!");


        }
    }
}
