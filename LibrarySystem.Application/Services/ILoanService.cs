using LibrarySystem.Application.Models;

namespace LibrarySystem.Application.Services
{
    public interface ILoanService
    {
        ResultViewModel<List<LoanViewModel>> GetAll();

        ResultViewModel<int> CreateLoan(CreateLoanInputModel loanModel);

        ResultViewModel SetReturnDate(int id, DateTime returnDate);

        ResultViewModel ReturnBook(int id, DateTime returned);
    }
}
