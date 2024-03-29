﻿using WebApp.Models.Baza_sportiva;
using WebApp.Models.Echipa;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories.EchipaRepository
{
    public interface IEchipaRepository : IGenericRepository<Echipa>
    {
        Task<Echipa> GetEchipaAsync(Guid Id);
        Task<ICollection<Echipa>> GetAllEchipeAsync();
    }
}
