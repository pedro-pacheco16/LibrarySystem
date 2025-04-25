using LibrarySystem.API.Entities;

namespace LibrarySystem.API.Models
{
    public class CreateLoanInputModel
    {
        public int IdUser { get; set; }

        public int IdBook { get; set; }

        public DateTime LoanBook {  get; set; }

        public Loan ToEntity()
            => new(IdUser, IdBook);
    }
}