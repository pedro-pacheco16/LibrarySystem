using LibrarySystem.Application.Models;
using LibrarySystem.Application.Query.GetAllLoan;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllLoanHandler : IRequestHandler<GetAllLoanQuery, ResultViewModel<List<LoanViewModel>>>
{
    private readonly LibrarySystemDbContext _context;

    public GetAllLoanHandler(LibrarySystemDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel<List<LoanViewModel>>> Handle(GetAllLoanQuery request, CancellationToken cancellationToken)
    {
        var loans = await _context.Loans
               .Where(l => l.ReturnedAt == null)
               .Include(l => l.Book)
               .Include(l => l.User)
               .ToListAsync();

        var loanViewModel = loans.Select(LoanViewModel.FromEntity).ToList();

        return ResultViewModel<List<LoanViewModel>>.Success(loanViewModel);
    }
}
