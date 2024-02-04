using WebApp.Models.Baza_sportiva;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories.BazaRepository
{
    public interface IBazaRepository : IGenericRepository<Baza_sportiva>
    {
        Task<IEnumerable<Baza_sportiva>> GetAllBazeAsync();
    }
}
