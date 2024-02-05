using WebApp.Models.Echipa;
using WebApp.Models.Echipa_liga;
using WebApp.Models.Liga;

namespace WebApp.Services.Echipa_ligaService
{
    public interface IEchipa_ligaService
    {
        Task<Echipa_liga>CreateEchipa_liga(Echipa_liga echipa_liga);
     

        Task DeleteEchipa_liga(Echipa_liga echipa_liga);

        Task UpdateEchipa_liga(Echipa_liga echipa_liga);
        Task<IEnumerable<Echipa_liga>> GetAllEchipe_ligiAsync();
        Task<Echipa_liga>AdaugaRelatie(Liga liga, Echipa echipa);
    }
}
