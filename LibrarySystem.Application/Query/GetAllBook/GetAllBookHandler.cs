using LibrarySystem.Application.Models;
using LibrarySystem.Application.Query.GetAllBook;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllBookHandler : IRequestHandler<GetAllBookQuery, ResultViewModel<List<BookViewModel>>>
{
    private readonly LibrarySystemDbContext _context;

    public GetAllBookHandler(LibrarySystemDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel<List<BookViewModel>>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
    {
        var books = await _context.Books
            .Where(b => !b.IsDeleted)
            .ToListAsync();

        var model = books.Select(BookViewModel.FromEntity).ToList();

        return ResultViewModel<List<BookViewModel>>.Success(model);
    }
}
