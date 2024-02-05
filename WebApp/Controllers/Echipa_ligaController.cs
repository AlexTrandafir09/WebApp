using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebApp.Models.Baza_sportiva.BazaDto;
using WebApp.Models.Baza_sportiva;
using WebApp.Models.Echipa_liga;
using WebApp.Models.Echipa_liga.Echipa_ligaDto;
using WebApp.Services.Echipa_ligaService;
using WebApp.Models.Liga.LigaDto;
using WebApp.Models.Jucator.JucatorDto;
using WebApp.Services.EchipaService;
using WebApp.Services.LigaService;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Echipa_ligaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEchipa_ligaService _echipa_ligaService;
        private readonly IEchipaService _echipaService;
        private readonly ILigaService _ligaService;

        public Echipa_ligaController(IMapper mapper, IEchipa_ligaService echipa_ligaService, IEchipaService echipaService, ILigaService ligaService)

        {
            _mapper = mapper;
            _echipa_ligaService = echipa_ligaService;
            _echipaService = echipaService;
            _ligaService = ligaService;

        }

        [HttpGet] //afiseaza toate relatiile echipa-liga

        public async Task<ActionResult<IEnumerable<Echipa_ligaResponseDto>>> GetAllEchipe_ligi()
        {
            var new_el = await _echipa_ligaService.GetAllEchipe_ligiAsync();
            var elResponseDto = _mapper.Map<IEnumerable<Echipa_ligaResponseDto>>(new_el);
            return Ok(elResponseDto);
        }


        [HttpPost("{liga_id:guid}/echipa/{echipa_id:guid}"),Authorize] //creeaza o relatie e-l

        public async Task<ActionResult<Echipa_ligaResponseDto>> AdaugaEchipa_liga(Guid liga_id, Guid echipa_id)
        {
            var liga = await _ligaService.GetLigaAsync(liga_id);
            if (liga == null)
            {
                return NotFound("nu exista liga cu id ul dat");
            }
            var echipa = await _echipaService.GetEchipaAsync(echipa_id);
            if (echipa == null)
            {
                return NotFound("nu exista echipa cu id ul dat");
            }

            var new_el = await _echipa_ligaService.AdaugaRelatie(liga,echipa);
       
            return Ok(_mapper.Map<JucatorResponseDto>(new_el));
        }
    }
}
