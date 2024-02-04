using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;
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

        public JucatorController(IMapper mapper, IJucatorService jucatorService,IEchipaService echipaService)
        {
            _mapper = mapper;
            _jucatorService = jucatorService;
            _echipaService = echipaService;
        }

        [HttpPost("{echipa_id?:Guid}")]
        public async Task<ActionResult<JucatorResponseDto>> CreateJucator(Guid? echipa_id, [FromBody] JucatorRequestDto jucatorRequestDto)
        {
            Jucator jucator; 
            if (echipa_id.HasValue)
            {
                var echipa = _echipaService.GetEchipaById(echipa_id.Value);
                if (echipa == null)
                    throw new NotFoundException("echipa not found");

                jucator = _mapper.Map<Jucator>(jucatorRequestDto);
                jucator.echipa_id = echipa_id.Value;
            }
            else
            {
                jucator = _mapper.Map<Jucator>(jucatorRequestDto);
            }
            await _jucatorService.CreateJucator(jucator);
            return Ok(_mapper.Map<JucatorResponseDto>(jucator));
        }




    }
}
