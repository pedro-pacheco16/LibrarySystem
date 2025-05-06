using LibrarySystem.Application.Models;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;

namespace LibrarySystem.Application.Command.CreateBook
{
    public class CreateaBookHandler : IRequestHandler<CreateBookCommand, ResultViewModel<int>>
    {
        private readonly LibrarySystemDbContext _context;

        public CreateaBookHandler(LibrarySystemDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.ToEntity();

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(book.Id);
        }
    }
}
