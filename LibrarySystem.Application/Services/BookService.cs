using LibrarySystem.Application.Models;
using LibrarySystem.Application.Services;
using LibrarySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class BookService : IBookService
{
    private readonly LibrarySystemDbContext _context;

    public BookService(LibrarySystemDbContext context)
    {
        _context = context;
    }

    public ResultViewModel<int> CreateBook(CreateBookInputModel model)
    {
        var book = model.ToEntity();

        _context.Books.Add(book);
        _context.SaveChanges();

        return ResultViewModel<int>.Success(book.Id);
    }

    public ResultViewModel DeleteBook(int id)
    {
        var book = _context.Books.SingleOrDefault(b => b.Id == id);

        if (book is null)
        {
            return ResultViewModel.Error("Livro Não encontrado");
        }

        _context.Books.Update(book);
        _context.SaveChanges();

        return ResultViewModel.Success();
    }

    public ResultViewModel<List<BookViewModel>> GetAllBooks()
    {
        var books = _context.Books.ToList();

        var model = books.Select(BookViewModel.FromEntity).ToList();

        return ResultViewModel<List<BookViewModel>>.Success(model);
    }

    public ResultViewModel<BookViewModel> GetById(int id)
    {
        var books = _context.Books
                .Include(l => l.LoanList)
                .SingleOrDefault(b => b.Id == id);

        if (books is null)
        {
            return ResultViewModel<BookViewModel>.Error("Livro não encontrado");
        }

        var model = BookViewModel.FromEntity(books);

        return ResultViewModel<BookViewModel>.Success(model);
    }

    public ResultViewModel UpdateBook(UpdateBookInputModel model)
    {
        var book = _context.Books.SingleOrDefault(b => b.Id == model.IdBook);

        if (book is null)
        {
            return ResultViewModel.Error("Livro não encontrado");
        }

        book.Update(model.Title, model.Author, model.Isbn, model.Publication);

        _context.Books.Update(book);
        _context.SaveChanges();

        return ResultViewModel.Success();
    }
}