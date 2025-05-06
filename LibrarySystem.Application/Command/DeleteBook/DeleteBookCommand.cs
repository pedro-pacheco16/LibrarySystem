using LibrarySystem.Application.Models;
using MediatR;

namespace LibrarySystem.Application.Command.DeleteBook
{
    public class DeleteBookCommand : IRequest<ResultViewModel>
    {
        public DeleteBookCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
