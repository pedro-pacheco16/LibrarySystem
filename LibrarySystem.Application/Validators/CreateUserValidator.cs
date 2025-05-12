using FluentValidation;
using LibrarySystem.Application.Command.CreateUser;

namespace LibrarySystem.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio");

            RuleFor(u => u.Email)
                .NotEmpty()
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("E-mail inválido. Use formato: usuario@dominio.com");
        }
    }
}
