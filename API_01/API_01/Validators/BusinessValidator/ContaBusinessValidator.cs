using API_01.Interfaces.Repository;
using API_01.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_01.Validators.BusinessValidator
{
    public class ContaBusinessValidator : AbstractValidator<ContaModel>
    {
        public ContaBusinessValidator(IContaRepository contaRep)
        {
            RuleFor(cx => cx.NomeDoCredor).Must(nome => contaRep.GetByName(nome).Count() == 0).WithMessage("O nome não pode ser repetido !");

            RuleFor(a => a.Email).Must(email => contaRep.GetByEmail(email) == null).WithMessage("O E-mail já encontra-se cadastrado !");
        }
    }
}
