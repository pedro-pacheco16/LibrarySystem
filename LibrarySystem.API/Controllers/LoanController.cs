using LibrarySystem.Application.Models;
using LibrarySystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/loan")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public IActionResult GetAllLoans()
        {
            var result = _loanService.GetAll();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateLoan(CreateLoanInputModel loanModel)
        {
            var result = _loanService.CreateLoan(loanModel);

            return Ok(result);
        }

        [HttpPut("{id}/set-return")]
        public IActionResult SetReturnDate(int id, DateTime returnDate)
        {
            var result = _loanService.SetReturnDate(id, returnDate);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("{id}/returnBook")]
        public IActionResult ReturnBook(int id, DateTime returned)
        {
            var result = _loanService.ReturnBook(id, returned);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}