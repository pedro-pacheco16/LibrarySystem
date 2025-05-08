using LibrarySystem.Application.Command.DeleteBook;
using LibrarySystem.Application.Models;
using LibrarySystem.Core.Repositories;
using MediatR;

public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ResultViewModel>
{
    private readonly IBookRepository _repository;

    public DeleteBookHandler(IBookRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetById(request.Id);

        if (book is null)
        {
            return ResultViewModel.Error("Livro Não encontrado");
        }

        book.setAsDeleted();
        await _repository.UpdateBook(book);

        return ResultViewModel.Success();
    }
}
