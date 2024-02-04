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
    }
}
