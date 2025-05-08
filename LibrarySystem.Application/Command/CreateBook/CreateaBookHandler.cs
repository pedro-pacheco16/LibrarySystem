using LibrarySystem.Application.Models;
using LibrarySystem.Core.Repositories;
using MediatR;

namespace LibrarySystem.Application.Command.CreateBook
{
    public class CreateaBookHandler : IRequestHandler<CreateBookCommand, ResultViewModel<int>>
    {
        private readonly IBookRepository _repository;

        public CreateaBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.ToEntity();

            await _repository.CreateBook(book);
           
            return ResultViewModel<int>.Success(book.Id);
        }
    }
}
