using LibrarySystem.Application.Models;
using MediatR;

namespace LibrarySystem.Application.Query.GetByIdBook
{
    public class GetByIdBookQuery : IRequest<ResultViewModel<BookViewModel>>
    {
        public GetByIdBookQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
