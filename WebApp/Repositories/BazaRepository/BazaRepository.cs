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
    }
}
