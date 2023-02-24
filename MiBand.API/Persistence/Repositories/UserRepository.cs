using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MiBand.API.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IBaseRespository<User>
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(User model)
        {
            await _context.Users.AddAsync(model);
        }

        public void Delete(User model)
        {
            _context.Users.Remove(model);
        }

        public async Task<User> FindByStringAsync(string value)
        {
            return await _context.Users.FirstOrDefaultAsync(i => i.Id.ToString() == value);
        }

        public void Update(User model)
        {
            _context.Users.Update(model);
        }
    }
}
