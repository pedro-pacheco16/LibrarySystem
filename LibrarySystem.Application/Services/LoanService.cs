using LibrarySystem.Application.Models;
using LibrarySystem.Application.Services;
using LibrarySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class LoanService : ILoanService
{
    private readonly LibrarySystemDbContext _context;

    public LoanService(LibrarySystemDbContext context)
    {
        _context = context;
    }

    public ResultViewModel<int> CreateLoan(CreateLoanInputModel loanModel)
    {
        var loan = loanModel.ToEntity();

        _context.Loans.Add(loan);
        _context.SaveChanges();

        return ResultViewModel<int>.Success(loan.Id);
    }

    public ResultViewModel ReturnBook(int id, DateTime returned)
    {
        var returnBook = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .SingleOrDefault(r => r.Id == id);

        if (returnBook is null)
        {
            return ResultViewModel.Error("Empréstimo não encontrado.");
        }

        if (returnBook.ReturnedAt.HasValue)
        {
            return ResultViewModel.Error("Livro já foi devolvido.");
        }

        returnBook.MarkAsReturned(returned);
        _context.SaveChanges();

        var atraso = (returned - returnBook.ReturnFromLoan).Days;

       var message = atraso > 0 
            ? $"Livro devolvido com {atraso} dias de atraso." 
            : "Livro devolvido dentro do prazo.";

        return ResultViewModel.Success();
    }

    public ResultViewModel SetReturnDate(int id, DateTime returnDate)
    {
        var loan = _context.Loans.SingleOrDefault(l => l.Id == id);

        if (loan is null)
            return ResultViewModel.Error("Empréstimo não encontrado.");

        loan.SetReturnDate(returnDate);
        _context.SaveChanges();

        return ResultViewModel.Success();
    }

    public ResultViewModel<List<LoanViewModel>> GetAll()
    {
        var loans = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .ToList();

        var loanViewModel = loans.Select(LoanViewModel.FromEntity).ToList();

        return ResultViewModel<List<LoanViewModel>>.Success(loanViewModel);
    }
}
