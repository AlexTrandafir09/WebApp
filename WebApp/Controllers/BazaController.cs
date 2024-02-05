using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Baza_sportiva;
using WebApp.Models.Baza_sportiva.BazaDto;
using WebApp.Services.BazaService;
using WebApp.Services.EchipaService;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BazaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBazaService _bazaService;
        private readonly IEchipaService _echipaService;

        public BazaController(IMapper mapper,IBazaService bazaService1, IEchipaService echipaService)
        {
            _mapper = mapper;
            _bazaService = bazaService1;
            _echipaService = echipaService;
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
            var baza = await _bazaService.GetBazaById(id);
            var bazaResponseDto = _mapper.Map<BazaResponseDto>(baza);
            return Ok(bazaResponseDto);
        }

        [HttpPost] //creeza baza
        public async Task<ActionResult<BazaResponseDto>> CreateBaza([FromBody] BazaRequestDto bazaRequestDto)
        {
            var baza = _mapper.Map<Baza_sportiva>(bazaRequestDto);
            var new_baza=await _bazaService.CreateBaza(baza);
            var bazaResponseDto = _mapper.Map<BazaResponseDto>(new_baza);
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

        [HttpPatch("{baza_id:guid}/echipa/{echipa_id:guid}")]

        public async Task<ActionResult<BazaResponseDto>> AdaugaEchipa(Guid baza_id ,Guid echipa_id)
        {
            var baza= await _bazaService.GetBazaById(baza_id);
            if(baza == null)
            {
                return NotFound("nu exista baza cu id ul dat");
            }
            var echipa = await _echipaService.GetEchipaAsync(echipa_id);
            if(echipa  == null)
            {
                return NotFound("nu exista echipa cu id ul dat");
            }
            baza.echipa_id = echipa_id;
            baza.echipa = echipa;
            await _bazaService.UpdateBaza(baza);
            return Ok(_mapper.Map<BazaResponseDto>(baza));
        }

    }
}
