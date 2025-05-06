using LibrarySystem.Application.Models;
using MediatR;

namespace LibrarySystem.Application.Command.CreateUser
{
    public class CreateUserCommand : IRequest<ResultViewModel<int>>
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
