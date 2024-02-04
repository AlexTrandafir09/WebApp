using WebApp.Models.Liga;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories.LigaRepository
{
    public interface ILigaRepository: IGenericRepository<Liga>
    {
        Task<IEnumerable<Liga>> GetAllLigiAsync();
        Task<Liga> GetLigaByIdAsync(Guid id);
    }
}
