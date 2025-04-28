using LibrarySystem.Core.Enums;

namespace LibrarySystem.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, string isbn, int publication) : base()
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            Publication = publication;

            Status = BookStatusEnum.available;
            LoanList = [];
        }

        public string Title { get; private set; }

        public string Author { get; private set; }

        public string Isbn { get; private set; }

        public int Publication { get; private set; }

        public BookStatusEnum Status { get; private set; }

        public List<Loan> LoanList { get; private set; }

        public void Available()
        {
            Status = BookStatusEnum.available;
        }

        public void Unavailable()
        {
            Status = BookStatusEnum.unavailable;
        }

        public void Loan()
        {
            Status = BookStatusEnum.Loan;
        }

        public void Reserved()
        {
            Status = BookStatusEnum.reserved;
        }

        public void Update(string title, string author, string isbn, int publication)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            Publication = publication;
        }
    }
}
