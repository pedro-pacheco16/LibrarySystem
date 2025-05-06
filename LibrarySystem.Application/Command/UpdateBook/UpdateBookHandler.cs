using LibrarySystem.Application.Command.UpdateBook;
using LibrarySystem.Application.Models;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ResultViewModel>
{
    private readonly LibrarySystemDbContext _context;

    public UpdateBookHandler(LibrarySystemDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {

        var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == request.IdBook);

        if (book is null)
        {
            return ResultViewModel.Error("Livro não encontrado");
        }

        book.Update(request.Title, request.Author, request.Isbn, request.Publication);

        _context.Books.Update(book);
        await _context.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}
