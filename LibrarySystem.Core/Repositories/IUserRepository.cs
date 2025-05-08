using LibrarySystem.Core.Entities;

namespace LibrarySystem.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll(); 

        Task<int> CreateUser(User user);
    }
}
