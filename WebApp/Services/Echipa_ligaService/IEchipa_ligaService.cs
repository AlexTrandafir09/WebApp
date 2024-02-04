using WebApp.Models.Echipa_liga;

namespace WebApp.Services.Echipa_ligaService
{
    public interface IEchipa_ligaService
    {
        Task<IEnumerable<Echipa_liga>> GetAllEchipe_ligi();
        Task CreateEchipa_liga(Echipa_liga echipa_liga);
        Task<Echipa_liga> GetEchipa_liga(Guid id);

        Task DeleteEchipa_liga(Echipa_liga echipa_liga);

        Task UpdateEchipa_liga(Echipa_liga echipa_liga);
    }
}
