using LibrarySystem.Application.Command.ReturnBook;
using LibrarySystem.Application.Models;
using LibrarySystem.Application.Notification.ReturnedBook;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class ReturnBookHandler : IRequestHandler<ReturnBookCommand, ResultViewModel>
{
    private readonly LibrarySystemDbContext _context;
    private readonly IMediator _mediator;

    public ReturnBookHandler(LibrarySystemDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }
    public async Task<ResultViewModel> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
    {
        var returnBook =await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .SingleOrDefaultAsync(r => r.Id == request.Id);

        if (returnBook is null)
        {
            return ResultViewModel.Error("Empréstimo não encontrado.");
        }

        if (returnBook.ReturnedAt.HasValue)
        {
            return ResultViewModel.Error("Livro já foi devolvido.");
        }

        returnBook.MarkAsReturned(request.Returned);
        returnBook.Book.Available();
        await _context.SaveChangesAsync();

        var atraso = (request.Returned - returnBook.ReturnFromLoan).Days;

        await _mediator.Publish(new ReturnedBookNotification(
            email: returnBook.User.Email,
            userName: returnBook.User.Name,
            idLoan:returnBook.Id,
            returnBook: returnBook.ReturnedAt.Value,
            delayInDays: atraso > 0 ? atraso : 0)); 
        return ResultViewModel.Success();
    }
}
