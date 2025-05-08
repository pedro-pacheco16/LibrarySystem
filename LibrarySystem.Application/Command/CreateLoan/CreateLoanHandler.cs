using LibrarySystem.Application.Command.CreateLoan;
using LibrarySystem.Application.Models;
using LibrarySystem.Core.Repositories;
using MediatR;

public class CreateLoanHandler : IRequestHandler<CreateLoanCommand, ResultViewModel<int>>
{
    private readonly ILoanRepository _repository;

    public CreateLoanHandler(ILoanRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<int>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var loanExists = await _repository.LoanExists(request.IdBook);

        if (loanExists)
        {
            return ResultViewModel<int>.Error("Livro Indisponível no momento");
        }
        var loan = request.ToEntity();

        var book = await _repository.GetAvailableBookAsync(request.IdBook);

        if (book is null)
        {
            return ResultViewModel<int>.Error("Livro não encontrado");
        }

        await _repository.CreateLoan(loan,book);

        return ResultViewModel<int>.Success(loan.Id);
    }
}
