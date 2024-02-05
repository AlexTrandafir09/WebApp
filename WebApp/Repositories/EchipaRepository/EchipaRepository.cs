using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models.Echipa;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories.EchipaRepository
{
    public class EchipaRepository : GenericRepository<Echipa>, IEchipaRepository
    {
        public EchipaRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public async Task<Echipa> GetEchipaAsync(Guid id)
        {
            return await _table.Include(e => e.jucatori)
                              .Include(el => el.echipe_ligi)
                              .Include(b => b.baza)
                .Where(b => b.Id == id)
                  .AsNoTracking()
                  .FirstOrDefaultAsync();
        }
        public async Task<ICollection<Echipa>> GetAllEchipeAsync()
        {
            return await _table.Include(e => e.jucatori)
                              .Include(el => el.echipe_ligi)
                              .Include(b => b.baza)
                              .AsNoTracking()
                              .ToListAsync();
        }

    }
}
