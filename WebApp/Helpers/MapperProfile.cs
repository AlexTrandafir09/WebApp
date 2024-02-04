using AutoMapper;
using WebApp.Models.Baza_sportiva;
using WebApp.Models.Baza_sportiva.BazaDto;
using WebApp.Models.Echipa;
using WebApp.Models.Echipa.EchipaDto;
using WebApp.Models.Echipa_liga;
using WebApp.Models.Jucator;
using WebApp.Models.Jucator.JucatorDto;
using WebApp.Models.Liga;
using WebApp.Models.Liga.LigaDto;

namespace WebApp.Helpers
{
    public class MapperProfile: Profile
    {
        public MapperProfile() { 
            CreateMap<Echipa,EchipaResponseDto>();
            CreateMap<EchipaRequestDto, Echipa>();

            CreateMap<Baza_sportiva, BazaResponseDto>();
            CreateMap<BazaRequestDto, Baza_sportiva>();

            CreateMap<Jucator,JucatorResponseDto>();
            CreateMap<JucatorRequestDto, Jucator>();

            CreateMap<Liga,LigaResponseDto>();
            CreateMap<LigaRequestDto, Liga>();

            CreateMap<Echipa_liga,EchipaResponseDto>();
            CreateMap<EchipaRequestDto, Echipa_liga>();


        }
    }
}
