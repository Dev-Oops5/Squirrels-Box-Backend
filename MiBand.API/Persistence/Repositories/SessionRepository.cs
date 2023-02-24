using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MiBand.API.Persistence.Repositories
{
    public class SessionRepository : BaseRepository, IBaseRespository<Session>
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

        public async Task<Session> FindByStringAsync(string value)
        {
            return await _context.Sesions.FirstOrDefaultAsync(i => i.Id.ToString() == value);
        }

        public void Update(Session model)
        {
            _context.Sesions.Update(model);
        }
    }
}
