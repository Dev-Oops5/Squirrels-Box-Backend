using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MiBand.API.Persistence.Repositories
{
    public class SharedRepository : BaseRepository, IStateRepository<Shared>
    {
        public SharedRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Shared model)
        {
            await _context.Shareds.AddAsync(model);
        }

        public void Delete(Shared model)
        {
            _context.Shareds.Remove(model);
        }

        public async Task<Shared> FindByIdAsync(int id)
        {
            return await _context.Shareds.FindAsync(id);
        }

        public async Task<IEnumerable<Shared>> ListByIdAsync(int id)
        {
            return await _context.Shareds.Where(i => i.ReceiverId == id).ToListAsync();
        }

        public void Update(Shared model)
        {
            _context.Shareds.Update(model);
        }
    }
}
