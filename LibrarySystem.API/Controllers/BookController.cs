using LibrarySystem.Application.Models;
using LibrarySystem.Application.Services;
using LibrarySystem.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.API.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService librarySystemService)
        {
            _bookService = librarySystemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _bookService.GetAllBooks();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _bookService.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateBook(CreateBookInputModel model)
        {
            var result = _bookService.CreateBook(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, UpdateBookInputModel model)
        {
            var result = _bookService.UpdateBook(model);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var result = _bookService.DeleteBook(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

    }
}
