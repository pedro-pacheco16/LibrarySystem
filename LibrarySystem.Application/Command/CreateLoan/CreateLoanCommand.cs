using LibrarySystem.Application.Models;
using LibrarySystem.Core.Entities;
using MediatR;

namespace LibrarySystem.Application.Command.CreateLoan
{
    public class CreateLoanCommand : IRequest<ResultViewModel<int>>
    {
        public int IdUser { get; set; }

        public int IdBook { get; set; }

        public DateTime LoanBook { get; set; }

        public Loan ToEntity()
            => new(IdUser, IdBook);
    }
}
