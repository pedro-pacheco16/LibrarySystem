using FluentValidation;
using LibrarySystem.Application.Command.CreateLoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Validators
{
    public class CreateLoanValidator : AbstractValidator<CreateLoanCommand>
    {
        public CreateLoanValidator()
        {
            RuleFor(l => l.IdUser)
                .NotEmpty()
                .WithMessage("ID do usuário é obrigatório");


            RuleFor(l => l.IdBook)
                .NotEmpty()
                .WithMessage("ID do livro é obrigatório");


            RuleFor(l => l.LoanBook)
                .NotEmpty().WithMessage("Data do empréstimo é obrigatória")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Data do empréstimo não pode ser futura")
                .Must(date => date.Year >= 2000).WithMessage("Data do empréstimo muito antiga");
        }
    }
}
