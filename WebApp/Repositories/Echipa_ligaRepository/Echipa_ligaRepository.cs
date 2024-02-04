using WebApp.Data;
using WebApp.Models.Echipa_liga;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories.Echipa_ligaRepository
{
    public class Echipa_ligaRepository : GenericRepository<Echipa_liga>, IEchipa_ligaRepository
    {
        public Echipa_ligaRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
