using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MiBand.API.Persistence.Repositories
{
    public class SectionRepository : BaseRepository, IStateRepository<Section>
    {
        public SectionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Section model)
        {
            await _context.Sections.AddAsync(model);
        }

        public void Delete(Section model)
        {
            _context.Sections.Remove(model);
        }

        public async Task<Section> FindByIdAsync(int id)
        {
            return await _context.Sections.FindAsync(id);
        }

        public async Task<IEnumerable<Section>> ListByIdAsync(int id)
        {
            return await _context.Sections.Where(i => i.BoxId == id).ToListAsync();
        }

        public void Update(Section model)
        {
            _context.Sections.Update(model);
        }
    }
}
