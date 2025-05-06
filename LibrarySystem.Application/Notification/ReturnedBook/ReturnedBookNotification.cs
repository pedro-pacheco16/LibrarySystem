using MediatR;

namespace LibrarySystem.Application.Notification.ReturnedBook
{
    public class ReturnedBookNotification : INotification
    {
        public ReturnedBookNotification(int idLoan, string userName, DateTime returnBook, string email, int delayInDays)
        {
            IdLoan = idLoan;
            UserName = userName;
            ReturnBook = returnBook;
            Email = email;
            DelayInDays = delayInDays;
        }

        public int IdLoan { get; private set; }

        public string UserName { get; private set; }

        public DateTime ReturnBook {  get; private set; }

        public string Email { get; private set; }

        public int DelayInDays { get; private set; }
    }
}
