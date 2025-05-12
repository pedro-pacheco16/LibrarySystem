using LibrarySystem.Application.Command.SetReturnDateBook;
using LibrarySystem.Application.Models;
using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Repositories;
using MediatR;

public class SetReturnDateBookHandler : IRequestHandler<SetReturnDateBookCommand, ResultViewModel>
{
    private readonly ILoanRepository _repository;

    public SetReturnDateBookHandler(ILoanRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel> Handle(SetReturnDateBookCommand request, CancellationToken cancellationToken)
    {
        var loan = await _repository.GetActiveLoanByIdAsync(request.Id);

        if (loan is null)
            return ResultViewModel.Error("Empréstimo não encontrado ou já devolvido.");

        var loanDate = loan.LoanDate;

        if (request.ReturnDate < loanDate)
            return ResultViewModel.Error("A data de devolução não pode ser anterior à data do empréstimo.");

        var maxReturnDate = loan.LoanDate.AddMonths(3);

        if (request.ReturnDate > maxReturnDate)
            return ResultViewModel.Error("A data de devolução deve ser no máximo 3 meses após a data do empréstimo.");

        await _repository.SetReturnLoan(loan, request.ReturnDate);

        return ResultViewModel.Success();
    }
}

