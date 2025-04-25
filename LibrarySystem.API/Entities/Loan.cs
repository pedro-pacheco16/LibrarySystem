namespace LibrarySystem.API.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int idUser, int idBook) : base()
        {
            IdUser = idUser;
            IdBook = idBook;
            LoanDate = DateTime.Now;
            ReturnFromLoan = LoanDate.AddMonths(3);
        }

        public int IdUser { get; private set; }

        public int IdBook { get; private set; }

        public DateTime LoanDate { get; private set; }

        public DateTime ReturnFromLoan { get; private set; }

        public DateTime? ReturnedAt { get; private set; }

        public User User { get; private set; }

        public Book Book { get; private set; }

        public void SetReturnDate (DateTime returnFromLoan)
        {
            ReturnFromLoan = returnFromLoan;
        }

        public void MarkAsReturned(DateTime returnAt)
        {
            ReturnedAt = DateTime.Now;
        }
    }
}
