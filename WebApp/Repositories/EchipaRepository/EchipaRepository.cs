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
            return await _table.Where(b => b.Id == id)
                  .AsNoTracking()
                  .FirstOrDefaultAsync();
        }
    }
}
