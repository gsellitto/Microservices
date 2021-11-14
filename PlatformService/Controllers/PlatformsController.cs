using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaltformService.SyncDataServices.Http;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private IPlatformRepo _repository;
        private IMapper _mapper;
        private ICommandDataClients _commandC;

        public PlatformsController(IPlatformRepo repository, IMapper mapper, ICommandDataClients commandC)
        {
            _repository = repository;
            _mapper = mapper;
            _commandC = commandC;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatForms()
        {
            Console.WriteLine("--> Getting platforms ....");

            var platformitems = _repository.GetAllPaltforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformitems));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var platfromitem = _repository.GetPlatform(id);
            if (platfromitem != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platfromitem));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var p = _mapper.Map<Platform>(platformCreateDto);
            _repository.CreatePlatform(p);
            _repository.SaveChanges();
            var platres = _mapper.Map<PlatformReadDto>(p);
            try
            {
                await _commandC.SendPlatformToCommand(platres);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> could not send sync: {ex.Message}");
            }
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platres.Id }, platres);
        }
    }
}