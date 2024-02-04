using WebApp.Models.Echipa;
using WebApp.Repositories.EchipaRepository;

namespace WebApp.Services.EchipaService
{
    public interface IEchipaService
    {
        Task<IEnumerable<Echipa>> GetAllEchipe();
        Task CreateEchipa(Echipa echipa);
        Task<Echipa> GetEchipa(Guid id);

        Task DeleteEchipa(Echipa echipa);

        Task UpdateEchipa(Echipa echipa);


    }
}
