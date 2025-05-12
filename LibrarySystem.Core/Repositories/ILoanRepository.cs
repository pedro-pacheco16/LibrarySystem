using LibrarySystem.Core.Entities;

namespace LibrarySystem.Core.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAllLoan();
        Task<int> CreateLoan(Loan loan, Book book);
        Task SetReturnLoan(Loan loan, DateTime? loanDate);
        Task ReturnBook(int id, DateTime returBook);
        Task<bool> LoanExists(int id);
        Task<bool> UserExists(int id);
        Task<Loan?> GetActiveLoanByIdAsync(int id);
        Task<Book?> GetAvailableBookAsync(int id);
        Task<Loan?> GetLoanById(int id);

    }
}
