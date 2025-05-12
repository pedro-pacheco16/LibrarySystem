using LibrarySystem.Application.Models;
using MediatR;

namespace LibrarySystem.Application.Command.SetReturnDateBook
{
    public class SetReturnDateBookCommand : IRequest<ResultViewModel>
    {
        public SetReturnDateBookCommand(int id, DateTime returnDate)
        {
            Id = id;
            ReturnDate = returnDate;
        }

        public int Id { get; set; }

        public DateTime ReturnDate {  get; set; }

    }
}
