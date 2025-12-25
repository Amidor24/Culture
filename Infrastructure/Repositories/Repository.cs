using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository(ApplicationDbContext context) : IRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Culture> Add(Culture culture)
        {
            _context.Cultures.Add(culture);

            await _context.SaveChangesAsync();

            return culture;
        }

        public async Task<IReadOnlyList<Culture>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.Cultures
                .AsNoTracking()
                .ToListAsync(ct);
        }


        public async Task<Culture?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.Cultures.FirstOrDefaultAsync(s => s.Id == id, ct);
        }

        public Task UpdateAsync(Culture culture, CancellationToken ct = default)
        {
            _context.Cultures.Update(culture);
            return _context.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            Culture? culture = await GetByIdAsync(id, ct);

            if (culture is not null)
            {
                _context.Cultures.Remove(culture);
                await _context.SaveChangesAsync(ct);
            }
            else
            {
                return;
            }
        }
    }
}
