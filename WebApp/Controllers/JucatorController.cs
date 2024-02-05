using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;
using WebApp.Models.Baza_sportiva;
using WebApp.Models.Baza_sportiva.BazaDto;
using WebApp.Models.Jucator;
using WebApp.Models.Jucator.JucatorDto;
using WebApp.Services.EchipaService;
using WebApp.Services.JucatorService;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JucatorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJucatorService _jucatorService;
        private readonly IEchipaService _echipaService;

        public JucatorController(IMapper mapper, IJucatorService jucatorService, IEchipaService echipaService)
        {
            _mapper = mapper;
            _jucatorService = jucatorService;
            _echipaService = echipaService;
        }

        [HttpGet] //afisare toti jucatorii

        public async Task<ActionResult<IEnumerable<JucatorResponseDto>>> GetAllJucator()
        {
            var jucatori = await _jucatorService.GetAllJucatoriAsync();
            var jucatorResponseDto = _mapper.Map<IEnumerable<JucatorResponseDto>>(jucatori);
            return Ok(jucatorResponseDto);
        }

        [HttpGet("{id:guid}")] //afisare un jucator
        public async Task<ActionResult<JucatorResponseDto>> GetJucator(Guid id)
        {
            var jucator= await _jucatorService.GetJucatorAsync(id);
            var jucatorResponseDto = _mapper.Map<JucatorResponseDto>(jucator);
            return Ok(jucatorResponseDto);
        }

        [HttpPost, Authorize(Roles = "Admin")] //creeza baza
        public async Task<ActionResult<JucatorResponseDto>> CreateJucator([FromBody] JucatorRequestDto jucatorRequestDto)
        {
            var jucator = _mapper.Map<Jucator>(jucatorRequestDto);
            var new_jucator = await _jucatorService.CreateJucator(jucator);
            var jucatorResponseDto = _mapper.Map<JucatorResponseDto>(new_jucator);
            return Ok(jucatorResponseDto);
        }

        [HttpPut("{id:guid}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<JucatorResponseDto>> UpdateJucator(Guid id, JucatorRequestDto jucator)
        {
            var _jucator = await _jucatorService.GetJucatorAsync(id);
            _mapper.Map(jucator, _jucator);
            await _jucatorService.UpdateJucator(_jucator);
            var _jucatorDTO = _mapper.Map<JucatorResponseDto>(_jucator);
            return Ok(_jucatorDTO);
        }

        [HttpDelete("{id:guid}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<JucatorResponseDto>> DeleteJucator(Guid id)
        {
            var _jucator = await _jucatorService.GetJucatorAsync(id);
            await _jucatorService.DeleteJucator(_jucator);
            var _jucatorDTO = _mapper.Map<JucatorResponseDto>(_jucator);
            return Ok(_jucatorDTO);
        }

        [HttpPatch("{jucator_id:guid}/echipa/{echipa_id:guid}"), Authorize(Roles = "Admin")]

        public async Task<ActionResult<JucatorResponseDto>> AdaugaEchipa(Guid jucator_id, Guid echipa_id)
        {
            var jucator = await _jucatorService.GetJucatorAsync(jucator_id);
            if (jucator == null)
            {
                return NotFound("nu exista jucator cu id ul dat");
            }
            var echipa = await _echipaService.GetEchipaAsync(echipa_id);
            if (echipa == null)
            {
                return NotFound("nu exista echipa cu id ul dat");
            }
            jucator.echipa_id = echipa_id;
            jucator.echipa = echipa;
            await _jucatorService.UpdateJucator(jucator);
            return Ok(_mapper.Map<JucatorResponseDto>(jucator));
        }




    }
}
