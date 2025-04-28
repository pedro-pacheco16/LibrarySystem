using LibrarySystem.Application.Models;
using LibrarySystem.Application.Services;
using LibrarySystem.Core.Entities;
using LibrarySystem.Infrastructure.Persistence;

public class UserService : IUserService
{
    private readonly LibrarySystemDbContext _context;

    public UserService(LibrarySystemDbContext context)
    {
        _context = context;
    }

    public ResultViewModel<int> CreateUser(CreateUserInputModel model)
    {
        var user = new User(model.Name, model.Email);

        _context.Users.Add(user);
        _context.SaveChanges();

        return ResultViewModel<int>.Success(user.Id);
    }

    public ResultViewModel<List<UserViewModel>> GetAll()
    {
        var users = _context.Users.ToList();

        var model = users.Select(user => new UserViewModel(user.Name, user.Email)).ToList();

        return ResultViewModel<List<UserViewModel>>.Success(model);
    }
}
