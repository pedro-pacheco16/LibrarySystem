using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibrarySystemDbContext _context;

        public UserRepository(LibrarySystemDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }
    }
}
