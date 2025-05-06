using LibrarySystem.Application.Models;
using MediatR;

namespace LibrarySystem.Application.Query.GetAllUser
{
    public class GetAllUserQuery : IRequest<ResultViewModel<List<UserViewModel>>>
    {

    }
}
