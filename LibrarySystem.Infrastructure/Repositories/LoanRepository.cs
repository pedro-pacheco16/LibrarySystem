using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibrarySystemDbContext _context;

        public LoanRepository(LibrarySystemDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateLoan(Loan loan, Book book)
        {
            book.Loan();
            await _context.Loans.AddAsync(loan);
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return loan.Id;
        }

        public async Task<List<Loan>> GetAllLoan()
        {
            var loans = await _context.Loans
                .Where(l => l.ReturnedAt == null)
                .Include(l => l.Book)
                .Include(l => l.User)
                .ToListAsync();

            return loans;
        }

        public async Task<Book?> GetAvailableBookAsync(int id)
        {
            return await _context.Books
                .SingleOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
        }

        public async Task<Loan?> GetLoanById(int id)
        {
            var returnBook = await _context.Loans
               .Include(l => l.Book)
               .Include(l => l.User)
               .SingleOrDefaultAsync(r => r.Id == id);

            return returnBook;
        }

        public async Task<bool> LoanExists(int id)
        {
            return await _context.Loans
                 .AnyAsync(l => l.IdBook == id && l.ReturnedAt == null);
        }

        public async Task<Loan?> GetActiveLoanByIdAsync(int id)
        {
            return await _context.Loans
                .SingleOrDefaultAsync(l => l.Id == id && l.ReturnedAt == null);
        }

        public async Task<bool> UserExists(int Id)
        {
            return await _context.Users
                .AnyAsync(u => u.Id == Id);
        }

        public async Task ReturnBook(int id, DateTime returBook)
        {
            var loan = await _context.Loans
               .Include(l => l.Book)
               .SingleOrDefaultAsync(l => l.Id == id);

            if (loan == null || loan.ReturnedAt.HasValue)
                throw new InvalidOperationException("Empréstimo inválido ou já devolvido.");

            loan.MarkAsReturned(returBook);
            loan.Book.Available();
            await _context.SaveChangesAsync();
        }

        public async Task SetReturnLoan(Loan loan, DateTime? loanDate)
        {
            var effectiveReturnDate = loanDate ?? loan.LoanDate.AddMonths(3);

            loan.SetReturnDate(effectiveReturnDate);
            await _context.SaveChangesAsync();

        }
    }
}
