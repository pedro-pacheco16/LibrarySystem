using LibrarySystem.Application.Command.CreateLoan;
using LibrarySystem.Application.Command.ReturnBook;
using LibrarySystem.Application.Command.SetReturnDateBook;
using LibrarySystem.Application.Query.GetAllLoan;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/loan")]
    [ApiController]
    public class LoanController : ControllerBase
    {
         private readonly IMediator _mediator;
        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoans()
        {
            var result = await _mediator.Send(new GetAllLoanQuery());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoan(CreateLoanCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPut("{id}/set-return")]
        public async Task<IActionResult> SetReturnDate(int id, DateTime returnDate)
        {
            var result = await _mediator.Send(new SetReturnDateBookCommand(id, returnDate));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("{id}/returnBook")]
        public async Task<IActionResult> ReturnBook(int id, DateTime returned)
        {
            var result = await _mediator.Send(new ReturnBookCommand(id, returned));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}