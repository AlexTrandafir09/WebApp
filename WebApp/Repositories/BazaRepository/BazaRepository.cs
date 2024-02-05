using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models.Baza_sportiva;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories.BazaRepository
{
    public class BazaRepository : GenericRepository<Baza_sportiva>, IBazaRepository
    {
        public BazaRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public async Task<IEnumerable<Baza_sportiva>> GetAllBazeAsync() {
            return await _table.Include(b => b.echipa).AsNoTracking().ToListAsync();
        }
        public async Task<Baza_sportiva> GetBazaByIdAsync(Guid id)
        {
            return await _table.Where(b => b.Id == id)
                  .Include(b => b.echipa)
                  .AsNoTracking()
                  .FirstOrDefaultAsync();
        }
    }
}
