using WebApp.Models.Echipa;
using WebApp.Models.Echipa_liga;
using WebApp.Models.Liga;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories.Echipa_ligaRepository
{
    public interface IEchipa_ligaRepository 
    {
        Task CreateAsync(Echipa_liga echipa_liga);
        void Delete(Echipa_liga echipa_liga);
        Task<IEnumerable<Echipa_liga>> GetAllElAsync();
        Task<bool> SaveAsync();
        void Update(Echipa_liga echipa_liga);
    }
}
