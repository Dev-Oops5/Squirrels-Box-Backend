using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MiBand.API.Persistence.Repositories
{
    public class SessionRepository : BaseRepository, IBaseRespository<Session>, ISessionRepository
    {
        public SessionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Session model)
        {
            await _context.Sesions.AddAsync(model);
        }

        public void Delete(Session model)
        {
            _context.Sesions.Remove(model);
        }

        public async Task<Session> FindByIdAsync(int id)
        {
            return await _context.Sesions.FindAsync(id);
        }

        public async Task<Session> FindByUsernameOrEmailAndPasswordAsync(string username, string email, string password)
        {
            {
                return await _context.Sesions.FirstOrDefaultAsync(
                    i => 
                    ((i.Username !=null && i.Username == username) || (i.Email != null && i.Email == email)) 
                    && i.Password == password);
            }
        }

        public void Update(Session model)
        {
            _context.Sesions.Update(model);
        }
    }
}
