using LibrarySystem.Application.Models;
using MediatR;

namespace LibrarySystem.Application.Command.ReturnBook
{
    public class ReturnBookCommand : IRequest<ResultViewModel>
    {
        public ReturnBookCommand(int id, DateTime returned)
        {
            Id = id;
            Returned = returned;
        }

        public int Id { get; set; }

        public DateTime Returned { get; set; }
    }
}
