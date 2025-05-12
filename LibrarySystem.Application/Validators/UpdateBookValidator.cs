using FluentValidation;
using LibrarySystem.Application.Command.UpdateBook;

namespace LibrarySystem.Application.Validators
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookValidator() 
        {
            RuleFor(b => b.IdBook)
                .NotEmpty()
                .WithMessage("Id do Livro não pode ser vazio");

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
