using LibrarySystem.Application.Command.CreateUser;
using LibrarySystem.Application.Models;
using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Repositories;
using MediatR;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, ResultViewModel<int>>
{
    private readonly IUserRepository _repository;

    public CreateUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Email);

       await _repository.CreateUser(user);

        return ResultViewModel<int>.Success(user.Id);
    }
}
