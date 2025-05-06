using LibrarySystem.Application.Command.CreateLoan;
using LibrarySystem.Application.Models;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class CreateLoanHandler : IRequestHandler<CreateLoanCommand, ResultViewModel<int>>
{
    private readonly LibrarySystemDbContext _context;

    public CreateLoanHandler(LibrarySystemDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel<int>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var loanExists = await _context.Loans.AnyAsync(l => l.IdBook == request.IdBook && l.ReturnedAt == null);

        if(loanExists)
        {
            return ResultViewModel<int>.Error("Livro Indisponível no momento");
        }
        var loan = request.ToEntity();

        var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == request.IdBook && !b.IsDeleted);

        if(book is null)
        {
            return ResultViewModel<int>.Error("Livro não encontrado");
        }
        book.Loan();
        await _context.Loans.AddAsync(loan);
        _context.Books.Update(book);
        await _context.SaveChangesAsync();

        return ResultViewModel<int>.Success(loan.Id);
    }
}
