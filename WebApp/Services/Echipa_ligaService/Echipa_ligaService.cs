using Microsoft.AspNetCore.Http.HttpResults;
using WebApp.Models.Echipa;
using WebApp.Models.Echipa_liga;
using WebApp.Models.Liga;
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

        public async Task<Echipa_liga> CreateEchipa_liga(Echipa_liga echipa_liga)
        {
            await elRepository.CreateAsync(echipa_liga);
            await elRepository.SaveAsync();
            return echipa_liga;
        }

        public async Task DeleteEchipa_liga(Echipa_liga echipa_liga)
        {
            elRepository.Delete(echipa_liga);
            await elRepository.SaveAsync();
        }



        public async Task UpdateEchipa_liga(Echipa_liga echipa_liga)
        {
            elRepository.Update(echipa_liga);
            await elRepository.SaveAsync();
        }
        public async Task<IEnumerable<Echipa_liga>> GetAllEchipe_ligiAsync() {
            return await elRepository.GetAllElAsync();
        }

        public async Task<Echipa_liga> AdaugaRelatie(Liga liga, Echipa echipa)
        {
            var echipa_liga = new Echipa_liga
            {
                Echipa_id = echipa.Id,
                Liga_id = liga.Id

            };
            liga.echipe_ligi.Add(echipa_liga);

            echipa.echipe_ligi.Add(echipa_liga);

            await elRepository.CreateAsync(echipa_liga);
            await elRepository.SaveAsync();
            return echipa_liga;
        }

    }
}
