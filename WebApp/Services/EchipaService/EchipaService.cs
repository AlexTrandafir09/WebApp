using WebApp.Models.Echipa;
using WebApp.Repositories.EchipaRepository;
namespace WebApp.Services.EchipaService
{
    public class EchipaService : IEchipaService
    {
        private readonly IEchipaRepository _echipaRepository;

        public EchipaService(IEchipaRepository echipaRepository)
        {
            _echipaRepository = echipaRepository;
        }
        public async Task<IEnumerable<Echipa>> GetAllEchipe()
        {
            return await _echipaRepository.GetAllAsync();
        }
        public async Task CreateEchipa(Echipa echipa)
        {
            await _echipaRepository.CreateAsync(echipa);
            await _echipaRepository.SaveAsync();
        }
        public async Task<Echipa> GetEchipa(Guid id)
        {
            return await _echipaRepository.FindByIdAsync(id);
        }

        public async Task DeleteEchipa(Echipa echipa)
        {
            _echipaRepository.Delete(echipa);
            await _echipaRepository.SaveAsync();
        } 

        public async Task UpdateEchipa(Echipa echipa)
        {
            _echipaRepository.Update(echipa);
            await _echipaRepository.SaveAsync();
        }
    }
}
