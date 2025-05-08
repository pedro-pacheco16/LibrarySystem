using LibrarySystem.Application.Models;
using LibrarySystem.Application.Query.GetAllUser;
using LibrarySystem.Core.Repositories;
using MediatR;

public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, ResultViewModel<List<UserViewModel>>>
{
    private readonly IUserRepository _repository;

    public GetAllUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAll();

        var model = users.Select(user => new UserViewModel(user.Name, user.Email)).ToList();

        return ResultViewModel<List<UserViewModel>>.Success(model);
    }
}
