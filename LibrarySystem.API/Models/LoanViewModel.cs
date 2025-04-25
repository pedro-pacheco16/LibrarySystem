using LibrarySystem.API.Entities;

namespace LibrarySystem.API.Models
{
    public class LoanViewModel
    {
        public LoanViewModel(string title, string userName, DateTime loanDate, DateTime returnFromLoan)
        {
            Title = title;
            UserName = userName;
            LoanDate = loanDate; 
            ReturnFromLoan = returnFromLoan;
        }

        public string Title { get; private set; }

        public string UserName { get; private set; }

        public DateTime LoanDate { get; private set; }

        public DateTime ReturnFromLoan { get; private set; }

        public static LoanViewModel FromEntity(Loan entity)
            => new LoanViewModel(entity.Book.Title, entity.User.Name, entity.LoanDate, entity.ReturnFromLoan);
    }
}
