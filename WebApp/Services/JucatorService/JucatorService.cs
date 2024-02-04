using WebApp.Models.Echipa;
using WebApp.Models.Jucator;
using WebApp.Repositories.JucatorRepository;

namespace WebApp.Services.JucatorService
{
    public class JucatorService :IJucatorService
    {
        private readonly IJucatorRepository _jucatorRepository;

        public JucatorService(IJucatorRepository jucatorRepository)
        {
            _jucatorRepository = jucatorRepository;
        }

        public async Task CreateJucator(Jucator jucator)
        {
            await _jucatorRepository.CreateAsync(jucator);
            await _jucatorRepository.SaveAsync();
        }

        public async Task DeleteJucator(Jucator jucator)
        {
            _jucatorRepository.Delete(jucator);
            await _jucatorRepository.SaveAsync();
        }

        public async Task<IEnumerable<Jucator>> GetAllJucatori()
        {
            return await _jucatorRepository.GetAllAsync();
        }

        public async Task<Jucator> GetJucator(Guid id)
        {
            return await _jucatorRepository.FindByIdAsync(id);
        }

        public async Task UpdateJucator(Jucator jucator)
        {
            _jucatorRepository.Update(jucator);
            await _jucatorRepository.SaveAsync();
        }
    }
}
