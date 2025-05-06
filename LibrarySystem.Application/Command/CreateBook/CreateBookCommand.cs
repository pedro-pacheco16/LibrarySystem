using LibrarySystem.Application.Models;
using LibrarySystem.Core.Entities;
using MediatR;

namespace LibrarySystem.Application.Command.CreateBook
{
    public class CreateBookCommand : IRequest<ResultViewModel<int>>
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Isbn { get; set; }

        public int Publication { get; set; }

        public Book ToEntity()
            => new(Title, Author, Isbn, Publication);
    }
}
