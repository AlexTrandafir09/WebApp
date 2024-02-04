using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Baza_sportiva;
using WebApp.Models.Baza_sportiva.BazaDto;
using WebApp.Services.BazaService;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BazaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBazaService _bazaService;

        public BazaController(IMapper mapper,IBazaService bazaService1)
        {
            _mapper = mapper;
            _bazaService=bazaService1;
        }

        [HttpGet] //afisare toate bazele sportive

        public async Task<ActionResult<IEnumerable<BazaResponseDto>>> GetAllBaze()
        {
            var baze = await _bazaService.GetAllBaze();
            var bazeResponseDto = _mapper.Map<IEnumerable<BazaResponseDto>>(baze); 
            return Ok(bazeResponseDto);
        }

        [HttpGet("{id:guid}")] //afisare o baza sportiva
        public async Task<ActionResult<BazaResponseDto>> GetBaza(Guid id)
        {
            var baza = await _bazaService.GetBaza(id);
            var bazaResponseDto = _mapper.Map<BazaResponseDto>(baza);
            return Ok(bazaResponseDto);
        }

        [HttpPost] //creeza baza
        public async Task<ActionResult<BazaResponseDto>> CreateBaza([FromBody] BazaRequestDto bazaRequestDto)
        {
            var baza = _mapper.Map<Baza_sportiva>(bazaRequestDto);
            await _bazaService.CreateBaza(baza);
            var bazaResponseDto = _mapper.Map<BazaResponseDto>(baza);
            return Ok(bazaResponseDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BazaResponseDto>> UpdateBaza(Guid id, BazaRequestDto baza)
        {
            var _baza = await _bazaService.GetBaza(id);
            _mapper.Map(baza, _baza);
            await _bazaService.UpdateBaza(_baza);
            var _bazaDTO = _mapper.Map<BazaResponseDto>(_baza);
            return Ok(_bazaDTO);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BazaResponseDto>> DeleteBaza(Guid id)
        {
            var baza = await _bazaService.GetBaza(id);
            await _bazaService.DeleteBaza(baza);
            var _bazaDTO = _mapper.Map<BazaResponseDto>(baza);
            return Ok(_bazaDTO);
        }

    }
}
