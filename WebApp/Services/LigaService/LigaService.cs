using WebApp.Models.Jucator;
using WebApp.Models.Liga;
using WebApp.Repositories.LigaRepository;

namespace WebApp.Services.LigaService
{
    public class LigaService:ILigaService
    {
        private readonly ILigaRepository _ligaRepository;

        public LigaService(ILigaRepository ligaRepository)
        {
            _ligaRepository = ligaRepository;
        }

        public async Task CreateLiga(Liga liga)
        {
            await _ligaRepository.CreateAsync(liga);
            await _ligaRepository.SaveAsync();
        }

        public async Task DeleteLiga(Liga liga)
        {
            _ligaRepository.Delete(liga);
            await _ligaRepository.SaveAsync();
        }

        public async Task<IEnumerable<Liga>> GetAllLigi()
        {
            return await _ligaRepository.GetAllAsync();
        }

        public async Task<Liga> GetLiga(Guid id)
        {
            return await _ligaRepository.FindByIdAsync(id);
        }

        public async Task UpdateLiga(Liga liga)
        {
            _ligaRepository.Update(liga);
            await _ligaRepository.SaveAsync();
        }
    }
}
