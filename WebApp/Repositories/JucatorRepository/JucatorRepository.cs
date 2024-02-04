using WebApp.Data;
using WebApp.Models.Jucator;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories.JucatorRepository
{
    public class JucatorRepository : GenericRepository<Jucator>, IJucatorRepository
    {
        public JucatorRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
