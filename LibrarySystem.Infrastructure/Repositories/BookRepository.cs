using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibrarySystemDbContext _context;

        public BookRepository(LibrarySystemDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateBook(Book book)
        {
            book.Available();
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task<List<Book>> GetAll()
        {
            var books = await _context.Books
           .Where(b => !b.IsDeleted)
           .ToListAsync();

            return books;
        }

        public async Task<Book?> GetById(int id)
        {
            var books = await _context.Books
              .Include(l => l.LoanList.Where(l => !l.IsDeleted))
              .SingleOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

            return books;
        }

        public async Task UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
