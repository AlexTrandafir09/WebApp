using WebApp.Models.Jucator;

namespace WebApp.Services.JucatorService
{
    public interface IJucatorService
    {
        Task<IEnumerable<Jucator>> GetAllJucatori();
        Task CreateJucator(Jucator jucator);
        Task<Jucator> GetJucator(Guid id);

        Task DeleteJucator(Jucator jucator);

        Task UpdateJucator(Jucator jucator);
    }
}
