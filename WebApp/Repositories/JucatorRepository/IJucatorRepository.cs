using WebApp.Models.Jucator;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories.JucatorRepository
{
    public interface IJucatorRepository :IGenericRepository<Jucator>
    {
        Task<IEnumerable<Jucator>> GetAllJucatoriAsync();
        Task<Jucator> GetJucatorByIdAsync(Guid id);
    }
}
