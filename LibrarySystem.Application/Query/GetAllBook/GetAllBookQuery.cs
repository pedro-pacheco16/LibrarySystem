using LibrarySystem.Application.Models;
using LibrarySystem.Application.Query.GetAllBook;
using MediatR;

namespace LibrarySystem.Application.Query.GetAllBook
{
    public class GetAllBookQuery : IRequest<ResultViewModel<List<BookViewModel>>>
    {

    }
}

