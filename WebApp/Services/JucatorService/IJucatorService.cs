using WebApp.Models.Jucator;

namespace WebApp.Services.JucatorService
{
    public interface IJucatorService
    {
        Task<IEnumerable<Jucator>> GetAllJucatori();
        Task<Jucator> CreateJucator(Jucator jucator);
        Task<Jucator> GetJucator(Guid id);

        Task DeleteJucator(Jucator jucator);

        Task UpdateJucator(Jucator jucator);

        Task<IEnumerable<Jucator>> GetAllJucatoriAsync();
        Task<Jucator> GetJucatorAsync(Guid id);
    }
}
