using LibrarySystem.Application.Command.UpdateBook;
using LibrarySystem.Application.Models;
using LibrarySystem.Core.Repositories;
using MediatR;

public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ResultViewModel>
{
    private readonly IBookRepository _repository;

    public UpdateBookHandler(IBookRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {

        var book = await _repository.GetById(request.IdBook);

        if (book is null)
        {
            return ResultViewModel.Error("Livro não encontrado");
        }

        book.Update(request.Title, request.Author, request.Isbn, request.Publication);

        await _repository.UpdateBook(book);

        return ResultViewModel.Success();
    }
}
