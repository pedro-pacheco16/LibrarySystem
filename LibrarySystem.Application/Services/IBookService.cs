using LibrarySystem.Application.Models;


namespace LibrarySystem.Application.Services
{
    public interface IBookService
    {
        ResultViewModel<List<BookViewModel>> GetAllBooks();

        ResultViewModel<BookViewModel> GetById(int id);

        ResultViewModel<int> CreateBook(CreateBookInputModel model);

        ResultViewModel UpdateBook(UpdateBookInputModel model);

        ResultViewModel DeleteBook(int id);
    }
}
