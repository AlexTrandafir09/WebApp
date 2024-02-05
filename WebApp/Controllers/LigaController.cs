using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Baza_sportiva;
using WebApp.Models.Baza_sportiva.BazaDto;
using WebApp.Models.Liga;
using WebApp.Models.Liga.LigaDto;
using WebApp.Services.JucatorService;
using WebApp.Services.LigaService;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LigaController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILigaService _ligaService;
        
        public LigaController(IMapper mapper, ILigaService ligaService)
        {
            _mapper = mapper;
            _ligaService = ligaService;
        }
        [HttpGet] //afisare toate ligile

        public async Task<ActionResult<IEnumerable<LigaResponseDto>>> GetAllLigi()
        {
            var ligi = await _ligaService.GetAllLigiAsync();
            var ligaResponseDto = _mapper.Map<IEnumerable<LigaResponseDto>>(ligi);
            return Ok(ligaResponseDto);
        }

        [HttpGet("{id:guid}"), Authorize] //afisare o liga
        public async Task<ActionResult<LigaResponseDto>> GetLiga(Guid id)
        {
            var liga = await _ligaService.GetLigaAsync(id);
            var ligaResponseDto = _mapper.Map<LigaResponseDto>(liga);
            return Ok(ligaResponseDto);
        }
        [HttpPost, Authorize(Roles = "Admin")] //creeza liga
        public async Task<ActionResult<LigaResponseDto>> CreateLiga([FromBody] LigaRequestDto ligaRequestDto)
        {
            var liga = _mapper.Map<Liga>(ligaRequestDto);
            await _ligaService.CreateLiga(liga);
            var ligaResponseDto = _mapper.Map<LigaResponseDto>(liga);
            return Ok(ligaResponseDto);
        }

        [HttpPut("{id:guid}"), Authorize(Roles = "Admin")] //
        public async Task<ActionResult<LigaResponseDto>> UpdateLiga(Guid id, LigaRequestDto liga)
        {
            var _liga = await _ligaService.GetLiga(id);
            _mapper.Map(liga, _liga);
            await _ligaService.UpdateLiga(_liga);
            var _ligaDTO = _mapper.Map<LigaResponseDto>(_liga);
            return Ok(_ligaDTO);
        }

        [HttpDelete("{id:guid}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<LigaResponseDto>> DeleteLiga(Guid id)
        {
            var _liga = await _ligaService.GetLiga(id);
            await _ligaService.DeleteLiga(_liga);
            var _ligaDTO = _mapper.Map<LigaResponseDto>(_liga);
            return Ok(_ligaDTO);
        }
    }
}
