using LibrarySystem.API.Models;
using LibrarySystem.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.API.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibrarySystemDbContext _context;
        public BookController(LibrarySystemDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _context.Books.ToList();

            var model = books.Select(BookViewModel.FromEntity).ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var books = _context.Books
                .Include(l => l.LoanList)
                .SingleOrDefault(b => b.Id == id);

            var model = BookViewModel.FromEntity(books);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateBook(CreateBookInputModel model)
        {
            var book = model.ToEntity();

            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, UpdateBookInputModel model)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if(book is null)
            {
                return NoContent();
            }

            book.Update(model.Title, model.Author, model.Isbn, model.Publication);

            _context.Books.Update(book);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book is null)
            {
                return NoContent();
            }

            _context.Books.Update(book);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
