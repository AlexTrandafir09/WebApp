using WebApp.Models.Echipa;
using WebApp.Models.Echipa_liga;
using WebApp.Repositories.Echipa_ligaRepository;

namespace WebApp.Services.Echipa_ligaService
{
    public class Echipa_ligaService : IEchipa_ligaService
    {
        private readonly IEchipa_ligaRepository elRepository;

        public Echipa_ligaService(IEchipa_ligaRepository echipa_LigaRepository)
        {
            elRepository = echipa_LigaRepository;
        }

        public async Task CreateEchipa_liga(Echipa_liga echipa_liga)
        {
            await elRepository.CreateAsync(echipa_liga);
            await elRepository.SaveAsync();
        }

        public async Task DeleteEchipa_liga(Echipa_liga echipa_liga)
        {
            elRepository.Delete(echipa_liga);
            await elRepository.SaveAsync();
        }

        public async Task<IEnumerable<Echipa_liga>> GetAllEchipe_ligi()
        {
            return await elRepository.GetAllAsync();
        }

        public async Task<Echipa_liga> GetEchipa_liga(Guid id)
        {
            return await elRepository.FindByIdAsync(id);
        }

        public async Task UpdateEchipa_liga(Echipa_liga echipa_liga)
        {
            elRepository.Update(echipa_liga);
            await elRepository.SaveAsync();
        }
    }
}
