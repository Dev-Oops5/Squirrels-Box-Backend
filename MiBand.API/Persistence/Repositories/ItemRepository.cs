using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MiBand.API.Persistence.Repositories
{
    public class ItemRepository : BaseRepository, IStateRepository<Item>
    {
        public ItemRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Item model)
        {
            await _context.Items.AddAsync(model);
        }

        public void Delete(Item model)
        {
            _context.Items.Remove(model);
        }

        public async Task<Item> FindByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<IEnumerable<Item>> ListByIdAsync(int id)
        {

            return await _context.Items.Where(i => i.SectionId == id).ToListAsync();
        }

        public void Update(Item model)
        {
            _context.Items.Update(model);
        }
    }
}
