using WebApp.Models.Baza_sportiva;
using WebApp.Repositories.BazaRepository;

namespace WebApp.Services.BazaService
{
    public class BazaService: IBazaService
    {
        private readonly IBazaRepository _bazaRepository;

        public BazaService(IBazaRepository bazaRepository)
        {
            _bazaRepository = bazaRepository;
        }

        public async Task CreateBaza(Baza_sportiva baza)
        {
            await _bazaRepository.CreateAsync(baza);
            await _bazaRepository.SaveAsync();
        }

        public async Task DeleteBaza(Baza_sportiva baza)
        {
            _bazaRepository.Delete(baza);
            await _bazaRepository.SaveAsync();
        }

        public async Task<IEnumerable<Baza_sportiva>> GetAllBaze()
        {
            return await _bazaRepository.GetAllAsync();
        }

        public async Task<Baza_sportiva> GetBaza(Guid id)
        {
            return await _bazaRepository.FindByIdAsync(id);
        }

        public async Task UpdateBaza(Baza_sportiva baza)
        {
            _bazaRepository.Update(baza);
            await _bazaRepository.SaveAsync();
        }
    }
}
