using LibrarySystem.Application.Models;
using LibrarySystem.Application.Query.GetAllBook;
using MediatR;

namespace LibrarySystem.Application.Query.GetAllLoan
{
    public class GetAllLoanQuery : IRequest<ResultViewModel<List<LoanViewModel>>>
    {

    }
}
