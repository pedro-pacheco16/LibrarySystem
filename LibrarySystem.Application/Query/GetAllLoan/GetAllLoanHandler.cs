using LibrarySystem.Application.Models;
using LibrarySystem.Application.Query.GetAllLoan;
using LibrarySystem.Core.Repositories;
using MediatR;

public class GetAllLoanHandler : IRequestHandler<GetAllLoanQuery, ResultViewModel<List<LoanViewModel>>>
{
    private readonly ILoanRepository _repository;

    public GetAllLoanHandler(ILoanRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<List<LoanViewModel>>> Handle(GetAllLoanQuery request, CancellationToken cancellationToken)
    {
        var loans = await _repository.GetAllLoan();

        var loanViewModel = loans.Select(LoanViewModel.FromEntity).ToList();

        return ResultViewModel<List<LoanViewModel>>.Success(loanViewModel);
    }
}
