using WebApp.Models.Baza_sportiva;

namespace WebApp.Services.BazaService
{
    public interface IBazaService
    {
        Task<IEnumerable<Baza_sportiva>> GetAllBaze();
        Task<Baza_sportiva> CreateBaza(Baza_sportiva baza);
        Task<Baza_sportiva> GetBaza(Guid id);

        Task DeleteBaza(Baza_sportiva baza);

        Task UpdateBaza(Baza_sportiva baza);

        Task<Baza_sportiva> GetBazaById(Guid id);
    }
}
