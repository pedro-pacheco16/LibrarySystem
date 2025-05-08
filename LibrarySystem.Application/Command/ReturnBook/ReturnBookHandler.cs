using LibrarySystem.Application.Command.ReturnBook;
using LibrarySystem.Application.Models;
using LibrarySystem.Application.Notification.ReturnedBook;
using LibrarySystem.Core.Repositories;
using MediatR;

public class ReturnBookHandler : IRequestHandler<ReturnBookCommand, ResultViewModel>
{
    private readonly ILoanRepository _repository;
    private readonly IMediator _mediator;

    public ReturnBookHandler(ILoanRepository repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }
    public async Task<ResultViewModel> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
    {
        var returnBook = await _repository.GetLoanById(request.Id);

        if (returnBook is null)
        {
            return ResultViewModel.Error("Empréstimo não encontrado.");
        }

        if (returnBook.ReturnedAt.HasValue)
        {
            return ResultViewModel.Error("Livro já foi devolvido.");
        }

        await _repository.ReturnBook(request.Id, request.Returned);

        var atraso = (request.Returned.Date - returnBook.ReturnFromLoan.Date).Days;

        await _mediator.Publish(new ReturnedBookNotification(
            email: returnBook.User.Email,
            userName: returnBook.User.Name,
            idLoan:returnBook.Id,
            returnBook: returnBook.ReturnedAt.Value,
            delayInDays: atraso > 0 ? atraso : 0)); 
        return ResultViewModel.Success();
    }
}
