using API_2._0.Interfaces.Repository;
using API_2._0.Models;
using API_2._0.Validation.ErrorMenssages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2._0.Validation.BusinessValidation
{
    public class ContaBusinessValidation : AbstractValidator<ContaModel>
    {
        public ContaBusinessValidation(IContaRepository conta)
        {
           // RuleFor(x => x.Email).Must(email => conta.GetByEmail(email) == null).WithMessage(ErrorMenssagesConta.EmailAlreadyRegistered);
           
            When(v => conta.GetByEmail(v.Email)?.Id_Conta != v.Id_Conta, () =>
            {
                RuleFor(a => a.Email).Must(email => conta.GetByEmail(email) == null).WithMessage(ErrorMenssagesConta.EmailAlreadyRegistered);
            });
        }
    }
}
