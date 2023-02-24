using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MiBand.API.Persistence.Repositories
{
    public class BoxRepository : BaseRepository, IStateRepository<Box>
    {
        public BoxRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Box model)
        {
            await _context.Boxes.AddAsync(model);
        }

        public void Delete(Box model)
        {
            _context.Boxes.Remove(model);
        }

        public async Task<Box> FindByStringAsync(string value)
        {
            return await _context.Boxes.FirstOrDefaultAsync(i => i.Id.ToString() == value);
        }

        public async Task<IEnumerable<Box>> ListByIdAsync(int id)
        {
            return await _context.Boxes.Where(i => i.UserId == id).ToListAsync();
        }

        public void Update(Box model)
        {
            _context.Boxes.Update(model);
        }
    }
}
