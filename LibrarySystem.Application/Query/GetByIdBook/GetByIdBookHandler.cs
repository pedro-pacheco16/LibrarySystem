using Azure.Core;
using LibrarySystem.Application.Models;
using LibrarySystem.Application.Query.GetByIdBook;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetByIdBookHandler : IRequestHandler<GetByIdBookQuery, ResultViewModel<BookViewModel>>
{
    private readonly LibrarySystemDbContext _context;

    public GetByIdBookHandler(LibrarySystemDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel<BookViewModel>> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
    {
        var books = await _context.Books
               .Include(l => l.LoanList)
               .SingleOrDefaultAsync(b => b.Id == request.Id);

        if (books is null)
        {
            return ResultViewModel<BookViewModel>.Error("Livro não encontrado");
        }

        var model = BookViewModel.FromEntity(books);

        return ResultViewModel<BookViewModel>.Success(model);
    }
}
