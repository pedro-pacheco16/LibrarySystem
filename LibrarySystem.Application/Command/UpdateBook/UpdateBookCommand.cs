using LibrarySystem.Application.Models;
using MediatR;

namespace LibrarySystem.Application.Command.UpdateBook
{
    public class UpdateBookCommand : IRequest<ResultViewModel>
    {
        public int IdBook { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Isbn { get; set; }

        public int Publication { get; set; }
    }
}
