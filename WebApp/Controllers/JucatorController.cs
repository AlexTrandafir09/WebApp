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

        public JucatorController(IMapper mapper, IJucatorService jucatorService, IEchipaService echipaService)
        {
            _mapper = mapper;
            _jucatorService = jucatorService;
            _echipaService = echipaService;
        }

        [HttpPost("{idechipa:guid}")]
        public async Task<ActionResult<JucatorResponseDto>> CreateJucator(Guid? idechipa, [FromBody] JucatorRequestDto jucatorRequestDto)
        {
            Jucator jucator; 
            if (idechipa.HasValue)
            {
                var echipa = _echipaService.GetEchipaById(idechipa.Value);
                if (echipa == null)
                    throw new NotFoundException("echipa not found");

                jucator = _mapper.Map<Jucator>(jucatorRequestDto);
                jucator.echipa_id = idechipa.Value;
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
