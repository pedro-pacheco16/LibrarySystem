using LibrarySystem.Core.Entities;

namespace LibrarySystem.Core.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
        Task<Book?> GetById(int id);
        Task<int> CreateBook(Book book);
        Task UpdateBook(Book book);

    }
}
