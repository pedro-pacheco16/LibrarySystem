using LibrarySystem.API.Models;
using LibrarySystem.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.API.Controllers
{
    [Route("api/loan")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly LibrarySystemDbContext _context;

        public LoanController(LibrarySystemDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllLoans()
        {
            var loans = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .ToList();

            var loanViewModel = loans.Select(LoanViewModel.FromEntity).ToList();

            return Ok(loanViewModel);
        }

        [HttpPost]
        public IActionResult CreateLoan(CreateLoanInputModel loanModel)
        {
            var loan = loanModel.ToEntity();

            _context.Loans.Add(loan);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}/set-return")]
        public IActionResult SetReturnDate(int id, DateTime returnDate)
        {
            var loan = _context.Loans.SingleOrDefault(l => l.Id == id);

            if (loan is null)
                return NotFound("Empréstimo não encontrado.");

            loan.SetReturnDate(returnDate);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}/returnBook")]
        public IActionResult ReturnBook(int id, DateTime? returned)
        {
            var returnBook = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .SingleOrDefault(r => r.Id == id);

            if (returnBook is null)
            {
                return NotFound("Empréstimo não encontrado.");
            }

            if (returnBook.ReturnedAt.HasValue)
            {
                return BadRequest("Livro já foi devolvido.");
            }

            var returnDate = returned ?? DateTime.Now;

            returnBook.MarkAsReturned(returnDate);
            _context.SaveChanges();

            var atraso = (returnDate - returnBook.ReturnFromLoan).Days;

            if (atraso > 0)
            {

                return Ok(new
                {
                    message = $"Livro devolvido com {atraso} dias de atraso.",
                    dataDevolucao = returnDate.ToShortDateString()
                });
            }
            else
            {
                return Ok(new
                {
                    message = "Livro devolvido dentro do prazo.",
                    dataDevolucao = returnDate.ToShortDateString()
                });
            }
        }
    }
}