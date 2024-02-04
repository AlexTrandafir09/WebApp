using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApp.Data;
using WebApp.Models.Liga;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories.LigaRepository
{
    public class LigaRepository : GenericRepository<Liga>, ILigaRepository
    {
        public LigaRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
            public async Task<IEnumerable<Liga>> GetAllLigiAsync()
            {
                return await _table.AsNoTracking().ToListAsync();
            }
            public async Task<Liga> GetLigaByIdAsync(Guid id)
            {
                return await _table.AsNoTracking().FirstOrDefaultAsync();
            }
    }
}
