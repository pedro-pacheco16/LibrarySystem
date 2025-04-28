using LibrarySystem.Application.Models;

namespace LibrarySystem.Application.Services
{
    public interface IUserService
    {
        ResultViewModel<List<UserViewModel>> GetAll();

        ResultViewModel<int> CreateUser(CreateUserInputModel model);
    }
}
