using LibrarySystem.Application.Models;
using LibrarySystem.Application.Query.GetAllUser;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, ResultViewModel<List<UserViewModel>>>
{
    private readonly LibrarySystemDbContext _context;

    public GetAllUserHandler(LibrarySystemDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _context.Users.ToListAsync();

        var model = users.Select(user => new UserViewModel(user.Name, user.Email)).ToList();

        return ResultViewModel<List<UserViewModel>>.Success(model);
    }
}
