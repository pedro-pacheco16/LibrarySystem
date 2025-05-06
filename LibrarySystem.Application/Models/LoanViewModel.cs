using LibrarySystem.Core.Entities;

namespace LibrarySystem.Application.Models
{
    public class LoanViewModel
    {
        public LoanViewModel(int idLoan,string title, string userName, DateTime loanDate, DateTime returnFromLoan)
        {
            IdLoan = idLoan;
            Title = title;
            UserName = userName;
            LoanDate = loanDate;
            ReturnFromLoan = returnFromLoan;
        }
        public int IdLoan { get; private set; }

        public string Title { get; private set; }

        public string UserName { get; private set; }

        public DateTime LoanDate { get; private set; }

        public DateTime ReturnFromLoan { get; private set; }

        public static LoanViewModel FromEntity(Loan entity)
            => new LoanViewModel(entity.Id, entity.Book.Title, entity.User.Name, entity.LoanDate, entity.ReturnFromLoan);
    }
}
