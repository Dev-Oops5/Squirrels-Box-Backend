using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MiBand.API.Persistence.Repositories
{
    public class SpecRepository : BaseRepository, IStateRepository<Spec>
    {
        public SpecRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Spec model)
        {
            await _context.Specs.AddAsync(model);
        }

        public void Delete(Spec model)
        {
            _context.Specs.Remove(model);
        }

        public async Task<Spec> FindByStringAsync(string value)
        {
            return await _context.Specs.FirstOrDefaultAsync(i => i.Id.ToString() == value);
        }

        public async Task<IEnumerable<Spec>> ListByIdAsync(int id)
        {
            return await _context.Specs.Where(i => i.ItemId == id).ToListAsync();
        }

        public void Update(Spec model)
        {
            _context.Specs.Update(model);
        }
    }
}
