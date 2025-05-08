using LibrarySystem.Application.Models;
using LibrarySystem.Application.Query.GetByIdBook;
using LibrarySystem.Core.Repositories;
using MediatR;


public class GetByIdBookHandler : IRequestHandler<GetByIdBookQuery, ResultViewModel<BookViewModel>>
{
    private readonly IBookRepository _repository;

    public GetByIdBookHandler(IBookRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<BookViewModel>> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
    {
        var books = await _repository.GetById(request.Id);

        if (books is null)
        {
            return ResultViewModel<BookViewModel>.Error("Livro não encontrado");
        }

        var model = BookViewModel.FromEntity(books);

        return ResultViewModel<BookViewModel>.Success(model);
    }
}
