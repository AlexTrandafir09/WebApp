using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models.Echipa;
using WebApp.Models.Echipa_liga;
using WebApp.Models.Liga;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories.Echipa_ligaRepository
{
    public class Echipa_ligaRepository : IEchipa_ligaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Echipa_liga> _table;
        public Echipa_ligaRepository(ApplicationDbContext context)
        {
            _context = context;
            _table=_context.Set<Echipa_liga>();
        }
        public async Task<IEnumerable<Echipa_liga>> GetAllElAsync()
        {
            return await _table.Include(e => e.echipa).Include(e => e.liga).AsNoTracking().ToListAsync();
        }


        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task CreateAsync(Echipa_liga echipa_liga)
        {
            await _table.AddAsync(echipa_liga);
        }

        public void Delete(Echipa_liga echipa_liga)
        {
            _table.Remove(echipa_liga);
        }
        public void Update(Echipa_liga echipa_liga)
        {
            _table.Update(echipa_liga);
        }


    }
}
