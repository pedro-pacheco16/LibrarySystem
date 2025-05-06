using LibrarySystem.Application.Command.CreateUser;
using LibrarySystem.Application.Models;
using LibrarySystem.Core.Entities;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, ResultViewModel<int>>
{
    private readonly LibrarySystemDbContext _context;

    public CreateUserHandler(LibrarySystemDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Email);

       await _context.Users.AddAsync(user);
       await _context.SaveChangesAsync();

        return ResultViewModel<int>.Success(user.Id);
    }
}
