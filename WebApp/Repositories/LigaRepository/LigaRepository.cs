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
    }
}
