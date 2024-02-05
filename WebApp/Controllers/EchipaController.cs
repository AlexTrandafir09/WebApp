using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Baza_sportiva;
using WebApp.Models.Baza_sportiva.BazaDto;
using WebApp.Models.Echipa;
using WebApp.Models.Echipa.EchipaDto;
using WebApp.Services.EchipaService;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EchipaController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEchipaService _echipaService;

        public EchipaController(IMapper mapper, IEchipaService echipaService)
        {
            _mapper = mapper;
            _echipaService = echipaService;
        }
        [HttpGet] //afisare toate echipele

        public async Task<ActionResult<IEnumerable<EchipaResponseDto>>> GetAllEchipe()
        {
            var echipe = await _echipaService.GetAllEchipeAsync();
            var echipeResponseDto = _mapper.Map<IEnumerable<EchipaResponseDto>>(echipe);
            return Ok(echipeResponseDto);
        }
        [HttpGet("{id:guid}")] //afisare o echipa sportiva
        public async Task<ActionResult<EchipaResponseDto>> GetEchipa(Guid id)
        {
            var echipa = await _echipaService.GetEchipaAsync(id);
            var echipaResponseDto = _mapper.Map<EchipaResponseDto>(echipa);
            return Ok(echipaResponseDto);
        }
        [HttpPost, Authorize(Roles = "Admin")] //creeza echipa
        public async Task<ActionResult<EchipaResponseDto>> CreateEchipa([FromBody] EchipaRequestDto echipaRequestDto)
        {
            var echipa1 = _mapper.Map<Echipa>(echipaRequestDto);
            var new_echipa= await _echipaService.CreateEchipa(echipa1);
            var echipaResponseDto = _mapper.Map<EchipaResponseDto>(new_echipa);
            return Ok(echipaResponseDto);
        }

        [HttpPut("{id:guid}"), Authorize(Roles = "Admin")] //update echipa
        public async Task<ActionResult<EchipaResponseDto>> UpdateEchipa(Guid id, EchipaRequestDto echipa)
        {
            var _echipa = await _echipaService.GetEchipa(id);
            _mapper.Map(echipa, _echipa);
            await _echipaService.UpdateEchipa(_echipa);
            var _echipaDTO = _mapper.Map<EchipaResponseDto>(_echipa);
            return Ok(_echipaDTO);
        }

        [HttpDelete("{id:guid}"), Authorize(Roles = "Admin")] //sterge echipa
        public async Task<ActionResult<EchipaResponseDto>> DeleteEchipa(Guid id)
        {
            var echipa = await _echipaService.GetEchipaAsync(id);
            await _echipaService.DeleteEchipa(echipa);
            var _echipaDTO = _mapper.Map<EchipaResponseDto>(echipa);
            return Ok(_echipaDTO);
        }
    }
}
