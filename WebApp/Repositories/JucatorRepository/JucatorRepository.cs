using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models.Baza_sportiva;
using WebApp.Models.Jucator;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories.JucatorRepository
{
    public class JucatorRepository : GenericRepository<Jucator>, IJucatorRepository
    {
        public JucatorRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public async Task<IEnumerable<Jucator>> GetAllJucatoriAsync()
        {
            return await _table.Include(b => b.echipa).AsNoTracking().ToListAsync();
        }
        public async Task<Jucator> GetJucatorByIdAsync(Guid id)
        {
            return await _table.Where(b => b.Id == id)
                  .Include(b=>b.echipa)
                  .FirstOrDefaultAsync();
        }
    }
}
