using WebApp.Models.Liga;

namespace WebApp.Services.LigaService
{
    public interface ILigaService
    {
        Task<IEnumerable<Liga>> GetAllLigi();
        Task CreateLiga(Liga liga);
        Task<Liga> GetLiga(Guid id);

        Task DeleteLiga(Liga liga);

        Task UpdateLiga(Liga liga);

        Task <Liga> GetLigaAsync(Guid id);
        Task<IEnumerable<Liga>> GetAllLigiAsync();
    }
}
