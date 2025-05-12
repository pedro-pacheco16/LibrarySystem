using FluentValidation;
using LibrarySystem.Application.Command.CreateBook;

namespace LibrarySystem.Application.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookValidator()
        {
            RuleFor(b => b.Author)
                .NotEmpty()
                .WithMessage("Deve conter um autor")
                .MaximumLength(30)
                .WithMessage("Tamanho Máximo de 30 caracteres");

            RuleFor(b => b.Title)
                .NotEmpty()
                .WithMessage("Deve conter um Título")
                .MaximumLength(50)
                .WithMessage("Tamanho Máximo de 50 caracteres");

            RuleFor(b => b.Publication)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("Ano de publicação não pode ser vazio e não pode ser maior que ano atual");

        }

    }
}
