using LibrarySystem.Application.Command.SetReturnDateBook;
using LibrarySystem.Application.Models;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class SetReturnDateBookHandler : IRequestHandler<SetReturnDateBookCommand, ResultViewModel>
{
    private readonly LibrarySystemDbContext _context;

    public SetReturnDateBookHandler(LibrarySystemDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel> Handle(SetReturnDateBookCommand request, CancellationToken cancellationToken)
    {
        var loan = await _context.Loans
            .SingleOrDefaultAsync(l => l.Id == request.Id && l.ReturnedAt == null);

        if (loan is null)
            return ResultViewModel.Error("Empréstimo não encontrado ou devolvido.");

        loan.SetReturnDate(request.ReturnDate);
        await _context.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}

