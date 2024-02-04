using WebApp.Models.Echipa;

namespace WebApp.Services.EchipaService
{
    public interface IEchipaService
    {
        Task<IEnumerable<Echipa>> GetAllEchipe();
        Task CreateEchipa(Echipa echipa);
        Task<Echipa> GetEchipa(Guid id);

        Task DeleteEchipa(Echipa echipa);

        Task UpdateEchipa(Echipa echipa);
        Task<Echipa> GetEchipaById(Guid echipa_id);
    }
}
