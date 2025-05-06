using LibrarySystem.Application.Command.DeleteBook;
using LibrarySystem.Application.Models;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ResultViewModel>
{
    private readonly LibrarySystemDbContext _context;

    public DeleteBookHandler(LibrarySystemDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == request.Id);

        if (book is null)
        {
            return ResultViewModel.Error("Livro Não encontrado");
        }

        book.setAsDeleted();
        _context.Books.Update(book);
        await _context.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}
