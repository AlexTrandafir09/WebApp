﻿using AutoMapper;
using WebApp.Models.Baza_sportiva;
using WebApp.Models.Baza_sportiva.BazaDto;
using WebApp.Models.Echipa;
using WebApp.Models.Echipa.EchipaDto;
using WebApp.Models.Echipa_liga;
using WebApp.Models.Echipa_liga.Echipa_ligaDto;
using WebApp.Models.Jucator;
using WebApp.Models.Jucator.JucatorDto;
using WebApp.Models.Liga;
using WebApp.Models.Liga.LigaDto;

namespace WebApp.Helpers
{
    public class MapperProfile: Profile
    {
        public MapperProfile() {
            CreateMap<Echipa, EchipaResponseDto>()
                .ForMember(dest=> dest.baza_id, opt=> opt.MapFrom(src=> src.baza.Id))
                .ForMember(dest => dest.denumire_baza, opt => opt.MapFrom(src => src.baza.nume_baza))
                .ForMember(dest => dest.nume_jucatori, opt => opt.MapFrom(src => src.jucatori.Select(j => j.nume)))
                .ForMember(dest => dest.nume_ligi, opt => opt.MapFrom(src => src.echipe_ligi.Where(el => el.liga != null)
                .Select(el => el.liga.denumire)));
            CreateMap<EchipaRequestDto, Echipa>();

            CreateMap<Baza_sportiva, BazaResponseDto>()
                .ForMember(dest => dest.nume_echipa, opt => opt.MapFrom(src => src.echipa.denumire));
            CreateMap<BazaRequestDto, Baza_sportiva>();

            CreateMap<Jucator, JucatorResponseDto>()
                .ForMember(dest => dest.id_echipa, opt=> opt.MapFrom(src=> src.echipa.Id))
                .ForMember(dest => dest.denumire_echipa, opt => opt.MapFrom(src => src.echipa.denumire));
            CreateMap<JucatorRequestDto, Jucator>();

            CreateMap<Liga, LigaResponseDto>()
                .ForMember(dest => dest.echipe_participante, opt => opt
                .MapFrom(src => src.echipe_ligi.Where(el => el.echipa !=null).Select(el => el.echipa.denumire)));
            CreateMap<LigaRequestDto, Liga>();

            CreateMap<Echipa_liga, Echipa_ligaResponseDto>()
                .ForMember(dest => dest.denumire_echipa, opt => opt.MapFrom(src => src.echipa.denumire))
                .ForMember(dest => dest.denumire_liga, opt => opt.MapFrom(src => src.liga.denumire));
            CreateMap<Echipa_ligaRequestDto, Echipa_liga>();


        }
    }
}
